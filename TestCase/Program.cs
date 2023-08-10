//====================================To do list=====================================================
// 1st - between each turn say whos turn it currently is
// 2nd - input handling (optionally return it to redo the specific x or y input that needs redoing)
// 3rd - loop it so that the players can play again if they want to
// 4th - split out the code into different classes
// 5th - (optional) redo check win method to see if it can be shorter
// 6th - post code to github get code reviewed by Avtar.

using TestCase.Managers;

namespace Tut1
{
    public class Program
    {
        static void Main()
        {
            new GameManager().PlayGame();
        }
    }
}