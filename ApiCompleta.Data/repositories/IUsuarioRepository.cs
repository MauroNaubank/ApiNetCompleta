using ApiCompleta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompleta.Data.repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsers();
        Task<Usuario> GetDetails(int id);
        Task<bool> InsertarUser(Usuario usuario);
        Task<bool> UpdateUser(Usuario usuario);
        Task<bool> DeleteUser(Usuario usuario);
    }
}
