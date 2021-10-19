using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Game.cs is responsible for logic of game in places like:
 *         Drawing boards
 *         Setting ships position
 *         Round playing
 *         Managing turns etc.
 * Game.cs - Ai vs Ai mode
 */


namespace BattleshipsRecrutation.AppCore.Games
{
    public class Game
    {

        //taking Ai players properties from AiPlayer.cs
        public AiPlayer Player1 { get; set; }
        public AiPlayer Player2 { get; set; }

        //Preparing needed stuff
        public Game()
        {
            Player1 = new AiPlayer("HenricTheBotsKing");
            Player2 = new AiPlayer("StefanTheRealKing");

            Player1.SetShipsPosition();
            Player2.SetShipsPosition();

            Player1.DrawingBoards();
            Player2.DrawingBoards();
        }

        public void PlayRound()
        {
            //Each exchange of shots is called a Round.
            //One round = Player 1 fires a shot, then Player 2 fires a shot.
            var coordinates = Player1.OpenFire();
            var result = Player2.InAirShot(coordinates);
            Player1.InAirShotResult(coordinates, result);

            if (!Player2.Looser) //If player 2 already lost, we can't let them take another turn.
            {
                coordinates = Player2.OpenFire();
                result = Player1.InAirShot(coordinates);
                Player2.InAirShotResult(coordinates, result);
            }
        }

        // Logic - AiPlayer will play until one of them will lose
        public void PlayToEnd()
        {
            while (!Player1.Looser && !Player2.Looser)
            {
                PlayRound();
            }

            Player1.DrawingBoards();
            Player2.DrawingBoards();
            //Loosing condition
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
