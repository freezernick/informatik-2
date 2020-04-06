namespace GameMaster.Logging
{
    public static class LogHelper
    {
        public static void Log(string message) => FormHandler.Get<MainForm>().Vm.Log(message);

        public static void OverlayLog(string message, bool useLogfile = false)
        {
            FormHandler.Get<MainForm>().Vm.OverlayLog(message);
            if (useLogfile) { FormHandler.Get<MainForm>().Vm.Log(message); }
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