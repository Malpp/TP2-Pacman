﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Pacman
{
	class Ghost
	{
		/// <summary>
		/// Indicates the state ghosts are in.
		/// </summary>
		public GhostState state = GhostState.Chase;
		private static CircleShape body;

		private static bool GotPacman;

		public const float UPDATE_TICKRATE = 0.3f;

		private int iPos;
		private int jPos;
		private float totalTime;
		private int[,] distances;
		private Direction nextMove;

		public Direction direction = Direction.Down;

		static Ghost()
		{
			body = new CircleShape(Grid.TILE_SIZE / 2f);
			body.FillColor = Color.Red;
			GotPacman = false;
		}

		public Ghost()
		{

			distances = new int[Grid.GRID_WIDTH, Grid.GRID_HEIGHT];
			GotPacman = false;

			iPos = 14;
			jPos = 13;
			nextMove = Direction.None;

		}

		public void Draw(RenderWindow window)
		{
			if (!GotPacman)
			{
				body.Position = new Vector2f(iPos * Grid.TILE_SIZE, jPos * Grid.TILE_SIZE + Grid.DRAW_OFFSET);
				window.Draw(body);
			}
		}

		public void Update(float time, Grid grid, Pacman pacman)
		{

			totalTime += time;
			if (grid.IsPelletActive)
			{
				state = GhostState.Frightened;
			}

			distances = PathFinding.InitMoves(distances, iPos, jPos);
			PathFinding.CalculateMoves(grid, iPos, jPos, pacman.iPos, pacman.jPos, ref distances);
			//for (int i = 0; i < distances.GetLength(1); i++)
			//{
			//	for (int j = 0; j < distances.GetLength(0); j++)
			//	{
			//		if (distances[j, i] != int.MaxValue)
			//			Console.Write(((distances[j, i] <= 9) ? "0" + distances[j, i] : distances[j, i] + "") + " ");
			//		else
			//		{
			//			Console.Write("XX ");
			//		}
			//	}
			//	Console.WriteLine();
			//}
			nextMove = PathFinding.FindFirstMove(distances, pacman.iPos, pacman.jPos, pacman.iPos, pacman.jPos, nextMove);

			if (state == GhostState.Frightened)
			{

			}

			else if (state == GhostState.Scatter)
			{

				if (iPos == pacman.iPos && jPos == pacman.jPos && !GotPacman)
				{

					GotPacman = true;
					pacman.Caught();
				}

			}
			//Console.WriteLine(nextMove);

			if (totalTime > 0.2f)
			{
				totalTime = 0;
				switch (nextMove)
				{
					case Direction.Down:
						jPos++;
						break;

					case Direction.Left:
						iPos--;
						break;

					case Direction.Right:
						iPos++;
						break;

					case Direction.Up:
						jPos--;
						break;

				}
			}
		}

		private void ChangeToFrightenedMode()
		{
			body.FillColor = Color.Blue;
			SuddenlyChangeDirection();
		}

		private void SuddenlyChangeDirection()
		{
			if (nextMove == Direction.Up)
				nextMove = Direction.Down;
			else if (nextMove == Direction.Down)
				nextMove = Direction.Up;
			else if (nextMove == Direction.Left)
				nextMove = Direction.Right;
			else if (nextMove == Direction.Right)
				nextMove = Direction.Left;
		}

		//private void isGhostAtCrossroads()
		//{
		//    if (distances[iPos + 1, jPos] == )
		//}



	}
}

