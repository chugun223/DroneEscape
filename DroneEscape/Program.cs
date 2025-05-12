using System;
using System.Windows.Forms;
using DroneEscape.View;

namespace DroneEscape
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MenuForm());
        }
    }
}