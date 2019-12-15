using MoiraSoftDatos.Entities;
using MoiraSoftDatos.IRepository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;

namespace MoiraSoftDatos.Repository
{
    public class TurnoRepository : ITurnoRepository
    {
        public async Task<List<InfoTurnoEntity>> GetInfoTurno(string connection)
        {
            List<InfoTurnoEntity> collDatos = new List<InfoTurnoEntity>();
            InfoTurnoEntity datos;
            var fechaActual = DateTime.Now.ToString("yyyyMMdd");
            var fechaInicio = fechaActual.Substring(0, 6) + "01";
            var fechaFin = DateTime.ParseExact(fechaInicio, "yyyyMMdd", CultureInfo.InvariantCulture).AddMonths(1).AddDays(-1).ToString("yyyyMMdd");

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"select 	p.INT_PK_PERSONA_ID AS PersonaID,rt.INT_PK_REGISTRO_ID AS TurnoID,p.VC_NOMBRES AS Nombre,p.VC_APELLIDO_PATERNO AS Apellido,rt.DT_FECHA_INICIO_REGISTRO AS InicioTurno,rt.DT_FECHA_FIN_REGISTRO AS FinTurno from bd_moira.persona p Inner join bd_moira.persona_trabajo pt on p.INT_PK_PERSONA_ID = pt.INT_FK_INT_PERSONA_ID inner join bd_moira.registro_turno rt on rt.INT_FK_PERSONA_TRABAJO_ID = pt.INT_PK_PERSONA_TRABAJO_ID Inner join bd_moira.tipo_registro tp on tp.INT_PK_TIPO_REGISTRO_ID = rt.FK_INT_TIPO_REGISTRO Where rt.FK_INT_TIPO_REGISTRO in (1) and rt.DT_FECHA_INICIO_REGISTRO >= '{fechaInicio}' and rt.DT_FECHA_FIN_REGISTRO <= '{fechaFin}' order by rt.INT_PK_REGISTRO_ID desc LIMIT 10 OFFSET 0";
                    cmd.CommandType = CommandType.Text;

                    await con.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            datos = new InfoTurnoEntity
                            {
                                TurnoId = Convert.ToInt32(reader["PersonaID"].ToString()),
                                PersonaId = Convert.ToInt32(reader["TurnoID"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                FechaInicioTurno = Convert.ToDateTime(reader["InicioTurno"].ToString()),
                                FechaTerminoTurno = Convert.ToDateTime(reader["FinTurno"].ToString())
                            };

                            collDatos.Add(datos);
                        }
                    }
                }
            }

            return collDatos;
        }
    }
}
