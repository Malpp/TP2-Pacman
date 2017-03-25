using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Pacman
{
	class Pacman
	{

		public const float UPDATE_TICKRATE = 0.3f;

		private static CircleShape body;
		private Direction direction;
		private float totalTime;
		private Direction toMoveDirection;

		private int iPos;
		private int jPos;

		private float iOffset;
		private float jOffset;

		public Direction ToMove
		{
			get { return toMoveDirection; }
		}

		static Pacman()
		{
			
			body = new CircleShape(Grid.TILE_SIZE / 2f);
			body.FillColor = Color.Yellow;

		}

		public Pacman()
		{
			
			direction = Direction.Up;
			totalTime = 0;

			jPos = 23;
			iPos = 13;
			toMoveDirection = Direction.Left;

		}

		public void Update(float time, Grid grid)
		{

			totalTime += time;

			if (totalTime > UPDATE_TICKRATE)
			{

				totalTime = 0;

				Move(ToMove, grid);

			}
			else
			{

				//iOffset = totalTime * Grid.TILE_SIZE / UPDATE_TICKRATE;

			}

		}

		public void Draw(RenderWindow window)
		{
			
			body.Position = new Vector2f(iPos * Grid.TILE_SIZE + iOffset, jPos * Grid.TILE_SIZE + jOffset);
			window.Draw(body);

		}

		public void Move(Direction direction, Grid grid)
		{

			switch (direction)
			{
					
				case Direction.Up:
					if (CanMove(Direction.Up, grid))
						jPos--;
					break;

				case Direction.Down:
					if (CanMove(Direction.Down, grid))
						jPos++;
					break;

				case Direction.Left:
					if (CanMove(Direction.Left, grid))
					{
						iPos--;
						if (iPos < 0)
							iPos = Grid.GRID_WIDTH - 1;
					}

					break;

				case Direction.Right:
					if (CanMove(Direction.Right, grid))
					{
						iPos++;
						if (iPos >= Grid.GRID_WIDTH)
							iPos = 0;
					}
					break;

			}

		}

		private bool CanMove(Direction direction, Grid grid)
		{

			switch (direction)
			{

				case Direction.Up:
					if (grid.GetElementAt(iPos, jPos - 1) != PacmanElement.Wall)
						return true;
					break;

				case Direction.Down:
					if (grid.GetElementAt(iPos, jPos + 1) != PacmanElement.Wall)
						return true;
					break;

				case Direction.Left:
					if (grid.GetElementAt(iPos - 1, jPos) != PacmanElement.Wall)
						return true;
					break;

				case Direction.Right:
					if (grid.GetElementAt(iPos + 1, jPos) != PacmanElement.Wall)
						return true;
					break;

				default:
					return false;

			}

			return false;

		}

		public void ChangeDirection(Direction direction, Grid grid)
		{

			if (CanMove(direction, grid))
				toMoveDirection = direction;

		}

	}
}
