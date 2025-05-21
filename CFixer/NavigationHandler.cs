using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CFixer
{
    /// <summary>
    /// Handles navigation button highlighting for a set of UI buttons.
    /// </summary>
    public class NavigationHandler
    {
        // List of all buttons managed by the navigation handler
        private readonly List<Button> _buttons;

        // Color used for the active (selected) button
        private readonly Color _activeColor = Color.FromArgb(76, 145, 235);

        // Color used for inactive (non-selected) buttons
        private readonly Color _inactiveColor = Color.FromArgb(104, 104, 104);

        // Border color for inactive buttons
        private readonly Color _inactiveBorderColor = Color.FromArgb(114, 114, 114);

        /// <summary>
        /// Event fired when a navigation button is clicked.
        /// </summary>
        public event Action<Button> NavigationButtonClicked;

        /// <summary>
        /// Initializes the handler with the buttons that should be managed.
        /// </summary>
        /// <param name="buttons">The buttons to include in the navigation group.</param>
        public NavigationHandler(params Button[] buttons)
        {
            _buttons = new List<Button>(buttons);

            foreach (var button in _buttons)
            {
                button.Click += OnButtonClick;
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                SetActive(clickedButton);
                NavigationButtonClicked?.Invoke(clickedButton);
            }
        }
        /// <summary>
        /// Sets the specified button as active, changing colors accordingly.
        /// </summary>
        /// <param name="activeButton">The button to highlight as active.</param>
        public void SetActive(Button activeButton)
        {
            foreach (var button in _buttons)
            {
                bool isActive = button == activeButton;

                // Set the background color for the button (active or inactive)
                button.BackColor = isActive ? _activeColor : _inactiveColor;

                // Set the border color for the button (active or inactive)
                button.FlatAppearance.BorderColor = isActive ? _activeColor : _inactiveBorderColor;

                // Set the text color to white for both active and inactive
                button.ForeColor = Color.White;
            }
        }
    }
}
