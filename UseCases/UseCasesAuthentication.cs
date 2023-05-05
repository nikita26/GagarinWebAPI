using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class UseCasesAuthentication
    {
        private readonly IUserRepository _userRepository;
        public UseCasesAuthentication(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<bool> AuthenticateUserAsync(string login,string password)
        {
            var user = await _userRepository.GetByLoginAsync(login);
            if(user?.Password == password)
                return true;

            return false;
        }
    }
}
