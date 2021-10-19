using BattleshipsRecrutation.Enlargements;
using BattleshipsRecrutation.AppCore.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

        /*
         * In this class there will be logic, that will allow HumanPlayer to:
         *  -set his own ships on MyBoard
         *  -input coords (x and y) that HumanPlayer wants to shot at
         * 
         * Not modified yet - no time.
         */

namespace BattleshipsRecrutation.AppCore
{
    class HumanPlayer
    {
        public string Name { get; set; }
        public MyBoard MyBoard { get; set; }
        public EnemyFoggedBoard EnemyFoggedBoard { get; set; }
        public List<Ship> Ships { get; set; }
        public bool Looser
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }

        public HumanPlayer(string name)
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

        // Same DrawingBoard method as in AiPlayer.cs
        public void DrawingBoards()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Own Board:                          Your Shots:");

            // setting board size, 10 rows

            for (int row = 1; row <= 10; row++)
            {
                // columns of MyBoard (the left board in console)
                for (int ownColumn = 1; ownColumn <= 10; ownColumn++)
                {
                    Console.Write(MyBoard.Squers.At(row, ownColumn).Status + " ");
                }
                Console.Write("                ");
                // columns of EnemyFoggedBoard (the right board in console)
                for (int shotsColumn = 1; shotsColumn <= 10; shotsColumn++)
                {
                    Console.Write(EnemyFoggedBoard.Squers.At(row, shotsColumn).Status + " ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        /*
         * Class SetShipsPosition is responsible for settings ships position on MyBoard
         * for this project to save time of testing ships location on board is generated randomly 
         * 
         * In HumanPlayer.cs - Need to modify so user can set his ships wherever he would like to.
         */
        public void SetShipsPosition()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Ships)
            {
                //Select a random row/column combination, then select a random orientation.
                //If none of the proposed squers are disable, place the ship
                //Method will set all ships after checking conditions

                bool isEnable = true;
                while (isEnable)
                {

                    
                    var entryColumn = rand.Next(1, 11);
                    var entryRow = rand.Next(1, 11);
                    int lastRow = entryRow, lastColumn = entryColumn;
                    var orientation = rand.Next(1, 101) % 2; 

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

                    //Ships can be set only on the board, not beside it
                    if (lastRow > 10 || lastColumn > 10)
                    {
                        isEnable = true;
                        continue;
                    }

                    //Checking if specified squers are disable and if they can be used
                    var isSquerEnable = MyBoard.Squers.Range(entryRow, entryColumn, lastRow, lastColumn);
                    if (isSquerEnable.Any(x => x.IsDisable))
                    {
                        isEnable = true;
                        continue;
                    }

                    foreach (var squer in isSquerEnable)
                    {
                        squer.StatusOfSquer = ship.StatusOfSquer;
                    }
                    isEnable = false;
                }
            }
        }

        // Coppied from AiPlayer Shoting logic - for change
        // More informations in AiPlayer.cs file!

        public Coords HumanOpenFire()
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
                coords = FireAtRandomPosition();
            }
            Console.WriteLine(Name + " says: \"Firing shot at " + coords.Row.ToString() + ", " + coords.Column.ToString() + "\"");
            return coords;
        }

        private Coords FireAtRandomPosition()
        {
            var CanShotThere = EnemyFoggedBoard.EverySquerShot();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var squerId = rand.Next(CanShotThere.Count);
            return CanShotThere[squerId];
        }

        private Coords SquersNearHit()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var HitWasNear = EnemyFoggedBoard.CloseToGoodHit();
            var nearHitSquerId = rand.Next(HitWasNear.Count);
            return HitWasNear[nearHitSquerId];
        }

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
