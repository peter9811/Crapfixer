using Features;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrapFixer
{
    /// <summary>
    /// Manages features by loading them into a TreeView, analyzing their status,
    /// applying fixes or restorations, and providing help information.
    /// This class operates on <see cref="FeatureNode"/> objects, which represent individual features or categories.
    /// </summary>
    public static class FeatureNodeManager
    {
        private static int totalChecked;
        private static int issuesFound;

        /// <summary>
        /// Gets the total number of features that were checked during the last analysis.
        /// </summary>
        public static int TotalChecked => totalChecked;

        /// <summary>
        /// Gets the number of features that were found to have issues (misconfigurations) during the last analysis.
        /// </summary>
        public static int IssuesFound => issuesFound;

        /// <summary>
        /// Resets the counters for total checked features and issues found.
        /// This should be called before starting a new analysis run.
        /// </summary>
        public static void ResetAnalysis()
        {
            totalChecked = 0;
            issuesFound = 0;
        }

        /// <summary>
        /// Loads all available features from the <see cref="FeatureLoader"/> into the specified <see cref="TreeView"/>.
        /// Feature categories are displayed as bold, blue root nodes.
        /// All nodes are expanded by default after loading.
        /// </summary>
        /// <param name="tree">The <see cref="TreeView"/> control to populate with feature nodes.</param>
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
        /// Asynchronously analyzes all features that are checked in the TreeView, starting from the provided collection of nodes.
        /// It recursively checks each node and logs any issues found.
        /// Updates <see cref="TotalChecked"/> and <see cref="IssuesFound"/> properties.
        /// </summary>
        /// <param name="nodes">The collection of <see cref="TreeNode"/> objects to start the analysis from (typically the root nodes of the TreeView).</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
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
        /// Asynchronously applies fixes to all features that are checked in the TreeView, starting from the specified node and recursing through its children.
        /// Logs the outcome of each fix attempt.
        /// </summary>
        /// <param name="node">The <see cref="TreeNode"/> from which to start fixing checked features. This is typically a root node or a specific category node.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation of fixing all checked features under the given node.</returns>
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
        /// Restores all features that are checked in the TreeView to their original state,
        /// starting from the specified node and recursing through its children.
        /// Logs the outcome of each restoration attempt.
        /// </summary>
        /// <param name="node">The <see cref="TreeNode"/> from which to start restoring checked features. This is typically a root node or a specific category node.</param>
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
        /// Asynchronously analyzes a single selected feature associated with the given <see cref="TreeNode"/>.
        /// It logs whether the feature is properly configured or requires attention.
        /// The node's foreground color is updated (Gray for OK, Red for issues).
        /// Note: This method is `async void` because it's intended as an event handler or a fire-and-forget UI action.
        /// </summary>
        /// <param name="node">The <see cref="TreeNode"/> representing the feature to analyze. The feature must not be a category.</param>
        public static async void AnalyzeFeature(TreeNode node)
        {
            // no && node.Checked 
            if (node.Tag is FeatureNode fn && !fn.IsCategory && fn.Feature != null)
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
        /// Asynchronously attempts to fix the single feature associated with the given <see cref="TreeNode"/>.
        /// Logs the outcome of the fix attempt.
        /// </summary>
        /// <param name="node">The <see cref="TreeNode"/> representing the feature to fix. The feature must not be a category.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task FixFeature(TreeNode node)
        {
            // no && node.Checked 
            if (node.Tag is FeatureNode fn && !fn.IsCategory && fn.Feature != null)
            {
                bool result = await fn.Feature.DoFeature();
                Logger.Log(result
                    ? $"🔧 {fn.Name} - Fixed"
                    : $"❌ {fn.Name} - ⚠️ Fix failed (This feature may require admin privileges)",
                    result ? LogLevel.Info : LogLevel.Error);
            }
        }

        /// <summary>
        /// Restores the single feature associated with the given <see cref="TreeNode"/> to its original state.
        /// Logs the outcome of the restoration attempt.
        /// </summary>
        /// <param name="node">The <see cref="TreeNode"/> representing the feature to restore. The feature must not be a category.</param>
        public static void RestoreFeature(TreeNode node)
        {
            // no && node.Checked 
            if (node.Tag is FeatureNode fn && !fn.IsCategory && fn.Feature != null)
            {
                bool ok = fn.Feature.UndoFeature();
                Logger.Log(ok
                    ? $"↩️ {fn.Name} - Restored"
                    : $"❌ {fn.Name} - Restore failed",
                    ok ? LogLevel.Info : LogLevel.Error);
            }
        }

        /// <summary>
        /// Logs a preview of the changes or details for features, starting from the specified <see cref="TreeNode"/>
        /// and recursing through its children. This method does not apply any changes.
        /// It logs the name, category, and details of each feature encountered.
        /// </summary>
        /// <param name="node">The <see cref="TreeNode"/> from which to start previewing. This is typically a root node or a specific category node.</param>
        public static void PreviewChanges(TreeNode node)
        {
            if (node.Tag is FeatureNode fn)
            {
                if (!fn.IsCategory && fn.Feature != null)
                {
                    string details = fn.Feature.GetFeatureDetails();

                    string category = node.Parent?.Text ?? "General";
                    Logger.Log($"🛈 [PREVIEW] [{category}] {fn.Name}", LogLevel.Info);
                    Logger.Log($"   ➤ {details}");
                    Logger.Log(new string('-', 50), LogLevel.Info);
                }

                foreach (TreeNode child in node.Nodes)
                    PreviewChanges(child);
            }
        }


        /// <summary>
        /// Displays a <see cref="MessageBox"/> with help information for the feature associated with the selected <see cref="TreeNode"/>.
        /// If no specific information is available or the node is invalid, an appropriate message is shown.
        /// </summary>
        /// <param name="node">The <see cref="TreeNode"/> representing the feature for which to show help.</param>
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

        /// <summary>
        /// Opens the default web browser (Microsoft Edge, if available, falling back to system default)
        /// to search Google for more information about the feature associated with the selected <see cref="TreeNode"/>.
        /// The search query is based on the feature's details.
        /// </summary>
        /// <param name="node">The <see cref="TreeNode"/> representing the feature for which to search online help.</param>
        public static void ShowHelpOnline(TreeNode node)
        {
            if (node?.Tag is FeatureNode fn)
            {
                string searchQuery = Uri.EscapeDataString( fn.Feature.GetFeatureDetails());
                string webUrl = $"microsoft-edge:https://www.google.com/search?q={searchQuery}";

                System.Diagnostics.Process.Start(webUrl);
            }
        }

    }
}