using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct Color
{
    byte r;
    byte g;
    byte b;
    byte a;
    public Color(byte r, byte g, byte b, byte a)
    {
        this.r = r;
        this.g = g;
        this.b = b;
        this.a = a;
    }
}

public struct Vector2
{
    public float x;
    public float y;

    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}

public struct Rectangle
{
    float x;                // Rectangle top-left corner position x
    float y;                // Rectangle top-left corner position y
    float width;            // Rectangle width
    float height;           // Rectangle height

    public Rectangle(float x, float y, float width, float height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }
}

public enum MouseButton
{
    MOUSE_BUTTON_LEFT = 0,       // Mouse button left
    MOUSE_BUTTON_RIGHT = 1,       // Mouse button right
    MOUSE_BUTTON_MIDDLE = 2,       // Mouse button middle (pressed wheel)
    MOUSE_BUTTON_SIDE = 3,       // Mouse button side (advanced mouse device)
    MOUSE_BUTTON_EXTRA = 4,       // Mouse button extra (advanced mouse device)
    MOUSE_BUTTON_FORWARD = 5,       // Mouse button forward (advanced mouse device)
    MOUSE_BUTTON_BACK = 6,       // Mouse button back (advanced mouse device)
};

public static class Raylib
{

    [DllImport("libraylib.so", EntryPoint = "InitWindow")]
    public static extern void InitWindow(int width, int height, string title);
    [DllImport("libraylib.so", EntryPoint = "WindowShouldClose")]
    public static extern bool WindowShouldClose();

    [DllImport("libraylib.so", EntryPoint = "BeginDrawing")]
    public static extern void BeginDrawing();

    [DllImport("libraylib.so", EntryPoint = "ClearBackground")]
    public static extern void ClearBackground(Color color);

    [DllImport("libraylib.so", EntryPoint = "DrawText")]
    public static extern void DrawText(string text, int posX, int posY, int fontSize, Color color);

    [DllImport("libraylib.so", EntryPoint = "GetMousePosition")]
    public static extern Vector2 GetMousePosition();

    [DllImport("libraylib.so", EntryPoint = "IsMouseButtonPressed")]
    public static extern bool IsMouseButtonPressed(int button);

    [DllImport("libraylib.so", EntryPoint = "DrawRectangleLines")]
    public static extern void DrawRectangleLines(int posX, int posY, int width, int height, Color color);

    [DllImport("libraylib.so", EntryPoint = "DrawLine")]
    public static extern void DrawLine(int startPosX, int startPosY, int endPosX, int endPosY, Color color);

    [DllImport("libraylib.so", EntryPoint = "CloseWindow")]
    public static extern void CloseWindow();

    [DllImport("libraylib.so", EntryPoint = "EndDrawing")]
    public static extern void EndDrawing();

    [DllImport("libraylib.so", EntryPoint = "SetTargetFPS")]
    public static extern void SetTargetFPS(int fps);

    [DllImport("libraylib.so", EntryPoint = "GetFPS")]
    public static extern int GetFPS();

    [DllImport("libraylib.so", EntryPoint = "CheckCollisionPointRec")]
    public static extern bool CheckCollisionPointRec(Vector2 point, Rectangle rec);                                         // Check if point is inside rectangle

}
