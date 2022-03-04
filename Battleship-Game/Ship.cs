using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Game
{
    internal class Ship
    {
        private String position;

        public Ship(String position) {
            this.position = position;
        }

        public String GetPosition() {
            return position;
        }

        public void SetPosition(String position) {
            this.position = position;
        }

    }
}
