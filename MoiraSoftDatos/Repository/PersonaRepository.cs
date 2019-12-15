using MoiraSoftDatos.Entities;
using MoiraSoftDatos.IRepository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MoiraSoftDatos.Repository
{
    public class PersonaRepository : IPersonaRepository
    {

        public async Task<List<CargoEntity>> GetCargos(string connection)
        {
            List<CargoEntity> collDatos = new List<CargoEntity>();
            CargoEntity datos;

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"select * from bd_moira.cargo ";
                    cmd.CommandType = CommandType.Text;

                    await con.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            datos = new CargoEntity
                            {
                                CargoId = Convert.ToInt32(reader["INT_PK_CARGO_ID"].ToString()),
                                Descripcion = reader["VC_DESCRIPCION"].ToString(),
                                Estado = reader["BI_ESTADO"].ToString() == "1" ? true : false
                            };

                            collDatos.Add(datos);
                        }
                    }
                }
            }

            return collDatos;
        }

        public async Task<PersonaEntity> CrearPersona(PersonaEntity persona, string connection)
        {
            PersonaEntity datos = new PersonaEntity
            {
                PersonaId = await GetMaxId(connection),
                LoginId = persona.LoginId,
                PerfilId = persona.PerfilId,
                Rut = persona.Rut,
                Nombres = persona.Nombres,
                ApellidoPaterno = persona.ApellidoPaterno,
                ApellidoMaterno = persona.ApellidoMaterno
            };

            //Validacion de Usuario Existente
            if (await GetRutInUse(persona.Rut, connection) != 0)
            {
                throw new Exception("La persona ya existe en el sistema.");
            }

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO bd_moira.persona (INT_PK_PERSONA_ID,INT_FK_LOGIN_ID,INT_FK_PERFIL_ID,INT_RUT,VC_NOMBRES,VC_APELLIDO_PATERNO,VC_APELLIDO_MATERNO) VALUES ({datos.PersonaId},{datos.LoginId},{datos.PerfilId},{datos.Rut},'{datos.Nombres}','{datos.ApellidoPaterno}','{datos.ApellidoMaterno}')";
                    cmd.CommandType = CommandType.Text;

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await con.CloseAsync();
                }
            }

            return datos;
        }

        public async Task<List<PersonaInfoEntity>> GetInfoPersonaTurno(string connection)
        {
            List<PersonaInfoEntity> collDatos = new List<PersonaInfoEntity>();
            PersonaInfoEntity datos;

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"select p.INT_PK_PERSONA_ID AS PersonaID,p.VC_NOMBRES AS Nombre,p.VC_APELLIDO_PATERNO AS Apellido,c.VC_DESCRIPCION AS Cargo,rt.INT_PK_REGISTRO_ID AS TurnoID,t.VC_DESCRIPCION AS Turno,rt.DT_FECHA_INICIO_REGISTRO AS InicioTurno,rt.DT_FECHA_FIN_REGISTRO AS FinTurno from bd_moira.persona p Inner join bd_moira.persona_trabajo pt on p.INT_PK_PERSONA_ID = pt.INT_FK_INT_PERSONA_ID Inner join bd_moira.cargo c on c.INT_PK_CARGO_ID = pt.INT_FK_CARGO_ID inner join bd_moira.registro_turno rt on rt.INT_FK_PERSONA_TRABAJO_ID = pt.INT_PK_PERSONA_TRABAJO_ID Inner join bd_moira.turno t on t.INT_PK_TURNO_ID = rt.FK_INT_TURNO_ID order by rt.INT_PK_REGISTRO_ID desc LIMIT 10 OFFSET 0 ";
                    cmd.CommandType = CommandType.Text;

                    await con.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            datos = new PersonaInfoEntity
                            {
                                PersonaId = Convert.ToInt32(reader["PersonaID"].ToString()),
                                TurnoId = Convert.ToInt32(reader["TurnoID"].ToString()),
                                Apellido = reader["Apellido"].ToString(),
                                Cargo = reader["Cargo"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Turno = reader["Turno"].ToString(),
                                FechaFinTurno = Convert.ToDateTime(reader["FinTurno"].ToString()),
                                FechaInicioTurno = Convert.ToDateTime(reader["InicioTurno"].ToString())
                            };

                            collDatos.Add(datos);
                        }
                    }
                }
            }

            return collDatos;

        }

        private async Task<int> GetMaxId(string connection)
        {
            int maximoId = 0;
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"select ifnull(MAX(INT_PK_PERSONA_ID),0) as Maximo from bd_moira.persona";
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
        private async Task<int> GetRutInUse(int rut, string connection)
        {
            int maximoId = 0;
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"select Count(INT_PK_PERSONA_ID) as Cantidad from bd_moira.persona where INT_RUT = '{rut}' ";
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
