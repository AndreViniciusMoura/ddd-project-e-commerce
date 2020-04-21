using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Entities;

namespace NerdStore.Catalogo.Application.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        #region Propriedades

        #endregion

        #region Contrutor

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));

            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(p =>
                    new Produto(p.Nome, p.Descricao, p.Ativo,
                                p.Valor, p.CategoriaId, p.DataCadastro,
                                p.Imagem, new Dimensoes(p.Altura, p.Largura, p.Profundidade)));
        }

        #endregion
    }
}
