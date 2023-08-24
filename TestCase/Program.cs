//====================================To do list=====================================================
// 1st - between each turn say whos turn it currently is - COMPLETED
// 2nd - input handling (optionally return it to redo the specific x or y input that needs redoing) - COMPLETED
// 3rd - loop it so that the players can play again if they want to - COMPLETED
// 4th - split out the code into different classes
// 5th - (optional) redo check win method to see if it can be shorter
// 6th - make the game look nicer by putting Console.WriteLines between each print
// 7th - post code to github get code reviewed by Avtar.

using TestCase.Managers;

namespace Tut1
{
    public class Program
    {
        static void Main(string[] args)
        {
            new GameManager().StartGame();
        }

        

    }
}