using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Features;

namespace CrapFixer
{
    public static class FeatureNodeManager
    {
        private static int totalChecked = 0;
        private static int issuesFound = 0;

        public static void ResetAnalysis()
        {
            totalChecked = 0;
            issuesFound = 0;
        }

        public static void Initialize(TreeView treeView)
        {
            treeView.Nodes.Clear();
            var features = FeatureLoader.Load();
            foreach (var feature in features)
                AddNode(treeView.Nodes, feature);
        }

        static void AddNode(TreeNodeCollection treeNodes, FeatureNode featureNode)
        {
            string text = featureNode.IsCategory
                ? "  " + featureNode.Name + "  "
                : featureNode.Name;

            TreeNode node = new TreeNode(text)
            {
                Tag = featureNode,
                Checked = featureNode.DefaultChecked,
            };
            treeNodes.Add(node);

            foreach (var child in featureNode.Children)
                AddNode(node.Nodes, child);
        }

        public static async Task AnalyzeAll(TreeNodeCollection nodes, IProgress<int> progress = null)
        {
            ResetAnalysis();
            int totalNodes = CountCheckedNodes(nodes);
            int current = 0;

            foreach (TreeNode node in nodes)
                await AnalyzeCheckedRecursive(node, progress, totalNodes, ref current);

            Logger.Log("🔎 ANALYSIS COMPLETE", LogLevel.Info);
            Logger.Log(new string('=', 50), LogLevel.Info);

            int ok = totalChecked - issuesFound;
            Logger.Log($"Summary: {ok} of {totalChecked} checked settings are OK; {issuesFound} require attention.",
                issuesFound > 0 ? LogLevel.Warning : LogLevel.Info);
        }

        public static int CountCheckedNodes(TreeNodeCollection nodes)
        {
            int count = 0;
            foreach (TreeNode node in nodes)
            {
                if (node.Tag is FeatureNode fn && !fn.IsCategory && node.Checked) count++;
                count += CountCheckedNodes(node.Nodes);
            }
            return count;
        }

        private static async Task AnalyzeCheckedRecursive(TreeNode node, IProgress<int> progress, int total, ref int current)
        {
            if (node.Tag is FeatureNode fn)
            {
                if (!fn.IsCategory && node.Checked && fn.Feature != null)
                {
                    totalChecked++;
                    bool isOk = await fn.Feature.CheckFeature();
                    node.ForeColor = isOk ? Color.Gray : Color.Red;
                    if (!isOk)
                    {
                        issuesFound++;
                        string category = node.Parent?.Text ?? "General";
                        Logger.Log($"❌ [{category}] {fn.Name} - Not configured as recommended.");
                        Logger.Log($"   ➤ {fn.Feature.GetFeatureDetails()}");
                        Logger.Log(new string('-', 50), LogLevel.Info);
                    }
                    current++;
                    if (total > 0) progress?.Report((current * 100) / total);
                }
                foreach (TreeNode child in node.Nodes)
                    await AnalyzeCheckedRecursive(child, progress, total, ref current);
            }
        }

        public static async Task FixChecked(TreeNode node, IProgress<int> progress = null, int total = 0, Counter current = null)
        {
            if (current == null) current = new Counter();
            if (node.Tag is FeatureNode fn)
            {
                if (!fn.IsCategory && node.Checked && fn.Feature != null)
                {
                    bool result = await fn.Feature.DoFeature();
                    Logger.Log(result
                        ? $"🔧 {fn.Name} - Fixed"
                        : $"❌ {fn.Name} - ⚠️ Fix failed (This feature may require admin privileges)",
                        result ? LogLevel.Info : LogLevel.Error);
                    current.Value++;
                    if (total > 0) progress?.Report((current.Value * 100) / total);
                }
                foreach (TreeNode child in node.Nodes)
                    await FixChecked(child, progress, total, current);
            }
        }

        public class Counter { public int Value; }

        public static async Task RestoreChecked(TreeNode node)
        {
            if (node.Tag is FeatureNode fn)
            {
                if (!fn.IsCategory && node.Checked && fn.Feature != null)
                {
                    bool ok = await fn.Feature.UndoFeature();
                    string category = node.Parent?.Text ?? "General";
                    Logger.Log(ok
                        ? $"↩️ [{category}] {fn.Name} - Restored"
                        : $"❌ [{category}] {fn.Name} - Restore failed",
                        ok ? LogLevel.Info : LogLevel.Error);
                }
                foreach (TreeNode child in node.Nodes)
                    await RestoreChecked(child);
            }
        }

        public static async void AnalyzeFeature(TreeNode node)
        {
            if (node.Tag is FeatureNode fn && !fn.IsCategory && fn.Feature != null)
            {
                bool isOk = await fn.Feature.CheckFeature();
                node.ForeColor = isOk ? Color.Gray : Color.Red;
                if (isOk) Logger.Log($"✅ Feature: {fn.Name} is properly configured.", LogLevel.Info);
                else
                {
                    string category = node.Parent?.Text ?? "General";
                    Logger.Log($"❌ Feature: {fn.Name} requires attention.", LogLevel.Warning);
                    Logger.Log($"   ➤ {fn.Feature.GetFeatureDetails()}");
                    Logger.Log(new string('-', 50), LogLevel.Info);
                }
            }
            else
            {
                foreach (TreeNode child in node.Nodes)
                    if (child.Checked) AnalyzeFeature(child);
            }
        }

        public static async Task FixFeature(TreeNode node)
        {
            if (node.Tag is FeatureNode fn && !fn.IsCategory && fn.Feature != null)
            {
                bool result = await fn.Feature.DoFeature();
                Logger.Log(result ? $"🔧 {fn.Name} - Fixed" : $"❌ {fn.Name} - ⚠️ Fix failed", result ? LogLevel.Info : LogLevel.Error);
            }
            else
            {
                foreach (TreeNode child in node.Nodes)
                    if (child.Checked) await FixFeature(child);
            }
        }

        public static async Task RestoreFeature(TreeNode node)
        {
            if (node.Tag is FeatureNode fn && !fn.IsCategory && fn.Feature != null)
            {
                bool ok = await fn.Feature.UndoFeature();
                Logger.Log(ok ? $"↩️ {fn.Name} - Restored" : $"❌ {fn.Name} - Restore failed", ok ? LogLevel.Info : LogLevel.Error);
            }
            else
            {
                foreach (TreeNode child in node.Nodes)
                    if (child.Checked) await RestoreFeature(child);
            }
        }

        public static void ShowHelp(TreeNode node)
        {
            if (node?.Tag is FeatureNode fn && fn.Feature != null)
            {
                string info = fn.Feature.Info();
                MessageBox.Show(!string.IsNullOrEmpty(info) ? info : "No additional information available.", $"Help: {fn.Name}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var result = MessageBox.Show("Would you like to search online?", "Online Help", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string searchQuery = Uri.EscapeDataString(fn.Feature.GetFeatureDetails());
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = $"https://www.google.com/search?q={searchQuery}", UseShellExecute = true });
                }
                return;
            }
            if (!PluginManager.ShowHelp(node))
                MessageBox.Show("⚠️ No feature or plugin selected.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
