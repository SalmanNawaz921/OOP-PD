using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Task_01.BL
{
    public class Grid
    {
        public Cell[,] maze;
        private int rowSize = 0;
        private int colSize = 0;
        private string path = "";

        public Grid(int rowSize, int colSize, string path)
        {
            this.rowSize = rowSize;
            this.colSize = colSize;
            this.path = path;
            maze = new Cell[rowSize, colSize];
            // Load data from file
            LoadData();
        }

        public Cell getLeftCell(Cell c)
        {
            return maze[c.getX() - 1, c.getY()];
        }

        public Cell getRightCell(Cell c)
        {
            return maze[c.getX() + 1, c.getY()];
        }

        public Cell getUpCell(Cell c)
        {
            return maze[c.getX(), c.getY() - 1];
        }

        public Cell getDownCell(Cell c)
        {
            return maze[c.getX(), c.getY() + 1];
        }

        public Cell FindPacman()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j].getValue() == 'P')
                    {
                        return maze[i, j];
                    }
                }
            }
            return null;
        }

        public Cell FindGhost(char ghostCharacter)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j].getValue() == ghostCharacter)
                    {
                        return maze[i, j];
                    }
                }
            }
            return null;
        }

        public bool isStoppingCondition(char ghostCharacter)
        {
            Cell pacman = FindPacman();
            Cell ghost = FindGhost(ghostCharacter);

            // Check if Pacman and Ghost are in the same position
            if (
                pacman != null
                && ghost != null
                && pacman.getX() == ghost.getX()
                && pacman.getY() == ghost.getY()
            )
            {
                // Pacman and Ghost collide
                return true;
            }

            // Pacman and Ghost do not collide
            return false;
        }

        public void draw()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j].value);
                }
                Console.WriteLine();
            }
        }

        public void LoadData()
        {
            string line;
            StreamReader reader = new StreamReader(path);
            if (File.Exists(path))
            {
                int row = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    for (int i = 0; i < colSize; i++)
                    {
                        maze[row, i] = new Cell(line[i], row, i);
                        maze[row, i].setValue(line[i]);
                    }
                    row++;
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("File Not FOUND");
            }
        }
    }
}
