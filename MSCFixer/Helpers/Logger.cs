using System;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// A simple logger class to log messages to a RichTextBox.
/// </summary>
public static class Logger
{
    public static RichTextBox OutputBox;

    private static readonly Font DefaultFont = new Font("Consolas", 8.25f, FontStyle.Regular);

    public static void Log(string message, LogLevel level = LogLevel.Info)
    {
        if (OutputBox == null) return;

        if (OutputBox.InvokeRequired)
        {
            OutputBox.Invoke(new Action(() => LogInternal(message, level)));
        }
        else
        {
            LogInternal(message, level);
        }
    }

    private static void LogInternal(string message, LogLevel level)
    {
        // string prefix = $"[{DateTime.Now:HH:mm:ss}] [{level}] ";
        string fullMessage = message + Environment.NewLine;

        // Set color based on log level
        Color color;
        switch (level)
        {
            case LogLevel.Warning:
                color = Color.OrangeRed;
                break;

            case LogLevel.Error:
                color = Color.Red;
                break;

            case LogLevel.Custom:
                color = Color.Magenta; // for plugins and other custom messages
                break;

            default:
                color = Color.Black;
                break;
        }

        // Append text with color
        OutputBox.SelectionStart = OutputBox.TextLength;
        OutputBox.SelectionLength = 0;
        OutputBox.SelectionColor = color;
        OutputBox.AppendText(fullMessage);

        // Reset selection to default
        OutputBox.SelectionColor = OutputBox.ForeColor; // reset color
        OutputBox.SelectionFont = DefaultFont; // reset font
        OutputBox.ScrollToCaret();   // scroll to the end
    }
}

public enum LogLevel
{
    Info,
    Warning,
    Error,
    Custom
}