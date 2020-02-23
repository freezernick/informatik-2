namespace GameMaster.Logging
{
    public static class LogHelper
    {
        public static void Log(string message)
        {
            FormHandler.MainForm().vm.Log(message);
        }

        public static void OverlayLog(string message, bool useLogfile = false)
        {
            FormHandler.MainForm().vm.OverlayLog(message);
            if(useLogfile) { FormHandler.MainForm().vm.Log(message);  }
        }
    }

    struct LogMessage
    {
        public string message;
        public int clockCount;

        public LogMessage(string logMessage)
        {
            message = logMessage;
            clockCount = 0;
        }
    }
}