using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSU.CIS300.Snake
{

    /// <summary>
    /// grid data enum
    /// </summary>
    public enum GridData
    {
        Empty,
        SnakeHead,
        SnakeBody,
        SnakeFood
    }

    /// <summary>
    /// game node class
    /// </summary>
    public class GameNode
    {
        /// <summary>
        /// y location
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// x location
        /// </summary>
        public int X { get; set; }
        

        /// <summary>
        /// data enum
        /// </summary>
        public GridData Data { get; set; } 
        /// <summary>
        /// constructor that represents a connection in the graph to another game node, connects snake pieces
        /// </summary>
        public GameNode SnakeEdge { get; set; }

        public GameNode(int x, int y)
        {
            X = x;
            Y = y;
            Data = GridData.Empty;
            SnakeEdge = null;
        }
        /// <summary>
        /// to string override
        /// </summary>
        /// <returns>the string</returns>
        public override string ToString()
        {
            return $"({X}, {Y}) - {Data}";
        }




    }
}
