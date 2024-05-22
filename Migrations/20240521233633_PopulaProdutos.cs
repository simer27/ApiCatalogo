using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into produtos(Nome, Descricao, Preco, imageUrl, Estoque, DataCadastro, CategoriaId) " +
                "Values('Suco de Laranja','Suco de Laranja 500ml',7.45,'sucolaranja.jpg',10,now(),1)");
            mb.Sql("Insert into produtos(Nome, Descricao, Preco, imageUrl, Estoque, DataCadastro, CategoriaId) " +
                "Values('Lanche de Atum','Lanche de Atum com Maionese',7.99,'lancheatum.jpg',10,now(),2)");
            mb.Sql("Insert into produtos(Nome, Descricao, Preco, imageUrl, Estoque, DataCadastro, CategoriaId) " +
                "Values('Pudim 100g','Pudim de leite condensado 100g',6.75,'pudim.jpg',20,now(),3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
