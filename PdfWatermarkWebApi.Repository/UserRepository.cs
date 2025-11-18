using PdfWatermarkWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfWatermarkWebApi.Repository
{
    public interface IUserRepository
    {
        ApplicationUser GetUserByEmail(string email);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IDapper _dapper;

        public UserRepository(IDapper dapper)
        {
            _dapper = dapper;
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            const string sql = @"
                SELECT UserId
                      ,Email
                      ,IsGoogleLogin
                      ,IsEmailLogin
                      ,CreatedAt
                FROM users
                WHERE Email = @Email AND IsDeleted = 0
            ";

            return _dapper.QueryMain<ApplicationUser>(sql, new { Email = email }).FirstOrDefault();
        }
    }
}
