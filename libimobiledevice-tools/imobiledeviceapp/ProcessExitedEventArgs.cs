namespace iMobileDeviceApp
{
    using System;

    public class ProcessExitedEventArgs : EventArgs
    {
        public int ExitCode { get; private set; }

        public ProcessExitedEventArgs(int exitCode)
        {
            ExitCode = exitCode;
        }
    }
}
