namespace EstudoGuiado.Models;

public class Produto
{
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public int Quantidade { get;  private set; }

    public Produto(string nome, decimal preco, int quantidade)
    {
        Nome = nome;
        if (preco > 0 && quantidade > 0)
        {
            Preco = preco;
            Quantidade = quantidade;
        }
        else
        {
            throw new ArgumentException("Escolha um valor e/ou quantidade valido");
        }
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Preco: {Preco}, Quantidade: {Quantidade}";
    }

   public void Vender( int quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentException("Quantidade deve ser maior que 0.");
        }

        if (quantidade > Quantidade)
        {
            throw new ArgumentException("Estoque insuficiente.");
        }
        Quantidade -= quantidade;
    }
}