
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTQT.Satellite.Service.SatelliteService.DataContext;
using VTQT.Satellite.Service.SatelliteService.Repository;

namespace VTQT.Satellite.Service.SatelliteService.DIUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDataConnection _context;

        public ISubscriberRepository SubscriberRepository{ get; }

        public UnitOfWork(AppDataConnection context, ISubscriberRepository asstType)
        {
            _context = context;
            SubscriberRepository = asstType;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}