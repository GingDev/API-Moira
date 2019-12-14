using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MoiraSoftNegocio
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConnectionServicesOption
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            //return string.Empty;
            return DependencyResolver.ServiceProvider.GetService<IOptions<ConnectionStringOption>>().Value.ConnectionString;
        }
    }
}
