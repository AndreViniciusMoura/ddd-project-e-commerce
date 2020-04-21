using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Catalogo.Domain.Interfaces.Repositories;
using NerdStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Data.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        #region Propriedades

        public readonly CatalogoContext _catalogoContext;
        public IUnitOfWork UnitOfWork => _catalogoContext;

        #endregion

        #region Contrutor

        public CategoriaRepository(CatalogoContext catalogoContext)
        {
            _catalogoContext = catalogoContext;
        }

        #endregion

        #region Metodos

        public void Adicionar(Categoria categoria)
        {
            _catalogoContext.Categorias.Add(categoria);
        }

        public void Atualizar(Categoria categoria)
        {
            _catalogoContext.Categorias.Update(categoria);
        }

        #region Consultas

        public async Task<IEnumerable<Categoria>> ObterTodos()
        {
            return await _catalogoContext.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<Categoria> ObterPorId(Guid id)
        {
            return await _catalogoContext.Categorias.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        #endregion

        public void Dispose()
        {
            _catalogoContext?.Dispose();
        }

        #endregion
    }
}
