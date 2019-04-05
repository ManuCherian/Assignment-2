using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event.Models
{
    public class IDataEventDetails : IMockEventDetails
    {
        // db connection
        private DbModel db = new DbModel();

        public IQueryable<EventDetail> EventDetails { get { return db.EventDetails; } }

        public void Delete(EventDetail eventDetail)
        {
            db.EventDetails.Remove(eventDetail);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public EventDetail Save(EventDetail eventDetail)
        {
            if(eventDetail.IdNumber == 0)
            {
                db.EventDetails.Add(eventDetail);
            }
            else
            {
                db.Entry(eventDetail).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return eventDetail;

        }
    }
}