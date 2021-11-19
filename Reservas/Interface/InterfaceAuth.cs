using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Reservas.Interface
{
    public interface InterfaceAuth
    {
        void Login(ClaimsPrincipal claimsPrincipal);

        void Logout();
        Claim LoggedUser();
    }
}
