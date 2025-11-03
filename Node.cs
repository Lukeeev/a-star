public class Node
{
    public Rectangle rectangle;
    public bool traversable;
    public Vector2 position;
    public Node parent;
    public int g;
    public int h;
    // public int f = g + h;
    public Node(bool traversable, float x, float y, int size)
    {
        this.traversable = traversable;
        position = new Vector2(x, y);
        rectangle = new Rectangle(position.x, position.y, size, size);
    }
}