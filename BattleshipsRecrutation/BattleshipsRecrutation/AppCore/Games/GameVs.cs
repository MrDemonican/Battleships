using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Not in use yet 
 * Human vs computer mode
 * 
 * In future AiPlayer logic will stay same, but HumanPlayer will be able to play as he wants to
 * 
 */


namespace BattleshipsRecrutation.AppCore.Games

{
    class GameVs
    {
        public HumanPlayer Player1 { get; set; }
        public AiPlayer Player2 { get; set; }

        public GameVs()
        {
            Console.WriteLine("Enter your nickname");
            string name = Console.ReadLine();
            Player1 = new HumanPlayer(name);
            Player2 = new AiPlayer("Vince");

            Player1.SetShipsPosition();
            Player2.SetShipsPosition();

            Player1.DrawingBoards();
            Player2.DrawingBoards();
        }

        //Tu szczylają
        public void PlayRound()
        {
            //Each exchange of shots is called a Round.
            //One round = Player 1 fires a shot, then Player 2 fires a shot.
            var coordinates = Player1.HumanOpenFire();
            var result = Player2.InAirShot(coordinates);
            Player1.InAirShotResult(coordinates, result);

            if (!Player2.Looser) //If player 2 already lost, we can't let them take another turn.
            {
                coordinates = Player2.OpenFire();
                result = Player1.InAirShot(coordinates);
                Player2.InAirShotResult(coordinates, result);
            }
        }

        public void PlayToEnd()
        {
            while (!Player1.Looser && !Player2.Looser)
            {
                PlayRound();
            }

            Player1.DrawingBoards();
            Player2.DrawingBoards();

            if (Player1.Looser)
            {
                Console.WriteLine(Player2.Name + " has won the game!");
            }
            else if (Player2.Looser)
            {
                Console.WriteLine(Player1.Name + " has won the game!");
            }
        }
    }
}