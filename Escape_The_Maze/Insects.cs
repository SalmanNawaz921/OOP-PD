using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_The_Maze
{
    public class Insects
    {
        public static char[] insect1 = new char[9] { '(', 'v', '.', 'v', ')', '_', '(', '.', ')' };
        public static char[] insect2 = new char[9] { '(', '.', ')', '_', '(', 'v', '.', 'v', ')' };
        public static bool moveInsect(ref string direction, char[,] maze, ref int X, ref int Y)
        {
            if (direction == "LEFT")
            {
                char nextPosition = maze[X, Y - 1];
                if (nextPosition == ' ' || nextPosition == '/' || nextPosition == '\\')
                {
                    Program.clear(maze, ref X, ref Y);
                    Y = Y - 1;
                    Program.printInsect2(maze, ref X, ref Y);
                }
                if (nextPosition == '#' || nextPosition == '\u2588' || nextPosition == '|' || nextPosition == '(')
                {
                    direction = "RIGHT";
                }
            }
            if (direction == "RIGHT")
            {
                char nextPosition = maze[X, Y + 9];
                if (nextPosition == ' ' || nextPosition == '/' || nextPosition == '\\')
                {
                    Program.clear(maze, ref X, ref Y);
                    Y = Y + 1;
                    Program.printInsect2(maze, ref X, ref Y);
                }
                if (nextPosition == '#' || nextPosition == '\u2588' || nextPosition == '|' || nextPosition == '(')
                {
                    direction = "LEFT";
                }
            }
            return true;
        }
        public static bool moveInsect1(char[,] maze, ref int X, ref int Y, ref string direction)
        {
            if (direction == "LEFT")
            {

                char nextPosition = maze[X, Y - 1];
                if (nextPosition == ' ' || nextPosition == '/' || nextPosition == '\\')
                {
                    Program.removeInsect1(maze, ref X, ref Y);
                    Y = Y - 1;
                    Program.printInsect1(maze, ref X, ref Y);
                }
                if (nextPosition == '#' || nextPosition == '\u2588' || nextPosition == '|' || nextPosition == ')')
                {
                    direction = "RIGHT";
                }
            }
            if (direction == "RIGHT")
            {
                char nextPosition = maze[X, Y + 9];
                if (nextPosition == ' ' || nextPosition == '/' || nextPosition == '\\')
                {
                    Program.removeInsect1(maze, ref X, ref Y);
                    Y = Y + 1;
                    Program.printInsect1(maze, ref X, ref Y);
                }
                if (nextPosition == '#' || nextPosition == '\u2588' || nextPosition == '|' || nextPosition == ')')
                {
                    direction = "LEFT";
                }
            }
            return true;
        }
        public static bool collisionwithInsects(ref bool gameRunning, ref int insect2X, ref int insect2Y, ref int insectX, ref int insectY, User user)
        {
            if ((insect2X == user.userX && insect2Y == user.userY && Program.insect2Move == true) || (insectX == user.userX && insectY == user.userY && Program.insectMove == true))
            {
                return false;
            }
            return true;
        }
    }
}
