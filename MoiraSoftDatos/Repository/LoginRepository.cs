using MoiraSoftDatos.Entities;
using MoiraSoftDatos.IRepository;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace MoiraSoftDatos.Repository
{
    public class LoginRepository : ILoginRepository
    {
        public async Task<LoginEntity> GetLogin(string user, string pass, string connection)
        {
            LoginEntity datos = new LoginEntity();

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"select * from bd_moira.login where VC_USUARIO = '{user}' and VC_PASSWORD = '{pass}'";
                    cmd.CommandType = CommandType.Text;

                    await con.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            datos = new LoginEntity
                            {
                                LoginId = Convert.ToInt32(reader["INT_PK_LOGIN_ID"].ToString()),
                                Usuario = reader["VC_USUARIO"].ToString(),
                                Password = reader["VC_PASSWORD"].ToString(),
                                Estado = reader["BI_ESTADO"].ToString() == "1" ? true : false
                            };
                        }
                    }
                }
            }

            return datos;
        }

        public async Task<LoginEntity> CreateLogin(LoginEntity login, string connection)
        {
            LoginEntity datos = new LoginEntity
            {
                LoginId = await GetMaxId(connection),
                Usuario = login.Usuario,
                Password = login.Password,
                Estado = login.Estado
            };

            //Validacion de Usuario Existente
            if (await GetUserNameInUse(login.Usuario, connection) != 0)
            {
                throw new Exception("El usuario ingresado, ya existe en el sistema.");
            }

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO bd_moira.login (INT_PK_LOGIN_ID,VC_USUARIO,VC_PASSWORD,BI_ESTADO) VALUES ({datos.LoginId},'{datos.Usuario}','{datos.Password}',{datos.Estado})";
                    cmd.CommandType = CommandType.Text;

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await con.CloseAsync();
                }
            }

            return datos;
        }

        private async Task<int> GetMaxId(string connection)
        {
            int maximoId = 0;
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"select ifnull(MAX(int_pk_login_id),0) as Maximo from bd_moira.login";
                    cmd.CommandType = CommandType.Text;

                    await con.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            maximoId = Convert.ToInt32(reader["Maximo"].ToString());
                        }
                    }
                }
            }
            return maximoId + 1;
        }

        private async Task<int> GetUserNameInUse(string user, string connection)
        {
            int maximoId = 0;
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"select Count(int_pk_login_id) as Cantidad from bd_moira.login where VC_USUARIO = '{user}' ";
                    cmd.CommandType = CommandType.Text;

                    await con.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            maximoId = Convert.ToInt32(reader["Cantidad"].ToString());
                        }
                    }
                }
            }
            return maximoId;
        }
    }
}
