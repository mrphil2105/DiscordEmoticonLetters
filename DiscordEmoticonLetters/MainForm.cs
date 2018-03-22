using System;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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

        private void OnTextChanged(object sender, EventArgs e)
        {
            var outputBuilder = new StringBuilder();

            foreach (char character in txtInput.Text)
            {
                string characterStr = character.ToString();

                if (Regex.IsMatch(characterStr, "^[A-Za-z]$"))
                {
                    outputBuilder.Append(txtPattern.Text.Replace("$", characterStr));
                    outputBuilder.Append(' ');
                }
                else
                {
                    outputBuilder.Append(characterStr);
                }
            }

            txtOutput.Text = outputBuilder.ToString();
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOutput.Text))
            {
                Clipboard.SetText(txtOutput.Text);
            }
        }

        #endregion

        #endregion
    }
}
