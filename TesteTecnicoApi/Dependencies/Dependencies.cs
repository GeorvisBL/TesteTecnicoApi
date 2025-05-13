using Microsoft.EntityFrameworkCore;
using TesteTecnicoApi.Context;
using TesteTecnicoApi.Repositories.Interfaces;
using TesteTecnicoApi.Repositories.Repository;
using TesteTecnicoApi.Services.Interfaces;
using TesteTecnicoApi.Services.Service;

namespace TesteTecnicoApi.Dependencies
{
    public static class Dependencies
    {
        public static void InjecaoDeDependencias(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DBTesteTecnico"));
            });


            #region //Services

            services.AddScoped<IContratoServices, ContratoServices>();
            services.AddScoped<IFaturaServices, FaturaServices>();
            services.AddScoped<IFaturaStatusServices, FaturaStatusServices>();
            services.AddScoped<IOperadoraServices, OperadoraServices>();
            services.AddScoped<IPlanoServices, PlanoServices>();
            services.AddScoped<ITipoServicoServices, TipoServicoServices>();

            #endregion


            #region //Repositories

            services.AddScoped<IContratoRepository, ContratoRepository>();
            services.AddScoped<IFaturaRepository, FaturaRepository>();
            services.AddScoped<IFaturaStatusRepository, FaturaStatusRepository>();
            services.AddScoped<IOperadoraRepository, OperadoraRepository>();
            services.AddScoped<IPlanoRepository, PlanoRepository>();
            services.AddScoped<ITipoServicoRepository, TipoServicoRepository>();

            #endregion


        }
    }
}
