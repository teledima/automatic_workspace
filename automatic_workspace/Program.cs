using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automatic_workspace
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form_auth());
            User_info.status = 1;
            if (!string.IsNullOrEmpty(User_info.status.ToString()))
                Application.Run(new Form_workspace());
        }
    }

    public static class User_info
    {
        public static int status { get; set; }
    }
}
