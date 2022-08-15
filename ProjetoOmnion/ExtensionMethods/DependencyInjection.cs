using Domain.Clientes;
using Domain.Contas;
using Domain.Enderecos;
using Domain.Telefones;
using Repositorio;
using Repositorio.Repositorio;
using Servicos;

namespace ProjetoOmnion.ExtensionMethods
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectDependecies(this IServiceCollection services)
        {
            //Services
            services.AddTransient<IClienteServico, ClienteServico>();
            services.AddTransient<IContaServico, ContaServico>();
            services.AddTransient<ITelefoneServico, TelefoneServico>();
            services.AddTransient<IEnderecoServico, EnderecoServico>();


            //Repositories
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IContaRepositorio, ContaRepositorio>();
            services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
            services.AddScoped<ITelefoneRepositorio, TelefoneRepositorio>();

            return services;
        }
    }
}
