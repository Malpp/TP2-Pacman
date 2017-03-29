using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
	class PathFinding
	{
		//<mdumas>
		/// <summary>
		/// Initialise the grid on integers to 0
		/// </summary>
		/// <param name="distances"> grid of integers that represents the distance between pacman and the ghost</param>
		/// <param name="origX"> ghost position in X</param>
		/// <param name="origY"> ghost position in Y</param>
		/// <returns></returns>
		int[,] InitaliseMoves(int[,] distances, int origX, int origY)
		{
			for (int i = 0; i < distances.GetLength(0); i++)
			{
				for (int j = 0; i < distances.GetLength(1); i++)
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
        /// <param name="origX"> the point the algorithm is at in X</param>
        /// <param name="origY"> the point the algorithm is at in Y</param>
        /// <param name="destX"> the point where the algorithm is going next in X</param>
        /// <param name="destY"> the point where the algorithm is going next in Y</param>
        /// <param name="distances"> grid of integers that represents the distance between pacman and the ghost</param>
        void CalculateMoves(Grid grid, int origX, int origY, int destX, int destY, int[,] distances)
		{
			//up
			if (origY - 1 >= 0 && grid.GetElementAt(origY - 1, origX) != PacmanElement.Wall &&
				distances[origY - 1, origX] > distances[origY, origX] + 1)
			{
				distances[origY - 1, origX] = distances[origY, origX] + 1;
				CalculateMoves(grid, origX, origY - 1, destX, destY, distances);
			}

			//down
			if (origY + 1 <= Grid.GRID_HEIGHT - 1 && grid.GetElementAt(origY + 1, origX) != PacmanElement.Wall &&
				distances[origY + 1, origX] > distances[origY, origX] + 1)
			{
				distances[origY + 1, origX] = distances[origY, origX] + 1;
				CalculateMoves(grid, origX, origY + 1, destX, destY, distances);
			}

			//left
			if (origX - 1 >= 0 && grid.GetElementAt(origY, origX - 1) != PacmanElement.Wall &&
				distances[origY, origX - 1] > distances[origY, origX] + 1)
			{
				distances[origY, origX - 1] = distances[origY, origX] + 1;
				CalculateMoves(grid, origX - 1, origY, destX, destY, distances);
			}

			//right
			if (origX + 1 >= Grid.GRID_WIDTH && grid.GetElementAt(origY, origX + 1) != PacmanElement.Wall &&
				distances[origY, origX + 1] > distances[origY, origX] + 1)
			{
				distances[origY, origX + 1] = distances[origY, origX] + 1;
				CalculateMoves(grid, origX + 1, origY, destX, destY, distances);
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
        /// <param name="priorMove"></param>
        /// <returns></returns>
        Direction FindFirstMove(int[,] distances, int targetX, int targetY, int origX, int origY, Direction priorMove)
        {
        	if (distances[targetY, targetX] == 0)
        	{
                return priorMove;
        	}

        	//up
        	else if (targetY - 1 >= 0 && distances[targetY - 1, targetY] < distances[targetY, targetX])
        	{
        		return FindFirstMove(distances, targetX, targetY - 1, targetX, targetY, Direction.Up);
        	}

        	//down
        	else if (targetY + 1 < distances.GetLength(1) && distances[targetY + 1, targetX] < distances[targetY, targetX])
        	{
        		return FindFirstMove(distances, targetX , targetY + 1, targetX, targetY, Direction.Down);
        	}

        	//left
        	else if (targetX - 1 >= 0 && distances[targetY, targetX - 1] < distances[targetY, targetX])
        	{
        		return FindFirstMove(distances, targetX - 1, targetY, targetX, targetY, Direction.Left);
        	}

        	//right
        	else if (targetX + 1 < distances.GetLength(1) && distances[targetY, targetX + 1] < distances[targetY, targetX])
        	{
        		return FindFirstMove(distances, targetX + 1, targetY, targetX, targetY, Direction.Right);
        	}

            else
            {
                return Direction.None;
            }
        }     
    }
}
