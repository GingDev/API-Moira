namespace MoiraSoft.ConfigServer
{
    /// <summary>
    /// Permite mapear configuraciones establecidas en el config server.
    /// </summary>
    public class ConfigServerProvider
    {
        /// <summary>
        /// String de conexion a la BD
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
