using System;
using Infrastructure;


namespace BusinessServices
{
    public abstract class ServiceBase : IDisposable
    {
        private bool _disposed = false;
        public ILogger Logger { get; set; }
        public IExceptionHandler ExceptionHandler { get; set; }
        public ISecurityProvider SecurityProvider { get; set; }
        public IConfig Config { get; set; }

        protected ServiceBase(IConfig config,ILogger logger,IExceptionHandler exceptionHandler , ISecurityProvider securityProvider)
        {
            Logger = logger;
            ExceptionHandler = exceptionHandler;
            SecurityProvider = securityProvider;
            Config = config;
        }

        public virtual void DoSomething()
        {
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Cleanup()
        {

        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Cleanup();
                }
            }
            _disposed = true;
        }
    }
}