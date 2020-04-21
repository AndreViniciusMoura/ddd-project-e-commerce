using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Catalogo.Application.Services.Interfaces;
using NerdStore.Catalogo.Data;
using NerdStore.Catalogo.Data.Repository;
using NerdStore.Catalogo.Domain.Events;
using NerdStore.Catalogo.Domain.Interfaces.Repositories;
using NerdStore.Catalogo.Domain.Interfaces.Services;
using NerdStore.Catalogo.Domain.Services;
using NerdStore.Core.bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Domain Bus (Mediator)

            services.AddScoped<IMediatrHandler, MediatrHandler>();

            #endregion

            #region Catalogo

            #region Application Services

            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<ICategoriaAppService, CategoriaAppService>();

            #endregion

            #region Domain Services

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IEstoqueService, EstoqueService>();

            #endregion

            #region Context

            services.AddScoped<CatalogoContext>();

            #endregion

            #region Repository

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            #endregion

            #region Events

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

            #endregion


            #endregion

        }
    }
}
