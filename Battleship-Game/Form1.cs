using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Battleship_Game
{
    public partial class Form1 : Form
    {

        private bool button_click = false;
        private Player player = new Player("player", 0);
        private Player enemy = new Player("Enemy", 0);
        private List<string> shipPositions = new List<string>();
        private List<String> hitPos = new List<string>();
        private enum Positions
        {
            //enemy player grid
            a1, a2, a3, a4,
            b1, b2, b3, b4,
            c1, c2, c3, c4,
            d1, d2, d3, d4,
            //player grid
            w1, w2, w3, w4,
            x1, x2, x3, x4,
            y1, y2, y3, y4,
            z1, z2, z3, z4
        }
        public Form1()
        {
            InitializeComponent();
        }

        //player buttons

        private void W1_Click(object sender, EventArgs e)
        {
            w1 = SetPlayerShips(w1);
        }

        private void W2_Click(object sender, EventArgs e)
        {
            w2 = SetPlayerShips(w2);

        }

        private void W3_Click(object sender, EventArgs e)
        {
            w3 = SetPlayerShips(w3);
        }

        private void W4_Click(object sender, EventArgs e)
        {
            w4 = SetPlayerShips(w4);
        }
        private void X1_Click(object sender, EventArgs e)
        {
            x1 = SetPlayerShips(x1);
        }

        private void X2_Click(object sender, EventArgs e)
        {
            x2 = SetPlayerShips(x2);
        }

        private void X3_Click(object sender, EventArgs e)
        {
            x3 = SetPlayerShips(x3);
        }

        private void X4_Click(object sender, EventArgs e)
        {
            x4 = SetPlayerShips(x4);
        }

        private void Y1_Click(object sender, EventArgs e)
        {
            y1 = SetPlayerShips(y1);
        }
        private void Y2_Click(object sender, EventArgs e)
        {
            y2 = SetPlayerShips(y2);
        }

        private void Y3_Click(object sender, EventArgs e)
        {
            y3 = SetPlayerShips(y3);
        }

        private void Y4_Click(object sender, EventArgs e)
        {
            y4 = SetPlayerShips(y4);
        }
        private void Z1_Click(object sender, EventArgs e)
        {
            z1 = SetPlayerShips(z1);
        }

        private void Z2_Click(object sender, EventArgs e)
        {
            z2 = SetPlayerShips(z2);
        }

        private void Z3_Click(object sender, EventArgs e)
        {
            z3 = SetPlayerShips(z3);
        }

        private void Z4_Click(object sender, EventArgs e)
        {
            z4 = SetPlayerShips(z4);
        }


        //enemy buttons

        private void A1_Click(object sender, EventArgs e)
        {
            HitEnemyShips(a1);
        }

        private void A2_Click(object sender, EventArgs e)
        {
            HitEnemyShips(a2);
        }

        private void A3_Click(object sender, EventArgs e)
        {
            HitEnemyShips(a3);
        }

        private void A4_Click(object sender, EventArgs e)
        {
            HitEnemyShips(a4);
        }

        private void B1_Click(object sender, EventArgs e)
        {
            HitEnemyShips(b1);
        }

        private void B2_Click(object sender, EventArgs e)
        {
            HitEnemyShips(b2);
        }

        private void B3_Click(object sender, EventArgs e)
        {
            HitEnemyShips(b3);
        }

        private void B4_Click(object sender, EventArgs e)
        {
            HitEnemyShips(b4);
        }

        private void C1_Click(object sender, EventArgs e)
        {
            HitEnemyShips(c1);
        }

        private void C2_Click(object sender, EventArgs e)
        {
            HitEnemyShips(c2);
        }

        private void C3_Click(object sender, EventArgs e)
        {
            HitEnemyShips(c3);
        }

        private void C4_Click(object sender, EventArgs e)
        {
            HitEnemyShips(c4);
        }

        private void D1_Click(object sender, EventArgs e)
        {
            HitEnemyShips(d1);
        }

        private void D2_Click(object sender, EventArgs e)
        {
            HitEnemyShips(d2);
        }

        private void D3_Click(object sender, EventArgs e)
        {
            HitEnemyShips(d3);
        }

        private void D4_Click(object sender, EventArgs e)
        {
            HitEnemyShips(d4);
        }

        //If player clicked start game check initialize the enemy ships and their positions
        //check if player placed exactly 3 ships
        private void GameButton_Click(object sender, EventArgs e)
        {
            if (!button_click)
            {

                if (player.GetShips().Count == 3)
                {
                    SetEnemyPlayerShips();
                    button_click = true;
                }
                else {
                    int remShips = 3 - player.GetShips().Count;
                    MessageBox.Show($"Please place 3 ships...Remaining: {remShips}");                  
                }
            }
            else
            {
                //Clear memory and form for the new game to start 
                player.DeleteShips();
                enemy.DeleteShips();
                ResetPicBox();
                hitPos.Clear();
                label1.Text = "3";
                label2.Text = "3";
                button_click = false;
            }


        }

        //If player clicks on pictureBox place a ship there
        //Only if the game has not started
        public PictureBox SetPlayerShips(PictureBox pictureBox)
        {
            if (!button_click)
            {
                List<Ship> shipsList = player.GetShips();
                if (pictureBox.BackColor == System.Drawing.SystemColors.ControlDark)
                {
                    if (shipsList.Count < 3)
                    {
                        Ship ship = new Ship(pictureBox.Name);
                        pictureBox.BackColor = System.Drawing.Color.Green;
                        player.SetShips(ship);
                    }
                }
                else
                {
                    //If clicked again remove the ship
                    pictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
                    foreach (Ship ship in shipsList)
                        if (ship.GetPosition().Equals(pictureBox.Name))
                        {
                            player.RemoveShip(ship);
                            break;
                        }
                }
            }
            return pictureBox;
        }

        //The computer randomly decides where to place it's ships just as the game starts
        public void SetEnemyPlayerShips()
        {
            int num;
            int i = 0;
            while (enemy.GetShips().Count < 3)
            {
                bool found = false;
                Random rand = new Random();
                num = rand.Next(0, 16);
                string positions = ((Positions)num).ToString();
                foreach (Ship shipFromList in enemy.GetShips())
                {
                    if (shipFromList.GetPosition().Equals(positions))
                        found = true;
                }
                //Check if the chosen position already contains a ship. If yes then try again  
                if (!found)
                {
                    Ship ship = new Ship(positions);
                    enemy.SetShips(ship);
                    i++;
                }
            }
            MessageBox.Show("Enemy Player Is Ready");
        }

        //Invocked when player clicks on a pictureBox in the enemy grid map. Only if the game has started
        //If player has 0 ships remaining the computer wins
        public void HitEnemyShips(PictureBox pictureBox)
        {
            if (button_click)
            {           
                if (player.GetShips().Count != 0)
                {
                    //Check if the position clicked contains a ship. If yes place fire and remove a ship from the enemy
                    //If no place a miss icon
                    foreach (Ship shipFromList in enemy.GetShips())
                    {
                        if (shipFromList.GetPosition().Equals(pictureBox.Name))
                        {
                            pictureBox.Image = Battleship_Game.Properties.Resources.fireIcon;
                            SetTag(pictureBox, "fireIcon");
                            enemy.RemoveShip(shipFromList);
                            break;
                        }
                        else
                        {
                            if (((String)pictureBox.Tag != "fireIcon") && (String)pictureBox.Tag != "missIcon")
                            {
                                pictureBox.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(pictureBox, "missIcon");
                            }
                        }
                    }
                    //Invokes a method for the computer to play
                    bool reRun = true;
                    //If the computer has 0 ships remaining the player wins
                    if (enemy.GetShips().Count != 0)
                        while (reRun)
                        {
                            reRun = HitPlayerShips();
                        }
                    else
                        MessageBox.Show("You Won!!!");
                    label1.Text = player.GetShips().Count.ToString();
                    label2.Text = enemy.GetShips().Count.ToString();
                }
                else
                    MessageBox.Show("You Lost...");
            }
        }

        //The computer selects a position to strike randomly
        //With an enum function (each position is defined by a number from 0 - 31) find the chosen position
        public bool HitPlayerShips()
        {
            bool reRun = false;
            Random rand = new Random();
            int num = rand.Next(16, 31);
            string position = ((Positions)num).ToString();
            bool found = SearchIsHit(hitPos, position);
            //If the position has not already been hit then, if it contains a ship remove a ship from player and place fire icon
            //Else place miss icon
            //If the selected position is already hit, then rerun the method until a position to strike is found
            if (!found)
            {
                foreach (Ship shipFromList in player.GetShips())
                {
                    if (shipFromList.GetPosition().Equals(position))
                    {
                        //Target Hit
                        switch (position)
                        {
                            case "w1":
                                w1.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(w1, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "w2":
                                w2.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(w2, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "w3":
                                w3.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(w3, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "w4":
                                w4.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(w4, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "x1":
                                x1.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(x1, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "x2":
                                x2.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(x2, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "x3":
                                x3.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(x3, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "x4":
                                x4.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(x4, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "y1":
                                y1.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(y1, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "y2":
                                y2.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(y2, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "y3":
                                y3.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(y3, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "y4":
                                y4.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(y4, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "z1":
                                z1.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(z1, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "z2":
                                z2.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(z2, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "z3":
                                z3.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(z3, "fireIcon");
                                hitPos.Add(position);
                                break;
                            case "z4":
                                z4.Image = Battleship_Game.Properties.Resources.fireIcon;
                                SetTag(z4, "fireIcon");
                                hitPos.Add(position);
                                break;
                        }
                        player.RemoveShip(shipFromList);
                        break;
                    }
                    else
                    {
                        //Missed Target
                        switch (position)
                        {
                            case "w1":
                                w1.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(w1, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "w2":
                                w2.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(w2, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "w3":
                                w3.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(w3, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "w4":
                                w4.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(w4, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "x1":
                                x1.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(x1, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "x2":
                                x2.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(x2, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "x3":
                                x3.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(x3, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "x4":
                                x4.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(x4, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "y1":
                                y1.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(y1, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "y2":
                                y2.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(y2, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "y3":
                                y3.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(y3, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "y4":
                                y4.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(y4, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "z1":
                                z1.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(z1, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "z2":
                                z2.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(z2, "missIcon");
                                hitPos.Add(position);
                                break;
                            case "z3":
                                z3.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(z3, "missIcon");
                                hitPos.Add(position);
                                hitPos.Add(position);
                                break;
                            case "z4":
                                z4.Image = Battleship_Game.Properties.Resources.missIcon;
                                SetTag(z4, "missIcon");
                                hitPos.Add(position);
                                break;
                        }
                    }
                }
            }
            else
                reRun = true;
            return reRun;
        }

        //A method to check if the selected position has already been hit
        public bool SearchIsHit(List<String> isHit, String picBoxName)
        {
            bool found = false;
            foreach (String pos in isHit)
            {
                if (pos.Equals(picBoxName))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        //set the tags of the pictureboxes to fire or miss
        public void SetTag(PictureBox pictureBox, String tag)
        {
            pictureBox.Tag = tag;
        }

        //Reset the board(form) for a new game 
        public void ResetPicBox()
        {
            w1.BackColor = System.Drawing.SystemColors.ControlDark;
            w2.BackColor = System.Drawing.SystemColors.ControlDark;
            w3.BackColor = System.Drawing.SystemColors.ControlDark;
            w4.BackColor = System.Drawing.SystemColors.ControlDark;
            x1.BackColor = System.Drawing.SystemColors.ControlDark;
            x2.BackColor = System.Drawing.SystemColors.ControlDark;
            x3.BackColor = System.Drawing.SystemColors.ControlDark;
            x4.BackColor = System.Drawing.SystemColors.ControlDark;
            y1.BackColor = System.Drawing.SystemColors.ControlDark;
            y2.BackColor = System.Drawing.SystemColors.ControlDark;
            y3.BackColor = System.Drawing.SystemColors.ControlDark;
            y4.BackColor = System.Drawing.SystemColors.ControlDark;
            z1.BackColor = System.Drawing.SystemColors.ControlDark;
            z2.BackColor = System.Drawing.SystemColors.ControlDark;
            z3.BackColor = System.Drawing.SystemColors.ControlDark;
            z4.BackColor = System.Drawing.SystemColors.ControlDark;

            a1.Image = w1.Image = null;
            a2.Image = w2.Image = null;
            a3.Image = w3.Image = null;
            a4.Image = w4.Image = null;
            b1.Image = x1.Image = null;
            b2.Image = x2.Image = null;
            b3.Image = x3.Image = null;
            b4.Image = x4.Image = null;
            c1.Image = y1.Image = null;
            c2.Image = y2.Image = null;
            c3.Image = y3.Image = null;
            c4.Image = y4.Image = null;
            d1.Image = z1.Image = null;
            d2.Image = z2.Image = null;
            d3.Image = z3.Image = null;
            d4.Image = z4.Image = null;

            a1.Tag = a2.Tag = a3.Tag = a4.Tag = null;
            b1.Tag = b2.Tag = b3.Tag = b4.Tag = null;
            c1.Tag = c2.Tag = c3.Tag = c4.Tag = null;
            d1.Tag = d2.Tag = d3.Tag = d4.Tag = null;
            w1.Tag = w2.Tag = w3.Tag = w4.Tag = null;
            x1.Tag = x2.Tag = x3.Tag = x4.Tag = null;
            y1.Tag = y2.Tag = y3.Tag = y4.Tag = null;
            z1.Tag = z2.Tag = z3.Tag = z4.Tag = null;
        }

    }
}
