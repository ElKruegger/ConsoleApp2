using ConsoleApp2;

Console.WriteLine("Deseja criar uma conta no nosso banco? S/N");
var Sn = Console.ReadLine();
Sn = Sn.Trim().ToLower();

if (Sn == "n")
{
    return;
}
else if (Sn == "s")
{
    // criar o objeto aqui : 

    var conta = new Contas();

    Console.WriteLine("Informe o seu nome : ");
    conta.name = Console.ReadLine();

    Console.WriteLine("Informe a sua idade :");
    conta.age = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Digite o saldo inicial inserido na criação da sua conta : ");
    conta.saldo = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Informe a sua localidade da sua residencia para o banco de dados :");
    conta.localidade = Console.ReadLine();

    Console.WriteLine("Por ultimo, informe o seu Cpf para a criação da sua conta : ");
    conta.cpf = Convert.ToDouble(Console.ReadLine());


    Console.WriteLine(" ______________________________ ");
    Console.WriteLine("Suas informações inseridas são estas? Verifique se digitou corretamente : ");
    Console.WriteLine($"Nome do usuário : {conta.name}");
    Console.WriteLine($"Idade do usuário : {conta.age}");
    Console.WriteLine($"Saldo inicial do cliente : {conta.saldo}");
    Console.WriteLine($"Residencia do Cliente : {conta.localidade}");
    Console.WriteLine($"Seu CPF : {conta.cpf}");
    Console.WriteLine("______________________________");


    // Adicionando no banco 

    var id = PostGreesql.inserirObjeto(conta);
    conta.id = id;

    Console.WriteLine("Deseja criar algo? s/n");
    var Simnao = Console.ReadLine().Trim().ToLower() == "s" ? true : false;
    while(Simnao)
    {
        Console.WriteLine("Qual sua proxima Ação? d/e");
        var respacao = Console.ReadLine();
        if (respacao.Trim().ToLower() == "e")
        {
            Console.WriteLine("Digite um valor para extrair");
            var price = Convert.ToDouble(Console.ReadLine());
            if (conta.saldo > price)
            {
                conta.payment(price);
            }
            Console.WriteLine(" ______________________________ ");
            Console.WriteLine("O valor foi extraido com sucesso, verifique suas informações : ");
            Console.WriteLine($"Nome do usuário : {conta.name}");
            Console.WriteLine($"Idade do usuário : {conta.age}");
            Console.WriteLine($"Saldo inicial do cliente : {conta.saldo}");
            Console.WriteLine($"Residencia do Cliente : {conta.localidade}");
            Console.WriteLine($"Seu CPF : {conta.cpf}");
            Console.WriteLine("______________________________");
            PostGreesql.UpdateObj(conta);
        }
        else
        {
            Console.WriteLine("Digite um valor para adicionar a sua conta : ");
            Console.WriteLine("O valor foi inserido com sucesso, verifique suas informações : ");
            Console.WriteLine($"Nome do usuário : {conta.name}");
            Console.WriteLine($"Idade do usuário : {conta.age}");
            Console.WriteLine($"Saldo inicial do cliente : {conta.saldo}");
            Console.WriteLine($"Residencia do Cliente : {conta.localidade}");
            Console.WriteLine($"Seu CPF : {conta.cpf}");
            Console.WriteLine("______________________________");
            PostGreesql.UpdateObj(conta);
        }
        Console.WriteLine("Deseja fazer algo mais? s/n");
         Simnao = Console.ReadLine().Trim().ToLower() == "s" ? true : false;

    }
    Console.ReadKey();


}
else
{
    var list = PostGreesql.ListAccounts();
    Console.WriteLine("Listagem de contas :");
    foreach (var item in list)
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Id: " + item.id);
        Console.WriteLine("Nome: " + item.name);
        Console.WriteLine("Idade: " + item.age);
        Console.WriteLine("Extrato: " + item.saldo);
        Console.WriteLine("Extrato: " + item.localidade);
        Console.WriteLine("Extrato: " + item.cpf);
        Console.WriteLine("--------------------------------");
    }
}