using System;
using Gtk;

namespace Demo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            var window = new MainWindow();
            window.Resize(640, 360);
            window.ShowAll();
            Application.Run();
        }
    }
}
