using BirdWatchersWorld.Data;
using BirdWatchersWorld.Models;
using BirdWatchersWorld.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Birds.Add(entity);
                return ctx.SaveChanges() == 1;
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
                                    SecondColor = e.SecondColor
                                }
                        );

                return query.ToArray();
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
                return
                    new BirdDetail
                    {
                        BirdID = entity.BirdID,
                        Name = entity.Name,
                        MainColor = entity.MainColor,
                        SecondColor = entity.SecondColor
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
