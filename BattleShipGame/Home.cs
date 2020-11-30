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

// Icon of the battleship has beed downloaded from https://icons8.com/icon/17887/battleship
// Velian Velikov - 180011401
// Lucas Khan - 180024439
// TODO VALID PLACEMENT WORKS YOU JUST NEED TO COLOUR THE BOXES
namespace BattleShipGame
{
    public partial class Home : Form
    {
        private SoundPlayer background;
        Dictionary<string, Tuple<int, int>> leagueTable = new Dictionary<string, Tuple<int, int>>();

        public Home()
        {
            InitializeComponent();
            menuStrip1.BackColor = Color.Honeydew;

            if (File.Exists("..\\..\\sounds\\background.wav"))
            {
                background = new SoundPlayer("..\\..\\sounds\\background.wav");
                background.PlayLooping();
                //sp.Play();
            }


            this.Load_ToolStipItems();

            this.Load_LeagueTable();

        }

        private void Load_LeagueTable()
        {
            this.leagueTable.Clear();
            lstLeagueTable.Items.Clear();
            string filePath = "..\\..\\Resources\\leagueTable.txt";

            if (File.Exists("..\\..\\Resources\\leagueTable.txt"))
            {
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filePath).ToList();

                if(lines.Count() == 0)
                {
                    lstLeagueTable.Items.Add("No one has entered the League Table yet.");
                    lstLeagueTable.Items.Add("Be the first one and Start a new Game!");
                }
                else
                {
                    foreach (String line in lines)
                    {
                        string[] lineData = line.Split(',');

                        leagueTable.Add(lineData[0], new Tuple<int, int>(Convert.ToInt32(lineData[1]), Convert.ToInt32(lineData[2])));

                        lstLeagueTable.Items.Add(lineData[0] + " - " + lineData[1] + " wins / " + lineData[2] + " loses");
                    }
                }
                
            }
            else 
            {
                lstLeagueTable.Items.Add("No one has entered the League Table yet.");
                lstLeagueTable.Items.Add("Be the first one and Start a new Game!");

            }

            //foreach (KeyValuePair<string, Tuple<int, int>> entry in leagueTable)
            //{
            //    Console.WriteLine(entry.Key + ", " + entry.Value.Item1 + ", " + entry.Value.Item2);
            //}

        }



        private void Load_ToolStipItems()
        {
            var tsiImport = optionsToolStripMenuItem.DropDownItems.Add("Import League Table");
            var tsiClear = optionsToolStripMenuItem.DropDownItems.Add("Clear League Table");
            var tsiHowToPlay = optionsToolStripMenuItem.DropDownItems.Add("How to Play");
            var tsiAbout = optionsToolStripMenuItem.DropDownItems.Add("About");
            var tsiExit = optionsToolStripMenuItem.DropDownItems.Add("Exit");

            // Add event handler for this ToolStipItems
            tsiImport.Click += new EventHandler(tsiImport_Click);
            tsiClear.Click += new EventHandler(tsiClear_Click);
            tsiHowToPlay.Click += new EventHandler(tsiHowToPlay_Click);
            tsiAbout.Click += new EventHandler(tsiAbout_Click);
            tsiExit.Click += new EventHandler(tsiExit_Click);


            //tsiHowToPlay.Name = "tsiHowToPlay";
            //optionsToolStripMenuItem.DropDownItems.RemoveByKey("tsiHowToPlay");
            //optionsToolStripMenuItem.DropDownItems.Remove(tsiAbout);
        }

        private void tsiImport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Import League Table from a file to be developed in the future.", "Import");
        }

        private void tsiClear_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to Clear the League Table?", "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                string filePath = "..\\..\\Resources\\leagueTable.txt";

                File.WriteAllText(filePath, String.Empty);
                lstLeagueTable.Items.Clear();

                this.Load_LeagueTable();
            }
            else if (dialog == DialogResult.No)
            {
               // nothing
            }
            
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

        private void tsiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            this.Start_Game();
        }

        private void Start_Game()
        {
            String name = txtName.Text;

            if (name == "")
            {
                MessageBox.Show("You should first enter a name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rbEasy.Checked)
                {
                    // Hide the current form window
                    this.Hide();

                    // 0 = easy
                    ShipPlacement shipPlacement = new ShipPlacement(0, this.background, name);
                    // Display the ShipPlacement form window
                    shipPlacement.ShowDialog();

                    
                    try
                    {
                        this.Show();
                        this.Load_LeagueTable();
                        this.background.PlayLooping();

                    }
                    catch (ObjectDisposedException e)
                    {
                        Console.WriteLine("Caught: {0}", e.Message);
                    }

                }
                else if (rbHard.Checked)
                {
                    // Hide the current form window
                    this.Hide();

                    // 1 = hard
                    ShipPlacement shipPlacement = new ShipPlacement(1, this.background, name);
                    // Display the ShipPlacement form window
                    shipPlacement.ShowDialog();

                    try
                    {
                        this.Show();
                        this.Load_LeagueTable();
                        this.background.PlayLooping();
                    }
                    catch (ObjectDisposedException e)
                    {
                        Console.WriteLine("Caught: {0}", e.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Unknown error. Please select level of difficulty");
                }

            }
        }

        // Note that Form.KeyPreview must be set to true for this event handler to be called.
        // If Enter key is pressed start the game
        void Home_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Enter key pressed
                this.Start_Game();
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
