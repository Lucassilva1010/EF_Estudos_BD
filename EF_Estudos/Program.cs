// See https://aka.ms/new-console-template for more information
using dal.Mysql.Models;
using Modelo;

Console.WriteLine("Hello, World!");

dal.Mysql.Class1 class1 = new dal.Mysql.Class1();
//dal.Sql.Class1 class2 = new dal.Sql.Class1();
dal.Sql.Funcoes funcoes = new dal.Sql.Funcoes();//Foi mudado para chamr a classe funções

//Listar

//funcoes.Listar();
funcoes.ListarDinamico(string.Empty, "Preto");


//Selecionar
        //funcoes.Selecionar(1002);//Lembrar que esse Numero de ID tem que existir na Tabela
    //funcoes.SelecionarLinq(1004);//

//Adicionando no SQL

    //Modelo.Produtoss produto = new Modelo.Produtoss();
    //produto.Nome = "TV";
    //produto.Cor = "Dourada";
    //
    //Estoqueee estoqueee = new Estoqueee();
    //estoqueee.Quantidade = 2;
    //estoqueee.Exemplo = 50;
    //produto.Estoques = estoqueee;//Passando os campos de Esrtoque para produtos vindo do relacionamento

    //funcoes.Adicionar(produto);

//Alterar 
//produto.Id = 8;
//produto.Cor = "Roxo";

//funcoes.Atualizar(produto);


//Alterar 2

//Modelo.Produtoss p = new Modelo.Produtoss();
//p.Id = 5;//Posição do valor a ser alterado
//p.Nome = "Mouse";
//p.Cor = "Verde";
//funcoes.Alterar(p);

//Deletar 01
//Modelo.Produtoss porC = new Modelo.Produtoss();
//porC.Id = 9;//Posição do valor a ser alterado
//funcoes.Deletrar(porC);

//Deletar 02

//funcoes.Remover(9);

Console.ReadKey();