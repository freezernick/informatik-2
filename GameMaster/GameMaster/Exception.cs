using GameMaster.Logging;

namespace GameMaster.Exception
{
    /// <summary>
    /// The severity of an exception.
    /// Low => The excecution can safely continue. Just logs the error.
    /// Medium => Problems may occur. Show the exception to the user.
    /// High => The excecution cannot be continued. Stops the execution.
    /// </summary>
    public enum Severity : uint
    {
        Low = 0,
        Medium = 1,
        High = 3
    }

    public static class GMException
    {
        public static void Throw(string exception, Severity severity = Severity.Low)
        {
            LogHelper.Log(exception);
            if (severity == Severity.Medium)
                LogHelper.OverlayLog("An exception has occured! The program may be unstable now!");
            if (severity == Severity.High)
                MainFormHelper.Get().Vm.Interrupt();
        }
    }
}
