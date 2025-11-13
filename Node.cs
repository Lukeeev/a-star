public class Node
{
    public Rectangle rectangle;
    public bool traversable;
    public Vector2 position;
    public Vector2 centerPos;
    public Node parent;
    public int g;
    public int h;
    // public int f = g + h;
    public Node(bool traversable, float x, float y, int size)
    {
        this.traversable = traversable;
        position = new Vector2(x, y);
        centerPos = new Vector2(x + size / 2, y + size / 2);
        rectangle = new Rectangle(position.x, position.y, size, size);
    }
}