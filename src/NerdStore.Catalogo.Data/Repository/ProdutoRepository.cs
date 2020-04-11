﻿using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Catalogo.Domain.Interfaces.Repositories;
using NerdStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        #region Propriedades

        public readonly CatalogoContext _catalogoContext;
        public IUnitOfWork UnitOfWork => _catalogoContext;

        #endregion

        #region Contrutor

        public ProdutoRepository(CatalogoContext catalogoContext)
        {
            _catalogoContext = catalogoContext;
        }

        #endregion

        #region Metodos

        #region Consultas

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _catalogoContext.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _catalogoContext.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
            return await _catalogoContext.Produtos.AsNoTracking().Include(p => p.Categoria).Where(c => c.Categoria.Codigo == codigo).ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _catalogoContext.Categorias.AsNoTracking().ToListAsync();
        }

        #endregion

        #region Produto

        public void Adicionar(Produto produto)
        {
            _catalogoContext.Produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            _catalogoContext.Produtos.Update(produto);
        }

        #endregion

        #region Categoria

        public void Adicionar(Categoria categoria)
        {
            _catalogoContext.Categorias.Add(categoria);
        }

        public void Atualizar(Categoria categoria)
        {
            _catalogoContext.Categorias.Update(categoria);
        }

        public void Dispose()
        {
            _catalogoContext?.Dispose();
        }

        #endregion

        #endregion
    }
}
