namespace GameMaster
{
    public static class LogClass
    {
        public static void Log(string message)
        {
            FormHandler.MainForm().Log(message);
            if (FormHandler.MainForm().vm != null)
            {
                FormHandler.MainForm().vm.Log(message);
            }
        }
    }
}