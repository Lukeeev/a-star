using System;
public class Program
{
    const int INITIAL_WINDOW_WIDTH = 800;
    const int INITIAL_WINDOW_HEIGHT = 600;
    const int NODE_SIZE = 70;

    static int windowWidth;
    static int windowHeight;

    static int screenNodeAmount;

    public static Color BLACK = new Color(0, 0, 0, 255);
    public static Color WHITE = new Color(255, 255, 255, 255);
    public static Color RED = new Color(255, 0, 0, 255);
    public static Color GREEN = new Color(0, 255, 0, 255);
    public static Color BLUE = new Color(0, 0, 255, 255);
    public static Color YELLOW = new Color(255, 255, 0, 255);

    public static Rectangle startPosition;
    public static Rectangle endPosition;

    public static void Main(string[] args)
    {
        Raylib.SetConfigFlags(Raylib.FLAG_WINDOW_RESIZABLE);
        Raylib.InitWindow(INITIAL_WINDOW_WIDTH, INITIAL_WINDOW_HEIGHT, "A STAR PATHFINDING");

        Raylib.SetTargetFPS(60);

        int prevWidth = INITIAL_WINDOW_WIDTH;
        int prevHeight = INITIAL_WINDOW_HEIGHT;

        int columns = INITIAL_WINDOW_WIDTH / NODE_SIZE;
        int rows = INITIAL_WINDOW_HEIGHT / NODE_SIZE;

        screenNodeAmount = (INITIAL_WINDOW_WIDTH / NODE_SIZE) * (INITIAL_WINDOW_HEIGHT / NODE_SIZE);

        Board board = new Board(
            columns,
            rows,
            NODE_SIZE
        );

        while (!Raylib.WindowShouldClose())
        {
            windowWidth = Raylib.GetScreenWidth();
            windowHeight = Raylib.GetScreenHeight();

            // Vector2 mousePos = Raylib.GetMousePosition();
            // Console.WriteLine($"x: {mousePos.x} y: {mousePos.y}");
            
            if (windowWidth != prevWidth || windowHeight != prevHeight)
            {
                columns = windowWidth / NODE_SIZE;
                rows = windowHeight / NODE_SIZE;
                screenNodeAmount = columns * rows;

                board = new Board(columns, rows, NODE_SIZE);
                prevWidth = windowWidth;
                prevHeight = windowHeight;
            }
            // Console.WriteLine($"screenNodeAmount: {screenNodeAmount}");

            Raylib.BeginDrawing();
            Raylib.ClearBackground(WHITE);

            board.RenderBoardNodes(NODE_SIZE, windowWidth, windowHeight, BLACK);

            if (Raylib.IsMouseButtonPressed((int)MouseButton.MOUSE_BUTTON_LEFT))
            {
                for (int i = 0; i < board.nodes.GetLength(0); i++)
                {
                    for (int j = 0; j < board.nodes.GetLength(1); j++)
                    {
                        if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), board.nodes[i, j].rectangle))
                        {
                            startPosition = board.SetStartingNode(i, j);
                        }
                    }
                }
            }
            if (Raylib.IsMouseButtonPressed((int)MouseButton.MOUSE_BUTTON_RIGHT))
            {
                for (int i = 0; i < board.nodes.GetLength(0); i++)
                {
                    for (int j = 0; j < board.nodes.GetLength(1); j++)
                    {
                        if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), board.nodes[i, j].rectangle))
                        {
                            endPosition = board.SetEndingNode(i, j);
                        }
                    }
                }
            }
            Raylib.DrawRectangle((int)startPosition.x, (int)startPosition.y, (int)startPosition.width, (int)startPosition.height, GREEN);
            Raylib.DrawRectangle((int)endPosition.x, (int)endPosition.y, (int)endPosition.width, (int)endPosition.height, YELLOW);

            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}