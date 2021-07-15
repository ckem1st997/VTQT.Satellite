
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTQT.Satellite.Service.SatelliteService.Repository;

namespace VTQT.Satellite.Service.SatelliteService.DIUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISubscriberRepository SubscriberRepository { get; }
    }
}

