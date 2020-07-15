using BirdWatchersWorld.Data;
using BirdWatchersWorld.Models;
using BirdWatchersWorld.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirdWatchersWorld.Services
{
    public class BirdService
    {
        private readonly Guid _userId;

        public BirdService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBird(BirdCreate model)
        {
            var entity =
                new Bird()
                {
                    Name = model.Name,
                    MainColor = model.MainColor,
                    SecondColor = model.SecondColor
                };

            var sighting =
                new Sighting()
                {
                    SpotterID = _userId.ToString(),
                    Bird = entity,
                    TimeSeen = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Birds.Add(entity);
                ctx.Sightings.Add(sighting);
                return ctx.SaveChanges() == 2;
            }
        }

        public IEnumerable<BirdListItem> GetBirds()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Birds
                        .Select(
                            e =>
                                new BirdListItem
                                {
                                    BirdID = e.BirdID,
                                    Name = e.Name,
                                    MainColor = e.MainColor,
                                    SecondColor = e.SecondColor,
                                    //SpotterName = e.Sightings.ToList()[0].Spotter.UserName
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<BirdListItem> SortBirds(string sortOrder, string searchString)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var birds = from s in ctx.Birds
                        select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    birds = birds.Where(s => s.Name.Contains(searchString)
                                           || s.MainColor.Contains(searchString)
                                           || s.SecondColor.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        birds = birds.OrderByDescending(s => s.Name);
                        break;
                    case "mainColor":
                        birds = birds.OrderBy(s => s.MainColor);
                        break;
                    case "mainColor_desc":
                        birds = birds.OrderByDescending(s => s.MainColor);
                        break;
                    case "secondaryColor":
                        birds = birds.OrderBy(s => s.SecondColor);
                        break;
                    case "secondaryColor_desc":
                        birds = birds.OrderByDescending(s => s.SecondColor);
                        break;
                    default:
                        birds = birds.OrderBy(s => s.Name);
                        break;
                }
                return (birds.Select(
                            e =>
                                new BirdListItem
                                {
                                    BirdID = e.BirdID,
                                    Name = e.Name,
                                    MainColor = e.MainColor,
                                    SecondColor = e.SecondColor,
                                    //SpotterName = e.Sightings.ToList()[0].Spotter.UserName
                                }
                        ).ToList());
            }
        }

        public BirdDetail GetBirdByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Birds
                        .Single(e => e.BirdID == id); //&& e.OwnerId == _userId
                var spotterName = entity.Sightings.Count == 0 ? "" : entity.Sightings.ToList()[0].Spotter.UserName;
                var timeSeen = entity.Sightings.Count == 0 ? DateTimeOffset.Now : entity.Sightings.ToList()[0].TimeSeen;
                return
                    new BirdDetail
                    {
                        BirdID = entity.BirdID,
                        Name = entity.Name,
                        MainColor = entity.MainColor,
                        SecondColor = entity.SecondColor,
                        SpotterName = spotterName,
                        TimeSeen = timeSeen
                    };
            }
        }

        public bool UpdateBird(BirdEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Birds
                        .Single(e => e.BirdID == model.BirdID);

                entity.Name = model.Name;
                entity.MainColor = model.MainColor;
                entity.SecondColor = model.SecondColor;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBird(int birdID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Birds
                        .Single(e => e.BirdID == birdID);

                ctx.Birds.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
