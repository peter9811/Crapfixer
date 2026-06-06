using Features;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views;

namespace CrapFixer
{
    public partial class MainForm : Form
    {
        private AppManagerService _appManager = new AppManagerService();
        private NavigationManager _navigationManager;

        public MainForm()
        {
            InitializeComponent();
            _navigationManager = new NavigationManager(panelContainer);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            FeatureNodeManager.Initialize(treeFeatures);
            Logger.OutputBox = rtbLogger;

            if (IniStateManager.IsViewSettingEnabled("SETTINGS", "checkSaveToINI"))
            {
                IniStateManager.Load(treeFeatures, this);
            }

            lblVersionInfo.Text = "Version " + Program.GetAppVersion();
            statusLabel.Text = "Detecting OS...";
            string os = await OSHelper.GetWindowsVersion();
            statusLabel.Text = os;

            CheckAdminPrivileges();
        }

        private void CheckAdminPrivileges()
        {
            if (!OSHelper.IsAdministrator())
            {
                Logger.Log("⚠️ Running without Administrator privileges. Some fixes may fail.", LogLevel.Warning);
                var result = MessageBox.Show("CrapFixer works best with Administrator privileges.\nWould you like to restart as Administrator?", "Administrator Rights", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    OSHelper.RestartAsAdmin();
                }
            }
        }

        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            rtbLogger.Clear();
            btnAnalyze.Enabled = false;
            progressBar.Visible = true;
            progressBar.Value = 0;
            statusLabel.Text = "Analyzing features...";

            var progress = new Progress<int>(v => progressBar.Value = v);

            await FeatureNodeManager.AnalyzeAll(treeFeatures.Nodes, progress);

            statusLabel.Text = "Analyzing plugins...";
            await PluginManager.AnalyzeAllPlugins(treeFeatures.Nodes);

            statusLabel.Text = "Analyzing apps...";
            await AnalyzeApps();

            progressBar.Visible = false;
            btnAnalyze.Enabled = true;
            statusLabel.Text = "Analysis complete.";
        }

        private async Task AnalyzeApps()
        {
            checkedListBoxApps.Items.Clear();
            var (bloatwarePatterns, whitelistPatterns, scanAll) = _appManager.LoadExternalBloatwarePatterns();

            if (bloatwarePatterns.Length == 0)
            {
                string predefinedApps = "Microsoft.BingNews,Microsoft.GetHelp,Microsoft.Getstarted,Microsoft.Messaging,Microsoft.MicrosoftOfficeHub,Microsoft.MicrosoftSolitaireCollection,Microsoft.People,Microsoft.SkypeApp,Microsoft.WindowsFeedbackHub,Microsoft.YourPhone,Microsoft.ZuneVideo,Microsoft.ZuneMusic,Microsoft.WindowsMaps,Microsoft.Office.OneNote,Microsoft.XboxApp,Microsoft.XboxGamingOverlay,Microsoft.XboxIdentityProvider,Microsoft.XboxSpeechToTextOverlay,Microsoft.GamingApp";
                bloatwarePatterns = predefinedApps.Split(',').Select(s => s.Trim().ToLower()).ToArray();
            }

            var apps = await _appManager.AnalyzeAndLogAppsAsync(bloatwarePatterns, whitelistPatterns, scanAll);
            foreach (var app in apps)
            {
                checkedListBoxApps.Items.Add(app.FullName);
            }
        }

        private async void btnFix_Click(object sender, EventArgs e)
        {
            rtbLogger.Clear();
            btnFix.Enabled = false;

            if (MessageBox.Show("Would you like to create a System Restore Point before proceeding?", "Safety First", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                statusLabel.Text = "Creating Restore Point...";
                await OSHelper.CreateRestorePoint("CrapFixer Optimization");
            }

            int total = FeatureNodeManager.CountCheckedNodes(treeFeatures.Nodes);
            progressBar.Visible = true;
            progressBar.Value = 0;
            statusLabel.Text = "Applying fixes...";
            var progress = new Progress<int>(v => progressBar.Value = v);

            var counter = new FeatureNodeManager.Counter();
            foreach (TreeNode node in treeFeatures.Nodes)
                await FeatureNodeManager.FixChecked(node, progress, total, counter);

            statusLabel.Text = "Running plugins...";
            foreach (TreeNode node in treeFeatures.Nodes)
                await PluginManager.FixChecked(node);

            var selectedApps = checkedListBoxApps.CheckedItems.Cast<string>().ToList();
            if (selectedApps.Count > 0)
            {
                statusLabel.Text = "Uninstalling apps...";
                var removedApps = await _appManager.UninstallSelectedAppsAsync(selectedApps);
                foreach (var app in removedApps)
                {
                    checkedListBoxApps.Items.Remove(app);
                }
            }

            progressBar.Visible = false;
            btnFix.Enabled = true;
            statusLabel.Text = "Fixes applied.";
        }

        private async void btnRestore_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "⚠️ This will restore all selected features to their original state.\n" +
                "Are you sure you want to proceed?",
                "Restore Selected Features",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                rtbLogger.Clear();
                statusLabel.Text = "Restoring features...";
                foreach (TreeNode node in treeFeatures.Nodes)
                    await FeatureNodeManager.RestoreChecked(node);

                Logger.Log("↩️ All selected features have been restored.", LogLevel.Info);
                statusLabel.Text = "Restore complete.";
            }
        }

        private async void analyzeMarkedFeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeFeatures.SelectedNode is TreeNode selectedNode)
            {
                statusLabel.Text = $"Analyzing {selectedNode.Text}...";
                if (selectedNode.Nodes.Count == 0) await PluginManager.AnalyzePlugin(selectedNode);
                else await PluginManager.AnalyzeAll(selectedNode);
                FeatureNodeManager.AnalyzeFeature(selectedNode);
                statusLabel.Text = "Ready";
            }
        }

        private async void fixMarkedFeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeFeatures.SelectedNode is TreeNode selectedNode)
            {
                statusLabel.Text = $"Fixing {selectedNode.Text}...";
                await FeatureNodeManager.FixFeature(selectedNode);
                await PluginManager.FixPlugin(selectedNode);
                statusLabel.Text = "Ready";
            }
        }

        private async void restoreMarkedFeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeFeatures.SelectedNode is TreeNode selectedNode)
            {
                statusLabel.Text = $"Restoring {selectedNode.Text}...";
                if (PluginManager.IsPluginNode(selectedNode)) await PluginManager.RestorePlugin(selectedNode);
                await FeatureNodeManager.RestoreFeature(selectedNode);
                statusLabel.Text = "Ready";
            }
        }

        private void helpMarkedFeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeFeatures.SelectedNode is TreeNode selectedNode)
            {
                FeatureNodeManager.ShowHelp(selectedNode);
            }
        }

        private void treeFeatures_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                foreach (TreeNode child in e.Node.Nodes)
                    child.Checked = e.Node.Checked;
            }
        }

        private void treeFeatures_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode nodeUnderMouse = treeFeatures.GetNodeAt(e.X, e.Y);
                if (nodeUnderMouse != null)
                {
                    treeFeatures.SelectedNode = nodeUnderMouse;
                    contextMenuStrip.Show(treeFeatures, e.Location);
                }
            }
        }

        private bool treeChecked = false;
        private void linkSelection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tabControl.SelectedTab == Windows)
            {
                treeChecked = !treeChecked;
                foreach (TreeNode node in treeFeatures.Nodes)
                {
                    node.Checked = treeChecked;
                    foreach (TreeNode child in node.Nodes)
                    {
                        child.Checked = treeChecked;
                        foreach (TreeNode grandChild in child.Nodes)
                            grandChild.Checked = treeChecked;
                    }
                }
                linkSelection.Text = treeChecked ? "Deselect all" : "Select all";
            }
            else if (tabControl.SelectedTab == Apps)
            {
                bool shouldCheck = checkedListBoxApps.Items.Cast<object>().Any(item => !checkedListBoxApps.GetItemChecked(checkedListBoxApps.Items.IndexOf(item)));
                for (int i = 0; i < checkedListBoxApps.Items.Count; i++) checkedListBoxApps.SetItemChecked(i, shouldCheck);
            }
        }

        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "Log files (*.txt)|*.txt|All files (*.*)|*.*", FileName = "CrapFixer_Log.txt" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, rtbLogger.Text);
                    Logger.Log($"Log saved to {sfd.FileName}", LogLevel.Info);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            if (filter == "Search settings..." || string.IsNullOrEmpty(filter))
            {
                foreach (TreeNode node in treeFeatures.Nodes) ResetNodeVisibility(node);
                return;
            }

            foreach (TreeNode node in treeFeatures.Nodes) FilterNode(node, filter.ToLower());
        }

        private void ResetNodeVisibility(TreeNode node)
        {
            node.BackColor = Color.White;
            foreach (TreeNode child in node.Nodes) ResetNodeVisibility(child);
        }

        private bool FilterNode(TreeNode node, string filter)
        {
            bool matches = node.Text.ToLower().Contains(filter);
            bool childMatches = false;
            foreach (TreeNode child in node.Nodes)
            {
                if (FilterNode(child, filter)) childMatches = true;
            }

            if (matches) node.BackColor = Color.Yellow;
            else node.BackColor = Color.White;

            if (matches || childMatches) { node.Expand(); return true; }
            return false;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search settings...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search settings...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.FromArgb(77, 77, 77));
            Color baseColor = Color.FromArgb(80, 80, 80);
            using (var topLine = new Pen(ControlPaint.Light(baseColor, 0.0f)))
            using (var bottomLine = new Pen(ControlPaint.Dark(baseColor, 0.2f)))
            {
                g.DrawLine(topLine, 0, panelHeader.Height - 2, panelHeader.Width, panelHeader.Height - 2);
                g.DrawLine(bottomLine, 0, panelHeader.Height - 1, panelHeader.Width, panelHeader.Height - 1);
            }
        }

        private void PictureHeader_Click(object sender, EventArgs e) => Utils.OpenGitHubPage(sender, e);
        private void linkUpdateCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = $"https://builtbybel.github.io/CrapFixer/update-check.html?version={Program.GetAppVersion()}", UseShellExecute = true });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IniStateManager.IsViewSettingEnabled("SETTINGS", "checkSaveToINI")) IniStateManager.Save(treeFeatures, this);
            Logger.OutputBox = null;
        }

        private void btnGitHub_Click(object sender, EventArgs e) => _navigationManager.SwitchView(new OptionsView());
    }
}
