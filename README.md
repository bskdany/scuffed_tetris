# scuffed_tetris

I tried to make tetris with Unity but then realized that it couldn't be made the way I firstly concieved it.
Basically instead of using a grid as every sane persone would I used 2DCollisions and an open space.
The game "works" in a really bad way because it has to check for collisions from every center of the four squares that make a tetris piece and to setup this I just had to hardcode them.
Then there is the movement, the tetris piece needs to go down every amount of time but you still should be able to move it left and right. Sometimes there is an error that occurs when both checking on the sides to move left or right and the down movement happen at the same frame.
Then there is the rotation problem, shloud I just hardcode 4 different cases for almost every piece of tetris based on it's rotation? And what about the blocks disappearing when a line is formed? Yeah to do all of that I should just have used a grid.
For now I'll just keep this as an example of why I should plan things before coding them.
