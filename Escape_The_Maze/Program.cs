using System;
using System.Threading;
using EZInput;
using System.IO;

namespace Escape_The_Maze
{
    public class Program
    {

        public static int insectX = 27,
               insectY = 60;

        public static int grandpa2X = 11, grandpa2Y = 25;
        public static int grannyX = 18,
            grannyY = 8;

        public static int insect2X = 27, insect2Y = 10;

        public static int grandpaX = 13;
        public static int grandpaY = 17;

        public static int granny2X = 16,
            granny2Y = 85;
        public static char previous = ' ';
        public static string direction = "up";
        public static string dir1 = "right";
        public static string insectDir1 = "LEFT";
        public static string insectDir2 = "RIGHT";
        public static int count1 = 0;
        public static int count2 = 0;

        public static bool insect2Move = true;

        public static bool insectMove = true;
        public static char pCharacter = ' ';
        public static int scoreCount = 0;
        static void Main(string[] args)
        {
            Program program = new Program();
            User user = new User(3, 3, 5);
            Bullet userBullet = new Bullet(user);
            char[,] maze = new char[30, 140];
            readData(maze);
            bool gameRunning = true;
            while (true)
            {
                char option = printMenu();
                if (option == '1')
                {
                    Console.Clear();
                    while (gameRunning)
                    {
                        char opt = difficultyLevel();
                        if (opt == '1')
                        {
                            Console.Clear();
                            printMaze(maze);
                            user.lives();
                            updateScore();
                            easyDifficulty(ref gameRunning, maze, user, userBullet);
                        }
                        else if (opt == '2')
                        {
                            Console.Clear();
                            printMaze(maze);
                            user.lives();
                            updateScore();
                            mediumDifficulty(ref gameRunning, maze, user, userBullet);
                        }
                        else if (opt == '3')
                        {
                            Console.Clear();
                            printMaze(maze);
                            user.lives();
                            updateScore();
                            hardDifficulty(ref gameRunning, maze, user, userBullet);
                        }
                    }
                }
                // else if (option == '3') { }
                else if (option == '4')
                {
                    break;
                }
            }
        }



        static char printMenu()
        {
            Console.WriteLine("     MAIN MENU");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. RESUME GAME ");
            Console.WriteLine("2. START THE GAME ");
            Console.WriteLine("3. HOW TO PLAY ? ");
            Console.WriteLine("4. EXIT");
            Console.Write("   YOUR OPTION: ");
            char option = Convert.ToChar(Console.ReadLine());
            return option;
        }

        static char difficultyLevel()
        {
            Console.WriteLine("     SELECT DIFFICULTY LEVEL");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("           1. EASY");
            Console.WriteLine("           2. MEDIUM");
            Console.WriteLine("           3. HARD");
            Console.Write("           YOUR OPTION: ");
            char opt = Convert.ToChar(Console.ReadLine());

            return opt;
        }


        static void printMaze(char[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == '#')
                    {
                        // Console.Write('\u2665'); // use the Unicode code point for the solid block character directly
                        Console.Write('\u2588'); // use the Unicode code point for the solid block character directly
                    }
                    else
                    {
                        Console.Write(maze[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        static void readData(char[,] maze)
        {
            StreamReader file = new StreamReader("maze.txt");
            string record;
            int row = 0;
            while ((record = file.ReadLine()) != null)
            {
                for (int x = 0; x < 140; x++)
                {
                    maze[row, x] = record[x];
                }
                row++;
            }

            file.Close();
        }


        public static void printGranny(char[,] maze, ref int X, ref int Y)
        {
            // Console.SetCursorPosition(userY, userX);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(Y + j, X + i);
                    Console.Write(Enemys.granny[i, j]);
                    maze[X + i, Y + j] = Enemys.granny[i, j];
                }
            }
        }

        public static void removeGranny(char[,] maze, ref int X, ref int Y)
        {
            // Console.SetCursorPosition(userY, userX);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(Y + j, X + i);
                    Console.Write(" ");
                    maze[X + i, Y + j] = ' ';
                }
            }
        }
        public static void printGrandpa(char[,] maze, ref int X, ref int Y)
        {
            // Console.SetCursorPosition(userY, userX);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(Y + j, X + i);
                    Console.Write(Enemys.grandpa[i, j]);
                    maze[X + i, Y + j] = Enemys.grandpa[i, j];
                }
            }
        }

        public static void removeGrandpa(char[,] maze, ref int X, ref int Y)
        {
            // Console.SetCursorPosition(userY, userX);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(Y + j, X + i);
                    Console.Write(" ");
                    maze[X + i, Y + j] = ' ';
                }
            }
        }

        public static void clear(char[,] maze, ref int X, ref int Y)
        {
            for (int index = 0; index < 9; index++)
            {
                Console.SetCursorPosition(Y + index, X);
                Console.Write(" ");
                maze[X, Y + index] = ' ';

            }
        }
        public static void removeInsect1(char[,] maze, ref int X, ref int Y)
        {
            for (int index = 0; index < 9; index++)
            {
                Console.SetCursorPosition(Y + index, X);
                Console.Write(" ");
                maze[X, Y + index] = ' ';

            }
        }

        //**************************** END OF INSECT1 FUNCTIONS ***************************

        //**************************** START OF INSECT1 FUNCTIONS ***************************

        public static void printInsect1(char[,] maze, ref int X, ref int Y)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(Y + i, X);
                Console.Write(Insects.insect1[i]);
                maze[X, Y + i] = Insects.insect1[i];
            }
        }
        public static void printInsect2(char[,] maze, ref int X, ref int Y)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(Y + i, X);
                Console.Write(Insects.insect2[i]);
                maze[X, Y + i] = Insects.insect2[i];
            }
        }
        public static void updateScore()
        {
            Console.SetCursorPosition(108, 8);
            Console.Write("SCORE: ");
            // generateColors2();
            Console.Write(scoreCount);
        }

        public static void hardDifficulty(ref bool gameRunning, char[,] maze, User user, Bullet userBullet)
        {

            while (gameRunning)
            {
                Thread.Sleep(40);
                User.playerMovement(maze, user, userBullet);
                Bullet.moveBullet(maze);
                count1++;
                count2++;
                if (count1 == 5)            // Slowest Movement
                {
                    gameRunning = Enemys.moveGrandpa(ref direction, maze, ref grandpaX, ref grandpaY, user);
                    if (gameRunning == false)
                    {
                        break;
                    }
                    count1 = 0;
                }
                if (count2 == 2)            // Slow Movement
                {
                    gameRunning = Enemys.moveGrandpa(ref dir1, maze, ref grandpa2X, ref grandpa2Y, user);
                    if (gameRunning == false)
                    {
                        break;
                    }
                    count2 = 0;
                }
                gameRunning = Enemys.moveGhostRandom(maze, ref granny2X, ref granny2Y, user);
                if (gameRunning == false)
                {
                    break;
                }
                if (insect2Move != false)
                {
                    gameRunning = Insects.moveInsect(ref insectDir1, maze, ref insect2X, ref insect2Y);
                }
                if (insectMove != false)
                {
                    gameRunning = Insects.moveInsect1(maze, ref insectX, ref insectY, ref insectDir2);
                }
                Bullet.bulletCollisionWithInsect2(maze, ref insect2X, ref insect2Y, ref insect2Move);
                Bullet.bulletCollisionWithInsect1(maze, ref insectX, ref insectY, ref insectMove);

                gameRunning = Enemys.moveGranny(maze, ref grannyX, ref grannyY, ref previous, user);
                gameRunning = Insects.collisionwithInsects(ref gameRunning, ref insect2X, ref insect2Y, ref insectX, ref insectY, user);
                gameRunning = User.winningCondition(user, ref gameRunning);
                if (gameRunning == false)
                {
                    break;
                }
            }
        }
        public static void mediumDifficulty(ref bool gameRunning, char[,] maze, User user, Bullet userBullet)
        {

            while (gameRunning)
            {
                Thread.Sleep(40);
                User.playerMovement(maze, user, userBullet);
                Bullet.moveBullet(maze);
                count1++;
                count2++;
                if (count2 == 2)            // Slow Movement
                {
                    gameRunning = Enemys.moveGrandpa(ref dir1, maze, ref grandpa2X, ref grandpa2Y, user);
                    if (gameRunning == false)
                    {
                        break;
                    }
                    count2 = 0;
                }
                gameRunning = Enemys.moveGhostRandom(maze, ref granny2X, ref granny2Y, user);
                if (gameRunning == false)
                {
                    break;
                }
                if (insect2Move != false)
                {
                    gameRunning = Insects.moveInsect(ref insectDir1, maze, ref insect2X, ref insect2Y);
                }
                if (insectMove != false)
                {
                    gameRunning = Insects.moveInsect1(maze, ref insectX, ref insectY, ref insectDir2);
                }
                Bullet.bulletCollisionWithInsect2(maze, ref insect2X, ref insect2Y, ref insect2Move);
                Bullet.bulletCollisionWithInsect1(maze, ref insectX, ref insectY, ref insectMove);

                gameRunning = Enemys.moveGranny(maze, ref grannyX, ref grannyY, ref previous, user);
                gameRunning = Insects.collisionwithInsects(ref gameRunning, ref insect2X, ref insect2Y, ref insectX, ref insectY, user);
                gameRunning = User.winningCondition(user, ref gameRunning);
                if (gameRunning == false)
                {
                    break;
                }
            }
        }
        public static void easyDifficulty(ref bool gameRunning, char[,] maze, User user, Bullet userBullet)
        {

            while (gameRunning)
            {
                Thread.Sleep(40);
                User.playerMovement(maze, user, userBullet);
                Bullet.moveBullet(maze);
                count1++;
                count2++;
                if (count2 == 2)            // Slow Movement
                {
                    gameRunning = Enemys.moveGrandpa(ref dir1, maze, ref grandpa2X, ref grandpa2Y, user);
                    if (gameRunning == false)
                    {
                        break;
                    }
                    count2 = 0;
                }
                gameRunning = Enemys.moveGhostRandom(maze, ref granny2X, ref granny2Y, user);
                if (gameRunning == false)
                {
                    break;
                }
                if (insect2Move != false)
                {
                    gameRunning = Insects.moveInsect(ref insectDir1, maze, ref insect2X, ref insect2Y);
                }
                if (insectMove != false)
                {
                    gameRunning = Insects.moveInsect1(maze, ref insectX, ref insectY, ref insectDir2);
                }
                Bullet.bulletCollisionWithInsect2(maze, ref insect2X, ref insect2Y, ref insect2Move);
                Bullet.bulletCollisionWithInsect1(maze, ref insectX, ref insectY, ref insectMove);
                gameRunning = Insects.collisionwithInsects(ref gameRunning, ref insect2X, ref insect2Y, ref insectX, ref insectY, user);
                gameRunning = User.winningCondition(user, ref gameRunning);
                if (gameRunning == false)
                {
                    break;
                }
            }
        }

    }
}
