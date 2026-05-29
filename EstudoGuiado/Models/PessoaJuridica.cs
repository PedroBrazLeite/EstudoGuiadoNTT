namespace EstudoGuiado.Models;

public class PessoaJuridica : Pessoa
{
    public string CNPJ { get;}

    public PessoaJuridica(string nome, DateTime dataNascimento, string cpf, string cnpj) : base(nome, dataNascimento, cpf)
    {
        CNPJ = cnpj;
    }
    public override string ToString()
    {
        return base.ToString() + $" | CNPJ: {CNPJ}";
    }
}