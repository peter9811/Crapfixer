using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFixer.Views
{
    public partial class PluginsView : UserControl
    {
        private List<PluginEntry> plugins = new List<PluginEntry>();
        private HashSet<string> installedPlugins = new HashSet<string>();
        private const string manifestUrl = "https://raw.githubusercontent.com/builtbybel/CrapFixer/main/plugins/plugins_manifest.txt";

        public class PluginEntry
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Url { get; set; }
        }

        public PluginsView()
        {
            InitializeComponent();
        }

        private async void PluginsView_Load(object sender, EventArgs e)
        {
            await LoadPlugins();
        }

        private void LoadInstalledPlugins()
        {
            var pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
            if (Directory.Exists(pluginPath))
            {
                foreach (var file in Directory.GetFiles(pluginPath))
                {
                    installedPlugins.Add(Path.GetFileName(file));
                }
            }
        }

        private async Task LoadPlugins()
        {
            try
            {
                LoadInstalledPlugins();

               
                using (var client = new WebClient())
                {
                    string content = await Task.Run(() => client.DownloadString(manifestUrl));
                    plugins = ParseManifest(content);

                    listBoxPlugins.Items.Clear();
                    foreach (var plugin in plugins)
                    {
                        var fileName = Path.GetFileName(plugin.Url);
                        string displayName = plugin.Name;

                        if (installedPlugins.Contains(fileName))
                            displayName += " (Installed)";

                        listBoxPlugins.Items.Add(displayName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading plugins: " + ex.Message);
            }
        }

        private List<PluginEntry> ParseManifest(string content)
        {
            var result = new List<PluginEntry>();
            var lines = content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            PluginEntry current = null;

            foreach (var line in lines)
            {
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    if (current != null)
                        result.Add(current);

                    var name = line.Substring(1, line.Length - 2).Trim();
                    current = new PluginEntry { Name = name };
                }
                else if (!string.IsNullOrWhiteSpace(line) && line.Contains("=") && current != null)
                {
                    var parts = line.Split(new[] { '=' }, 2);
                    var key = parts[0].Trim();
                    var value = parts[1].Trim();

                    switch (key)
                    {
                        case "description":
                            current.Description = value;
                            break;

                        case "url":
                            current.Url = value;
                            break;
                    }
                }
            }

            if (current != null)
                result.Add(current);

            return result;
        }

        private async Task InstallPlugins(bool force = false)
        {
            var checkedIndices = listBoxPlugins.CheckedIndices;
            if (checkedIndices.Count == 0)
            {
                MessageBox.Show("Please check one or more plugins to download.");
                return;
            }

            string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
            Directory.CreateDirectory(savePath);

            progressBarDownload.Visible = true;
            progressBarDownload.Value = 0;
            progressBarDownload.Maximum = checkedIndices.Count;

            int done = 0;

            using (var client = new WebClient())
            {
                foreach (int index in checkedIndices)
                {
                    var plugin = plugins[index];
                    string file = Path.Combine(savePath, Path.GetFileName(plugin.Url));

                    if (!force && File.Exists(file))              // skip only if not in force‑mode
                    {
                        progressBarDownload.Value = ++done;
                        continue;
                    }

                    try
                    {
                        await client.DownloadFileTaskAsync(new Uri(plugin.Url), file);
                        installedPlugins.Add(Path.GetFileName(plugin.Url));
                        listBoxPlugins.Items[index] = plugin.Name + " (Installed)";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to download {plugin.Name}: {ex.Message}");
                    }

                    progressBarDownload.Value = ++done;
                }
            }

            progressBarDownload.Visible = false;
        }


        private async void btnPluginInstall_Click(object sender, EventArgs e)
        {
            await InstallPlugins(force: false);   // skip installed
        }


        private async void btnPluginUpdateAll_Click(object sender, EventArgs e)
        {
            // check every item
            for (int i = 0; i < listBoxPlugins.Items.Count; i++)
                listBoxPlugins.SetItemChecked(i, true);

            await InstallPlugins(force: true);    // always overwrite
            MessageBox.Show("All plugins updated.");
        }

        private void listBoxPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxPlugins.SelectedIndex;
            if (index >= 0 && index < plugins.Count)
            {
                btnDescription.Text = plugins[index].Description;
            }
        }

        private void btnPluginOpen_Click(object sender, EventArgs e)
        {
            string pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");

            if (Directory.Exists(pluginPath))
            {
                System.Diagnostics.Process.Start("explorer.exe", pluginPath);
            }
            else
            {
                MessageBox.Show("The plugins folder does not exist yet.");
            }
        }

        private void btnPluginRemove_Click(object sender, EventArgs e)
        {
            string pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            var indices = listBoxPlugins.CheckedIndices.Cast<int>().ToList();

            if (indices.Count == 0)
            {
                MessageBox.Show("No plugins selected.");
                return;
            }

            foreach (int i in indices)
            {
                var plugin = plugins[i];
                string path = Path.Combine(pluginPath, Path.GetFileName(plugin.Url));

                if (File.Exists(path))
                    File.Delete(path);

                listBoxPlugins.Items[i] = plugin.Name;          // Remove (Installed) tag
                listBoxPlugins.SetItemChecked(i, false);         // Uncheck
                installedPlugins.Remove(Path.GetFileName(plugin.Url));
            }

            MessageBox.Show("Selected plugins removed.");
        }

        private void btnPluginSubmit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/builtbybel/CrapFixer/blob/main/plugins/plugins_manifest.txt",
                UseShellExecute = true
            });
        }
    }
}