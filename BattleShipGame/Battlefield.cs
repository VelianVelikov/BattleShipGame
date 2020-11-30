using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

// Velian Velikov - 180011401
// Lucas Khan - 180024439

namespace BattleShipGame
{
    public partial class Battlefield : Form
    {
        // Level of Difficulty, where 0 means an Easy level - random computer moves, and 1 m
        private int levelOfDifficulty;
        //This is to distinguish between exit and go back button
        //if it is set to true this means that go back button has been pressed
        private bool goBack = false;
        private bool playAgain = false;
        Dictionary<int, Tuple<int, int, int, string>> playerShips = new Dictionary<int, Tuple<int, int, int, string>>();
        Dictionary<int, Tuple<int, int, int, string>> computerShips = new Dictionary<int, Tuple<int, int, int, string>>();
        //grids
        Button[,] playerGrid = new Button[10, 10];
        Button[,] computerGrid = new Button[10, 10];
        Button[,] computerGridVisible = new Button[10, 10];

        // Random variable
        Random r = new Random();
        SoundPlayer hit;
        SoundPlayer miss;
        SoundPlayer winner;
        SoundPlayer loser;
        SoundPlayer background;

        int playerCount = 0;
        int computerCount = 0;

        int playerWinCount = 0;
        int computerWinCount = 0;

        string playersName;

        Dictionary<string, Tuple<int, int>> leagueTable = new Dictionary<string, Tuple<int, int>>();


        public Battlefield(int levelOfDifficulty, Dictionary<int, Tuple<int, int, int, string>> playerShips, Dictionary<int, Tuple<int, int, int, string>> computerShips, string playersName, SoundPlayer background)
        {
            // Initialise the new item
            InitializeComponent();

            this.background = background;
            this.background.Stop();

            this.playersName = playersName;
            this.Load_LeagueTable();

            bool exists = false;
            foreach (KeyValuePair<string, Tuple<int, int>> entry in leagueTable)
            {
                if (entry.Key == this.playersName)
                {
                    playerWinCount = entry.Value.Item1;
                    computerWinCount = entry.Value.Item2;
                    exists = true;
                }
            }

            if (exists == false)
            {
                // add it to the leagueTable
                leagueTable.Add(this.playersName, new Tuple<int, int>(this.playerWinCount, this.computerWinCount));
                this.Write_LeagueTable(0);
            
            }

            lblComputerWins.Text = "Computer - " + computerWinCount + " wins";
            lblPlayerWins.Text = playersName + " - " + playerWinCount + " wins";

            this.playerShips = playerShips;
            this.computerShips = computerShips;

            //Load the menu options
            this.Load_ToolStipItems();

            //Set level of difficulty to a private field and changes the text of lblLevelOfDifficulty
            this.Check_LevelOfDifficulty(levelOfDifficulty);

            this.Display_playerGrid();
            this.Load_playerShips();

            // it is hidden - not visible for the player
            this.Display_computerGrid();
            this.Load_computerShips();

            this.Display_computerGridVisible();

            if (File.Exists("..\\..\\sounds\\hit.wav"))
            {
                this.hit = new SoundPlayer("..\\..\\sounds\\hit.wav");
                //hit.PlayLooping();
                //hit.Play();
            }
            if (File.Exists("..\\..\\sounds\\miss.wav"))
            {
                this.miss = new SoundPlayer("..\\..\\sounds\\miss.wav");
                //background.PlayLooping();
                //miss.Play();
            }
        }

        private void Load_LeagueTable()
        {
            string filePath = "..\\..\\Resources\\leagueTable.txt";

            if (File.Exists("..\\..\\Resources\\leagueTable.txt"))
            {
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filePath).ToList();
                foreach (String line in lines)
                {
                    string[] lineData = line.Split(',');

                    leagueTable.Add(lineData[0], new Tuple<int, int>(Convert.ToInt32(lineData[1]), Convert.ToInt32(lineData[2])));
                }
            }
            //foreach (KeyValuePair<string, Tuple<int, int>> entry in leagueTable)
            //{
            //    Console.WriteLine(entry.Key + ", " + entry.Value.Item1 + ", " + entry.Value.Item2);
            //}

        }

        private void Write_LeagueTable(int type)
        {
            string filePath = "..\\..\\Resources\\leagueTable.txt";

            File.WriteAllText(filePath, String.Empty);

            if (type == 1)
            {
                foreach (KeyValuePair<string, Tuple<int, int>> entry in leagueTable)
                {
                    if (entry.Key == this.playersName)
                    {
                        File.AppendAllText(filePath, entry.Key + ", " + this.playerWinCount + ", " + this.computerWinCount + Environment.NewLine);
                    }
                    else
                    {
                        File.AppendAllText(filePath, entry.Key + ", " + entry.Value.Item1 + ", " + entry.Value.Item2 + Environment.NewLine);
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<string, Tuple<int, int>> entry in leagueTable)
                {
                    File.AppendAllText(filePath, entry.Key + ", " + entry.Value.Item1 + ", " + entry.Value.Item2 + Environment.NewLine);
                }
            }


        }

        private void Load_playerShips()
        {
            foreach (var ship in playerShips)
            {
                this.Place_playerShip(ship.Value.Item1, ship.Value.Item2, ship.Value.Item3, ship.Value.Item4);
            }
        }

        private void Load_computerShips()
        {
            foreach (var ship in computerShips)
            {
                this.Place_computerShip(ship.Value.Item1, ship.Value.Item2, ship.Value.Item3, ship.Value.Item4);
            }
        }

        private void Place_playerShip(int x, int y, int size, string orientation)
        {
            if (size == 31 || size == 32)
            {
                size = 3;
            }

            if (orientation == "x")
            {
                for (int i = 0; i < size; i++)
                {
                    playerGrid[x + i, y].BackColor = Color.Lime;
                }
            }
            else if (orientation == "y")
            {
                for (int i = 0; i < size; i++)
                {
                    playerGrid[x, y + i].BackColor = Color.Lime;
                }
            }
        }

        private void Place_computerShip(int x, int y, int size, string orientation)
        {
            if (size == 31 || size == 32)
            {
                size = 3;
            }

            if (orientation == "x")
            {
                for (int i = 0; i < size; i++)
                {
                    computerGrid[x + i, y].BackColor = Color.Lime;
                }
            }
            else if (orientation == "y")
            {
                for (int i = 0; i < size; i++)
                {
                    computerGrid[x, y + i].BackColor = Color.Lime;
                }
            }
        }

        private void Display_playerGrid()
        {
            for (int x = 0; x < playerGrid.GetLength(0); x++) // Loop for x
            {
                for (int y = 0; y < playerGrid.GetLength(1); y++)
                {
                    playerGrid[x, y] = new Button(); // Create button
                    playerGrid[x, y].SetBounds(22 + 31 * x, 65 + 31 * y, 30, 30); // Set size & position
                    playerGrid[x, y].BackColor = Color.FromArgb(144, 202, 249);   // Set colour
                    playerGrid[x, y].FlatStyle = FlatStyle.Flat;
                    playerGrid[x, y].FlatAppearance.BorderColor = Color.Honeydew;
                    playerGrid[x, y].FlatAppearance.BorderSize = 0;
                    //playerGrid[x, y].FlatAppearance.MouseDownBackColor = Color.Lime;
                    //playerGrid[x, y].FlatAppearance.MouseOverBackColor = Color.FromArgb(144, 202, 249);
                    playerGrid[x, y].Enabled = false;
                    //playerGrid[x, y].Text = Convert.ToString((x + 1) + ", " + (y + 1));
                    playerGrid[x, y].Tag = Convert.ToString((x + 1) + ", " + (y + 1));
                    playerGrid[x, y].Font = new Font("Arial", 6, FontStyle.Regular);
                    // Add link to the event handler to use when clicked
                    playerGrid[x, y].Click += new EventHandler(this.playerGridEvent_Click);
                    Controls.Add(playerGrid[x, y]);  // Put the item onto the GUI
                }
            }

            //grid[r.Next(10), r.Next(10)].BackColor = Color.Lime; // Random green placement
        }

        private void Display_computerGrid()
        {
            for (int x = 0; x < computerGrid.GetLength(0); x++) // Loop for x
            {
                for (int y = 0; y < computerGrid.GetLength(1); y++)
                {
                    computerGrid[x, y] = new Button(); // Create button
                    computerGrid[x, y].SetBounds(363 + 31 * x, 65 + 31 * y, 30, 30); // Set size & position
                    computerGrid[x, y].BackColor = Color.FromArgb(144, 202, 249);   // Set colour
                    computerGrid[x, y].FlatStyle = FlatStyle.Flat;
                    computerGrid[x, y].FlatAppearance.BorderColor = Color.Honeydew;
                    computerGrid[x, y].FlatAppearance.BorderSize = 0;
                    computerGrid[x, y].FlatAppearance.MouseDownBackColor = Color.Lime;
                    computerGrid[x, y].FlatAppearance.MouseOverBackColor = Color.FromArgb(33, 150, 243);
                    //computerGrid[x, y].Text = Convert.ToString((x + 1) + ", " + (y + 1));
                    computerGrid[x, y].Tag = Convert.ToString((x + 1) + ", " + (y + 1));
                    computerGrid[x, y].Font = new Font("Arial", 6, FontStyle.Regular);
                    // Add link to the event handler to use when clicked
                    computerGrid[x, y].Click += new EventHandler(this.computerGridEvent_Click);
                    //this hides the ships from the player
                    computerGrid[x, y].Visible = false;
                    Controls.Add(computerGrid[x, y]);  // Put the item onto the GUI
                }
            }

            //grid[r.Next(10), r.Next(10)].BackColor = Color.Lime; // Random green placement
        }

        private void Display_computerGridVisible()
        {
            for (int x = 0; x < computerGridVisible.GetLength(0); x++) // Loop for x
            {
                for (int y = 0; y < computerGridVisible.GetLength(1); y++)
                {
                    computerGridVisible[x, y] = new Button(); // Create button
                    computerGridVisible[x, y].SetBounds(363 + 31 * x, 65 + 31 * y, 30, 30); // Set size & position
                    computerGridVisible[x, y].BackColor = Color.FromArgb(33, 150, 243);   // Set colour
                    computerGridVisible[x, y].FlatStyle = FlatStyle.Flat;
                    computerGridVisible[x, y].FlatAppearance.BorderColor = Color.Honeydew;
                    computerGridVisible[x, y].FlatAppearance.BorderSize = 0;
                    //computerGridVisible[x, y].FlatAppearance.MouseDownBackColor = Color.Lime;
                    computerGridVisible[x, y].FlatAppearance.MouseOverBackColor = Color.FromArgb(144, 202, 249);
                    //computerGridVisible[x, y].Text = Convert.ToString((x + 1) + ", " + (y + 1));
                    computerGridVisible[x, y].Tag = Convert.ToString((x + 1) + ", " + (y + 1));
                    computerGridVisible[x, y].Font = new Font("Arial", 6, FontStyle.Regular);
                    // Add link to the event handler to use when clicked
                    computerGridVisible[x, y].Click += new EventHandler(this.computerGridVisibleEvent_Click);
                    Controls.Add(computerGridVisible[x, y]);  // Put the item onto the GUI
                }
            }

            //grid[r.Next(10), r.Next(10)].BackColor = Color.Lime; // Random green placement
        }

        void playerGridEvent_Click(object sender, EventArgs e) // Event Handler
        {
            MessageBox.Show(((Button)sender).Tag.ToString());
        }

        void computerGridEvent_Click(object sender, EventArgs e) // Event Handler
        {
            MessageBox.Show(((Button)sender).Tag.ToString());
        }

        void computerGridVisibleEvent_Click(object sender, EventArgs e) // Event Handler
        {
            string[] tagData = ((Button)sender).Tag.ToString().Split(',');
            int x = Convert.ToInt32(tagData[0]) - 1;
            int y = Convert.ToInt32(tagData[1]) - 1;

            if (computerGrid[x, y].BackColor == Color.Lime)
            {
                this.hit.Play();
                computerGridVisible[x, y].BackColor = Color.Red;
                computerGridVisible[x, y].Enabled = false;

                playerCount++;
            }
            else
            {
                this.miss.Play();
                computerGridVisible[x, y].BackColor = Color.FromArgb(144, 202, 249);
                computerGridVisible[x, y].Enabled = false;
            }

            if (playerCount == 17)
            {
                if (File.Exists("..\\..\\sounds\\winner.wav"))
                {
                    this.winner = new SoundPlayer("..\\..\\sounds\\winner.wav");
                    //hit.PlayLooping();
                    winner.Play();
                }
                MessageBox.Show(this.playersName + " wins!", "Congratulations!");
                this.playerWinCount++;
                lblPlayerWins.Text = playersName + " - " + playerWinCount + " wins";

                btnAgainOrSurrender.Text = "Play Again!";
            }

            this.computerMakesMove();

            if (computerCount == 17)
            {
                if (File.Exists("..\\..\\sounds\\loser.wav"))
                {
                    this.loser = new SoundPlayer("..\\..\\sounds\\loser.wav");
                    //hit.PlayLooping();
                    loser.Play();
                }
                MessageBox.Show("Computer wins!", "Ohh, no! Try again.");
                this.computerWinCount++;
                lblComputerWins.Text = "Computer - " + computerWinCount + " wins";

                this.Display_computerAnswers();

                btnAgainOrSurrender.Text = "Play Again!";
            }

            this.Write_LeagueTable(1);

        }

        private void Display_computerAnswers()
        {
            for (int x = 0; x < computerGridVisible.GetLength(0); x++) // Loop for x
            {
                for (int y = 0; y < computerGridVisible.GetLength(1); y++)
                {
                    if (computerGrid[x, y].BackColor == Color.Lime && computerGridVisible[x, y].BackColor != Color.Red)
                    {
                        computerGridVisible[x, y].BackColor = Color.Lime;
                    }
                }
            }
        }


        private void computerMakesMove()
        {
            if (this.levelOfDifficulty == 0)
            {
                int x, y;
                do
                {
                    x = r.Next(10);
                    y = r.Next(10);
                }
                while (playerGrid[x, y].BackColor == Color.FromArgb(33, 150, 243) || playerGrid[x, y].BackColor == Color.Red);

                if (playerGrid[x, y].BackColor == Color.Lime)
                {
                    // hit
                    playerGrid[x, y].BackColor = Color.Red;
                    playerGrid[x, y].Enabled = false;

                    computerCount++;
                }
                else
                {
                    // miss
                    playerGrid[x, y].BackColor = Color.FromArgb(33, 150, 243);
                    playerGrid[x, y].Enabled = false;
                }
            }
            else if (this.levelOfDifficulty == 1)
            {
                // if level is hard the computer makes absolute hit every third turn
                int x, y;
                int absoluteHit = r.Next(3);

                // if lucky 3
                if (absoluteHit == 2)
                {
                    Console.WriteLine("Lucky 3");
                    do
                    {
                        x = r.Next(10);
                        y = r.Next(10);
                    }
                    while (playerGrid[x, y].BackColor != Color.Lime);

                    // hit
                    playerGrid[x, y].BackColor = Color.Red;
                    playerGrid[x, y].Enabled = false;

                    computerCount++;
                }
                // else normal turn
                else
                {
                    do
                    {
                        x = r.Next(10);
                        y = r.Next(10);
                    }
                    while (playerGrid[x, y].BackColor == Color.FromArgb(33, 150, 243) || playerGrid[x, y].BackColor == Color.Red);

                    if (playerGrid[x, y].BackColor == Color.Lime)
                    {
                        // hit
                        playerGrid[x, y].BackColor = Color.Red;
                        playerGrid[x, y].Enabled = false;

                        computerCount++;
                    }
                    else
                    {
                        // miss
                        playerGrid[x, y].BackColor = Color.FromArgb(33, 150, 243);
                        playerGrid[x, y].Enabled = false;
                    }
                }


            }
        }

        private void Check_LevelOfDifficulty(int levelOfDifficulty)
        {
            //Set level of difficulty to a private field
            this.levelOfDifficulty = levelOfDifficulty;

            if (this.levelOfDifficulty == 0)
            {
                lblLevelOfDifficulty.Text = lblLevelOfDifficulty.Text + "Easy";
            }
            else if (this.levelOfDifficulty == 1)
            {
                lblLevelOfDifficulty.Text = lblLevelOfDifficulty.Text + "Hard";
            }
        }

        private void Load_ToolStipItems()
        {
            //Change the colour for aesthetics
            menuStrip1.BackColor = Color.Honeydew;

            var tsiHowToPlay = optionsToolStripMenuItem.DropDownItems.Add("How to Play");
            var tsiAbout = optionsToolStripMenuItem.DropDownItems.Add("About");
            var tsiGoBack = optionsToolStripMenuItem.DropDownItems.Add("Go to Homescreen");
            var tsiExit = optionsToolStripMenuItem.DropDownItems.Add("Exit");

            // Add event handler for this ToolStipItems
            tsiHowToPlay.Click += new EventHandler(tsiHowToPlay_Click);
            tsiAbout.Click += new EventHandler(tsiAbout_Click);
            tsiGoBack.Click += new EventHandler(tsiGoBack_Click);
            tsiExit.Click += new EventHandler(tsiExit_Click);


            //tsiHowToPlay.Name = "tsiHowToPlay";
            //optionsToolStripMenuItem.DropDownItems.RemoveByKey("tsiHowToPlay");
            //optionsToolStripMenuItem.DropDownItems.Remove(tsiAbout);
        }


        private void tsiHowToPlay_Click(object sender, EventArgs e)
        {
            String howToPlay =
                "The game is played on four grids, two for each player. The grids are typically square – usually 10×10 – and the individual " +
                "squares in the grid are identified by letter and number. On one grid the player arranges ships and records the shots by the " +
                "opponent. On the other grid the player records his/her own shots. " +
                "\n\n" +
                "Before play begins, each player secretly arranges his/her ships on his/her primary grid. Each ship occupies a number of " +
                "consecutive squares on the grid, arranged either horizontally or vertically. The number of squares for each ship is determined " +
                "by the type of the ship. The ships cannot overlap (i.e., only one ship can occupy any given square in the grid). The types and " +
                "numbers of ships allowed are the same for each player. These may vary depending on the rules." +
                "\n\n" +
                "The following are the typical set of ships, as given in the Milton Bradley version of the rules:" +
                "\nAircraft carrier 5" +
                "\nBattleship 4" +
                "\nSubmarine 3" +
                "\nCruiser 3" +
                "\nDestroyer 2" +
                "\n\n" +
                "After the ships have been positioned, the game proceeds in a series of rounds. In each round, each player takes a turn to " +
                "announce a target square in the opponent's grid which is to be shot at. The opponent announces whether or not the square " +
                "is occupied by a ship, and if it is a \"miss\", the player marks their primary grid with a white peg; if a \"hit\" they mark this on " +
                "their own primary grid with a red peg. The attacking player notes the hit or miss on their own \"tracking\" grid with the " +
                "appropriate color peg (red for \"hit\", white for \"miss\"), in order to build up a picture of the opponent's fleet." +
                "\n\n" +
                "When all of the squares of a ship have been hit, the ship is sunk, and the ship's owner announces this (e.g. \"You sank my " +
                "battleship!\"). If all of a player's ships have been sunk, the game is over and their opponent wins.";
            MessageBox.Show(howToPlay, "How to Play");
        }

        private void tsiAbout_Click(object sender, EventArgs e)
        {
            String about = "The Battleship Game is a coursework assignment for AC22005 - Computer Systems 2B: " +
                "Architecture and Operating Systems at University of Dundee, UK";
            MessageBox.Show(about, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsiGoBack_Click(object sender, EventArgs e)
        {
            this.goBack = true;
            Close();
        }
        private void tsiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Battlefield_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Go Back button has been pressed
            if ((e.CloseReason == CloseReason.UserClosing) && (this.goBack == true))
            {
                DialogResult dialog = MessageBox.Show("Do you really want to End the battle and go to the Homescreen?", "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    // home screen will appear
                }
                else if (dialog == DialogResult.No)
                {
                    this.goBack = false;
                    e.Cancel = true;
                }
            }
            // Play Again button has been pressed
            else if ((e.CloseReason == CloseReason.UserClosing) && (this.playAgain == true))
            {
                // Hide the current form window
                this.Hide();

                // 0 = easy
                this.background.PlayLooping();
                ShipPlacement shipPlacement = new ShipPlacement(this.levelOfDifficulty, this.background, this.playersName);
                // Display the ShipPlacement form window
                shipPlacement.ShowDialog();
            }
            // Exit, X or Close window button has been pressed
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialog = MessageBox.Show("Do you really want to Exit the game?", "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }


        }

        private void btnAgainOrSurrender_Click(object sender, EventArgs e)
        {
            if (btnAgainOrSurrender.Text == "Surrender")
            {
                DialogResult dialog = MessageBox.Show("Do you really want to Surrender?", "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    if (File.Exists("..\\..\\sounds\\loser.wav"))
                    {
                        this.loser = new SoundPlayer("..\\..\\sounds\\loser.wav");
                        //hit.PlayLooping();
                        loser.Play();
                    }
                    MessageBox.Show("Computer wins!", "Ohh, no! Try again.");
                    this.computerWinCount++;
                    lblComputerWins.Text = "Computer - " + computerWinCount + " wins";

                    this.Display_computerAnswers();

                    for (int x = 0; x < computerGridVisible.GetLength(0); x++) // Loop for x
                    {
                        for (int y = 0; y < computerGridVisible.GetLength(1); y++)
                        {
                            computerGridVisible[x, y].Enabled = false;
                        }
                    }

                    this.Write_LeagueTable(1);

                    btnAgainOrSurrender.Text = "Play Again!";
                }
                else if (dialog == DialogResult.No)
                {
                    // nothing
                }
            }
            else
            {
                this.playAgain = true;
                Close();
            }
        }
    }
}
