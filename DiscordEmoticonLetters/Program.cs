using System;
using System.Windows.Forms;

namespace DiscordEmoticonLetters
{
    public static class Program
    {
        #region Methods

        #region Public

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        #endregion

        #endregion
    }
}
