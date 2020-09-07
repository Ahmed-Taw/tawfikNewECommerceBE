using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TawfikStoreBackEnd.Entities.Entities;

namespace TawfikStoreBackEnd.DAL.Infra.IRepositories
{
    interface IUserRepository
    {
        User getUser(int id);
        IEnumerable<User> getUsers();

        User getUser(string email);
    }
}
