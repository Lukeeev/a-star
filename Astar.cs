/*
What A* Search Algorithm does is that at each step it picks the node according to a value-‘f’ 
which is a parameter equal to the sum of two other parameters - ‘g’ and ‘h’. 
At each step it picks the node/cell having the lowest ‘f’, and process that node/cell.
We define ‘g’ and ‘h’ as simply as possible below
g = the movement cost to move from the starting point to a given square on the grid, following the path generated to get there. 
h = the estimated movement cost to move from that given square on the grid to the final destination. This is often referred to as the heuristic, which is nothing but a kind of smart guess. We really don’t know the actual distance 
until we find the path, because all sorts of things can be in the way (walls, water, etc.). 
There can be many ways to calculate this ‘h’ which are discussed in the later sections.
*/

public class Astar
{
    public readonly int[] board;
    public readonly int start;
    public readonly int goal;

    public Astar(int[] board, int start, int goal)
    {
        this.board = board;
        this.start = start;
        this.goal = goal;
    }
}