using Data.DataContext;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class TrainingUserRepository : BaseRepository<TrainingUser>
    {
        public TrainingUserRepository(TransformationContext context) : base(context)
        {
        }

        public TrainingUser GetById(int id)
        {
            var userById = Context.TrainingUsers.AsQueryable();

            return userById.Where(i => i.UserId == id).FirstOrDefault();

        }

        public List<TrainingUser> getAll ()
        {
            List<TrainingUser> users = new List<TrainingUser>();

            foreach(var u in Context.TrainingUsers)
            {
                users.Add(u);
            }
            List<TrainingUser> sortedUsers;
            sortedUsers = users.OrderByDescending(p => p.Rating).ToList();


            return sortedUsers;
        }

    }
}
