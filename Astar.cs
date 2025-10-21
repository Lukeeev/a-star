/*

    Each cell / node has 3 key values:
        g - the cost from the start to this cell
        h - the heuristic, an estimate of the cost from this cell to the goal
            - can be calculated with the Manhattan distance: |x1 - x2| + |y1 - y2| 
        f = g + h - the total estimated cost of going through this cell to reach the goal

    In A* algorithm, we keep track of two lists / collections: Open list and Closed list
        - can be a List (dynamic array) or Hashmap or etc.
        Open list - represents cells that are candidates for exploration.
            - At the start of the algorithm, the start cell goes here with g = 0 and h = distance to the end
        Closed list - contains cells that have already been explored

    Algorithm steps:
        1. Put Start cell into Open list and pick the cell with the lowest f score
            - check if it is the goal, if yes then stop
        2. Move this cell from the Open list to the Closed one
        3. For each neighbor of this cell (up, down, left, right) or check diagonals aswell
            - Ignore it if it's in a Closed list or an obstacle
            - Calculate the g score if we go there from the current cell (this is 1 for all neighbors in a 
            uniform grid like this one) - so what decides? the heuristic and the final equation of f = g + h
            And if multiple neighbors have the same f, then pick whichever
            - If the neighbor is not in the open list, add it and record its parent and its g, h and f values
            - If it’s already in the open list but the new g is smaller, update it — you found a better route to that cell.
        4. Repeat the cycle until you reach the goal.

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