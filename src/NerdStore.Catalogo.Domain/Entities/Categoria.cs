using NerdStore.Core.DomainObjects;
using System.Collections.Generic;

namespace NerdStore.Catalogo.Domain.Entities
{
    public class Categoria : Entity
    {
        #region Propriedades

        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        //EF Relation
        public ICollection<Produto> Produtos { get; set; }

        #endregion

        #region Construtor

        public Categoria()
        {
            Produtos = new List<Produto>();
        }

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
            Produtos = new List<Produto>();

            Validar();
        }

        #endregion

        #region Comportamento

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0");
        }

        #endregion
    }
}
