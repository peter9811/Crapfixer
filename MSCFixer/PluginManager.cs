using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

public static class PluginManager
{
    public static async Task ExecutePlugin(string pluginPath)
    {
        try
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{pluginPath}\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                var outputBuilder = new StringBuilder();
                var errorBuilder = new StringBuilder();

                process.OutputDataReceived += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        Logger.Log($"[PS Output] {e.Data}");
                };

                process.ErrorDataReceived += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        Logger.Log($"[PS Error] {e.Data}", LogLevel.Error);
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await Task.Run(() => process.WaitForExit());
                Logger.Log($"✅ Script executed: {Path.GetFileName(pluginPath)}");
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"❌ Error executing script: {ex.Message}", LogLevel.Error);
        }
    }

    public static void LoadPlugins(TreeView treeView)
    {
        string pluginsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");

        if (!Directory.Exists(pluginsFolder))
        {
            Directory.CreateDirectory(pluginsFolder);
            // Logger.Log("No Plugins found.\nGet it on https://github.com/builtbybel/Crapfixer");
            return;
        }

        var pluginsNode = new TreeNode("Plugins")
        {
           // NodeFont = new Font(treeView.Font, FontStyle.Bold),
            BackColor = Color.Magenta,
            ForeColor = Color.White
        };

        foreach (var scriptPath in Directory.GetFiles(pluginsFolder, "*.ps1"))
        {
            var scriptName = Path.GetFileNameWithoutExtension(scriptPath);
            var scriptNode = new TreeNode
            {
                Text = $"{scriptName} [PS]",
                ToolTipText = scriptPath,
                Tag = scriptPath,
                Checked = false
            };
            pluginsNode.Nodes.Add(scriptNode);
        }

        treeView.Nodes.Add(pluginsNode);
        treeView.ExpandAll(); // expand all nodes
    }

    public static void AnalyzeAll(TreeNode node)
    {
        if (node.Tag is string path && node.Checked)
        {
            Logger.Log($"🔎 Plugin ready: {Path.GetFileName(path)}");
        }

        foreach (TreeNode child in node.Nodes)
            AnalyzeAll(child);
    }

    /// <summary>
    /// Executes all checked plugins in the tree view.
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static async Task FixChecked(TreeNode node)
    {
        if (node.Checked)
        {
            // Show a warning for each checked plugin
            if (node.Tag is string pluginPath)  
            {
                var pluginName = Path.GetFileName(pluginPath);  // get the plugin name
                var proceed = ShowPluginWarning(pluginName);  // the warning message box
                if (!proceed) return;  // If user chooses not to proceed, exit the method
            }
        }

        if (node.Tag is string path && node.Checked)
        {
            await ExecutePlugin(path);
        }

        // Recursively process all child nodes
        foreach (TreeNode child in node.Nodes)
            await FixChecked(child);
    }

    /// <summary>
    /// Analyzes individual plugin files.
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static async Task AnalyzePlugin(TreeNode node)
    {
        if (node?.Tag is string path && File.Exists(path))
        {
            string content = File.ReadAllText(path);
            Logger.Log(new string('=', 50), LogLevel.Custom);
            Logger.Log($"📄 Script content:{node.Text}\n{content}", LogLevel.Info);

            await Task.CompletedTask;
        }
        else
        {
            Logger.Log($"❌ Script file not found for plugin: {node?.Text}", LogLevel.Error);
        }
    }

    /// <summary>
    /// Executes individual plugin files.
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static async Task FixPlugin(TreeNode node)
    {
        if (node?.Tag is string path && File.Exists(path))
        {
            Logger.Log($"🔧 Executing Plugin: {node.Text}", LogLevel.Info);
            await ExecutePlugin(path);
        }
        else
        {
            Logger.Log($"❌ Script file not found for plugin: {node?.Text}", LogLevel.Error);
        }
    }

    public static void RestorePlugin(TreeNode node)
    {
        Logger.Log($"⚠️ Restore is not available for Plugins: {node?.Text}", LogLevel.Warning);
        MessageBox.Show("Restore is not possible for Plugins.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    /// <summary>
    /// Checks if the node is a plugin node.
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static bool IsPluginNode(TreeNode node)
    {
        return node?.Tag is string path && path.EndsWith(".ps1", StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Shows a warning message box when the root plugin node is checked.
    /// </summary>
    /// <returns>True if the user confirmed, otherwise false.</returns>
    public static bool ShowPluginWarning(string pluginName)
    {
        var result = MessageBox.Show(
             $"⚠️ WARNING: The plugin '{pluginName}' is an external script. Its execution is outside this apps responsibility and at your own risk.\n" +
             "Proceed only if you trust the source of this plugin. Do you want to continue?",
             "Plugin Activation Warning",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Warning
         );

        return result == DialogResult.Yes; // Return true if "Yes" was clicked
    }
}