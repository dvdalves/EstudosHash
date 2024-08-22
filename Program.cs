namespace EstudosHash;

internal class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var sha256 = new Sha256();
        Sha256.GetHash(input);
    }
}
