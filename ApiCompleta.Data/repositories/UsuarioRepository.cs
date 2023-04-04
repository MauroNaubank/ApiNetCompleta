using ApiCompleta.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompleta.Data.repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MySqlConfiguration _connectionString;

        public UsuarioRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteUser(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM usuario WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new {Id = usuario.Id});
            return result > 0;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsers()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM usuario";
            //dapper
            return await db.QueryAsync<Usuario>(sql, new { });
        }

        public async Task<Usuario> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM usuario WHERE id= @Id";
            //dapper
            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }

        public async Task<bool> InsertarUser(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO usuario(nombre, apellido, telefono)
                        VALUES(@Nombre, @Apellido, @Telefono)";
            //dapper
            var result = await db.ExecuteAsync(sql, new { usuario.Id, usuario.Nombre, usuario.Apellido, usuario.Telefono });
            return result > 0;
        }

        public async Task<bool> UpdateUser(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @"UPDATE usuario
                        SET nombre = @Nombre,
                            apellido = @Apellido,
                            telefono = @Telefono
                        Where id = @Id";
            //dapper
            var result = await db.ExecuteAsync(sql, new { usuario.Id, usuario.Nombre, usuario.Apellido, usuario.Telefono });
            return result > 0;
        }
    }
}
