public class Board
{

    public int amount;
    public int startPosX;
    public int startPosY;

    public Board(int amount, int startPosX, int startPosY)
    {
        this.amount = amount;
        this.startPosX = startPosX;
        this.startPosY = startPosY;
    }

    // private Board adjustBoard(int amount)
    // {
    //     return (amount / 2);
    // }

    public void RenderBoardNodes(int amount, int startPosX, int startPosY, int nodeSize, int screenWidth, int screenHeight, Color color)
    {
        int rowAmount = screenWidth / nodeSize;
        int posX = startPosX;
        int posY = startPosY;
        int rowCounter = 1;
        for (int i = 0; i < amount; i++)
        {
            if (rowCounter == rowAmount)
            {
                posY += nodeSize + 5;
                posX = startPosX;
                rowCounter = 1;

            }
            Raylib.DrawRectangleLines(posX * rowCounter, posY, nodeSize, nodeSize, color);
            rowCounter++;
        }
    }

    // TODO: Implement the setting of start and gol positions


}