using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservas.Models;

namespace Reservas.Interface
{
    public interface ICategoria
    {
        IEnumerable<CategoriaPlato> getLista();
        void createCategoriaPlato(CategoriaPlato categoriaPlato);
        CategoriaPlato getCategoria(int? id);
        void updateCategoria(CategoriaPlato categoriaPlato);
        void deleteCategoria(int? id);
    }
}
