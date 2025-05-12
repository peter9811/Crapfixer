using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public static class IniStateManager
{
    // Saves the states of the TreeView nodes to an INI file
    public static void Save(TreeView tree, string path)
    {
        using (var writer = new StreamWriter(path))
        {
            // Iterates through all nodes and saves their state
            WriteNodeStates(writer, tree.Nodes);
        }
    }

    // Loads the states of the TreeView nodes from an INI file
    public static void Load(TreeView tree, string path)
    {
        if (!File.Exists(path)) return;

        var lines = File.ReadAllLines(path);
        var states = lines.Select(l => l.Split(new[] { '=' }, 2))
                          .Where(p => p.Length == 2)
                          .ToDictionary(p => p[0].Trim(), p => p[1].Trim().ToLower() == "true");

        // Sets the state of the nodes based on the loaded data
        ApplyStates(tree.Nodes, states);
    }

    /// <summary>
    /// Saves the state of each node in the TreeView recursively.
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="nodes"></param>
    private static void WriteNodeStates(StreamWriter writer, TreeNodeCollection nodes)
    {
        foreach (TreeNode node in nodes)
        {
            // Saves the node's name and its checked status
            writer.WriteLine($"{node.Text.Trim()}={node.Checked}");
            // If the node has children, recursively go through all nodes
            if (node.Nodes.Count > 0)
                WriteNodeStates(writer, node.Nodes);
        }
    }

    /// <summary>
    /// Applies the saved states to the TreeView nodes recursively.
    /// </summary>
    /// <param name="nodes"></param>
    /// <param name="states"></param>
    private static void ApplyStates(TreeNodeCollection nodes, Dictionary<string, bool> states)
    {
        foreach (TreeNode node in nodes)
        {
            string nodeName = node.Text.Trim();
            if (states.ContainsKey(nodeName))
            {
                node.Checked = states[nodeName];
            }

            // Apply recursively to child nodes
            if (node.Nodes.Count > 0)
                ApplyStates(node.Nodes, states);
        }
    }
}
