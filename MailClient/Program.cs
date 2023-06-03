using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new F_Login());
        }
    }
    public static class Constants
    {
        public const string EMAIL = "nguyenminhduc22352801@gmail.com";
        public const string PASSWORD = "dvtpupjaxpmgptlu";
        public const string FOLDER_READ = "Inbox";
        public const string EMAILOUTLOOK = "";
        public const string PASSWORDOUTLOOK = "";

    }
}
