# BattleShipGame

This is a BattleShip game which tries to demonstrate SOLID principle and a TDD approach.

**Currently supports:**
.net Framework : 5.0 

### Game Rules

At the moment, this is a single player game with one ship to be placed. 

The aim of the game is to attack the ships on board until the player has lost, that is, the player has lost his ship.

### Steps to Game

Place Ship
* Enter Row and Column as integer
* Enter Direction as a string which can only be U,D,L,R.
* Once the direction is entered, the game will try to point the ship in supplied direction.

Attack
* Enter Row as integer
* Enter Column as integer
* You will be notified if the attack was a HIT or a MISS!

### How To Run the Game ? 

* Clone https://github.com/BizCover/BizCover.Start
* Open the solution file in Visual Studio 
* Build the solution (Restore and packages will be done here)
* Run the application (F5) to view console. 

