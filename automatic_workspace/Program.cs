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
            Application.Run(new Form_auth());
            if (User_info.Current_status != null)
                Application.Run(new Form_workspace());
        }
    }

    public static class User_info
    {
        public enum Status { Admin, Operator, Guest};

        public static Status? Current_status;
    }
}
