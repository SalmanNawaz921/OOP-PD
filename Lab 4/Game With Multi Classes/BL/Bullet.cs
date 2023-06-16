using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escape_The_Maze;

namespace game.BL
{
    public class Bullet
    {
        User user;

        public Bullet(User user)
        {
            this.user = user;
        }

        public static int[] bulletX = new int[100];
        public static int[] bulletY = new int[100];
        public static int numBulletsHitInsect2 = 0;
        public static int numBulletsHitInsect1 = 0;


        public static int bulletCount = 0;
        public void generateBullet(User user)
        {

            bulletX[bulletCount] = user.userX;
            bulletY[bulletCount] = user.userY + 4;
            Console.SetCursorPosition(user.userY + 4, user.userX);
            Console.Write(".");
            bulletCount++;
        }
        public static void removeBulletFromArray(int index)
        {
            for (int x = index; x < bulletCount - 1; x++)
            {
                bulletX[x] = bulletX[x + 1];
                bulletY[x] = bulletY[x + 1];
            }
            bulletCount--;
        }

        public static void printBullet(char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(".");
            maze[x, y] = '.';

        }
        public static void eraseBullet(char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
            maze[x, y] = ' ';
        }
        public static void bulletCollisionWithInsect2(char[,] maze, ref int insect2X, ref int insect2Y, ref bool insect2Move)
        {
            for (int x = 0; x < bulletCount; x++)
            {
                if (bulletX[x] == insect2X && bulletY[x] == insect2Y)
                {
                    Program.scoreCount = Program.scoreCount + 1;
                    Program.updateScore();
                    eraseBullet(maze, bulletX[x], bulletY[x]);
                    removeBulletFromArray(x);
                    numBulletsHitInsect2++;
                    Console.SetCursorPosition(110, 26);
                    Console.Write(numBulletsHitInsect2);
                    if (numBulletsHitInsect2 >= 10)
                    {
                        Console.SetCursorPosition(110, 27);
                        Console.WriteLine("Bullet Are 10");
                        Insects.insect2Move = false;
                        Program.clear(maze, ref insect2X, ref insect2Y);
                        numBulletsHitInsect2 = 0; // Reset the counter after clearing the insect
                    }
                    break;
                }
            }
            // numBulletsHitInsect2 = totalNumBulletsHitInsect2;
        }
        public static void bulletCollisionWithInsect1(char[,] maze, ref int insectX, ref int insectY, ref bool insectMove)
        {
            for (int x = 0; x < bulletCount; x++)
            {
                if (bulletX[x] == insectX && bulletY[x] == insectY)
                {
                    Program.scoreCount = Program.scoreCount + 1;
                    Program.updateScore();
                    eraseBullet(maze, bulletX[x], bulletY[x]);
                    removeBulletFromArray(x);
                    numBulletsHitInsect1++;

                    if (numBulletsHitInsect1 >= 10)
                    {

                        Insects.insectMove = false;
                        Program.removeInsect1(maze, ref insectX, ref insectY);
                        numBulletsHitInsect1 = 0; // Reset the counter after clearing the insect
                    }
                    break;
                }
            }
            // numBulletsHitInsect2 = totalNumBulletsHitInsect2;
        }
        public static void moveBullet(char[,] maze)
        {
            for (int x = 0; x < bulletCount; x++)
            {
                char next = maze[bulletX[x] + 1, bulletY[x] + 1];
                if (next == '#' || next == '\u2588')
                {
                    eraseBullet(maze, bulletX[x], bulletY[x]);
                    removeBulletFromArray(x);
                }
                else
                {
                    // The bullet hasn't hit an obstacle, so erase it from its current position and update its position.
                    eraseBullet(maze, bulletX[x], bulletY[x]);
                    bulletY[x] = bulletY[x] + 1;
                    printBullet(maze, bulletX[x], bulletY[x]);
                }
            }
        }

    }
}
