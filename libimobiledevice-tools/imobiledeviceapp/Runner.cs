namespace iMobileDeviceApp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    internal class Runner : IDisposable
    {   
        #region Constants

        public const int ProcessTerminatedStatusCode = int.MinValue;

        #endregion Constants

        #region Fields

        private readonly ICollection<string> _arguments = new List<string>();
        private Process _process;

        #endregion Fields

        #region Properties

        public string FileName { get; private set; }
        public ICollection<string> Arguments { get { return _arguments; } }

        public event EventHandler<ProcessExitedEventArgs> ProcessExited;
        public event EventHandler<DataReceivedEventArgs> ErrorReceived;
        public event EventHandler<DataReceivedEventArgs> DataReceived;

        private bool IsDisposed { get; set; }

        #endregion Properties

        #region Methods

        public Runner(string fileName)
        {
            #region Argument sanitizing

            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }

            if (!File.Exists(fileName))
            {
                throw new ArgumentException(String.Format("File with name \'{0}\' must exist.", fileName));
            }

            #endregion Argument sanitizing

            FileName = fileName;
        }

        public bool Run()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }

            StopRunning();

            var argumentsString = String.Join(" ", _arguments);

            var processStartInfo = new ProcessStartInfo(FileName, argumentsString) {
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            _process = new Process
            {
                StartInfo = processStartInfo,
                EnableRaisingEvents = true
            };

            _process.Exited += delegate {
                if (ProcessExited != null)
                {
                    ProcessExited(this, new ProcessExitedEventArgs(_process.ExitCode));
                }
            };

            _process.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs args)
            {
                if (ErrorReceived != null)
                {
                    ErrorReceived(this, args);
                }
            };

            _process.OutputDataReceived += delegate(object sender, DataReceivedEventArgs args)
            {
                if (DataReceived != null)
                {
                    DataReceived(this, args);
                }
            };

            return _process.Start();
        }

        public void StopRunning()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }

            if (_process != null && !_process.HasExited)
            {
                _process.Kill();
                _process.WaitForExit(1000);
                if (ProcessExited != null)
                {
                    ProcessExited(this, new ProcessExitedEventArgs(ProcessTerminatedStatusCode));
                }

                _process = null;
            }
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
            
            StopRunning();
            IsDisposed = true;
        }

        #endregion Implementation of IDisposable

        #endregion Methods
    }
}
