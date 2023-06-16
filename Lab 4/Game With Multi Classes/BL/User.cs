using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using Escape_The_Maze;

namespace game.BL
{
    public class User
    {

        public User()
        {
            userX = 2;
            userY = 2;
            livesCount = 3;
        }
        public User(int x, int y, int life)
        {
            userX = x;
            userY = y;
            livesCount = life;
        }
        public int userX = 2; public int userY = 3;
        public int livesCount = 3;
        public void lives()
        {
            Console.SetCursorPosition(108, 5);
            Console.Write("LIVES: ");
            for (int i = 0; i < livesCount; i++)
            {
                Console.SetCursorPosition(115 + i, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('\u2665');
            }
            Console.ResetColor();
        }

        public void lifeLoss()
        {
            for (int i = livesCount; i >= 0; i--)
            {

                Console.SetCursorPosition(115 + livesCount, 5);
                Console.Write(" ");
            }
        }
        public char[,] userArr = new char[2, 3]
     {
            { '/', 'o', '\\' },
            { '|', '_', '|' }
     };
        public void printUser(char[,] maze, User user)
        {
            // Console.SetCursorPosition(userY, userX);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(user.userY + j, user.userX + i);
                    Console.Write(userArr[i, j]);
                    maze[user.userX + i, user.userY + j] = userArr[i, j];
                }
            }
        }
        public void eraseUser(char[,] maze, User user)
        {
            // Console.SetCursorPosition(userY, userX);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(user.userY + j, user.userX + i);
                    Console.Write(" ");
                    maze[user.userX + i, user.userY + j] = ' ';
                }
            }
        }
        public void moveUserRight(char[,] maze, User user)
        {
            if (maze[user.userX, user.userY + 3] != '#' && maze[user.userX + 1, user.userY + 3] != '#')
            {
                user.eraseUser(maze, user);
                user.userY = user.userY + 1;
                user.printUser(maze, user);
            }
        }


        public void moveUserLeft(char[,] maze, User user)
        {
            if (user.userY > 0 && maze[user.userX, user.userY - 1] != '#' && maze[user.userX + 1, user.userY - 1] != '#')
            {
                // Erase the user from the current location

                // Update the user location
                user.eraseUser(maze, user);
                user.userY = user.userY - 1;
                user.printUser(maze, user);

                // Print the user at the new location
            }
        }

        public void moveUserDown(char[,] maze, User user)
        {
            if (maze[user.userX + 2, user.userY] != '#' &&
        maze[user.userX + 2, user.userY + 1] != '#' && maze[user.userX + 2, user.userY + 2] != '#')
            {
                user.eraseUser(maze, user);
                user.userX = user.userX + 1;
                user.printUser(maze, user);
            }
        }

        public void moveUserUp(char[,] maze, User user)
        {
            if (maze[user.userX - 1, user.userY] != '#' &&
        maze[user.userX - 1, user.userY + 1] != '#' && maze[user.userX - 1, user.userY - 1] != '#' && maze[user.userX - 1, user.userY + 1] != '#')
            {
                user.eraseUser(maze, user);
                user.userX = user.userX - 1;
                user.printUser(maze, user);
            }
        }

        public static bool winningCondition(User user, ref bool gameRunning)
        {
            if (((user.userX == 27 && user.userY == 44) || ((user.userX == 28 && user.userY == 44))) && (Insects.insect2Move == false && Insects.insectMove == false))
            {

                Console.SetCursorPosition(99, 28);
                Console.WriteLine("YOU WON");
                return false;

            }
            return true;
        }
        public static void playerMovement(char[,] maze, User user, Bullet userBullet)
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                user.moveUserRight(maze, user);
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                user.moveUserLeft(maze, user);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                user.moveUserUp(maze, user);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                user.moveUserDown(maze, user);
                // insect2Move = false;
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                userBullet.generateBullet(user);
                // insect2Move = false;
            }
        }


    }
}
