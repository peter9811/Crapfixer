using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public static class IniStateManager
{
    // CrapFixer.ini path
    private static readonly string IniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CrapFixer.ini");

    private static readonly object FileLock = new object();

    // Saves the global states (App size, TreeView nodes states)
    public static void Save(TreeView tree, Form form)
    {
        lock (FileLock)
        {
            // Read existing lines if file exists
            var lines = File.Exists(IniPath) ? File.ReadAllLines(IniPath).ToList() : new List<string>();

            // Remove old APP and FEATURES sections
            RemoveSection(lines, "APP");
            RemoveSection(lines, "FEATURES");

            // Append new APP section
            lines.Add("[APP]");
            lines.Add($"Width={form.Width}");
            lines.Add($"Height={form.Height}");
            lines.Add(""); // empty line for spacing

            // Append new FEATURES section (TreeView nodes states)
            lines.Add("[FEATURES]");
            AppendNodeStates(lines, tree.Nodes);

            // Write all back
            File.WriteAllLines(IniPath, lines);
        }
    }

    // Removes a section from the INI content
    private static void RemoveSection(List<string> lines, string sectionName)
    {
        int start = lines.FindIndex(l => l.Trim().Equals($"[{sectionName}]", StringComparison.OrdinalIgnoreCase));
        if (start < 0) return;

        int end = start + 1;
        while (end < lines.Count && !lines[end].TrimStart().StartsWith("["))
            end++;

        lines.RemoveRange(start, end - start);
    }

    // Helper to write TreeNode states to a list of strings
    private static void AppendNodeStates(List<string> lines, TreeNodeCollection nodes)
    {
        foreach (TreeNode node in nodes)
        {
            lines.Add($"{node.Text.Trim()}={node.Checked}");
            if (node.Nodes.Count > 0)
                AppendNodeStates(lines, node.Nodes);
        }
    }

    // Loads global states (App size, TreeView nodes states) from the INI file
    public static void Load(TreeView tree, Form form)
    {
        if (!File.Exists(IniPath)) return;

        var lines = File.ReadAllLines(IniPath);
        var section = "";
        var states = new Dictionary<string, bool>();

        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            if (string.IsNullOrWhiteSpace(trimmed)) continue;

            // Check if line is a section
            if (trimmed.StartsWith("[") && trimmed.EndsWith("]"))
            {
                section = trimmed;
                continue;
            }

            // Split line into key and value
            var parts = trimmed.Split(new[] { '=' }, 2);
            if (parts.Length != 2) continue;

            var key = parts[0].Trim();
            var value = parts[1].Trim();

            if (section == "[FEATURES]")
            {
                states[key] = value.ToLower() == "true";
            }
            else if (section == "[APP]")
            {
                if (int.TryParse(value, out int size))
                {
                    if (key.Equals("Width", StringComparison.OrdinalIgnoreCase))
                        form.Width = size;
                    else if (key.Equals("Height", StringComparison.OrdinalIgnoreCase))
                        form.Height = size;
                }
            }
        }

        // Apply saved feature states to tree nodes
        ApplyStates(tree.Nodes, states);
    }

    // Applies the saved states to the TreeView nodes
    private static void ApplyStates(TreeNodeCollection nodes, Dictionary<string, bool> states)
    {
        foreach (TreeNode node in nodes)
        {
            string nodeName = node.Text.Trim();
            if (states.ContainsKey(nodeName))
                node.Checked = states[nodeName];

            if (node.Nodes.Count > 0)
                ApplyStates(node.Nodes, states);
        }
    }

    // Saves individual settings (like checkbox states) for a specific view
    public static void SaveViewSettings(string viewName, Dictionary<string, bool> settings)
    {
        lock (FileLock)
        {
            var lines = File.Exists(IniPath) ? File.ReadAllLines(IniPath).ToList() : new List<string>();

            // Remove previous section to avoid duplicates
            RemoveSection(lines, viewName);

            // Append new section with updated settings
            lines.Add($"[{viewName}]");
            foreach (var kvp in settings)
            {
                lines.Add($"{kvp.Key}={kvp.Value}");
            }

            File.WriteAllLines(IniPath, lines);
        }
    }

    // Loads individual settings for a specific view (e.g. checkboxes)
    public static Dictionary<string, bool> LoadViewSettings(string viewName)
    {
        var result = new Dictionary<string, bool>();
        if (!File.Exists(IniPath)) return result;

        var lines = File.ReadAllLines(IniPath);
        bool inTargetSection = false;

        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            if (string.IsNullOrWhiteSpace(trimmed)) continue;

            // Check if we are in the desired view section
            if (trimmed.StartsWith("[") && trimmed.EndsWith("]"))
            {
                inTargetSection = trimmed.Equals($"[{viewName}]", StringComparison.OrdinalIgnoreCase);
                continue;
            }

            if (!inTargetSection) continue;

            var parts = trimmed.Split(new[] { '=' }, 2);
            if (parts.Length != 2) continue;

            var key = parts[0].Trim();
            var value = parts[1].Trim();

            result[key] = value.ToLower() == "true";
        }

        return result;
    }

    // Checks if a setting exists in a specific section
    public static bool IsViewSettingEnabled(string sectionName, string settingName)
    {
        var settings = LoadViewSettings(sectionName);
        return settings.ContainsKey(settingName) && settings[settingName];
    }
}

/// <summary>
/// Extension methods for IDictionary to provide default value retrieval.
/// </summary>
public static class DictionaryExtensions
{
    public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default)
    {
        return dict.TryGetValue(key, out var value) ? value : defaultValue;
    }
}