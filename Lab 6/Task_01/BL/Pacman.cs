using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EZInput;

namespace Task_01.BL
{
    public class Pacman
    {
        public static int PacmanX;
        public static int PacmanY;
        public int score = 0;
        public Grid mazeGrid;

        public Pacman(int X, int Y, Grid mazeGrid)
        {
            PacmanX = X;
            PacmanY = Y;
            this.mazeGrid = mazeGrid;
        }

        public void remove()
        {
            mazeGrid.maze[PacmanX, PacmanY].setValue(' ');
            Console.SetCursorPosition(PacmanY, PacmanX);
            Console.Write(" ");
        }

        public void draw()
        {
            // Console.Write("P");
            mazeGrid.maze[PacmanX, PacmanY].setValue('P');
            Console.SetCursorPosition(PacmanY, PacmanX);
            Console.Write("P");
        }

        public void moveLeft(Cell current, Cell next)
        {
            if (next.getValue() != '#')
            {
                PacmanY--;
            }
        }

        public void moveRight(Cell current, Cell next)
        {
            if (next.getValue() != '#')
            {
                PacmanY++;
            }
        }

        public void moveUp(Cell current, Cell next)
        {
            if (next.getValue() != '#')
            {
                PacmanX--;
            }
        }

        public void moveDown(Cell current, Cell next)
        {
            if (next.getValue() != '#')
            {
                PacmanX++;
            }
        }

        public void move()
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                moveRight(mazeGrid.maze[PacmanX, PacmanY], mazeGrid.maze[PacmanX, PacmanY + 1]);
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveLeft(mazeGrid.maze[PacmanX, PacmanY], mazeGrid.maze[PacmanX, PacmanY - 1]);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                moveUp(mazeGrid.maze[PacmanX, PacmanY], mazeGrid.maze[PacmanX - 1, PacmanY]);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                moveDown(mazeGrid.maze[PacmanX, PacmanY], mazeGrid.maze[PacmanX + 1, PacmanY]);
            }
        }

        public void printScore()
        {
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("Score: 0");
        }
    }
}
