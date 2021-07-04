using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShoping.Models
{
    public interface UnitTestsModel
    {
       public IEnumerable<User> GetAll();
        User Get(int id);
        void Create(User user);
    }
}
