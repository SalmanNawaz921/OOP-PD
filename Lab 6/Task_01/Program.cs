using System;
using Task_01.BL;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "maze.txt";
            Grid newGrid = new Grid(21, 71, path);
            Pacman player = new Pacman(9, 32, newGrid);
            Ghost ghost1 = new Ghost(15, 39, 'H', "left", 0.1F, ' ', newGrid);
            Ghost ghost2 = new Ghost(19, 57, 'V', "up", 0.2F, ' ', newGrid);
            Ghost ghost3 = new Ghost(19, 26, 'R', "up", 1F, ' ', newGrid);
            Ghost ghost4 = new Ghost(18, 21, 'C', "up", 0.5F, ' ', newGrid);

            List<Ghost> enemies = new List<Ghost>();
            enemies.Add(ghost1);
            enemies.Add(ghost2);
            enemies.Add(ghost3);
            enemies.Add(ghost4);
            newGrid.draw();
            player.draw();
            bool gameRunning = true;
            while (gameRunning)
            {
                Thread.Sleep(90);
                player.printScore();
                player.remove();
                player.move();
                player.draw();

                foreach (Ghost g in enemies)
                {
                    g.remove();
                    g.move(newGrid);
                    g.draw();
                }
                if (newGrid.isStoppingCondition(ghost1.getCharacter()))
                {
                    gameRunning = false;
                }
            }
            Console.ReadKey();
        }
    }
}
