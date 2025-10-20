public class Board
{

    public int startPosX;
    public int startPosY;
    public Rectangle[] rectangles;

    public Rectangle start;
    public Rectangle goal;

    public Board(int amount, int startPosX, int startPosY)
    {
        this.rectangles = new Rectangle[amount];
        this.startPosX = startPosX;
        this.startPosY = startPosY;
    }

    public void SetupAndRenderBoardNodes(int nodeSize, int screenWidth, int screenHeight, Color color)
    {
        int rowAmount = screenWidth / nodeSize;
        int posX = this.startPosX;
        int posY = this.startPosY;
        int rowCounter = 1;
        Rectangle rec;
        // Rectangle[] rectangles = new Rectangle[this.amount.Length];
        for (int i = 0; i < this.rectangles.Length; i++)
        {
            if (rowCounter == rowAmount)
            {
                posY += nodeSize;
                posX = this.startPosX;
                rowCounter = 1;
            }
            rec = new Rectangle((float)(posX * rowCounter), (float)posY, (float)nodeSize, (float)nodeSize);
            // Raylib.DrawRectangleLines(posX * rowCounter, posY, nodeSize, nodeSize, color);
            Raylib.DrawRectangleLines((int)rec.x, (int)rec.y, (int)rec.width, (int)rec.height, color);
            this.rectangles[i] = rec;
            rowCounter++;
        }
    }

    public Rectangle SetStartingNode(int i)
    {
        Rectangle rec = this.rectangles[i];
        this.start = rec;
        return rec;
    }
    public Rectangle SetEndingNode(int i)
    {
        Rectangle rec = this.rectangles[i];
        this.goal = rec;
        return rec;
    }

}