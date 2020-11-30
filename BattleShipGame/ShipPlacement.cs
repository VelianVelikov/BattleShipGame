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
    public partial class ShipPlacement : Form
    {
        // Level of Difficulty, where 0 means an Easy level - random computer moves, and 1 m
        private int levelOfDifficulty;
        //This is to distinguish between exit and go back button
        //if it is set to true this means that go back button has been pressed
        private bool goBack = false;
        // Create 2-D array/grid of buttons for placing ships on the field
        Button[,] grid = new Button[10, 10];
        // Records of all placements in a dictionary.
        // uniqued id and Tuple(X, Y, SIZE, ORIENTATION)
        // This is useful for the undo function and the result will be parced to 
        // the next stage of the game, which is the battlefield.
        // NOTE id starts from 0 and is max 4
        Dictionary<int, Tuple<int, int, int, string>> dictOfShips = new Dictionary<int, Tuple<int, int, int, string>>();
        // Random variable
        Random r = new Random();
        SoundPlayer background;
        string playersName;


        public ShipPlacement(int levelOfDifficulty, SoundPlayer background, string playersName)
        {
            this.background = background;
            this.playersName = playersName;            

            // Initialise the new item
            InitializeComponent();

            //foreach (KeyValuePair<string, Tuple<int, int>> entry in leagueTable)
            //{
            //    Console.WriteLine(entry.Key + ", " + entry.Value.Item1 + ", " + entry.Value.Item2);
            //}

            //Load the menu options
            this.Load_ToolStipItems();

            //Set level of difficulty to a private field and changes the text of lblLevelOfDifficulty
            this.Check_LevelOfDifficulty(levelOfDifficulty);


            this.Display_Grid();

            this.ActiveControl = btnStartBattle;

        }

        private void Display_Grid()
        {
            for (int x = 0; x < grid.GetLength(0); x++) // Loop for x
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    grid[x, y] = new Button(); // Create button
                    grid[x, y].SetBounds(42 + 31 * x, 65 + 31 * y, 30, 30); // Set size & position
                    grid[x, y].BackColor = Color.FromArgb(144, 202, 249);   // Set colour
                    grid[x, y].FlatStyle = FlatStyle.Flat;
                    grid[x, y].FlatAppearance.BorderColor = Color.Honeydew;
                    grid[x, y].FlatAppearance.BorderSize = 0;
                    grid[x, y].FlatAppearance.MouseDownBackColor = Color.Lime;
                    grid[x, y].FlatAppearance.MouseOverBackColor = Color.FromArgb(33, 150, 243);
                    //grid[x, y].Text = Convert.ToString((x + 1) + ", " + (y + 1));
                    grid[x, y].Tag = Convert.ToString((x + 1) + ", " + (y + 1));
                    grid[x, y].Font = new Font("Arial", 6, FontStyle.Regular);
                    // Add link to the event handler to use when clicked
                    grid[x, y].Click += new EventHandler(this.gridEvent_Click);
                    Controls.Add(grid[x, y]);  // Put the item onto the GUI
                }
            }

            //grid[r.Next(10), r.Next(10)].BackColor = Color.Lime; // Random green placement
        }

        void gridEvent_Click(object sender, EventArgs e) // Event Handler
        {
            string[] tagData = ((Button)sender).Tag.ToString().Split(',');
            int x = Convert.ToInt32(tagData[0]);
            int y = Convert.ToInt32(tagData[1]);
            string orientation = btnOrientation.Tag.ToString();

            // if the ship is selected and the ship has not already be placed on the grid
            if (picShip5_selected.Visible == true && picShip5_selected.Cursor != Cursors.No)
            {
                // check if the move is valid
                if (this.Check_ValidPlacement(x, y, 5, orientation) == 0)
                {
                    // if it is valid place it on the grid
                    this.Place_Ship(x, y, 5, orientation);
                    // disable click event of the ship image
                    picShip5_selected.Click -= picShip5_selected_Click;
                    // chenge the curor when hovered
                    picShip5_selected.Cursor = Cursors.No;
                }
                // the move is not valid
                else
                {
                    MessageBox.Show("Invalid ship placement!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (picShip4_selected.Visible == true && picShip4_selected.Cursor != Cursors.No)
            {
                if (this.Check_ValidPlacement(x, y, 4, orientation) == 0)
                {
                    this.Place_Ship(x, y, 4, orientation);
                    // disable click event
                    picShip4_selected.Click -= picShip4_selected_Click;
                    // chenge the curor when hovered
                    picShip4_selected.Cursor = Cursors.No;
                }
                else
                {
                    MessageBox.Show("Invalid ship placement!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (picShip31_selected.Visible == true && picShip31_selected.Cursor != Cursors.No)
            {
                if (this.Check_ValidPlacement(x, y, 31, orientation) == 0)
                {
                    this.Place_Ship(x, y, 31, orientation);
                    // disable click event
                    picShip31_selected.Click -= picShip31_selected_Click;
                    // chenge the curor when hovered
                    picShip31_selected.Cursor = Cursors.No;
                }
                else
                {
                    MessageBox.Show("Invalid ship placement!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (picShip32_selected.Visible == true && picShip32_selected.Cursor != Cursors.No)
            {
                if (this.Check_ValidPlacement(x, y, 32, orientation) == 0)
                {
                    this.Place_Ship(x, y, 32, orientation);
                    // disable click event
                    picShip32_selected.Click -= picShip32_selected_Click;
                    // chenge the curor when hovered
                    picShip32_selected.Cursor = Cursors.No;
                }
                else
                {
                    MessageBox.Show("Invalid ship placement!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (picShip2_selected.Visible == true && picShip2_selected.Cursor != Cursors.No)
            {
                if (this.Check_ValidPlacement(x, y, 2, orientation) == 0)
                {
                    this.Place_Ship(x, y, 2, orientation);
                    // disable click event
                    picShip2_selected.Click -= picShip2_selected_Click;
                    // chenge the curor when hovered
                    picShip2_selected.Cursor = Cursors.No;
                }
                else
                {
                    MessageBox.Show("Invalid ship placement!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            // if all the ships has been placed
            else if (picShip5_selected.Cursor == Cursors.No && picShip4_selected.Cursor == Cursors.No && picShip31_selected.Cursor == Cursors.No && picShip32_selected.Cursor == Cursors.No && picShip2_selected.Cursor == Cursors.No)
            {
                MessageBox.Show("All ships have been placed already!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // no ship was selected
            else
            {
                MessageBox.Show("You should select ship first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //if (((Button)sender).BackColor == Color.Red) // is clicked on red?
            //{
            //    ((Button)sender).BackColor = Color.FromArgb(144, 202, 249); // Change colour
            //    grid[r.Next(10), r.Next(10)].BackColor = Color.Red;//Pick new mole
            //    Console.WriteLine("WHACKED!");//Output message
            //}
            //else                                        //NO
            //{
            //    Console.WriteLine("Missed!");//Output message
            //}
        }

        private void Undo_ShipPlacement(int x, int y, int size, string orientation)
        {
            if (orientation == "x")
            {
                for (int i = 0; i < size; i++)
                {
                    grid[x + i, y].BackColor = Color.FromArgb(144, 202, 249);
                }
            }
            else if (orientation == "y")
            {
                for (int i = 0; i < size; i++)
                {
                    grid[x, y + i].BackColor = Color.FromArgb(144, 202, 249);
                }
            }
        }

        private void Place_Ship(int x, int y, int size, string orientation)
        {
            x = x - 1;
            y = y - 1;

            // add data of the placement to the Dictionary of Ships
            // id starts form 0 to 4
            // if the dictionary is empty
            if (dictOfShips.Count == 0)
            {
                dictOfShips.Add(0, new Tuple<int, int, int, string>(x, y, size, orientation));
            }
            else
            {
                // get the int_id of last entry
                int oldID = dictOfShips.Keys.Last();
                // to make it unique
                int newID = oldID + 1;
                dictOfShips.Add(newID, new Tuple<int, int, int, string>(x, y, size, orientation));
            }

            if (size == 31 || size == 32)
            {
                size = 3;
            }

            if (orientation == "x")
            {
                for (int i = 0; i < size; i++)
                {
                    grid[x + i, y].BackColor = Color.Lime;
                }
            }
            else if (orientation == "y")
            {
                for (int i = 0; i < size; i++)
                {
                    grid[x, y + i].BackColor = Color.Lime;
                }
            }

        }

        // x and y in the range from [1, 10] so we need to subtract 1 leter in the code
        // size is the size of the ship 5, 4, 31, 32 or 2
        // orientation is "x" or "y"
        private int Check_ValidPlacement(int x, int y, int size, string orientation)
        {
            bool valid = true;
            x = x - 1;
            y = y - 1;

            if (size == 31 || size == 32)
            {
                size = 3;
            }


            if (orientation == "x")
            {
                if (x + size > 10)
                {
                    valid = false;
                }
                else
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (grid[x + i, y].BackColor == Color.Lime)
                        {
                            valid = false;
                        }
                    }
                }
            }
            else if (orientation == "y")
            {
                if (y + size > 10)
                {
                    valid = false;
                }
                else
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (grid[x, y + i].BackColor == Color.Lime)
                        {
                            valid = false;
                        }
                    }
                }
            }

            if (valid == true)
            {
                return 0;
            }
            else
            {
                return 1;
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

        private void ShipPlacement_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Go Back button has been pressed
            if ((e.CloseReason == CloseReason.UserClosing) && (this.goBack == true))
            {
                //Go back
                //Nothing to be written here
            }
            // Exit, X or Close window button has been pressed
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialog = MessageBox.Show("Do you really want to Exit the game?", "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if(dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }


        }

        private void picShip5_unselected_Click(object sender, EventArgs e)
        {
            //set the other ships to unselected
            if (picShip4_selected.Cursor != Cursors.No)
            {
                picShip4_selected.Visible = false;
                picShip4_unselected.Visible = true;
            }

            if (picShip31_selected.Cursor != Cursors.No)
            {
                picShip31_selected.Visible = false;
                picShip31_unselected.Visible = true;
            }

            if (picShip32_selected.Cursor != Cursors.No)
            {
                picShip32_selected.Visible = false;
                picShip32_unselected.Visible = true;
            }

            if (picShip2_selected.Cursor != Cursors.No)
            {
                picShip2_selected.Visible = false;
                picShip2_unselected.Visible = true;
            }

            picShip5_unselected.Visible = false;
            picShip5_selected.Visible = true;
        }

        private void picShip5_selected_Click(object sender, EventArgs e)
        {
            picShip5_selected.Visible = false;
            picShip5_unselected.Visible = true;
        }

        private void picShip4_unselected_Click(object sender, EventArgs e)
        {
            //set the other ships to unselected
            if (picShip5_selected.Cursor != Cursors.No) 
            {
                picShip5_selected.Visible = false;
                picShip5_unselected.Visible = true;
            }

            if (picShip31_selected.Cursor != Cursors.No)
            {
                picShip31_selected.Visible = false;
                picShip31_unselected.Visible = true;
            }

            if (picShip32_selected.Cursor != Cursors.No)
            {
                picShip32_selected.Visible = false;
                picShip32_unselected.Visible = true;
            }

            if (picShip2_selected.Cursor != Cursors.No)
            {
                picShip2_selected.Visible = false;
                picShip2_unselected.Visible = true;
            }



            picShip4_unselected.Visible = false;
            picShip4_selected.Visible = true;
        }

        private void picShip4_selected_Click(object sender, EventArgs e)
        {
            picShip4_selected.Visible = false;
            picShip4_unselected.Visible = true;
        }

        private void picShip31_unselected_Click(object sender, EventArgs e)
        {
            //set the other ships to unselected
            if (picShip5_selected.Cursor != Cursors.No)
            {
                picShip5_selected.Visible = false;
                picShip5_unselected.Visible = true;
            }

            if (picShip4_selected.Cursor != Cursors.No)
            {
                picShip4_selected.Visible = false;
                picShip4_unselected.Visible = true;
            }

            if (picShip32_selected.Cursor != Cursors.No)
            {
                picShip32_selected.Visible = false;
                picShip32_unselected.Visible = true;
            }

            if (picShip2_selected.Cursor != Cursors.No)
            {
                picShip2_selected.Visible = false;
                picShip2_unselected.Visible = true;
            }

            picShip31_unselected.Visible = false;
            picShip31_selected.Visible = true;
        }

        private void picShip31_selected_Click(object sender, EventArgs e)
        {
            picShip31_selected.Visible = false;
            picShip31_unselected.Visible = true;
        }

        private void picShip32_unselected_Click(object sender, EventArgs e)
        {
            //set the other ships to unselected
            if (picShip5_selected.Cursor != Cursors.No)
            {
                picShip5_selected.Visible = false;
                picShip5_unselected.Visible = true;
            }

            if (picShip4_selected.Cursor != Cursors.No)
            {
                picShip4_selected.Visible = false;
                picShip4_unselected.Visible = true;
            }

            if (picShip31_selected.Cursor != Cursors.No)
            {
                picShip31_selected.Visible = false;
                picShip31_unselected.Visible = true;
            }

            if (picShip2_selected.Cursor != Cursors.No)
            {
                picShip2_selected.Visible = false;
                picShip2_unselected.Visible = true;
            }

            picShip32_unselected.Visible = false;
            picShip32_selected.Visible = true;
        }

        private void picShip32_selected_Click(object sender, EventArgs e)
        {
            picShip32_selected.Visible = false;
            picShip32_unselected.Visible = true;
        }

        private void picShip2_unselected_Click(object sender, EventArgs e)
        {
            //set the other ships to unselected
            if (picShip5_selected.Cursor != Cursors.No)
            {
                picShip5_selected.Visible = false;
                picShip5_unselected.Visible = true;
            }

            if (picShip4_selected.Cursor != Cursors.No)
            {
                picShip4_selected.Visible = false;
                picShip4_unselected.Visible = true;
            }

            if (picShip31_selected.Cursor != Cursors.No)
            {
                picShip31_selected.Visible = false;
                picShip31_unselected.Visible = true;
            }

            if (picShip32_selected.Cursor != Cursors.No)
            {
                picShip32_selected.Visible = false;
                picShip32_unselected.Visible = true;
            }


            picShip2_unselected.Visible = false;
            picShip2_selected.Visible = true;
        }

        private void picShip2_selected_Click(object sender, EventArgs e)
        {
            picShip2_selected.Visible = false;
            picShip2_unselected.Visible = true;
        }


        private void btnOrientation_Click(object sender, EventArgs e)
        {
            // if it is set to vertical
            if (btnOrientation.Tag.ToString() == "y")
            {
                // change it to vertical
                btnOrientation.Text = "Horizontal";
                btnOrientation.Tag = "x";
            }
            // if it is set to horizontal
            else if (btnOrientation.Tag.ToString() == "x")
            {
                // change it to horizontal
                btnOrientation.Text = "Vertical";
                btnOrientation.Tag = "y";
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (dictOfShips.Count == 0)
            {
                MessageBox.Show("Nothing to undo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Get the last ship from the dictionary
                Tuple<int, int, int, string> shipToUndo = dictOfShips.Values.Last();

                int x = shipToUndo.Item1;
                int y = shipToUndo.Item2;
                int size = shipToUndo.Item3;
                string orientation = shipToUndo.Item4;

                if (size == 5)
                {
                    // enable click event of the ship image
                    picShip5_selected.Click += picShip5_selected_Click;
                    // chenge the curor when hovered
                    picShip5_selected.Cursor = Cursors.Default;

                    // hide selected and show unselected
                    picShip5_unselected.Visible = true;
                    picShip5_selected.Visible = false;

                    
                }
                else if (size == 4)
                {
                    // enable click event of the ship image
                    picShip4_selected.Click += picShip4_selected_Click;
                    // chenge the curor when hovered
                    picShip4_selected.Cursor = Cursors.Default;

                    // hide selected and show unselected
                    picShip4_unselected.Visible = true;
                    picShip4_selected.Visible = false;
                }
                else if (size == 31)
                {
                    // enable click event of the ship image
                    picShip31_selected.Click += picShip31_selected_Click;
                    // chenge the curor when hovered
                    picShip31_selected.Cursor = Cursors.Default;

                    // hide selected and show unselected
                    picShip31_unselected.Visible = true;
                    picShip31_selected.Visible = false;
                }
                else if (size == 32)
                {
                    // enable click event of the ship image
                    picShip32_selected.Click += picShip32_selected_Click;
                    // chenge the curor when hovered
                    picShip32_selected.Cursor = Cursors.Default;

                    // hide selected and show unselected
                    picShip32_unselected.Visible = true;
                    picShip32_selected.Visible = false;
                }
                else if (size == 2)
                {
                    // enable click event of the ship image
                    picShip2_selected.Click += picShip2_selected_Click;
                    // chenge the curor when hovered
                    picShip2_selected.Cursor = Cursors.Default;

                    // hide selected and show unselected
                    picShip2_unselected.Visible = true;
                    picShip2_selected.Visible = false;
                }

                if (size == 31 || size == 32)
                {
                    size = 3;
                }

                //Undo the ship placement
                this.Undo_ShipPlacement(x, y, size, orientation);

                // remove last item
                dictOfShips.Remove(dictOfShips.Keys.Last());
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            int x, y, size;
            string orientation;

            while (dictOfShips.Count != 0)
            {
                //Get the last ship from the dictionary
                Tuple<int, int, int, string> shipToUndo = dictOfShips.Values.Last();

                x = shipToUndo.Item1;
                y = shipToUndo.Item2;
                size = shipToUndo.Item3;
                orientation = shipToUndo.Item4;

                if (size == 5)
                {
                    // enable click event of the ship image
                    picShip5_selected.Click += picShip5_selected_Click;
                    // chenge the curor when hovered
                    picShip5_selected.Cursor = Cursors.Default;

                    // hide selected and show unselected
                    picShip5_unselected.Visible = true;
                    picShip5_selected.Visible = false;


                }
                else if (size == 4)
                {
                    // enable click event of the ship image
                    picShip4_selected.Click += picShip4_selected_Click;
                    // chenge the curor when hovered
                    picShip4_selected.Cursor = Cursors.Default;

                    // hide selected and show unselected
                    picShip4_unselected.Visible = true;
                    picShip4_selected.Visible = false;
                }
                else if (size == 31)
                {
                    // enable click event of the ship image
                    picShip31_selected.Click += picShip31_selected_Click;
                    // chenge the curor when hovered
                    picShip31_selected.Cursor = Cursors.Default;

                    // hide selected and show unselected
                    picShip31_unselected.Visible = true;
                    picShip31_selected.Visible = false;
                }
                else if (size == 32)
                {
                    // enable click event of the ship image
                    picShip32_selected.Click += picShip32_selected_Click;
                    // chenge the curor when hovered
                    picShip32_selected.Cursor = Cursors.Default;

                    // hide selected and show unselected
                    picShip32_unselected.Visible = true;
                    picShip32_selected.Visible = false;
                }
                else if (size == 2)
                {
                    // enable click event of the ship image
                    picShip2_selected.Click += picShip2_selected_Click;
                    // chenge the curor when hovered
                    picShip2_selected.Cursor = Cursors.Default;

                    // hide selected and show unselected
                    picShip2_unselected.Visible = true;
                    picShip2_selected.Visible = false;
                }

                if (size == 31 || size == 32)
                {
                    size = 3;
                }

                //Undo the ship placement
                this.Undo_ShipPlacement(x, y, size, orientation);

                // remove last item
                dictOfShips.Remove(dictOfShips.Keys.Last());
            }
        }

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            // reset the field first
            this.btnReset_Click(sender, e);

            int x, y;
            int orientationRandom;
            string orientation;

            do
            {
                x = this.r.Next(10) + 1;
                y = this.r.Next(10) + 1;

                orientationRandom = this.r.Next(2);

                if (orientationRandom == 0)
                {
                    orientation = "x";
                }
                else 
                {
                    orientation = "y";
                }
            }
            // do while valid random move is found
            while (this.Check_ValidPlacement(x, y, 5, orientation) != 0);

            // if it is valid place it on the grid
            this.Place_Ship(x, y, 5, orientation);

            //make it look like selected
            picShip5_unselected.Visible = false;
            picShip5_selected.Visible = true;

            // disable click event of the ship image
            picShip5_selected.Click -= picShip5_selected_Click;
            // chenge the curor when hovered
            picShip5_selected.Cursor = Cursors.No;

            do
            {
                x = this.r.Next(10) + 1;
                y = this.r.Next(10) + 1;

                orientationRandom = this.r.Next(2);

                if (orientationRandom == 0)
                {
                    orientation = "x";
                }
                else
                {
                    orientation = "y";
                }
            }
            // do while valid random move is found
            while (this.Check_ValidPlacement(x, y, 4, orientation) != 0);

            // if it is valid place it on the grid
            this.Place_Ship(x, y, 4, orientation);

            //make it look like selected
            picShip4_unselected.Visible = false;
            picShip4_selected.Visible = true;

            // disable click event of the ship image
            picShip4_selected.Click -= picShip4_selected_Click;
            // chenge the curor when hovered
            picShip4_selected.Cursor = Cursors.No;

            do
            {
                x = this.r.Next(10) + 1;
                y = this.r.Next(10) + 1;

                orientationRandom = this.r.Next(2);

                if (orientationRandom == 0)
                {
                    orientation = "x";
                }
                else
                {
                    orientation = "y";
                }
            }
            // do while valid random move is found
            while (this.Check_ValidPlacement(x, y, 31, orientation) != 0);

            // if it is valid place it on the grid
            this.Place_Ship(x, y, 31, orientation);

            //make it look like selected
            picShip31_unselected.Visible = false;
            picShip31_selected.Visible = true;

            // disable click event of the ship image
            picShip31_selected.Click -= picShip31_selected_Click;
            // chenge the curor when hovered
            picShip31_selected.Cursor = Cursors.No;

            do
            {
                x = this.r.Next(10) + 1;
                y = this.r.Next(10) + 1;

                orientationRandom = this.r.Next(2);

                if (orientationRandom == 0)
                {
                    orientation = "x";
                }
                else
                {
                    orientation = "y";
                }
            }
            // do while valid random move is found
            while (this.Check_ValidPlacement(x, y, 32, orientation) != 0);

            // if it is valid place it on the grid
            this.Place_Ship(x, y, 32, orientation);

            //make it look like selected
            picShip32_unselected.Visible = false;
            picShip32_selected.Visible = true;

            // disable click event of the ship image
            picShip32_selected.Click -= picShip32_selected_Click;
            // chenge the curor when hovered
            picShip32_selected.Cursor = Cursors.No;

            do
            {
                x = this.r.Next(10) + 1;
                y = this.r.Next(10) + 1;

                orientationRandom = this.r.Next(2);

                if (orientationRandom == 0)
                {
                    orientation = "x";
                }
                else
                {
                    orientation = "y";
                }
            }
            // do while valid random move is found
            while (this.Check_ValidPlacement(x, y, 2, orientation) != 0);

            // if it is valid place it on the grid
            this.Place_Ship(x, y, 2, orientation);

            //make it look like selected
            picShip2_unselected.Visible = false;
            picShip2_selected.Visible = true;

            // disable click event of the ship image
            picShip2_selected.Click -= picShip2_selected_Click;
            // chenge the curor when hovered
            picShip2_selected.Cursor = Cursors.No;
        }

        private void btnStartBattle_Click(object sender, EventArgs e)
        {
            Dictionary<int, Tuple<int, int, int, string>> playerShips = new Dictionary<int, Tuple<int, int, int, string>>(this.dictOfShips);
            this.btnRandomize_Click(sender, e);

            //MessageBox.Show(" ");

            Dictionary<int, Tuple<int, int, int, string>> computerShips = new Dictionary<int, Tuple<int, int, int, string>>(this.dictOfShips);

            this.background.Stop();
            // Hide the current form window
            this.Hide();

            // 0 = easy
            Battlefield battlefield = new Battlefield(this.levelOfDifficulty, playerShips, computerShips, this.playersName, this.background);
            // Display the ShipPlacement form window
            battlefield.ShowDialog();
        }


    }
}
