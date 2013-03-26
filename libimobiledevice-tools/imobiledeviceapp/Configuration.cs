namespace iMobileDeviceApp
{
    using System.Collections.Specialized;
    using System.Configuration;

    internal static class Configuration
    {
        public static readonly string DeviceInfoFileName;
        public static readonly string DeviceScreenshotFileName;
        public static readonly string DeviceImageMounterFileName;

        static Configuration()
        {
            NameValueCollection nameValueCollection = ConfigurationManager.AppSettings;

            DeviceInfoFileName = nameValueCollection["DeviceInfo.FileName"];
            DeviceScreenshotFileName = nameValueCollection["DeviceScreenshot.FileName"];
            DeviceImageMounterFileName = nameValueCollection["DeviceImageMounter.FileName"];
        }
    }
}
