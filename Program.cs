using System;
public class Program
{
    const int INITIAL_WINDOW_WIDTH = 800;
    const int INITIAL_WINDOW_HEIGHT = 600;
    const int NODE_SIZE = 50;

    static int windowWidth;
    static int windowHeight;

    static int screenNodeAmount;

    public static Color BLACK = new Color(0, 0, 0, 255);
    public static Color WHITE = new Color(255, 255, 255, 255);
    public static Color RED = new Color(255, 0, 0, 255);
    public static Color GREEN = new Color(0, 255, 0, 255);
    public static Color BLUE = new Color(0, 0, 255, 255);

    public static Rectangle startPosition;
    public static Rectangle endPosition;

    public static void Main(string[] args)
    {
        Raylib.SetConfigFlags(Raylib.FLAG_WINDOW_RESIZABLE);
        Raylib.InitWindow(INITIAL_WINDOW_WIDTH, INITIAL_WINDOW_HEIGHT, "A STAR PATHFINDING");

        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {

            windowWidth = Raylib.GetScreenWidth();
            windowHeight = Raylib.GetScreenHeight();
            
            screenNodeAmount = (windowWidth * windowHeight) / (int)(NODE_SIZE * NODE_SIZE);
            Console.WriteLine($"screenNodeAmount: {screenNodeAmount}");
            
            Raylib.BeginDrawing();
            Raylib.ClearBackground(WHITE);

            Raylib.DrawText(Raylib.GetFPS().ToString(), 10, 10, 24, RED);

            Raylib.DrawText(Raylib.GetMousePosition().x.ToString(), 50, 10, 24, RED);
            Raylib.DrawText(Raylib.GetMousePosition().y.ToString(), 100, 10, 24, RED);

            Board board = new Board(screenNodeAmount, NODE_SIZE, NODE_SIZE);

            board.SetupAndRenderBoardNodes(NODE_SIZE, windowWidth, windowHeight, BLACK);

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