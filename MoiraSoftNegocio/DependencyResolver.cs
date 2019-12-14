using System;

namespace MoiraSoftNegocio
{
    public static class DependencyResolver
    {
        private static IServiceProvider _provider;
        /// <summary>
        /// Proveedor de servicios
        /// </summary>
        public static IServiceProvider ServiceProvider
        {
            get
            {
                return _provider;
            }
            set
            {
                if (_provider == null)
                {
                    _provider = value;
                }
            }
        }
    }
}
