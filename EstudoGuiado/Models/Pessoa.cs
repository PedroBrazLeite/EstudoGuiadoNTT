namespace EstudoGuiado.Models;

public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }

    public Pessoa(string nome, DateTime dataNascimento, string cpf)
    {
        Nome = nome;

        if (dataNascimento < DateTime.Now)
        {
            DataNascimento = dataNascimento;
        }
        else
        {
            throw new ArgumentException("data de nascimento não pode ser no futuro");
        }
        
        Cpf = cpf;
    }
   
    public override string ToString()
    {
        return $"Nome: {Nome} | CPF: {Cpf} | Nascimento: {DataNascimento:dd/MM/yyyy}";
    }
}