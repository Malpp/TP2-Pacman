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

		public const float UPDATE_TICKRATE = 200f;

		private static RectangleShape body;
		private Direction direction;
		private float totalTime;

		private int iPos;
		private int jPos;

		private float iOffset;
		private float jOffset;

		static Pacman()
		{
			
			body = new RectangleShape(new Vector2f(Grid.TILE_SIZE, Grid.TILE_SIZE));
			body.FillColor = Color.Yellow;

		}

		public Pacman()
		{
			
			direction = Direction.Up;
			totalTime = 0;

			jPos = 23;
			iPos = 15;

		}

		public void Update(float time, Grid grid)
		{

			totalTime += time;

			if (totalTime > UPDATE_TICKRATE)
			{

				totalTime = 0;



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
					if (grid.GetElementAt(iPos, jPos - 1) != PacmanElement.Wall)
						jPos--;
					break;

				case Direction.Down:
					if (grid.GetElementAt(iPos, jPos + 1) != PacmanElement.Wall)
						jPos++;
					break;

				case Direction.Left:
					if (grid.GetElementAt(iPos - 1, jPos) != PacmanElement.Wall)
					{
						iPos--;
						if (iPos < 0)
							iPos = Grid.GRID_WIDTH - 1;
					}

					break;

				case Direction.Right:
					if (grid.GetElementAt(iPos + 1, jPos) != PacmanElement.Wall)
					{
						iPos++;
						if (iPos >= Grid.GRID_WIDTH)
							iPos = 0;
					}
					break;

			}

		}

	}
}
