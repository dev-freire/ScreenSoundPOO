using ScreenSound;
using ScreenSound.Menus;
using ScreenSound.Models;
using OpenAI_API;

// var client = new OpenAIAPI();
// var chat = client.Chat.CreateConversation();
// chat.AppendSystemMessage("Resuma a banda Defones em 1 parágrafo. Adote um estilo informal.");

// string resposta = await chat.GetResponseFromChatbotAsync();
// System.Console.WriteLine(resposta);


Banda ira = new("Ira");
ira.AdicionarNota(new Avaliacao(8));
ira.AdicionarNota(new Avaliacao(6));

Banda deftones = new("Deftones");
deftones.AdicionarNota(new Avaliacao(10));
deftones.AdicionarNota(new Avaliacao(8));

//Usando o Dicionário para as Bandas
Dictionary<string, Banda> bandasRegistradas = new();
bandasRegistradas.Add(ira.Nome, ira);
bandasRegistradas.Add(deftones.Nome, deftones);

//Dicionário para as classes Menu
Dictionary<int, Menu> opcoesDoMenu = new();
opcoesDoMenu.Add(1, new MenuRegistrarBanda());
opcoesDoMenu.Add(2, new MenuRegistrarAlbum());
opcoesDoMenu.Add(3, new MenuMostrarBandasRegistradas());
opcoesDoMenu.Add(4, new MenuAvaliarBanda());
opcoesDoMenu.Add(5, new MenuAvaliarAlbum());
opcoesDoMenu.Add(6, new MenuExibirDetalhes());
opcoesDoMenu.Add(0, new MenuSair());

ExibirOpcoesDoMenu();

void ExibirOpcoesDoMenu()
{
    Menu.ExibirLogo();

    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para avaliar um álbum");
    Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite 0 para sair");
    
    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoesDoMenu.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuSerExibido = opcoesDoMenu[opcaoEscolhidaNumerica];
        menuSerExibido.Executar(bandasRegistradas);
        
        if (opcaoEscolhidaNumerica > 0)
        {
            ExibirOpcoesDoMenu();
        }
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }
}
