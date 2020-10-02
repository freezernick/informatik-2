namespace GameMaster.Logging
{
    public static class LogHelper
    {
        public static void Log(string message) => MainFormHelper.Get().GameMasterProcess.Log(message);

        public static void OverlayLog(string message, bool useLogfile = false)
        {
            MainFormHelper.Get().GameMasterProcess.OverlayLog(message);
            if (useLogfile) { MainFormHelper.Get().GameMasterProcess.Log(message); }
        }
    }

    public class LogMessage
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