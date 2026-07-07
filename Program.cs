using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiciosMedicosApp
{
    internal static class Program
    {
        public static frmLogin loginForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginForm =  new frmLogin();
                 
            Application.Run(loginForm);
        }
    }
}
