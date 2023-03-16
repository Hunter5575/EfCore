using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Database;

namespace WpfApp3.Core
{
    internal class AuthClass
    {
        public static User user;
        public static bool Auth(string login, string pass)
        {
            user = EfModel.Init().Users.FirstOrDefault(u => u.Login == login && u.Pass == pass);
            return user != null;
        }

    }
}
