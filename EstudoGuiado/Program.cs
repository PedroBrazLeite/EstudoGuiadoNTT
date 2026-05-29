using EstudoGuiado.Models;
using System.Text.RegularExpressions;

const int listarClientes = 1;
const int listarProdutos = 2;
const int cadastrarPf = 3;
const int cadastrarPj = 4;
const int cadastrarProduto = 5;
const int vender = 6;
const int sair = 7;

var pessoas = new List<Pessoa>();
var produtos = new List<Produto>();

int nav = 1;

while ( nav != 0)
{
    int option;
    Console.WriteLine("Escolha sua ação:");
    Console.WriteLine("1) listar Clientes");
    Console.WriteLine("2) Listar Produtos");
    Console.WriteLine("3) Cadastrar Pessoa Fisica");
    Console.WriteLine("4) Cadastrar Pessoa Juridica");
    Console.WriteLine("5) Cadastrar Produto");
    Console.WriteLine("6) Vender Produto");
    Console.WriteLine("7) Sair");
    
    option = int.Parse(Console.ReadLine()!);
    
    switch (option)
    {
        case listarClientes:
        {
            if (pessoas.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                break;
            }
            
            Console.WriteLine("lista de clientes:");
            for (int i = 0; i < pessoas.Count; i++)
            {
                Console.WriteLine($"{i}: {pessoas[i].Nome}");
            }
            break;
        }
        case listarProdutos:
        {
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                break;
            }

            Console.WriteLine("lista de produtos:");
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"{i}: {produtos[i]}");
            }
            break;
        }
        case cadastrarPf:
        {
            string nome = LerNome();

            string cpf = LerCpf();
    
            DateTime dataNasc = LerData();
            
            Console.Write("RG: ");
            string rg = Console.ReadLine()!;
    
            pessoas.Add(new PessoaFisica(nome, dataNasc, cpf, rg));
            Console.WriteLine("Pessoa cadastrada com sucesso!");
            break;
        }
        case cadastrarPj:
        {
            string nome = LerNome();

            string cpf = LerCpf();
    
            DateTime dataNasc = LerData();
            
            string cnpj = LerCnpj();
    
            pessoas.Add(new PessoaJuridica(nome, dataNasc, cpf, cnpj));
            Console.WriteLine("Pessoa cadastrada com sucesso!");
            break;
        }
        case cadastrarProduto:
        {
            string nome = LerNome();
            Console.Write("Preco: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());
            
            Console.Write("Quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());
            
            produtos.Add(new Produto(nome, preco, quantidade));
            Console.WriteLine("Produto cadastrado com sucesso!");
            break;
        }
        case vender:
        {
            if (pessoas.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                break;
            }
    
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                break;
            }
            
            Console.WriteLine("lista de clientes:");
            for (int i = 0; i < pessoas.Count; i++)
            {
                Console.WriteLine($"{i}: {pessoas[i].Nome}");
            }
            Console.Write("Escolha um cliente: ");
            int pessoaId;
            while (!int.TryParse(Console.ReadLine(), out pessoaId) 
                   || pessoaId < 0 
                   || pessoaId >= pessoas.Count)
            {
                Console.Write("Índice inválido, tente novamente: ");
            }
            
            Console.WriteLine("lista de produtos:");
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"{i}: {produtos[i]}");
            }
            Console.Write("Escolha um produto: ");
            int produtoId;
            while (!int.TryParse(Console.ReadLine(), out produtoId) 
                   || produtoId < 0 
                   || produtoId >= produtos.Count)
            {
                Console.Write("Índice inválido, tente novamente: ");
            }
            
            Console.Write("Quantidade: ");
            int produtoQuantidade = Convert.ToInt32(Console.ReadLine());
            
            var venda = new Venda(pessoas[pessoaId], produtos[produtoId], produtoQuantidade);
            venda.GerarNota();

            break;
        }
        case sair:
            Console.WriteLine("Obrigado por usar o sistema!");
            nav = 0;
            break;
    }
}

static string LerNome()
{
    string nome;
    bool invalido;
    do
    {
        Console.Write("Nome: ");
        nome = Console.ReadLine()!;
        
        invalido = nome.Any(c => !char.IsLetter(c) && c != ' ');
        
        if (invalido)
            Console.WriteLine("Nome inválido, use apenas letras.");
            
    } while (invalido);
    
    return nome;
}

static DateTime LerData()
{
    DateTime data;
    Console.Write("Data de nascimento (dd/MM/yyyy): ");
    while (!DateTime.TryParse(Console.ReadLine(), out data))
    {
        Console.Write("Data inválida, tente novamente (dd/MM/yyyy): ");
    }
    return data;
}

static string LerCpf()
{
    string cpf;
    bool invalido;
    do
    {
        Console.Write("CPF: ");
        cpf = Console.ReadLine()!;
        
        string apenasNumeros = Regex.Replace(cpf, @"[^\d]", "");
        
        invalido = apenasNumeros.Length != 11 || new string(apenasNumeros[0], 11) == apenasNumeros;
        
        if (invalido)
            Console.WriteLine("CPF inválido! Tente novamente.");

    } while (invalido);
    
    return cpf; 
}
static string LerCnpj()
{
    string cnpj;
    bool invalido;
    do
    {
        Console.Write("CNPJ: ");
        cnpj = Console.ReadLine()!;
        
        string apenasNumeros = Regex.Replace(cnpj, @"[^\d]", "");
        
        invalido = apenasNumeros.Length != 14;
        
        if (invalido)
            Console.WriteLine("CNPJ inválido! Tente novamente.");

    } while (invalido);
    
    return cnpj; 
}