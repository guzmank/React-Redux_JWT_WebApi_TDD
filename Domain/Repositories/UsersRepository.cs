using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUsersRepository
    {
        // GET ALL
        Task<IEnumerable<User>> GetUsersAsync();
        User Authenticate(string username, string password);
    }

    public class UsersRepository : IUsersRepository
    {
        HomeDBContext db;

        public UsersRepository(HomeDBContext _db)
        {
            db = _db;
        }

        //private async Task<List<Users>> GetUsers()
        //{
        //    if (db != null)
        //    {
        //        return await (from x in db.Users.AsNoTracking()
        //                      select new Users
        //                      {
        //                          Id = x.Id,
        //                          FirstName = x.FirstName,
        //                          LastName = x.LastName,
        //                          Username = x.Username,
        //                          Password = x.Password,
        //                          Token = x.Token,
        //                      }).ToListAsync();
        //    }

        //    return null;
        //}

        public User Authenticate(string username, string password)
        {
            /*
            var user = GetUsers().Result.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
                return null;
            
            user.Password = null;

            return user;
            */

            if (db != null)
            {
                var user = db.User.Where(x => x.Username == username && x.Password == password).SingleOrDefaultAsync();
                //var user = db.User.FirstOrDefault();

                if (user.Result == null)
                    return null;

                user.Result.Password = null;

                return user.Result;
            }

            return null;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            if (db != null)
            {
                var response = new HashSet<User>();

                foreach (var user in await db.User.ToListAsync())
                {
                    user.Password = null;
                    response.Add(user);
                }

                return response;
            }

            return null;
        }

    }
}
