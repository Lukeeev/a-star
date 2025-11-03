using System;
using System.Collections.Generic;
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

/*
OPEN - list of nodes to be evaluated
CLOSED - list of nodes already evaluated

add the START node to the OPEN list

loop
    current = node in the OPEN list with the lowest f cost
    remove current from the OPEN list
    add current to the CLOSED list

    if current is the target node //path has been found
        return
    
    foreach neighbour of the current node
        if neighbour is not traversable, or neighbour is in CLOSED 
            skip to the next neighbour
        
        if new path to neighbour is shorter OR neighbour is not in OPEN
            set f cost of neighbour
            set parent of neighbour to current
            if neighbour is not in OPEN
                add neighbour to OPEN
*/

public class Astar
{
    public readonly int[] board;
    public Dictionary<int, Node> openList = new Dictionary<int, Node>();
    public Dictionary<int, Node> closedList = new Dictionary<int, Node>();

    public readonly int start;
    public readonly int goal;

    public Astar(int[] board, int start, int goal)
    {
        this.board = board;
        this.start = start;
        this.goal = goal;
    }


}