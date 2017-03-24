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
        /// 
        /// </summary>
        /// <param name="distances"></param>
        /// <param name="origX"></param>
        /// <param name="origY"></param>
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
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="origX"></param>
        /// <param name="origY"></param>
        /// <param name="destX"></param>
        /// <param name="destY"></param>
        /// <param name="distances"></param>
        void CalculateMoves(Grid[,] grid, int origX, int origY, int destX, int destY, int[,] distances)
        {
            //up
            if (origY - 1 >= 0 && grid.GetElementAt(origY - 1, origX)) != PacmanElements.W && distances[origY - 1, origX] > distances[origY, origX] + 1)
            {
                distances[origY- 1, origX] = distances[origY, origX] + 1;
                CalculateMoves(grid, origX, origY - 1, destX, destY, distances);
            }

            //down
            if (origY + 1 <= grid.GetLength(0) - 1 && grid.GetElementAt(origY + 1, origX) != PacmanElement.W && distances[origY + 1,origX] > distances[origY,origX] + 1)
            {
                distances[origY + 1, origX] = distances[origY, origX] + 1;
                CalculateMoves(grid, origX, origY + 1, destX, destY, distances);
            }

            //left
            if (origX - 1 >= 0 && grid.GetElementAt(origY, origX - 1)) != PacmanElements.W && distances[origY, origX - 1] > distances[origY, origX] + 1)
            {
                distances[origY, origX - 1] = distances[origY, origX] + 1;
                CalculateMoves(grid, origX - 1, origY, destX, destY, distances);
            }

            //right
            if (origX + 1 >= grid.GetLength(0) && grid.GetElementAt(origY, origX + 1)) != PacmanElements.W && distances[origY, origX + 1] > distances[origY, origX] + 1)
            {
                distances[origY, origX + 1] = distances[origY, origX] + 1;
                CalculateMoves(grid, origX + 1, origY, destX, destY, distances);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distances"></param>
        /// <param name="targetX"></param>
        /// <param name="targetY"></param>
        /// <param name="origX"></param>
        /// <param name="origY"></param>
        /// <returns></returns>
        Direction FindFirstMove(int[,] distances, int targetX, int targetY, int origX, int origY)
        {
            if ( distances[targetY, targetX] == distances[origY, origX])
            {
                return Direction.None;
            }

            //up
            else if ( distances[origY - 1, origX] < distances[origY, origX])
            {
                return Direction.Up + FindFirstMove(distances, targetX, targetY, origX, origY - 1);
            }

            //down
            else if (distances[origY + 1, origX] < distances[origY, origX])
            {
                return Direction.Down + FindFirstMove(distances, targetX, targetY, origX, origY + 1);
            }

            //left
            else if (distances[origY, origX - 1] < distances[origY, origX])
            {
                return Direction.Left + FindFirstMove(distances, targetX, targetY, origX - 1, origY);
            }

            //right
            else if (distances[origY, origX + 1] < distances[origY, origX])
            {
                return Direction.Left + FindFirstMove(distances, targetX, targetY, origX + 1, origY);
            }
        }
}
