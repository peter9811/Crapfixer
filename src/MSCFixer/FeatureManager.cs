using Features;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crapfixer
{
    /// <summary>
    /// Provides operations to load, analyze, fix, restore, and show help for FeatureNodes.
    /// </summary>
    public static class FeatureNodeManager
    {
        private static int totalChecked;
        private static int issuesFound;

        // Public properties to access the analysis results
        public static int TotalChecked => totalChecked;
        public static int IssuesFound => issuesFound;

        public static void ResetAnalysis()
        {
            totalChecked = 0;
            issuesFound = 0;
        }

        /// <summary>
        /// Loads all features into the TreeView.
        /// </summary>
        public static void LoadFeatures(TreeView tree)
        {
            var features = FeatureLoader.Load();
            tree.Nodes.Clear();

            foreach (var feature in features)
                AddNode(tree.Nodes, feature);

            // root nodes (categories)
            foreach (TreeNode root in tree.Nodes)
            {
                root.NodeFont = new Font(tree.Font, FontStyle.Bold);
                root.ForeColor = Color.RoyalBlue; // category color
            }

            tree.ExpandAll(); // expand all nodes
        }

        /// <summary>
        /// Recursively adds a FeatureNode and its children into the TreeView.
        /// </summary>
        private static void AddNode(TreeNodeCollection treeNodes, FeatureNode featureNode)
        {
            string text = featureNode.IsCategory
                ? "  " + featureNode.Name + "  " // add extra space to avoid clipping
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

        /// <summary>
        /// Analyzes all checked features recursively and logs only issues.
        /// </summary>
        public static async Task AnalyzeAll(TreeNodeCollection nodes)
        {
            ResetAnalysis();

            // Iterate through all nodes and analyze each one recursively
            foreach (TreeNode node in nodes)
            {
                // Recursively analyze each node and ensure async tasks are awaited
                await AnalyzeCheckedRecursive(node);
            }

            Logger.Log("🔎 ANALYSIS COMPLETE", LogLevel.Info);
            Logger.Log(new string('=', 50), LogLevel.Info);

            int ok = totalChecked - issuesFound;
            Logger.Log($"Summary: {ok} of {totalChecked} checked settings are OK; {issuesFound} require attention.",
                issuesFound > 0 ? LogLevel.Warning : LogLevel.Info);
        }

        /// <summary>
        /// Recursively checks all features and logs misconfigurations.
        /// </summary>
        private static async Task AnalyzeCheckedRecursive(TreeNode node)
        {
            if (node.Tag is FeatureNode fn)
            {
                // If the node is not a category, is checked, and has a feature to check
                if (!fn.IsCategory && node.Checked && fn.Feature != null)
                {
                    totalChecked++;
                    bool isOk = await fn.Feature.CheckFeature();  // Await the async operation

                    if (!isOk)
                    {
                        issuesFound++;
                        node.ForeColor = Color.Red; // Mark as misconfigured
                        string category = node.Parent?.Text ?? "General";
                        Logger.Log($"❌ [{category}] {fn.Name} - Not configured as recommended.");
                        Logger.Log($"   ➤ {fn.Feature.GetFeatureDetails()}");
                        // Log a separator when an issue was found
                        Logger.Log(new string('-', 50), LogLevel.Info);
                    }
                    else
                    {
                        node.ForeColor = Color.Gray; // Mark as properly configured
                    }
                }

                // Recursively process child nodes and ensure awaiting the tasks
                foreach (TreeNode child in node.Nodes)
                {
                    await AnalyzeCheckedRecursive(child);  // Recursively call and await the result
                }
            }
        }

        /// <summary>
        /// Analyzes a selected feature and logs its status.
        /// </summary>
        public static async void AnalyzeFeature(TreeNode node)
        {
            if (node.Tag is FeatureNode fn && !fn.IsCategory && node.Checked && fn.Feature != null)
            {
                bool isOk = await fn.Feature.CheckFeature();
                node.ForeColor = isOk ? Color.Gray : Color.Red;

                Logger.Log(isOk
                    ? $"✅ Feature: {fn.Name} is properly configured."
                    : $"❌ Feature: {fn.Name} requires attention.\n   ➤ {fn.Feature.GetFeatureDetails()}",
                    isOk ? LogLevel.Info : LogLevel.Warning);

                if (!isOk)
                    Logger.Log(new string('-', 50), LogLevel.Info);
            }
        }

        /// <summary>
        /// Fixes all checked features recursively.
        /// </summary>
        public static async Task FixChecked(TreeNode node)
        {
            if (node.Tag is FeatureNode fn)
            {
                if (!fn.IsCategory && node.Checked && fn.Feature != null)
                {
                    bool result = await fn.Feature.DoFeature();
                    Logger.Log(result
                        ? $"🔧 {fn.Name} - Fixed"
                        : $"❌ {fn.Name} - ⚠️ Fix failed (This feature may require admin privileges)",
                        result ? LogLevel.Info : LogLevel.Error);
                }

                foreach (TreeNode child in node.Nodes)
                    await FixChecked(child);
            }
        }

        /// <summary>
        /// Restores all checked features recursively.
        /// </summary>
        public static void RestoreChecked(TreeNode node)
        {
            if (node.Tag is FeatureNode fn)
            {
                if (!fn.IsCategory && node.Checked && fn.Feature != null)
                {
                    bool ok = fn.Feature.UndoFeature();
                    string category = node.Parent?.Text ?? "General";
                    Logger.Log(ok
                        ? $"↩️ [{category}] {fn.Name} - Restored"
                        : $"❌ [{category}] {fn.Name} - Restore failed",
                        ok ? LogLevel.Info : LogLevel.Error);
                }

                foreach (TreeNode child in node.Nodes)
                    RestoreChecked(child);
            }
        }

        /// <summary>
        /// Attempts to fix the selected feature and logs the result.
        /// </summary>
        public static async Task FixFeature(TreeNode node)
        {
            if (node.Tag is FeatureNode fn && !fn.IsCategory && node.Checked && fn.Feature != null)
            {
                bool result = await fn.Feature.DoFeature();
                Logger.Log(result
                    ? $"🔧 {fn.Name} - Fixed"
                    : $"❌ {fn.Name} - ⚠️ Fix failed (This feature may require admin privileges)",
                    result ? LogLevel.Info : LogLevel.Error);
            }
        }

        /// <summary>
        /// Restores the selected feature to its original state and logs the result.
        /// </summary>
        public static void RestoreFeature(TreeNode node)
        {
            if (node.Tag is FeatureNode fn && !fn.IsCategory && node.Checked && fn.Feature != null)
            {
                bool ok = fn.Feature.UndoFeature();
                Logger.Log(ok
                    ? $"↩️ {fn.Name} - Restored"
                    : $"❌ {fn.Name} - Restore failed",
                    ok ? LogLevel.Info : LogLevel.Error);
            }
        }

        /// <summary>
        /// Displays help information for the selected feature.
        /// </summary>
        public static void ShowHelp(TreeNode node)
        {
            if (node.Tag is FeatureNode fn && fn.Feature != null)
            {
                string info = fn.Feature.Info();
                MessageBox.Show(
                    !string.IsNullOrEmpty(info) ? info : "No additional information available.",
                    $"Help: {fn.Name}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("⚠️ No feature selected or feature is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}