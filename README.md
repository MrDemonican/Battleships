# Battleship
C# Battleship consol app - created for the purposes of recruitment

1. About project:
A project was created as part of a response to a recruitment task.

For now, only the part of the application responsible for simulating the performance of two AI Players is working.
In the future, there will be implemented a module that will allow you to play against the computer AI Player.

The description of how the methods works can be found directly in the project files.

Application Environment: Console  
Language version: .Net 5.0 / C#


2. File descriptions:  

FOLDERS:  
AppCore - main project folder.  

Boards - First folder located in AppCore, it contains:  
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Coordinates.cs - class responsible for managing coordinates.<space><space>*<space>  
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CoordinatesForHuman.cs - class that will be responsible for managing coordinates for human actions (Not in use currently). 
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnemyFoggedBoard.cs - class responsible for managing one of game boards (Marks hits, misses and unexplored fields).   
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyBoard.cs - class responsible for managing one of game boards (current Player Board - includes ships, enemy shots etc.).  
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Squer.cs - class responsible for managing every single squer/field on the boards.
					
Games - Second folder located in AppCore, it contains:  
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Game.cs - class responsible for managing AiPlayer vs AiPlayer logic of whole game (turns, messages, result etc.).  
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GameVs.cs - class responsible for managing Human vs AiPlayer game logic (currently not in use). 
				
Ships - Third folder located in AppCore, it contains:  
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ship.cs -  class used for: storing ships properties (5 kind of ships). 

Enlargements - Last folder located in AppCore, it contains:  
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnumEnlargement.cs - class that helps to send "Description" of squer to methods located in other classes.  
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SquerEnlargement.cs - class that provides logic for few methods that are located in other classes (for example - DrawingBoard method). 
							 
CLASS:  
	AiPlayer.cs - class that contains computer player logic, managing computer AiPlayer behavor.  
	HumanPlayer.cs - class that contains human player logc (currently not in use).  
	Enums.cs - class that containt description of squer/field status.  
	Program.cs - "Main" class that is responsible for launching the application, responsible for Menu page navigation, runs the requested application mode etc.  

3. More informations:  
Of course, in places where such information can be useful for understanding the operation of the program you can find more detailed (and technical) informations are included in the comments of every file.   

4. Known / detected bugs:  
A) Problem with playing in Human vs computer mode - the logic operation that are responsible for Human player are not implemented (YET :))  

5. Advices:  
A) In computer vs computer play mode you should limit the number of rounds(1000 rounds may take a while to end...) that you want to watch (in this mode you can define how many rounds of game bots should play with eachother)  
