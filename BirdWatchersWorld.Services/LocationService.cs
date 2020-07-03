using BirdWatchersWorld.Data;
using BirdWatchersWorld.Models.Location;
using BirdWatchersWorld.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Services
{
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    Name = model.Name,
                    ClosestCity = model.ClosestCity,
                    North = model.North,
                    East = model.East,
                    South = model.South,
                    West = model.West
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Locations
                        .Select(
                            e =>
                                new LocationListItem
                                {
                                    Name = e.Name,
                                    ClosestCity = e.ClosestCity,
                                    North = e.North,
                                    East = e.East,
                                    South = e.South,
                                    West = e.West
                                }
                        );

                return query.ToArray();
            }
        }

        public LocationDetail GetLocationByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == id); //&& e.OwnerId == _userId
                return
                    new LocationDetail
                    {
                        Name = entity.Name,
                        ClosestCity = entity.ClosestCity,
                        North = entity.North,
                        East = entity.East,
                        South = entity.South,
                        West = entity.West
                    };
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == model.LocationID);

                entity.Name = model.Name;
                entity.ClosestCity = model.ClosestCity;
                entity.North = model.North;
                entity.East = model.East;
                entity.South = model.South;
                entity.West = model.West;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLocation(int locationID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == locationID);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
