using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Game
{
    internal class Player
    {
        private String name;
        private List<Ship> ships = new List<Ship>();

        public Player(String name, int score) {
            this.name = name;
        }

        public String GetName() {
            return name;
        }


        public List<Ship> GetShips(){       
            return ships;
        }

        public void SetName(String name)
        {
            this.name = name;
        }


        public void SetShips(Ship ships) {
            this.ships.Add(ships);
        }

        public void RemoveShip(Ship ship) {
            this.ships.Remove(ship);
        }

        public void DeleteShips() {
            this.ships.Clear();
        }
    }
}
