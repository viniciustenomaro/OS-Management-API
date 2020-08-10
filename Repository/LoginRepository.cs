using API.Context;
using API.Model;
using System;
using System.Linq;

namespace API.Repository
{
    public class LoginRepository
    {
        private MySqlContext _context;

        public LoginRepository(MySqlContext context)
        {
            _context = context;
        }

        public Login Register(Login login)
        {
            var command = _context.Login
                .Any(p => p.Username.Equals(login.Username));

            if(command == true)
            {
                return null;
            }

            login.Id = Guid.NewGuid().ToString();
            _context.Add(login);
            _context.SaveChanges();
            return login;
        }

        public Login Login(string login)
        { 
            var command = _context.Login
                .SingleOrDefault(p => p.Username.Equals(login));

            if(command == null)
            {
                return null;
            }

            return command;
        }
    }
}
