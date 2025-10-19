using System;

public class Program
{

    const int WINDOW_WIDTH = 800;
    const int WINDOW_HEIGHT = 600;

    const int NODE_SIZE = 10;

    public static Color WHITE = new Color(255, 255, 255, 255);
    public static Color RED = new Color(255, 0, 0, 255);
    public static Color BLACK = new Color(0, 0, 0, 255);

    public Vector2 mousePos = new Vector2();
    
    public static void Main(string[] args)
    {
        Raylib.InitWindow(WINDOW_WIDTH, WINDOW_HEIGHT, "Initialized Window from C");

        Raylib.SetTargetFPS(60);
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(WHITE);

            Raylib.DrawText(Raylib.GetFPS().ToString(), 10, 10, 24, RED);

            Raylib.DrawText(Raylib.GetMousePosition().x.ToString(), 50, 10, 24, RED);
            Raylib.DrawText(Raylib.GetMousePosition().y.ToString(), 100, 10, 24, RED);

            Board board = new Board(400, 30, 30);

            board.RenderBoardNodes(board.amount, board.startPosX, board.startPosY, 30, WINDOW_WIDTH, WINDOW_HEIGHT, BLACK);

            // for (int i = 0; i < board.amount; i++) {
            //     if (WINDOW_WIDTH - NODE_SIZE)
            //         Raylib.DrawRectangle(10, 10, 10, 10, BLACK);
            // }

            Raylib.EndDrawing();

        }

        Raylib.CloseWindow();
    }
}