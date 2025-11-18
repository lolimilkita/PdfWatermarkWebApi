using PdfWatermarkWebApi.Entities;
using PdfWatermarkWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfWatermarkWebApi.Service
{
    public interface IUserService
    {
        ApplicationUser GetUserByEmail(string email);
    }

    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;

        public UserService (IUnitOfWork uow, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _uow = uow;
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }
    }
}
