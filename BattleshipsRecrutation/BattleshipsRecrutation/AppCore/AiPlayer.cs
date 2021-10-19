using BattleshipsRecrutation.Enlargements;
using BattleshipsRecrutation.AppCore.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /*
     * File contains AiPlayer class and a buch of methods that are responsible for AiPlayer logic
     * You can find there why Ai is shoting so good :) or so bad if you are lucky
     * 
     */

namespace BattleshipsRecrutation.AppCore
{
    public class AiPlayer
    {
        //AiPlayer attributes 
        public string Name { get; set; }
        public MyBoard MyBoard { get; set; }
        public EnemyFoggedBoard EnemyFoggedBoard { get; set; }
        public List<Ship> Ships { get; set; }

        // Bool Looser - if all ships are sunked then round will be over and AiPlayer will lose 
        public bool Looser
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }

        //Ships of specific AiPlayer
        public AiPlayer(string name)
        {
            Name = name;
            Ships = new List<Ship>()
            {
                new Destroyer(),
                new Submarine(),
                new Cruiser(),
                new Battleship(),
                new Carrier()
            };
            MyBoard = new MyBoard();
            EnemyFoggedBoard = new EnemyFoggedBoard();
        }


        // The funcion responsible for boards drawing 
        public void DrawingBoards()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Own Board:                          Your Shots:");
            // ustawienie ilości rzędów
            for (int row = 1; row <= 10; row++)
            {
                // columns of MyBoard(the left board in console)
                for (int ownColumn = 1; ownColumn <= 10; ownColumn++)
                {
                    Console.Write(MyBoard.Squers.At(row, ownColumn).Status + " ");
                }
                Console.Write("                ");
                // columns of EnemyFoggedBoard(the right board in console)
                for (int shotsColumn = 1; shotsColumn <= 10; shotsColumn++)
                {
                    Console.Write(EnemyFoggedBoard.Squers.At(row, shotsColumn).Status + " ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        //AiPlayer will set his ships randomly, of course only in places that are avaiable.
        public void SetShipsPosition()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Ships)
            {
                //Select a random row/column combination, then select a random orientation.
                //If none of the proposed squers are occupied, place the ship
                //The function will do this to all ships

                bool isEnable = true;
                while (isEnable)
                {
                    var entryColumn = rand.Next(1, 11);
                    var entryRow = rand.Next(1, 11);
                    int lastRow = entryRow, lastColumn = entryColumn;
                    var orientation = rand.Next(1, 101) % 2; //0 for Horizontal

                    List<int> squerCoords = new List<int>();
                    if (orientation == 0)
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            lastRow++;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            lastColumn++;
                        }
                    }

                    //We cannot place ships beyond the boundaries of the board
                    if (lastRow > 10 || lastColumn > 10)
                    {
                        isEnable = true;
                        continue;
                    }

                    //Check if specified squers are avaiable - check their status.
                    var isSquerEnable = MyBoard.Squers.Range(entryRow, entryColumn, lastRow, lastColumn);
                    if (isSquerEnable.Any(x => x.IsDisable))
                    {
                        isEnable = true;
                        continue;
                    }

                    foreach (var squer in isSquerEnable)
                    {
                        // StatusOfSquer - Ship.cs <- Ships[Folder] <- AppCore[Folder]
                        squer.StatusOfSquer = ship.StatusOfSquer;
                    }
                    isEnable = false;
                }
            }
        }

        /*
         * The OpenFire method is responsible for core logic of AiPlayer shots
         * It decides if AiPlayer will shot in random avaiable squer
         * or if he will shot in squers that are "logically correct" (near last hit etc.)
         */

        public Coords OpenFire()
        {
            //If there are hits on the board with neighbors which we didn't have shot yet, we should fire at those first.
            var HitWasNear = EnemyFoggedBoard.CloseToGoodHit();
            Coords coords;
            if (HitWasNear.Any())
            {
                coords = SquersNearHit();
            }
            else
            {
                // If there is no "logically correct" squer to shot, just make random shot
                // Repeat every each round (move)
                coords = FireAtRandomPosition();
            }
            Console.WriteLine(Name + " says: \"Firing shot at " + coords.Row.ToString() + ", " + coords.Column.ToString() + "\"");
            return coords;
        }

        //Function is generating random coords that computer will shot at
        private Coords FireAtRandomPosition()
        {
            var CanShotThere = EnemyFoggedBoard.EverySquerShot();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var squerId = rand.Next(CanShotThere.Count);
            return CanShotThere[squerId];
        }

        //Function will calculate if next to hited squer are "avaible" for shot squers
        private Coords SquersNearHit()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var HitWasNear = EnemyFoggedBoard.CloseToGoodHit();
            var nearHitSquerId = rand.Next(HitWasNear.Count);
            return HitWasNear[nearHitSquerId];
        }

        /*
         * Anserw to oponent! - He should know if he hits
         * Logic of shot result part2. - empty squer = "Miss", squer that includes ship - "Hit",
         * If there was Hit after shot and ship was sunked = "You sunk my ..."
         */
        public ResultOfShot InAirShot(Coords coords)
        {
            var squer = MyBoard.Squers.At(coords.Row, coords.Column);
            if (!squer.IsDisable)
            {
                Console.WriteLine(Name + " says: \"Miss!\"");
                return ResultOfShot.Miss;
            }
            var ship = Ships.First(x => x.StatusOfSquer == squer.StatusOfSquer);
            ship.Damaged++;
            Console.WriteLine(Name + " says: \"Damage!\"");
            if (ship.IsSunk)
            {
                Console.WriteLine(Name + " says: \"You sunk my " + ship.Name + "!\"");
            }
            return ResultOfShot.Damage;
        }


        /*
         * Seting Status of squer - important for algorithm
         * Logic of shot result part1. - empty squer = Miss, squer that includes ship - Hit,
         * The function is proceding shot, taking result and seting different Status on squer.
         */
        public void InAirShotResult(Coords coords, ResultOfShot result)
        {
            var squer = EnemyFoggedBoard.Squers.At(coords.Row, coords.Column);
            switch (result)
            {
                case ResultOfShot.Damage:
                    squer.StatusOfSquer = StatusOfSquer.Damage;
                    break;

                default:
                    squer.StatusOfSquer = StatusOfSquer.Miss;
                    break;
            }
        }
    }
}
