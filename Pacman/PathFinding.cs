using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
	static class PathFinding
	{
		//<pmccormick>

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

			distances[origX, origY] = 0;

			return distances;
		}

        /// <summary>
        /// Calculate the distance ( in moves ) from the ghost to the present point and sets it to the integer grid
        /// </summary>
        /// <param name="grid"> the game grid</param>
        /// <param name="origI"> the point the algorithm is at in X</param>
        /// <param name="origJ"> the point the algorithm is at in Y</param>
        /// <param name="destI"> the point where the algorithm is going next in X</param>
        /// <param name="destJ"> the point where the algorithm is going next in Y</param>
        /// <param name="distances"> grid of integers that represents the distance between pacman and the ghost</param>
        public static void CalculateMoves(Grid grid, int origI, int origJ, int destI, int destJ, ref int[,] distances)
		{
			//up
			if (origJ - 1 >= 0 && (grid.GetElementAt(origI, origJ - 1) == PacmanElement.Empty || grid.GetElementAt(origI, origJ - 1) == PacmanElement.Dot || grid.GetElementAt(origI, origJ - 1) == PacmanElement.Pellet || grid.GetElementAt(origI, origJ - 1) == PacmanElement.Jail) &&
				distances[origI, origJ - 1] > distances[origI, origJ] + 1)
			{
				distances[origI, origJ - 1] = distances[origI, origJ] + 1;
				CalculateMoves(grid, origI, origJ - 1, destI, destJ, ref distances);
			}

			//down
			if (origJ + 1 <= Grid.GRID_HEIGHT - 1 && 
				(grid.GetElementAt(origI, origJ + 1) == PacmanElement.Empty || grid.GetElementAt(origI, origJ + 1) == PacmanElement.Dot || grid.GetElementAt(origI, origJ + 1) == PacmanElement.Pellet || grid.GetElementAt(origI, origJ + 1) == PacmanElement.Jail) &&
				distances[origI, origJ + 1] > distances[origI, origJ] + 1)
			{
				distances[origI, origJ + 1] = distances[origI, origJ] + 1;
				CalculateMoves(grid, origI, origJ + 1, destI, destJ, ref distances);
			}

			//left
			if (origI - 1 >= 0 && (grid.GetElementAt(origI - 1, origJ) == PacmanElement.Empty || grid.GetElementAt(origI - 1, origJ) == PacmanElement.Dot || grid.GetElementAt(origI - 1, origJ) == PacmanElement.Pellet|| grid.GetElementAt(origI - 1, origJ) == PacmanElement.Jail) &&
				distances[origI - 1, origJ] > distances[origI, origJ] + 1)
			{
				distances[origI - 1, origJ] = distances[origI, origJ] + 1;
				CalculateMoves(grid, origI - 1, origJ, destI, destJ, ref distances);
			}

			//right
			if (origI + 1 <= Grid.GRID_WIDTH && (grid.GetElementAt(origI + 1, origJ) == PacmanElement.Empty || grid.GetElementAt(origI + 1, origJ) == PacmanElement.Dot || grid.GetElementAt(origI + 1, origJ) == PacmanElement.Pellet || grid.GetElementAt(origI + 1, origJ) == PacmanElement.Jail) &&
				distances[origI + 1, origJ] > distances[origI, origJ] + 1)
			{
				distances[origI + 1, origJ] = distances[origI, origJ] + 1;
				CalculateMoves(grid, origI + 1, origJ, destI, destJ, ref distances);
			}
		}
		//</pmccormick>

		//<mdumas>

		/// <summary>
		///  Finds the first move the ghost has to make to reach pacman
		/// </summary>
		/// <param name="distances"> grid of integers that represents the distance between pacman and the ghost</param>
		/// <param name="targetX"> the point where the algorithm is going next in X</param>
		/// <param name="targetY"> the point where the algorithm is going next in Y</param>
		/// <param name="origX"> the point the algorithm is at in X</param>
		/// <param name="origY"> the point the algorithm is at in Y</param>
		/// <param name="priorMove"> the reverse of the move that was just used or none if this is the first move</param>
		/// <returns></returns>
		public static Direction FindFirstMove(int[,] distances, int targetX, int targetY, int origX, int origY, Direction priorMove)
        {

	        if (distances[origX, origY] == 0)
	        {
		        return Direction.None;
	        }
        	else if (distances[targetX, targetY] == 0)
        	{
                return priorMove;
        	}

        	//up
        	else if (targetY - 1 >= 0 && distances[targetX, targetY - 1] < distances[targetX, targetY])
        	{
        		return FindFirstMove(distances, targetX, targetY - 1, origX, origY, Direction.Down);
        	}

        	//down
        	else if (targetY + 1 < distances.GetLength(1) && distances[targetX, targetY + 1] < distances[targetX, targetY])
        	{
        		return FindFirstMove(distances, targetX , targetY + 1, origX, origY, Direction.Up);
        	}

        	//left
        	else if (targetX - 1 >= 0 && distances[targetX - 1, targetY] < distances[targetX, targetY])
        	{
        		return FindFirstMove(distances, targetX - 1, targetY, origX, origY, Direction.Right);
        	}

        	//right
        	else if (targetX + 1 < distances.GetLength(1) && distances[targetX + 1, targetY] < distances[targetX, targetY])
        	{
        		return FindFirstMove(distances, targetX + 1, targetY, origX, origY, Direction.Left);
        	}

            else
            {
                return Direction.None;
            }
        }
    }
}
