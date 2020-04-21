using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Catalogo.Domain.Interfaces.Repositories;
using NerdStore.Catalogo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Services
{
    class CategoriaService : ICategoriaService, IDisposable
    {
        #region Propriedades

        private readonly ICategoriaRepository _categoriaRepository;

        #endregion

        #region Contrutor

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        #endregion

        #region Metodos

        public async Task<Categoria> ObterPorId(Guid id)
        {
            return await _categoriaRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Categoria>> ObterTodos()
        {
            return await _categoriaRepository.ObterTodos();
        }

        public async Task Adicionar(Categoria categoria)
        {
            _categoriaRepository.Adicionar(categoria);

            await _categoriaRepository.UnitOfWork.Commit();
        }

        public async Task Atualizar(Categoria categoria)
        {
            _categoriaRepository.Atualizar(categoria);

            await _categoriaRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }

        #endregion
    }
}