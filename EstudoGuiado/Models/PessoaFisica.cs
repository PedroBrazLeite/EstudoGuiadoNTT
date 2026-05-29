namespace EstudoGuiado.Models;

public class PessoaFisica : Pessoa
{
    public string RG { get;}
    
    public PessoaFisica(string nome, DateTime dataNascimento, string cpf, string rg) : base(nome, dataNascimento, cpf)
    {
        RG = rg;
    }
    public override string ToString()
    {
        return base.ToString() + $" | RG: {RG}";
    }
}