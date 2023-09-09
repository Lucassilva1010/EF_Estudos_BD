namespace Modelo
{
    public class Categoria
    {

        public Categoria()
        {
            CategoriaProduto = new HashSet<ProdutoCategoria>();
        }
        public int Id { get; set; }
        public string? Nome { get; set; }

        //Com esse relacionamento, implica entender que 1 Catwgoria Pode possuir mais de 1 Produto
        public virtual ICollection<ProdutoCategoria> CategoriaProduto { get; set;}  //Cria uma relação de um para muito
    }
}