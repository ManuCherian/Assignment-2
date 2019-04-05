using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Models
{
    public interface IMockEventDetails
    {
        IQueryable<EventDetail> EventDetails { get; }

        EventDetail Save(EventDetail eventDetail);

        void Delete(EventDetail eventDetail);
        void Dispose();
    }
}
