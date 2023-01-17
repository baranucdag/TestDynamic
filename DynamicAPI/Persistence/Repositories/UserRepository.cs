using DynamicAPI.Persitence.Extensions;
using DynamicAPI.Persitence.Models.Dynamic;
using DynamicAPI.Persitence.Models.Pagination;
using DynamicAPI.Persitence.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DynamicAPI.Persitence.Repositories
{
    public class UserRepository
    {
        public IPaginate<User> GetListByDynamic(Dynamic dynamic,
                                            Func<IQueryable<User>, IIncludableQueryable<User, object>>?
                                                include = null, int index = 0, int size = 10,
                                            bool enableTracking = true)
        {
            IQueryable<User> queryable = GetAllUsers().AsQueryable().ToDynamic(dynamic);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (size == 0) size = 10;
            return queryable.ToPaginate(index, size);
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>
            {
                new User { Id = 1, FirstName = "user1", LastName = "user", PasswordSalt = "dsadasdsad", PasswordHash = "ab", CreatedAt = DateTime.Now },
                new User { Id = 2, FirstName = "user2", LastName = "user", PasswordSalt = "dsadasdsad", PasswordHash = "abc", CreatedAt = DateTime.Now },
                new User { Id = 3, FirstName = "use3", LastName = "user", PasswordSalt = "dsadasdsad", PasswordHash = "abcd", CreatedAt = DateTime.Now },
                new User { Id = 4, FirstName = "user4", LastName = "use2", PasswordSalt = "dsadasdsad", PasswordHash = "abcde", CreatedAt = DateTime.Now },
                new User { Id = 5, FirstName = "user5", LastName = "use3", PasswordSalt = "dsadasdsad", PasswordHash = "abcdef", CreatedAt = DateTime.Now },
                new User { Id = 6, FirstName = "user6", LastName = "user", PasswordSalt = "dsadasdsad", PasswordHash = "abcdefg", CreatedAt = DateTime.Now },
            };

            return users;
        }
    }


}
