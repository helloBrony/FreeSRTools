using System.Runtime.InteropServices;

namespace CharacterConfigurationTool {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        public static MainForm FormMain;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            AllocConsole();
            ApplicationConfiguration.Initialize();
            FormMain = new MainForm();
            Application.Run(FormMain);
        }
    }
}