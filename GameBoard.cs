using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSU.CIS300.Snake
{

    /// <summary>
    /// direction enum
    /// </summary>
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    /// <summary>
    /// status of the snake enum
    /// </summary>
    public enum SnakeStatus
    {
        Moving,
        InvalidDirection,
        Eating,
        Collision,
        Win
    }
    /// <summary>
    /// Game board class
    /// </summary>
    public class GameBoard
    {
        /// <summary>
        /// game node
        /// </summary>
        public GameNode Food { get; set; }
        /// <summary>
        /// head of the snake
        /// </summary>
        public GameNode Head { get; set; }
        /// <summary>
        /// grid of game nodes
        /// </summary>
        public GameNode[,] Grid { get; set; }
        /// <summary>
        /// tail of the snake
        /// </summary>
        public GameNode Tail { get; set; }
        /// <summary>
        /// snake size
        /// </summary>
        public int SnakeSize { get; set; }
        /// <summary>
        /// size of snake
        /// </summary>
        private int _size;
        
        /// <summary>
        /// direction of the snake ai
        /// </summary>
        private Direction[] _aiDirection;
        /// <summary>
        /// left right array
        /// </summary>
        private Direction[] _leftRight;
        /// <summary>
        /// up down array
        /// </summary>
        private Direction[] _upDown;
        /// <summary>
        /// random number generator
        /// </summary>
        private static Random _random;

        public GameBoard(int size)
        {
            _size = size;
            Grid = new GameNode[size, size];

            // Initialize the grid
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Grid[x, y] = new GameNode(x, y) { Data = GridData.Empty };
                }
            }

            // Set the snake's head and tail to the center of the board
            int center = size / 2;
            Grid[center, center].Data = GridData.SnakeHead;
            Head = Grid[center, center];
            Tail = Grid[center, center];

            // Add initial food (if required)
            AddFood();
        }




        /// <summary>
        /// add food to the board
        /// </summary>
        public void AddFood()
        {
            _random = new Random();

            while (true)
            {
                // Generate random coordinates
                int x = _random.Next(0, _size);
                int y = _random.Next(0, _size);

                // Check if the node is empty
                if (Grid[x, y].Data == GridData.Empty)
                {
                    // Place food on the node
                    Grid[x, y].Data = GridData.SnakeFood;
                    Food = Grid[x, y];
                    break;
                }
            }
        }

        /// <summary>
        /// gets the node that would be next from current
        /// </summary>
        /// <param name="dir">direction</param>
        /// <param name="current">current</param>
        /// <returns>next node</returns>
        public GameNode GetNextNode(Direction dir, GameNode current)
        {
            // Calculate the next position based on the direction
            int nextX = current.X;
            int nextY = current.Y;

            switch (dir)
            {
                case Direction.Up:
                    nextY -= 1;
                    break;
                case Direction.Down:
                    nextY += 1;
                    break;
                case Direction.Left:
                    nextX -= 1;
                    break;
                case Direction.Right:
                    nextX += 1;
                    break;
                case Direction.None:
                    return current; // No movement
            }

            // Check if the next position is within the bounds of the grid
            if (nextX < 0 || nextX >= _size || nextY < 0 || nextY >= _size)
            {
                return null; // Out of bounds
            }

            // Return the next node
            return Grid[nextX, nextY];
        }


        /// <summary>
        /// moves the snake in the given direction
        /// </summary>
        /// <param name="dir">dir</param>
        /// <returns>direction</returns>
        public SnakeStatus MoveSnake(Direction dir)
        {
            // Get the next node in the direction the snake is moving
            GameNode nextNode = GetNextNode(dir, Head);

            // Check for collision with wall
            if (nextNode == null)
            {
                return SnakeStatus.Collision;
            }

            // Check for invalid direction (backtracking into the neck)
            if (Head.SnakeEdge == nextNode)
            {
                return SnakeStatus.InvalidDirection;
            }

            // Check for collision with the snake's own body
            if (nextNode.Data == GridData.SnakeBody)
            {
                return SnakeStatus.Collision;
            }

            // Move forward:
            // 1. Mark current head as body
            Head.Data = GridData.SnakeBody;

            // 2. Link current head to new head
            Head.SnakeEdge = nextNode;

            // 3. Set the new head's data
            nextNode.Data = GridData.SnakeHead;

            // 4. Update head reference
            Head = nextNode;

            // 5. Check for food
            if (nextNode == Food)
            {
                SnakeSize++;

                if (SnakeSize == _size * _size)
                {
                    return SnakeStatus.Win; // Snake fills the grid
                }

                AddFood(); // Add new food after eating
                return SnakeStatus.Eating;
            }

            // 6. If snake did not eat, check if we should cut the tail
            if (Head != Tail && Tail.SnakeEdge != null)
            {
                // Clear the tail node
                Tail.Data = GridData.Empty;

                // Move the tail forward
                GameNode newTail = Tail.SnakeEdge;

                // Break the link from old tail to the rest
                Tail.SnakeEdge = null;

                // Update tail reference
                Tail = newTail;
            }

            return SnakeStatus.Moving;
        }



        /// <summary>
        /// returns a list of game nodes that represent the snake path
        /// </summary>
        /// <returns>snake path</returns>
        public List<GameNode> GetSnakePath()
        {
            List<GameNode> snakePath = new List<GameNode>();
            GameNode current = Tail;

            // Traverse the snake from the tail to the head
            while (current != null)
            {
                snakePath.Add(current);
                current = current.SnakeEdge; // Move to the next node in the snake
            }

            return snakePath;
        }

        /// <summary>
        /// Build the path from the head to the destination node
        /// </summary>
        /// <param name="path">path</param>
        /// <param name="dest">dest</param>
        /// <returns>directions</returns>
        private List<Direction> BuildPath(Dictionary<GameNode, (GameNode, Direction)> path, GameNode dest)
        {
            List<Direction> directions = new List<Direction>();
            GameNode current = dest;

            // Traverse the path dictionary from the destination to the head
            while (path.ContainsKey(current))
            {
                // Get the source node and direction for the current node
                (GameNode source, Direction dir) = path[current];

                // Add the direction to the list
                directions.Add(dir);

                // Move to the source node
                current = source;
            }

            // Reverse the list to get the path from head to destination
            directions.Reverse();

            return directions;
        }
        /// <summary>
        /// gets the valid edges from source to destination
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="dest">dest</param>
        /// <returns>edges that are valid</returns>
        private List<(GameNode, GameNode, Direction)> GetValidEdges(GameNode source, GameNode dest)
        {
            List<(GameNode, GameNode, Direction)> edges = new List<(GameNode, GameNode, Direction)>();

            // Iterate through all possible directions
            foreach (Direction dir in Enum.GetValues(typeof(Direction)))
            {
                if (dir == Direction.None) continue; // Skip the "None" direction

                // Get the adjacent node in the given direction
                GameNode adjacent = GetNextNode(dir, source);

                // Check if the adjacent node is valid
                if (adjacent != null && (adjacent.Data == GridData.Empty || adjacent == dest))
                {
                    // Add the edge (source, adjacent, direction) to the list
                    edges.Add((source, adjacent, dir));
                }
            }

            return edges;
        }
        /// <summary>
        /// Find the shortest path from the head of the snake to the destination node using BFS
        /// </summary>
        /// <param name="dest">dest</param>
        /// <returns>shortest path</returns>
        public List<Direction> FindShortestAiPath(GameNode dest)
        {
            // Dictionary to store the path (destination -> (source, direction))
            Dictionary<GameNode, (GameNode, Direction)> path = new Dictionary<GameNode, (GameNode, Direction)>();

            // Queue for BFS, storing (source, destination, direction)
            Queue<(GameNode, GameNode, Direction)> queue = new Queue<(GameNode, GameNode, Direction)>();

            // Start BFS from the head of the snake
            foreach (var edge in GetValidEdges(Head, dest))
            {
                queue.Enqueue(edge);
            }

            // Perform BFS
            while (queue.Count > 0)
            {
                var (source, current, direction) = queue.Dequeue();

                // If the current node is already visited, skip it
                if (path.ContainsKey(current))
                {
                    continue;
                }

                // Add the current node to the path
                path[current] = (source, direction);

                // If the destination is reached, rebuild and return the path
                if (current == dest)
                {
                    return BuildPath(path, dest);
                }

                // Add valid edges from the current node to the queue
                foreach (var edge in GetValidEdges(current, dest))
                {
                    queue.Enqueue(edge);
                }
            }

            // If no path is found, return an empty list
            return new List<Direction>();
        }


        /// <summary>
        /// Try to extend the path by adding a perpendicular direction
        /// </summary>
        /// <param name="path">path</param>
        /// <param name="visited">visited</param>
        /// <param name="current">current</param>
        /// <param name="next">next</param>
        /// <param name="currentDir">currentdir</param>
        /// <param name="index">index</param>
        /// <returns>false</returns>
        public bool TryExtendPath(List<Direction> path, HashSet<GameNode> visited, GameNode current, GameNode next, Direction currentDir, int index)
        {
            Direction[] perpendicularDirs = currentDir == Direction.Up || currentDir == Direction.Down
                ? new[] { Direction.Left, Direction.Right }
                : new[] { Direction.Up, Direction.Down };

            foreach (Direction dir in perpendicularDirs)
            {
                GameNode adjacentCurrent = GetNextNode(dir, current);
                GameNode adjacentNext = GetNextNode(dir, next);

                if (adjacentCurrent != null && adjacentNext != null &&
                    !visited.Contains(adjacentCurrent) && !visited.Contains(adjacentNext))
                {
                    visited.Add(adjacentCurrent);
                    visited.Add(adjacentNext);

                    path.Insert(index, dir);
                    path.Insert(index + 2, GetOppositeDirection(dir));

                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// gets the opposite direction
        /// </summary>
        /// <param name="dir">dir</param>
        /// <returns>direction</returns>
        public Direction GetOppositeDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.Up: return Direction.Down;
                case Direction.Down: return Direction.Up;
                case Direction.Left: return Direction.Right;
                case Direction.Right: return Direction.Left;
                default: throw new ArgumentException("Invalid direction");
            }
        }
        /// <summary>
        /// Finds the longest path for the AI to take from the head to the tail of the snake
        /// </summary>
        /// <returns>path queue</returns>
        public Queue<Direction> FindLongestAiPath()
        {
            // Step 1: Get the shortest path from head to tail
            List<Direction> path = FindShortestAiPath(Tail);
            if (path == null || path.Count == 0)
            {
                return new Queue<Direction>();
            }

            // Step 2: Mark all nodes in the path as visited
            HashSet<GameNode> visited = new HashSet<GameNode>();
            GameNode current = Head;
            visited.Add(current);

            List<GameNode> nodePath = new List<GameNode> { current };
            foreach (Direction dir in path)
            {
                current = GetNextNode(dir, current);
                visited.Add(current);
                nodePath.Add(current);
            }

            // Step 3: Try to extend the path
            int i = 0;
            while (i < path.Count - 1)
            {
                GameNode nodeA = nodePath[i];
                GameNode nodeB = nodePath[i + 1];
                Direction dirAB = path[i];

                // Choose perpendicular directions to current path direction
                Direction[] perpDirs = GetPerpendicularDirections(dirAB);
                bool extended = false;

                foreach (Direction perpDir in perpDirs)
                {
                    GameNode ext1 = GetNextNode(perpDir, nodeA);
                    GameNode ext2 = GetNextNode(perpDir, nodeB);

                    if (ext1 != null && ext2 != null &&
                        !visited.Contains(ext1) && !visited.Contains(ext2))
                    {
                        // Insert extension direction and its opposite
                        path.Insert(i, perpDir);
                        path.Insert(i + 2, GetOppositeDirection(perpDir));

                        // Update node path accordingly
                        nodePath.Insert(i + 1, ext1);
                        nodePath.Insert(i + 3, ext2);

                        // Mark as visited
                        visited.Add(ext1);
                        visited.Add(ext2);

                        // Move past the newly added directions
                        i += 3;
                        extended = true;
                        break;
                    }
                }

                if (!extended)
                {
                    i++;
                }
            }

            // Step 4: Ensure we end at the tail
            GameNode finalNode = nodePath[nodePath.Count - 1];
            if (finalNode != Tail)
            {
                Direction finalDir = GetDirectionBetweenNodes(finalNode, Tail);
                path.Add(finalDir);
            }

            // Step 5: Convert to queue and return
            return new Queue<Direction>(path);
        }

        /// <summary>
        /// gets the direction between two nodes
        /// </summary>
        /// <param name="from">from</param>
        /// <param name="to">to</param>
        /// <returns>gets the direction between nodes</returns>
        private Direction GetDirectionBetweenNodes(GameNode from, GameNode to)
        {
            if (to.X == from.X && to.Y == from.Y - 1) return Direction.Up;
            if (to.X == from.X && to.Y == from.Y + 1) return Direction.Down;
            if (to.X == from.X - 1 && to.Y == from.Y) return Direction.Left;
            if (to.X == from.X + 1 && to.Y == from.Y) return Direction.Right;
            return Direction.None;
        }

        /// <summary>
        /// perp directions
        /// </summary>
        /// <param name="dir">dir</param>
        /// <returns>returns</returns>
        public Direction[] GetPerpendicularDirections(Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                case Direction.Down:
                    return new Direction[] { Direction.Left, Direction.Right };
                case Direction.Left:
                case Direction.Right:
                    return new Direction[] { Direction.Up, Direction.Down };
                default:
                    return new Direction[0]; // Should never happen
            }
        }




    }
}
