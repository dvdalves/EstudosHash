using EstudosHash.Hash;

while (true)
{
    Console.Clear();
    Console.WriteLine("Digite o texto que deseja gerar o hash (ou digite 'sair' para encerrar): ");
    var input = Console.ReadLine();

    if (string.IsNullOrEmpty(input) || input.Equals("sair", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Encerrando o programa.");
        return;
    }

    string[] options = { "MD5", "SHA1", "SHA256", "SHA512", "Voltar", "Sair" };
    int currentSelection = 0;

    while (true)
    {
        Console.Clear();
        Console.WriteLine($"Mensagem: {input}");
        Console.WriteLine("Escolha o tipo de hash:");

        for (int i = 0; i < options.Length; i++)
        {
            if (i == currentSelection)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine(options[i]);

            Console.ResetColor();
        }

        var key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                currentSelection = (currentSelection == 0) ? options.Length - 1 : currentSelection - 1;
                break;
            case ConsoleKey.DownArrow:
                currentSelection = (currentSelection == options.Length - 1) ? 0 : currentSelection + 1;
                break;
            case ConsoleKey.Enter:
                if (currentSelection == options.Length - 1)
                {
                    Console.WriteLine("Encerrando o programa.");
                    return;
                }
                else if (currentSelection == options.Length - 2)
                {
                    break;
                }
                else
                {
                    ExecuteOption(currentSelection, input);
                }
                break;
        }

        if (currentSelection == options.Length - 2 && key == ConsoleKey.Enter)
        {
            break;
        }
    }
}

void ExecuteOption(int option, string input)
{
    string? hash = option switch
    {
        0 => Md5.GetHash(input),
        1 => Sha1.GetHash(input),
        2 => Sha256.GetHash(input),
        3 => Sha512.GetHash(input),
        _ => null
    };

    if (hash != null)
    {
        Console.Clear();
        Console.WriteLine($"Mensagem: {input}");
        Console.WriteLine($"Hash resultante: {hash}");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
