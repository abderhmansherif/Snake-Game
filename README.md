# Snake-Game
 Snake Game developed with C# 
Code explanation
 --------
 SetUp():

Initializes the game by clearing the snake's body.
Sets the snake's head to the center of the screen.
Randomly places the fruit on the grid.
Draw():

Clears the console and draws the game grid.
Displays the snake’s head (O), body (o), fruit (&), and the borders (#).
Shows the current score at the bottom of the screen.
HandleInput():

Checks for user input (arrow keys).
Changes the snake's direction based on the arrow key pressed, ensuring the snake doesn't reverse direction.
SnakeMovement():

Moves the snake by updating the head's position based on the current direction.
Adds the new head to the front of the snake's body list.
Removes the tail if the snake hasn't eaten the fruit.
CheckIfOver():

Checks if the snake has collided with the walls or itself.
Ends the game if any of these conditions are true.
CheckifSnakeEatFruit():

Checks if the snake’s head is at the same position as the fruit.
If true, it increases the score and generates a new fruit at a random position.
