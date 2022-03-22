using PontoMaisDomain.ClockIn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoMaisInfra.EF.Repositories
{
    public class ClockingEventRepository : BaseRepository<ClockingEvent>
    {
        public ClockingEventRepository(Context context) : base(context)
        {
        }

    }
}
