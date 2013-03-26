namespace iMobileDeviceApp
{
    using System;
    using System.Diagnostics;

    public class DeviceInfoProvider : BaseDeviceProcessor
    {
#region Fields

        private Runner _runner;

#endregion Fields

        #region Properties

        public string DeviceId { get; set; }
        public bool UseDebugMode { get; set; }
        public bool UseSimpleConnection { get; set; }
        public string QueryDomainName { get; set; }
        public string QueryKeyName { get; set; }
        public bool UseXmlOutput { get; set; }

#endregion Properties

#region Interface Implementation

        public override bool Run()
        {
            if (_runner != null)
            {
                return false;
            }

            _runner = new Runner(GetFileNameToRun());
            AttachDeviceIdArgument();
            AttachDebugArgument();
            AttachSimpleConnection();
            AttachXmlFlag();
            AttachDomainName();
            AttachKeyName();

            _runner.DataReceived += delegate(object sender, DataReceivedEventArgs args)
            {
                if (DataReceived != null)
                {
                    DataReceived(args.Data);
                }
            };
            _runner.ErrorReceived += delegate(object sender, DataReceivedEventArgs args)
            {
                if (ErrorOccured != null)
                {
                    ErrorOccured(args.Data);
                }
            };
            _runner.ProcessExited += delegate(object sender, ProcessExitedEventArgs args)
            {
                if (ApplicationExited != null)
                {
                    ApplicationExited(args.ExitCode);
                }
            };

            return _runner.Run();
        }

#endregion Interface Implementation

        public DeviceInfoProvider()
        {
            
        }

        public DeviceInfoProvider(string deviceId) : this()
        {
            DeviceId = deviceId;
        }

        private string GetFileNameToRun()
        {
            return Configuration.DeviceInfoFileName;
        }

        private void AttachDeviceIdArgument()
        {
            if (!String.IsNullOrWhiteSpace(DeviceId))
            {
                _runner.Arguments.Add("--udid", DeviceId);
            }
        }

        private void AttachDebugArgument()
        {
            if (UseDebugMode)
            {
                _runner.Arguments.Add("--debug");
            }
        }

        private void AttachSimpleConnection()
        {
            if (UseSimpleConnection)
            {
                _runner.Arguments.Add("--simple");
            }
        }

        private void AttachDomainName()
        {
            if (String.IsNullOrWhiteSpace(QueryDomainName))
            {
                _runner.Arguments.Add("--domain", QueryDomainName);
            }
        }

        private void AttachKeyName()
        {
            if (String.IsNullOrWhiteSpace(QueryKeyName))
            {
                _runner.Arguments.Add("--key", QueryKeyName);
            }
        }

        private void AttachXmlFlag()
        {
            if (UseXmlOutput)
            {
                _runner.Arguments.Add("--xml");
            }
        }
    }
}
