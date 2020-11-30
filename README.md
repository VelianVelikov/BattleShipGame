# BattleShipGame

This is a C# game project that simulates the classic Battleship Game. It is played by a human user and the computer itself. The game is played on two grids, one for each player. On one grid the player arranges 5 different ships placements and on the other attacks and tries to sink all of the opponent’s ships. The game ends when one of the players sinks all of the ships that belong to the opponent.

![alt tag](img/home.png)
![alt tag](img/shipselection.png)
![alt tag](img/gameplay.png)

[Full rules of the game available in the Option menu]
The game consists of two levels: easy and hard. It starts with the Home screen where the user can enjoy the background music, enter his/her name, choose level of difficulty and have a glance at the League Table. The data of the League Table is read and written to a .TXT file, and if the name is already listed there the user can continue playing under this name and increment the win/lose counter. The game also has a drop-down menu with variable options throughout the different form windows: Import League Table, Clear League Table, How to Play, About, Go to Home screen and Exit.  
When the player starts a new game he/she is presented with a 10x10 grid and five ships to place. They must not overlap and can be placed either vertically, or horizontally. What is more, the option to reset, undo and the ability to make a random placement of all the ships is present, thus giving the user full control of how to make his/her strategy. 
When the battle begins the user can see its ship placements on the left side and a 10x10 darker blue grid on the right. The darker blue grid is the opponent’s field on which the user can click and make a guess of the opponent’s ship placements. If it is a hit, a short explosion sound is played and the single field is coloured in red. If it is a miss, a sound resembling a droplet of water is played and the single field is coloured in lighter blue. After each user turn the computer also makes a turn based on the difficulty of the game. In the easy level the computer attacks the player’s fleet on random basis, while in the hard level each third move that it makes is an absolute hit.  If the user sinks all of the opponent’s ships a trumpet like winner sound is played and congratulations message displayed. If it is the case that the user loses against the computer, a disappointing laughing sound is played and regretful message displayed. What is more, after the user makes a lose he/she can see where the actual opponent’s ships were (marked with lime green colour). 
The player’s and computer’s winning counts are displayed bellow their corresponding grid. The option to surrender and play again after a loss or win can be seen in the middle bottom part of the battlefield window.
For future development:
•	The option to import a league table from an external file could be implemented, or;
•	The option to show during battlefield gameplay what type of ship has been sunk after a hit.
The work was separated unevenly, due to the absolute absence of one of the team members and the unhealthy condition of the other. Thus, the work was mostly carried by Velian, while Lucas made the Home page and helped with report part of the game development. 

Links and sources:
Icon of the battleship has been downloaded from: https://icons8.com/icon/17887/battleship
Sounds effects and background music have been downloaded from: https://freesound.org/
