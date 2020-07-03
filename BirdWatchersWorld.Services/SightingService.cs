using BirdWatchersWorld.Data;
using BirdWatchersWorld.Models.Sighting;
using BirdWatchersWorld.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Services
{

    public class SightingService
    {
        private readonly Guid _userId;

        public SightingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSighting(SightingCreate model)
        {
            var entity =
                new Sighting()
                {
                    TimeSeen = model.TimeSeen
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sightings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SightingListItem> GetSightings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sightings
                        .Select(
                            e =>
                                new SightingListItem
                                {
                                    TimeSeen = e.TimeSeen
                                }
                        );

                return query.ToArray();
            }
        }

        public SightingDetail GetSightingByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sightings
                        .Single(e => e.SightingID == id); //&& e.OwnerId == _userId
                return
                    new SightingDetail
                    {
                        TimeSeen = entity.TimeSeen
                    };
            }
        }

        public bool UpdateSighting(SightingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sightings
                        .Single(e => e.SightingID == model.SightingID);

                entity.TimeSeen = model.TimeSeen;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSighting(int sightingID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sightings
                        .Single(e => e.SightingID == sightingID);

                ctx.Sightings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}