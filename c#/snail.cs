public class SnailSolution
{
    public static int[] Snail(int[][] array)
    {
        var traverser = new Traverser(array);
        int[] result = new int[array.Length * array[0].Length];

        int iteration = 0;
        while (!traverser.IsDone())
        {
            var position = traverser.Next();
            result[iteration] = array[position.y][position.x];
            iteration++;
        }
        return result;
    }
}

enum Direction
{
    RIGHT = 1,
    DOWN,
    LEFT,
    UP
}

class Traverser
{
    private readonly DirectionTracker directionTracker;
    private Direction direction;
    private Limit limit;
    private Position position;
    private int iteration;
    private readonly int maxIteration;

    public Traverser(int[][] array)
    {
        limit = new Limit(array.Length - 1, array[0].Length - 1);
        directionTracker = new DirectionTracker();
        maxIteration = array.Length * array[0].Length;
        iteration = 0;
    }

    public bool IsDone()
    {
        return maxIteration <= iteration;
    }

    public Position Next()
    {
        iteration++;
        switch (direction)
        {
            default:
                direction = directionTracker.Next();
                position = new Position { x = 0, y = 0 };
                break;
            case Direction.RIGHT:
                if (position.x < limit.Right)
                {
                    position.x++;
                }
                else
                {
                    limit.Top++;
                    position.y++;
                    direction = directionTracker.Next();
                }
                break;
            case Direction.DOWN:
                if (position.y < limit.Bottom)
                {
                    position.y++;
                }
                else
                {
                    limit.Right--;
                    position.x--;
                    direction = directionTracker.Next();
                }
                break;
            case Direction.LEFT:
                if (position.x > limit.Left)
                {
                    position.x--;
                }
                else
                {
                    limit.Bottom--;
                    position.y--;
                    direction = directionTracker.Next();
                }
                break;
            case Direction.UP:
                if (position.y > limit.Top)
                {
                    position.y--;
                }
                else
                {
                    limit.Left++;
                    position.x++;
                    direction = directionTracker.Next();
                }
                break;
        }
        return position;
    }
}

class DirectionTracker
{
    private Direction currentDirection;
    public Direction Next()
    {
        switch (currentDirection)
        {
            default:
            case Direction.UP:
                currentDirection = Direction.RIGHT;
                break;
            case Direction.RIGHT:
                currentDirection = Direction.DOWN;
                break;
            case Direction.DOWN:
                currentDirection = Direction.LEFT;
                break;
            case Direction.LEFT:
                currentDirection = Direction.UP;
                break;
        }

        return currentDirection;
    }
}

struct Position
{
    public int x;
    public int y;
}

struct Limit
{
    public Limit(int verticalLimit, int horizontalLimit)
    {
        Top = 0;
        Right = horizontalLimit;
        Left = 0;
        Bottom = verticalLimit;
    }

    public int Top;
    public int Right;
    public int Left;
    public int Bottom;
}