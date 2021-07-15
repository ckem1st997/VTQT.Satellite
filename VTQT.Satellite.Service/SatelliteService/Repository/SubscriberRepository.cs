
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTQT.Satellite.Entity.Entity;
using VTQT.Satellite.Service.SatelliteService.DataContext;
using VTQT.Satellite.Service.SatelliteService.GenericRepository;

namespace VTQT.Satellite.Service.SatelliteService.Repository
{
    public class SubscriberRepository : GenericRepository<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(AppDataConnection context) : base(context)
        {

        }

    }
}
