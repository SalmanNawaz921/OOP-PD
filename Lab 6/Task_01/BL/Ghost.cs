using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_01.BL
{
    public class Ghost
    {
        private int X;
        private int Y;
        private string ghostDirection = "";
        private char ghostCharacter;
        private float speed;
        private char previousItem;
        private float deltaChange;
        public Grid mazeGrid;

        public Ghost(
            int X,
            int Y,
            char ghostCharacter,
            string ghostDirection,
            float speed,
            char previousItem,
            Grid mazeGrid
        )
        {
            this.X = X;
            this.Y = Y;
            this.ghostCharacter = ghostCharacter;
            this.ghostDirection = ghostDirection;
            this.speed = speed;
            this.previousItem = previousItem;
            // this.deltaChange = deltaChange;
            this.mazeGrid = mazeGrid;
        }

        public void setDirection(string ghostDirection)
        {
            this.ghostDirection = ghostDirection;
        }

        public string getDirection()
        {
            return this.ghostDirection;
        }

        public void remove()
        {
            mazeGrid.maze[X, Y].setValue(' ');
            Console.SetCursorPosition(Y, X);
            Console.Write(" ");
        }

        public void draw()
        {
            mazeGrid.maze[X, Y].setValue(ghostCharacter);
            Console.SetCursorPosition(Y, X);
            Console.Write(ghostCharacter);
        }

        public char getCharacter()
        {
            return this.ghostCharacter;
        }

        public void changeDelta()
        {
            deltaChange = deltaChange + speed;
        }

        public float getDelta()
        {
            return this.deltaChange;
        }

        public void setDeltaZero()
        {
            deltaChange = 0;
        }

        public void move(Grid mazeGrid)
        {
            changeDelta();
            if (Math.Floor(getDelta()) == 1)
            {
                if (ghostCharacter == 'H')
                {
                    moveHorizontal(mazeGrid);
                }
                else
                {
                    moveVertical(mazeGrid);
                }
                setDeltaZero();
            }
        }

        public void moveHorizontal(Grid mazeGrid)
        {
            if (ghostDirection == "left")
            {
                if (mazeGrid.maze[X, Y - 1].getValue() == ' ')
                {
                    Y--;
                }
                else
                {
                    previousItem = mazeGrid.maze[X, Y - 1].getValue();
                    mazeGrid.maze[X, Y - 1].setValue(previousItem);
                }
            }
            else if (ghostDirection == "right")
            {
                if (mazeGrid.maze[X + 1, Y].getValue() == ' ')
                {
                    Y++;
                }
                else
                {
                    previousItem = mazeGrid.maze[X + 1, Y].getValue();
                    mazeGrid.maze[X + 1, Y].setValue(previousItem);
                }
            }
        }

        public void moveVertical(Grid mazeGrid)
        {
            if (ghostDirection == "up")
            {
                if (mazeGrid.maze[X - 1, Y].getValue() == ' ')
                {
                    X--;
                }
                else
                {
                    previousItem = mazeGrid.maze[X - 1, Y].getValue();
                    mazeGrid.maze[X - 1, Y].setValue(previousItem);
                }
            }
            else if (ghostDirection == "down")
            {
                if (mazeGrid.maze[X, Y + 1].getValue() == ' ')
                {
                    X++;
                }
                else
                {
                    previousItem = mazeGrid.maze[X, Y + 1].getValue();
                    mazeGrid.maze[X, Y + 1].setValue(previousItem);
                }
            }
        }

        public int generateRandom()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }

        public void moveSmart()
        {
            double[] distance = new double[4] { 1000000, 1000000, 1000000, 1000000 };
            if (
                mazeGrid.maze[X, Y - 1].getValue() != '|'
                && mazeGrid.maze[X, Y - 1].getValue() != '%'
            )
            {
                distance[0] = (
                    calculateDistance(
                        mazeGrid.maze[X, Y],
                        mazeGrid.maze[Pacman.PacmanX, Pacman.PacmanY - 1]
                    )
                );
            }
            if (
                mazeGrid.maze[X, Y + 1].getValue() != '|'
                && mazeGrid.maze[X, Y + 1].getValue() != '%'
            )
            {
                distance[1] = calculateDistance(
                    mazeGrid.maze[X, Y],
                    mazeGrid.maze[Pacman.PacmanX, Pacman.PacmanY + 1]
                );
            }
            if (
                mazeGrid.maze[X + 1, Y].getValue() != '|'
                && mazeGrid.maze[X + 1, Y].getValue() != '%'
                && mazeGrid.maze[X + 1, Y].getValue() != '#'
            )
            {
                distance[2] = calculateDistance(
                    mazeGrid.maze[X, Y],
                    mazeGrid.maze[Pacman.PacmanX + 1, Pacman.PacmanY]
                );
            }
            if (
                mazeGrid.maze[X - 1, Y].getValue() != '|'
                && mazeGrid.maze[X - 1, Y].getValue() != '%'
                && mazeGrid.maze[X - 1, Y].getValue() != '#'
            )
            {
                distance[3] = calculateDistance(
                    mazeGrid.maze[X + 1, Y],
                    mazeGrid.maze[Pacman.PacmanX, Pacman.PacmanY]
                );
            }
            if (
                distance[0] <= distance[1]
                && distance[0] <= distance[2]
                && distance[0] <= distance[3]
            )
            {
                ghostDirection = "left";
                moveHorizontal(mazeGrid);
            }
            if (
                distance[1] <= distance[0]
                && distance[1] <= distance[2]
                && distance[1] <= distance[3]
            )
            {
                ghostDirection = "right";
                moveHorizontal(mazeGrid);
            }
            if (
                distance[2] <= distance[0]
                && distance[2] <= distance[1]
                && distance[2] <= distance[3]
            )
            {
                ghostDirection = "down";
                moveVertical(mazeGrid);
            }
            else
            {
                ghostDirection = "up";
                moveVertical(mazeGrid);
            }
        }

        public void moveGhostRandom()
        {
            if (
                mazeGrid.maze[X, Y - 1].getValue() == 'P'
                || mazeGrid.maze[X, Y + 1].getValue() == 'P'
                || mazeGrid.maze[X + 1, Y].getValue() == 'P'
                || mazeGrid.maze[X - 1, Y].getValue() == 'P'
            )
            {
                return;
            }
            int value = generateRandom();
            if (value == 0)
            {
                if (
                    mazeGrid.maze[X, Y - 1].getValue() == ' '
                    || mazeGrid.maze[X, Y - 1].getValue() == '.'
                    || mazeGrid.maze[X, Y - 1].getValue() == 'P'
                )
                {
                    mazeGrid.maze[X, Y].setValue(previousItem);
                    Console.SetCursorPosition(Y, X);
                    Console.Write(previousItem);

                    Y = Y - 1;
                    previousItem = mazeGrid.maze[X, Y].getValue();
                    Console.SetCursorPosition(Y, X);
                    Console.Write('G');
                }
            }
            else if (value == 1)
            {
                if (
                    mazeGrid.maze[X, Y + 1].getValue() == ' '
                    || mazeGrid.maze[X, Y + 1].getValue() == '.'
                    || mazeGrid.maze[X, Y + 1].getValue() == 'P'
                )
                {
                    mazeGrid.maze[X, Y].setValue(previousItem);
                    Console.SetCursorPosition(Y, X);
                    Console.Write(previousItem);
                    Y = Y + 1;
                    previousItem = mazeGrid.maze[X, Y].getValue();
                    Console.SetCursorPosition(Y, X);
                    Console.Write('G');
                }
            }
            else if (value == 2)
            {
                if (
                    mazeGrid.maze[X - 1, Y].getValue() == ' '
                    || mazeGrid.maze[X - 1, Y].getValue() == '.'
                    || mazeGrid.maze[X - 1, Y].getValue() == 'P'
                )
                {
                    mazeGrid.maze[X, Y].setValue(previousItem);
                    Console.SetCursorPosition(Y, X);
                    Console.Write(previousItem);
                    X = X - 1;
                    previousItem = mazeGrid.maze[X, Y].getValue();
                    Console.SetCursorPosition(Y, X);
                    Console.Write('G');
                }
            }
            else if (value == 3)
            {
                if (
                    mazeGrid.maze[X + 1, Y].getValue() == ' '
                    || mazeGrid.maze[X + 1, Y].getValue() == '.'
                    || mazeGrid.maze[X + 1, Y].getValue() == '.'
                )
                {
                    mazeGrid.maze[X, Y].setValue(previousItem);
                    Console.SetCursorPosition(Y, X);
                    Console.Write(previousItem);
                    X = X + 1;
                    previousItem = mazeGrid.maze[X, Y].getValue();
                    Console.SetCursorPosition(Y, X);
                    Console.Write('G');
                }
            }
        }

        public double calculateDistance(Cell current, Cell pacmanLocation)
        {
            return Math.Sqrt(
                Math.Pow((current.getX() - pacmanLocation.getX()), 2)
                    + Math.Pow((current.getY() - pacmanLocation.getY()), 2)
            );
        }
    }
}
