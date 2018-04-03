using System;
using System.Text;
using System.Windows.Forms;

namespace DiscordEmoticonLetters
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Private

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            // Ignore characters that aren't a letter/space/control.
            if (!char.IsLetter(e.KeyChar) &&
                e.KeyChar != ' ' &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            // Initialize a string builder to create the output.
            var outputBuilder = new StringBuilder();

            foreach (char character in txtInput.Text)
            {
                if (character == ' ')
                {
                    // Append an extra space to make individual words easier to see.
                    outputBuilder.Append("  ");
                }
                else
                {
                    // Replace all dollar signs in the pattern with the specified letter.
                    string emoticonText = txtPattern.Text.Replace('$', char.ToLower(character));
                    outputBuilder.Append(emoticonText);
                    // A space after each emoticon is required to make Discord parse it properly.
                    outputBuilder.Append(' ');
                }
            }

            // Append the string value to the output textbox.
            txtOutput.Text = outputBuilder.ToString();
        }

        private void OnClick(object sender, EventArgs e)
        {
            // Set the clipboard text if the output textbox has text.
            if (!string.IsNullOrEmpty(txtOutput.Text))
            {
                Clipboard.SetText(txtOutput.Text);
            }
        }

        #endregion

        #endregion
    }
}
