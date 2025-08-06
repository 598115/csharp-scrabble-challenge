

using csharp_scrabble_challenge.Main;

Console.WriteLine("Welcome to the Scrabble scorer. Insert a word to be scored: ");
string? word = Console.ReadLine();
if (word == null)
{
    word = "";
}
Scrabble game = new Scrabble(word);

bool run = true;
while (run)
{
    int score = game.score();
    Console.WriteLine($"The score was: {score}\nInsert a new word or x to quit: ");
    word = Console.ReadLine();
    if (word == null)
    {
        word = "";
    }
    if (word.Equals("x") || word.Equals("X")) { break; }
    game.Word = word;
}
