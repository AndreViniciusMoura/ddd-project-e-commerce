using AutoMapper;
using NerdStore.Catalogo.Application.Services.Interfaces;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Catalogo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Services
{
    public class CategoriaAppService : ICategoriaAppService
    {
        #region Propriedades

        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        #endregion

        #region Construtor

        public CategoriaAppService(ICategoriaService categoriaService,
                                 IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        #endregion

        #region Metodos

        public async Task Adicionar(CategoriaViewModel categoriaViewModel)
        {
            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaService.Adicionar(categoria);
        }

        public async Task Atualizar(CategoriaViewModel categoriaViewModel)
        {
            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaService.Atualizar(categoria);
        }

        public async Task<CategoriaViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<CategoriaViewModel>(await _categoriaService.ObterPorId(id));
        }

        public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaService.ObterTodos());
        }

        #endregion
    }
}
