using EstudoGuiado.Models;

var pessoas = new List<Pessoa>();
var produtos = new List<Produto>();

int nav = 1;

while ( nav != 0)
{
    int option = 0;
    Console.WriteLine("Escolha sua ação:");
    Console.WriteLine("1) listar Clientes");
    Console.WriteLine("2)Listar Produtos");
    Console.WriteLine("3) Cadastrar Pessoa Fisica");
    Console.WriteLine("4) Cadastrar Pessoa Juridica");
    Console.WriteLine("5) Cadastrar Produto");
    Console.WriteLine("6) Vender Produto");
    Console.WriteLine("7) Sair");
    
    option = int.Parse(Console.ReadLine()!);
    
    switch (option)
    {
        case 1:
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
        case 2:
        {
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                break;
            }

            Console.WriteLine("lista de produtos:");
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"{i}: {produtos[i].Nome} -  {produtos[i].Preco:C} - {produtos[i].Quantidade}");
            }
            break;
        }
        case 3:
        {
            string nome;
            do
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine()!;
                if (nome.Any(c => !char.IsLetter(c) && c != ' '))
                    Console.WriteLine("Nome inválido, use apenas letras.");
            } while (nome.Any(c => !char.IsLetter(c) && c != ' '));

            Console.Write("CPF: ");
            string cpf = Console.ReadLine()!;
    
            Console.Write("Data de nascimento (dd/MM/yyyy): ");
            DateTime dataNasc;
            while (!DateTime.TryParse(Console.ReadLine(), out dataNasc))
            {
                Console.Write("Data inválida, tente novamente (dd/MM/yyyy): ");
            }
            Console.Write("RG: ");
            string rg = Console.ReadLine()!;
    
            pessoas.Add(new PessoaFisica(nome, dataNasc, cpf, rg));
            Console.WriteLine("Pessoa cadastrada com sucesso!");
            break;
        }
        case 4:
        {
            string nome;
            do
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine()!;
                if (nome.Any(c => !char.IsLetter(c) && c != ' '))
                    Console.WriteLine("Nome inválido, use apenas letras.");
            } while (nome.Any(c => !char.IsLetter(c) && c != ' '));

            Console.Write("CPF: ");
            string cpf = Console.ReadLine()!;
    
            Console.Write("Data de nascimento (dd/MM/yyyy): ");
            DateTime dataNasc;
            while (!DateTime.TryParse(Console.ReadLine(), out dataNasc))
            {
                Console.Write("Data inválida, tente novamente (dd/MM/yyyy): ");
            }
            Console.Write("CNPJ: ");
            string cnpj = Console.ReadLine()!;
    
            pessoas.Add(new PessoaJuridica(nome, dataNasc, cpf, cnpj));
            Console.WriteLine("Pessoa cadastrada com sucesso!");
            break;
        }
        case 5:
        {
            string nome;
            do
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine()!;
                if (nome.Any(c => !char.IsLetter(c) && c != ' '))
                    Console.WriteLine("Nome inválido, use apenas letras.");
            } while (nome.Any(c => !char.IsLetter(c) && c != ' '));
            
            Console.Write("Preco: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());
            
            Console.Write("Quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());
            
            produtos.Add(new Produto(nome, preco, quantidade));
            Console.WriteLine("Produto cadastrado com sucesso!");
            break;
        }
        case 6:
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
                Console.WriteLine($"{i}: {produtos[i].Nome} -  {produtos[i].Preco:C} - {produtos[i].Quantidade}");
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
        case 7:
            Console.WriteLine("Obrigado por usar o sistema!");
            nav = 0;
            break;
    }
}