using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Reservas.Interface;
using Reservas.Models;
using Reservas.Models.Map;

namespace Reservas.Service
{
    public class RepositorioUser : InterfaceUser
    {

        private readonly ReservasDbContext mContext;
        public RepositorioUser(ReservasDbContext mContext)
        {
            this.mContext = mContext;
        }

        public Usuario FindUserByCredentials(string username, string password)
        {
            return mContext.Usuarios.FirstOrDefault(o => o.Username == username && o.Password == password);
        }

        public Usuario getUserId(Claim claim)
        {
            return mContext.Usuarios.FirstOrDefault(o => o.Username == claim.Value);
        }
    }
}
