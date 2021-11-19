using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Reservas.Models;

namespace Reservas.Interface
{
    public interface InterfaceUser
    {
        Usuario FindUserByCredentials(string username, string password);
        Usuario getUserId(Claim claim);
    }
}
