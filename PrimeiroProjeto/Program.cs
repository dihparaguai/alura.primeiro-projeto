// Screen Sound
string msgBoasVindas = "Bem vindos ao Screen Sound";
// List<string> listaDasBandas = new List<string> {"Calypso", "Rouge"}; // lista ligada nativa

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>> ();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6});
bandasRegistradas.Add("Beatles", new List<int> ());
void ExibirLogo()
{ 
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    ExibirTitulo(msgBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as banda");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a media de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break; // sem usar o break no switch
        case 2: MostrarBndasRegritadas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: ExibirMediaBanda();
            break;
        case -1: Console.WriteLine("Tchau Tchau :)");
            break;
        default: Console.WriteLine("Opção Invalida");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();;
    ExibirTitulo("Registro das Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomedaBanda = Console.ReadLine()!; // o ! impede valores de entrada nulos
    bandasRegistradas.Add(nomedaBanda, new List<int>()); // registra apenas a banda, e instacia o espaço para da nota
    Console.WriteLine($"A banda \"{nomedaBanda}\" foi registrada com sucesso!!!");
    Thread.Sleep(4000);
    Console.Clear(); // limpa o console
    ExibirOpcoesDoMenu();
}

void MostrarBndasRegritadas()
{
    Console.Clear();
    ExibirTitulo("Exibindo as Bandas Registradas");
/*
    for (int i = 0; i < listaDasBandas.Count; i++)
    {
        Console.WriteLine($"Banda {i + 1}: {listaDasBandas[i]}");
    }
*/
    // "para cada 'elemento' em 'todosElementos' faça...:
    foreach (string banda in bandasRegistradas.Keys) // no dicionario, o foreach percorre só os rotulos
    {
        Console.WriteLine(banda);
    }
    Console.WriteLine("\nPessione qualquer tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTitulo(string titulo)
{
    int qtdLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qtdLetras, '*'); // coloca a quantidade de letras a esquerda
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    ExibirTitulo("Avaliar Banda");
    Console.Clear();
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Que nota a banda \"{nomeDaBanda}\" merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota \"{nota}\" foi registrada com sucesso!!!");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else
    {
        Console.WriteLine($"\nA banda \"{nomeDaBanda}\" não foi encontrada!!!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void ExibirMediaBanda () 
{
    ExibirTitulo("Media da Banda");
    Console.Clear();
    Console.Write("Digite o nome da banda que deseja ver a media: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List <int> notaMedia = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA Banda \"{nomeDaBanda}\" tem media \"{notaMedia.Average()}\" de avaliação!!!");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda \"{nomeDaBanda}\" não foi encontrada!!!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

ExibirLogo();
ExibirOpcoesDoMenu();

