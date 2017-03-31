using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
	static class PathFinding
	{
        //<mdumas>

        /// <summary>
        /// Initialise the grid of integers to infinite and the starting point to 0
        /// </summary>
        /// <param name="distances"> grid of integers that represents the distance between pacman and the ghost</param>
        /// <param name="origX"> ghost position in X</param>
        /// <param name="origY"> ghost position in Y</param>
        /// <returns></returns>
        public static int[,] InitMoves(int[,] distances, int origX, int origY)
		{
			for (int i = 0; i < distances.GetLength(0); i++)
			{
				for (int j = 0; j < distances.GetLength(1); j++)
				{
					distances[i, j] = int.MaxValue;
				}
			}

			distances[origY, origX] = 0;

			return distances;
		}

        /// <summary>
        /// Calculate the distance ( in moves ) from the ghost to the present point and sets it to the integer grid
        /// </summary>
        /// <param name="grid"> the game grid</param>
        /// <param name="origX"> the point the algorithm is at in X</param>
        /// <param name="origY"> the point the algorithm is at in Y</param>
        /// <param name="destX"> the point where the algorithm is going next in X</param>
        /// <param name="destY"> the point where the algorithm is going next in Y</param>
        /// <param name="distances"> grid of integers that represents the distance between pacman and the ghost</param>
        public static void CalculateMoves(Grid grid, int origX, int origY, int destX, int destY, ref int[,] distances)
		{
			//up
			if (origY - 1 >= 0 && (grid.GetElementAt(origY - 1, origX) == PacmanElement.Empty || grid.GetElementAt(origY - 1, origX) == PacmanElement.Dot || grid.GetElementAt(origY - 1, origX) == PacmanElement.Pellet) &&
				distances[origY - 1, origX] > distances[origY, origX] + 1)
			{
				distances[origY - 1, origX] = distances[origY, origX] + 1;
				CalculateMoves(grid, origX, origY - 1, destX, destY, ref distances);
			}

			//down
			if (origY + 1 <= Grid.GRID_HEIGHT - 1 && 
				(grid.GetElementAt(origY + 1, origX) == PacmanElement.Empty || grid.GetElementAt(origY + 1, origX) == PacmanElement.Dot || grid.GetElementAt(origY + 1, origX) == PacmanElement.Pellet) &&
				distances[origY + 1, origX] > distances[origY, origX] + 1)
			{
				distances[origY + 1, origX] = distances[origY, origX] + 1;
				CalculateMoves(grid, origX, origY + 1, destX, destY, ref distances);
			}

			//left
			if (origX - 1 >= 0 && (grid.GetElementAt(origY, origX - 1) == PacmanElement.Empty || grid.GetElementAt(origY, origX - 1) == PacmanElement.Dot || grid.GetElementAt(origY, origX - 1) == PacmanElement.Pellet) &&
				distances[origY, origX - 1] > distances[origY, origX] + 1)
			{
				distances[origY, origX - 1] = distances[origY, origX] + 1;
				CalculateMoves(grid, origX - 1, origY, destX, destY, ref distances);
			}

			//right
			if (origX + 1 >= Grid.GRID_WIDTH && (grid.GetElementAt(origY, origX + 1) == PacmanElement.Empty || grid.GetElementAt(origY, origX + 1) == PacmanElement.Dot || grid.GetElementAt(origY, origX + 1) == PacmanElement.Pellet) &&
				distances[origY, origX + 1] > distances[origY, origX] + 1)
			{
				distances[origY, origX + 1] = distances[origY, origX] + 1;
				CalculateMoves(grid, origX + 1, origY, destX, destY, ref distances);
			}
		}

        /// <summary>
        ///  Finds the first move the ghost has to make to reach pacman
        /// </summary>
        /// <param name="distances"> grid of integers that represents the distance between pacman and the ghost</param>
        /// <param name="targetX"> the point where the algorithm is going next in X</param>
        /// <param name="targetY"> the point where the algorithm is going next in Y</param>
        /// <param name="origX"> the point the algorithm is at in X</param>
        /// <param name="origY"> the point the algorithm is at in Y</param>
        /// <param name="priorMove"> the reverse of the move that was just used</param>
        /// <returns></returns>
        public static Direction FindFirstMove(int[,] distances, int targetX, int targetY, int origX, int origY, Direction priorMove)
        {
        	if (distances[targetY, targetX] == 0)
        	{
                return priorMove;
        	}

        	//up
        	else if (targetY - 1 >= 0 && distances[targetY - 1, targetX] < distances[targetY, targetX])
        	{
        		return FindFirstMove(distances, targetX, targetY - 1, targetX, targetY, Direction.Down);
        	}

        	//down
        	else if (targetY + 1 < distances.GetLength(0) && distances[targetY + 1, targetX] < distances[targetY, targetX])
        	{
        		return FindFirstMove(distances, targetX , targetY + 1, targetX, targetY, Direction.Up);
        	}

        	//left
        	else if (targetX - 1 >= 0 && distances[targetY, targetX - 1] < distances[targetY, targetX])
        	{
        		return FindFirstMove(distances, targetX - 1, targetY, targetX, targetY, Direction.Right);
        	}

        	//right
        	else if (targetX + 1 < distances.GetLength(0) && distances[targetY, targetX + 1] < distances[targetY, targetX])
        	{
        		return FindFirstMove(distances, targetX + 1, targetY, targetX, targetY, Direction.Left);
        	}

            else
            {
                return Direction.None;
            }
        }

       /* #region Inky

        /// <summary>
        ///  Finds the first move the ghost has to make to reach pacman
        /// </summary>
        /// <param name="distances"> grid of integers that represents the distance between pacman and the ghost</param>
        /// <param name="targetX"> the point where the algorithm is going next in X</param>
        /// <param name="targetY"> the point where the algorithm is going next in Y</param>
        /// <param name="origX"> the point the algorithm is at in X</param>
        /// <param name="origY"> the point the algorithm is at in Y</param>
        /// <param name="priorMove"> the reverse of the move that was just used</param>
        /// <returns></returns>
        public static Direction FindFirstMoveI(int[,] distances, int targetX, int targetY, int origX, int origY, Direction priorMove, int blinkyX, int blinkyY)
        {
            if (distances[targetY, targetX] == 0)
            {
                return priorMove;
            }

            //up
            else if (targetY - 1 >= 0 && distances[targetY - 1, targetY] < distances[targetY, targetX])
            {
                return FindFirstMove(distances, targetX, targetY - 1, targetX, targetY, Direction.Down);
            }

            //down
            else if (targetY + 1 < distances.GetLength(1) && distances[targetY + 1, targetX] < distances[targetY, targetX])
            {
                return FindFirstMove(distances, targetX, targetY + 1, targetX, targetY, Direction.Up);
            }

            //left
            else if (targetX - 1 >= 0 && distances[targetY, targetX - 1] < distances[targetY, targetX])
            {
                return FindFirstMove(distances, targetX - 1, targetY, targetX, targetY, Direction.Right);
            }

            //right
            else if (targetX + 1 < distances.GetLength(1) && distances[targetY, targetX + 1] < distances[targetY, targetX])
            {
                return FindFirstMove(distances, targetX + 1, targetY, targetX, targetY, Direction.Left);
            }

            else
            {
                return Direction.None;
            }
        }

            #endregion

            #region Pinky
            #endregion

            #region Clyde
            #endregion*/
    }
}
