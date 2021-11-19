using Reservas.Models;
using System.Collections.Generic;

namespace Reservas.Interfaces
{
    public interface IPersonal
    {
        IEnumerable<Personal> getLista();
        void createPersonal(Personal personal);
        Personal getPersonal(int? id);
        void updatePersonal(Personal personal);
        void deletePersona(int? id);

    }
}