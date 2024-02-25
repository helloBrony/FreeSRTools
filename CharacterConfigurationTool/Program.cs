namespace CharacterConfigurationTool {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        public static MainForm FormMain;

        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            FormMain = new MainForm();
            Application.Run(FormMain);
        }
    }
}