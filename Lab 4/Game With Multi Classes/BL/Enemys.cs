using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escape_The_Maze;

namespace game.BL
{

    public class Enemys
    {
        public static int grannyX = 18,
            grannyY = 8;
        public static int grandpaX = 13;
        public static int grandpaY = 17;
        public static int grandpa2X = 11, grandpa2Y = 25;
        public static int granny2X = 16,
            granny2Y = 85;
        public static char[,] grandpa = new char[2, 3]
    {
            { '[', 'o', ']' },
            { '\\', '_', '/' }
    };
        public static char[,] granny = new char[2, 3]{
                { '(', 'o', ')'},
                     { '(', '_', ')'}
            };
        public static bool moveGrandpa(ref string direction, char[,] maze, ref int X, ref int Y, User user)
        {
            if (user.userX == X && user.userY == Y || user.userX - 1 == X - 1 && user.userY - 1 == Y - 1 || user.userX + 1 == X + 1 && user.userY + 1 == Y + 1)
            {
                user.livesCount--;
                user.lifeLoss();
                user.eraseUser(maze, user);
                user.userX = 3;
                user.userY = 3;
                user.printUser(maze, user);
                if (user.livesCount == 0)
                {

                    return false;
                }
            }
            if (direction == "left" && (maze[X, Y - 1] != '#' && maze[X + 1, Y - 1] != '#'))
            {
                Program.removeGrandpa(maze, ref X, ref Y);
                Y = Y - 1;
                Program.printGrandpa(maze, ref X, ref Y);
                if (maze[X, Y - 1] == '\u2588' || maze[X, Y - 1] == '#' || maze[X + 1, Y - 1] == '#')
                {
                    direction = "right";
                }
            }
            else if (direction == "right" && (maze[X, Y + 3] != '#'))
            {
                Program.removeGrandpa(maze, ref X, ref Y);
                Y = Y + 1;
                Program.printGrandpa(maze, ref X, ref Y);
                if (maze[X, Y + 3] == '\u2588' || maze[X, Y + 3] == '#')
                {
                    direction = "down";
                }
            }
            else if (direction == "up" && (maze[X - 1, Y] == ' '))
            {
                Program.removeGrandpa(maze, ref X, ref Y);
                X = X - 1;
                Program.printGrandpa(maze, ref X, ref Y);
                if (maze[X - 1, Y] == '\u2588' || maze[X - 1, Y] == '#')
                {
                    direction = "left";
                }
            }
            else if (direction == "down" && (maze[X + 2, Y] == ' '))
            {
                Program.removeGrandpa(maze, ref X, ref Y);
                X = X + 1;
                Program.printGrandpa(maze, ref X, ref Y);
                if (maze[X + 2, Y] == '\u2588' || maze[X + 2, Y] == '#')
                {
                    direction = "up";
                }
            }
            return true;
        }
        public static bool moveGrannys(ref string direction, char[,] maze, ref int X, ref int Y, User user)
        {
            if (user.userX == X && user.userY == Y || user.userX - 1 == X - 1 && user.userY - 1 == Y - 1 || user.userX + 1 == X + 1 && user.userY + 1 == Y + 1)
            {
                user.livesCount--;
                user.lifeLoss();
                user.eraseUser(maze, user);
                user.userX = 3;
                user.userY = 3;
                user.printUser(maze, user);
                if (user.livesCount == 0)
                {

                    return false;
                }
            }
            if (direction == "left" && (maze[X, Y - 1] == ' '))
            {
                Program.removeGranny(maze, ref X, ref Y);
                Y = Y - 1;
                Program.printGranny(maze, ref X, ref Y);
                if (maze[X, Y - 1] == '\u2588' || maze[X, Y - 1] == '#')
                {
                    direction = "right";
                }
            }
            else if (direction == "right" && (maze[X, Y + 3] == ' '))
            {
                Program.removeGranny(maze, ref X, ref Y);
                Y = Y + 1;
                Program.printGranny(maze, ref X, ref Y);
                if (maze[X, Y + 3] == '\u2588' || maze[X, Y + 3] == '#')
                {
                    direction = "down";
                }
            }
            else if (direction == "up" && (maze[X - 1, Y] == ' '))
            {
                Program.removeGranny(maze, ref X, ref Y);
                X = X - 1;
                Program.printGranny(maze, ref X, ref Y);
                if (maze[X - 1, Y] == '\u2588' || maze[X - 1, Y] == '#')
                {
                    direction = "left";
                }
            }
            else if (direction == "down" && (maze[X + 2, Y] == ' '))
            {
                Program.removeGranny(maze, ref X, ref Y);
                X = X + 1;
                Program.printGranny(maze, ref X, ref Y);
                if (maze[X + 2, Y] == '\u2588' || maze[X + 2, Y] == '#')
                {
                    direction = "up";
                }
            }
            return true;
        }
        public static bool moveGranny(char[,] maze, ref int X, ref int Y, ref char previous, User user)
        {
            double[] distance = new double[4] { 1000000, 1000000, 1000000, 1000000 };
            if (maze[X, Y - 1] != '|' && maze[X, Y - 1] != '%')
            {
                distance[0] = (calculateDistance(X, Y - 1, user));
            }
            if (maze[X, Y + 1] != '|' && maze[X, Y + 1] != '%')
            {
                distance[1] = (calculateDistance(X, Y + 1, user));
            }
            if (maze[X + 1, Y] != '|' && maze[X + 1, Y] != '%' && maze[X + 1, Y] != '#')
            {
                distance[2] = (calculateDistance(X + 1, Y, user));
            }
            if (maze[X - 1, Y] != '|' && maze[X - 1, Y] != '%' && maze[X - 1, Y] != '#')
            {
                distance[3] = (calculateDistance(X - 1, Y, user));
            }
            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
            {
                string direction = "left";
                return moveGrannys(ref direction, maze, ref X, ref Y, user);
            }
            if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
            {
                string direction = "right";
                return moveGrannys(ref direction, maze, ref X, ref Y, user);
            }
            if (distance[2] <= distance[0] && distance[2] <= distance[1] && distance[2] <= distance[3])
            {
                string direction = "down";
                return moveGrannys(ref direction, maze, ref X, ref Y, user);
            }
            else
            {
                string direction = "up";
                return moveGrannys(ref direction, maze, ref X, ref Y, user);
            }
        }
        public static double calculateDistance(int X, int Y, User user)
        {
            return Math.Sqrt(Math.Pow((user.userX - X), 2) + Math.Pow((user.userY - Y), 2));
        }
        public static bool moveGhostRandom(char[,] maze, ref int X, ref int Y, User user)
        {
            if (user.userX == X && user.userY == Y || user.userX - 1 == X - 1 && user.userY - 1 == Y - 1 || user.userX + 1 == X + 1 && user.userY + 1 == Y + 1)
            {
                user.livesCount--;
                user.lifeLoss();
                user.eraseUser(maze, user);
                user.userX = 3;
                user.userY = 3;
                user.printUser(maze, user);
                if (user.livesCount == 0)
                {

                    return false;
                }
            }
            int value = ghostDirection();
            if (value == 0)
            {
                if (maze[X, Y - 1] == ' ')
                {
                    Program.removeGranny(maze, ref X, ref Y);
                    Y = Y - 1;
                    Program.printGranny(maze, ref X, ref Y);
                }
            }
            else if (value == 1)
            {
                if (maze[X, Y + 2] == ' ')
                {
                    Program.removeGranny(maze, ref X, ref Y);
                    Y = Y + 1;
                    Program.printGranny(maze, ref X, ref Y);
                }
            }
            else if (value == 2)
            {
                if (maze[X - 1, Y] == ' ')
                {
                    Program.removeGranny(maze, ref X, ref Y);
                    X = X - 1;
                    Program.printGranny(maze, ref X, ref Y);

                }
            }
            else if (value == 3)
            {
                if (maze[X + 3, Y] == ' ')
                {
                    Program.removeGranny(maze, ref X, ref Y);
                    X = X + 1;
                    Program.printGranny(maze, ref X, ref Y);
                }
            }
            return true;
        }
        public static int ghostDirection()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }

        internal static bool moveGranny(char[,] maze, ref object grannyX, ref object grannyY, ref char previous, User user)
        {
            throw new NotImplementedException();
        }
    }
}
