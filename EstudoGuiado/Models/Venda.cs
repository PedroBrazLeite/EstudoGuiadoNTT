namespace EstudoGuiado.Models;

public class Venda
{
    public Pessoa Comprador { get;}
    public Produto Produto { get;}
    public int Quantidade { get;}
    public DateTime DataVenda { get; private set; }

    public Venda(Pessoa comprador, Produto produto, int quantidade)
    {
        Comprador = comprador;
        Produto = produto;
        Quantidade = quantidade;
        DataVenda = DateTime.Now;
        produto.Vender(quantidade);
    }

    public void GerarNota()
    {
        Console.WriteLine($"Comprador: {Comprador.Nome}");
        Console.WriteLine($"Produto: {Produto.Nome}");
        Console.WriteLine($"Quantidade: {Quantidade}");
        Console.WriteLine($"Preco: {Produto.Preco * Quantidade:C}");    
    }
}