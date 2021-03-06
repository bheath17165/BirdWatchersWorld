﻿using BirdWatchersWorld.Data;
using BirdWatchersWorld.Models;
using BirdWatchersWorld.Models.Spotting;
using BirdWatchersWorld.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Services
{
    public class SpotterService
    {
        private readonly Guid _userId;

        public SpotterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSpotter(SpotterCreate model)
        {
            var entity =
                new Spotter()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Spotters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SpotterListItem> GetSpotters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Spotters
                        .Select(
                            e =>
                                new SpotterListItem
                                {
                                    Id = e.Id,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName
                                }
                        );

                return query.ToArray();
            }
        }

        public SpotterDetail GetSpotterByID(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = (Spotter) //Casting
                    ctx
                        .Users
                        .Single(e => e.Id == id);

                List<BirdListItem> bli = new List<BirdListItem>();

                foreach(var sighting in entity.Sightings)
                {
                    BirdListItem birdListItem = new BirdListItem
                    {
                        BirdID = sighting.BirdID,
                        Name = sighting.Bird.Name,
                        MainColor = sighting.Bird.MainColor,
                        SecondColor = sighting.Bird.SecondColor
                    };
                 bli.Add(birdListItem);   
                }

                return
                    new SpotterDetail
                    {
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        UserName = entity.UserName,
                        BirdsSeen = bli
                    };
            }
        }

        public bool UpdateSpotter(SpotterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Spotters
                        .Single(e => e.Id == model.Id);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSpotter(string spotterID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Spotters
                        .Single(e => e.Id == spotterID);

                ctx.Spotters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
