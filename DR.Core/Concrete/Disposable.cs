using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Core.Concrete
{
    public class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCustomObjects();
            }

            isDisposed = true;
        }

        // Overide this to dispose custom objects
        protected virtual void DisposeCustomObjects()
        {
        }
    }
}
