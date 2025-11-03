public class Board
{
    public Node[,] nodes;
    public Rectangle start;
    public Rectangle goal;

    public Board(int columns, int rows, int nodeSize)
    {
        this.nodes = new Node[columns, rows];

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                float posX = i * nodeSize;
                float posY = j * nodeSize;

                this.nodes[i, j] = new Node(true, posX, posY, nodeSize);
            }
        }
    }

    public void RenderBoardNodes(int nodeSize, int screenWidth, int screenHeight, Color color)
    {
        for (int i = 0; i < this.nodes.GetLength(0); i++)
        {
            for (int j = 0; j < this.nodes.GetLength(1); j++)
            {
                Node node = this.nodes[i, j]; 
                Raylib.DrawRectangleLines(
                    (int)node.rectangle.x,
                    (int)node.rectangle.y,
                    (int)node.rectangle.width,
                    (int)node.rectangle.height,
                    color
                );

            }
        }
    }
    public Rectangle SetStartingNode(int i, int j)
    {
        Node node = this.nodes[i, j];
        this.start = node.rectangle;
        return node.rectangle;
    }
    public Rectangle SetEndingNode(int i, int j)
    {
        Node node = this.nodes[i, j];
        this.goal = node.rectangle;
        return node.rectangle;
    }

}