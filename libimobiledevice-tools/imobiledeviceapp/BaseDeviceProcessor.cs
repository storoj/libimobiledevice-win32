namespace iMobileDeviceApp
{
    using System;

    public abstract class BaseDeviceProcessor
    {
        public Action<string> DataReceived { get; set; }
        public Action<string> ErrorOccured { get; set; }
        public Action<int> ApplicationExited { get; set; }

        public abstract bool Run();
    }
}
