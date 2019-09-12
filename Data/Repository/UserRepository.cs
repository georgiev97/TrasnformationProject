using Data.DataContext;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class UserRepository : BaseRepository<User>
    {

        public UserRepository(TransformationContext context)
            : base(context)
        {
        }

        public User GetById(int? id)
        {
            var userById = Context.Users.AsQueryable();

            return userById.Where(i => i.UserId == id).FirstOrDefault();
        }

        public int GetCount()
        {
            var userCount = Context.Users;

            return userCount.Count();
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            var user = Context.Users.AsQueryable();
            return user.Where(i => i.Username == username && i.Password == password).FirstOrDefault();
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            var user = Context.Users.AsQueryable();
            return user.Where(i => i.Email == email && i.Password == password).FirstOrDefault();
        }

        public User IsEmailExist(string emailID)
        {                    
             var email = Context.Users.Where(a => a.Email == emailID).FirstOrDefault();
                return email;
            
        }

        public User IsUsernameExist( string usernameId)
        {
            var username = Context.Users.Where(u => u.Username == usernameId).FirstOrDefault();
            return username;

        }

        public bool passwordMatches(string password,string confirmPassword)
        {
            var match = password == confirmPassword;
            return match;

        }

        public User GetUser(User user)
        {
            var username = Context.Users.Where(u => u.Username == user.Username).FirstOrDefault();
            return username;

        }

    }
}
