using DN.AutoShopBrasil.Data.Context;
using DN.AutoShopBrasil.Data.Interfaces;
using System;

namespace DN.AutoShopBrasil.Data.UnityOfWork
{
    public class EFUnityOfWork : IUnityOfWork
    {
        private readonly AutoShopBrasilContext _context;
        private bool _disposed;
        public EFUnityOfWork(AutoShopBrasilContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
