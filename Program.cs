using System;

public class Program
{
    const int WINDOW_WIDTH      = 800;
    const int WINDOW_HEIGHT     = 600;
    const int NODE_SIZE         = 10;

    public static Color BLACK   = new Color(0, 0, 0, 255);
    public static Color WHITE   = new Color(255, 255, 255, 255);
    public static Color RED     = new Color(255, 0, 0, 255);
    public static Color GREEN   = new Color(0, 255, 0, 255);
    public static Color BLUE    = new Color(0, 0, 255, 255);

    public static Rectangle startPosition;
    public static Rectangle endPosition;

    public static void Main(string[] args)
    {
        Raylib.InitWindow(WINDOW_WIDTH, WINDOW_HEIGHT, "A STAR PATHFINDING");

        Raylib.SetTargetFPS(60);
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(WHITE);

            Raylib.DrawText(Raylib.GetFPS().ToString(), 10, 10, 24, RED);

            Raylib.DrawText(Raylib.GetMousePosition().x.ToString(), 50, 10, 24, RED);
            Raylib.DrawText(Raylib.GetMousePosition().y.ToString(), 100, 10, 24, RED);

            Board board = new Board(400, 30, 30);

            board.SetupAndRenderBoardNodes(30, WINDOW_WIDTH, WINDOW_HEIGHT, BLACK);

            for (int i = 0; i < board.rectangles.Length; i++)
            {
                if (Raylib.IsMouseButtonPressed((int)MouseButton.MOUSE_BUTTON_LEFT))
                {
                    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), board.rectangles[i]))
                    {
                        startPosition = board.SetStartingNode(i);
                    }
                }
                if (Raylib.IsMouseButtonPressed((int)MouseButton.MOUSE_BUTTON_RIGHT))
                {
                    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), board.rectangles[i]))
                    {
                        endPosition = board.SetEndingNode(i);
                    }
                }
            }
            
            Raylib.DrawRectangle((int)startPosition.x, (int)startPosition.y, (int)startPosition.width, (int)startPosition.height, RED);
            Raylib.DrawRectangle((int)endPosition.x, (int)endPosition.y, (int)endPosition.width, (int)endPosition.height, BLACK);

            Raylib.EndDrawing();
        }



        Raylib.CloseWindow();
    }
}