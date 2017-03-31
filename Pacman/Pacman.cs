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

		private static readonly Texture PacmanTexture;

		public const float UPDATE_TICKRATE = 0.3f;
		public const float PACSPEED = 0.15f;
		public const int TEXTURE_SIZE = 13;

		private static CircleShape body;
		private Direction direction;
		private float totalTime;
		private Direction toMoveDirection;
		private Sprite[,] pacmanSprite;

		private int _iPos;
		private int _jPos;

		private float iSpritePos;
		private float jSpritePos;

		private int currentFrame;

		private float tolarence = 0.05f;

		private static RectangleShape debugPos;

		public int iPos
		{

			get { return Math.Max(0, Math.Min(Grid.GRID_WIDTH - 1,_iPos));}

		}

		public int jPos
		{

			get { return _jPos; }

		}

		public Direction ToMove
		{
			get { return toMoveDirection; }
		}

		static Pacman()
		{
			
			PacmanTexture = new Texture(new Image("Assets/Art/pacman.png"));

			body = new CircleShape(Grid.TILE_SIZE / 2f);
			body.FillColor = Color.Yellow;

			debugPos = new RectangleShape(new Vector2f(Grid.TILE_SIZE, Grid.TILE_SIZE));
			debugPos.FillColor = Color.Red;

		}

		public Pacman()
		{
			
			direction = Direction.Up;
			totalTime = 0;

			_jPos = 23;
			_iPos = 13;
			toMoveDirection = Direction.Up;

			iSpritePos = _iPos;
			jSpritePos = _jPos;

			currentFrame = 0;

			SetUpSprites();

		}

		private void SetUpSprites()
		{
			
			pacmanSprite = new Sprite[PacmanTexture.Size.X / TEXTURE_SIZE, PacmanTexture.Size.Y / TEXTURE_SIZE];

			for (int j = 0; j < pacmanSprite.GetLength(1); j++)
			{
				for (int i = 0; i < pacmanSprite.GetLength(0); i++)
				{
					
					pacmanSprite[i,j] = new Sprite(PacmanTexture, new IntRect(i * TEXTURE_SIZE, j * TEXTURE_SIZE, TEXTURE_SIZE, TEXTURE_SIZE));
					pacmanSprite[i, j].Scale = new Vector2f(Grid.TILE_SIZE / 8f, Grid.TILE_SIZE / 8f);

				}
			}

		}

		public void Update(float time, Grid grid)
		{

			totalTime += time;

			float oldiPos = iSpritePos;
			float oldjPos = jSpritePos;

			Move(ToMove, grid);

			if (totalTime > 0.075f)
			{

				totalTime = 0;

				if (oldiPos != iSpritePos || oldjPos != jSpritePos)
					currentFrame++;
				else
					currentFrame = 0;

				if (currentFrame > 2)
				{
					currentFrame = 0;
				}

			}

		}

		public void Draw(RenderWindow window)
		{

			if (currentFrame == 2)
			{
				pacmanSprite[2, 0].Position = new Vector2f(iSpritePos * Grid.TILE_SIZE - (Grid.TILE_SIZE * 0.3f), jSpritePos * Grid.TILE_SIZE + Grid.DRAW_OFFSET - (Grid.TILE_SIZE * 0.3f));
				window.Draw(pacmanSprite[2, 0]);
			}
			else
			{
				pacmanSprite[currentFrame, (int)ToMove].Position = new Vector2f(iSpritePos * Grid.TILE_SIZE - (Grid.TILE_SIZE * 0.3f), jSpritePos * Grid.TILE_SIZE + Grid.DRAW_OFFSET - (Grid.TILE_SIZE * 0.3f));
				window.Draw(pacmanSprite[currentFrame, (int)ToMove]);
			}

			debugPos.Position = new Vector2f(_iPos * Grid.TILE_SIZE, _jPos * Grid.TILE_SIZE + Grid.DRAW_OFFSET);
			//window.Draw(debugPos);

			body.Position = new Vector2f(iSpritePos * Grid.TILE_SIZE, jSpritePos * Grid.TILE_SIZE + Grid.DRAW_OFFSET);
			//window.Draw(body);

		}

		public void Move(Direction direction, Grid grid)
		{

			switch (direction)
			{

				//case Direction.Up:
				//	if (CanMove(Direction.Up, grid))
				//		_jPos--;
				//	break;

				//case Direction.Down:
				//	if (CanMove(Direction.Down, grid))
				//		_jPos++;
				//	break;

				//case Direction.Left:
				//	if (CanMove(Direction.Left, grid))
				//	{
				//		_iPos--;
				//		if (_iPos < 0)
				//			_iPos = Grid.GRID_WIDTH - 1;
				//	}

				//	break;

				//case Direction.Right:
				//	if (CanMove(Direction.Right, grid))
				//	{
				//		_iPos++;
				//		if (_iPos >= Grid.GRID_WIDTH)
				//			_iPos = 0;
				//	}
				//	break;

				case Direction.Left:
					iSpritePos -= PACSPEED;
					if (iSpritePos < -0.5f)
						iSpritePos = Grid.GRID_WIDTH - 0.5f;
					if (!CanMove(Direction.Left, grid))
						iSpritePos = Math.Max(_iPos, iSpritePos);
					break;

				case Direction.Right:
					iSpritePos += PACSPEED;
					if (iSpritePos >= Grid.GRID_WIDTH - 1.5f)
						iSpritePos = -0.5f;
					if (!CanMove(Direction.Right, grid))
						iSpritePos = Math.Min(_iPos, iSpritePos);
					break;

				case Direction.Up:
					jSpritePos -= PACSPEED;
					if (!CanMove(Direction.Up, grid))
						jSpritePos = Math.Max(_jPos, jSpritePos);
					break;

				case Direction.Down:
					jSpritePos += PACSPEED;
						if (!CanMove(Direction.Down, grid))
						jSpritePos = Math.Min(_jPos, jSpritePos);
					break;

			}

			UpdatePos();

		}

		private void UpdatePos()
		{

			//Center of the Pacman sprite
			_iPos = (int)(iSpritePos + (body.Radius / Grid.TILE_SIZE));

			_jPos = (int)(jSpritePos + (body.Radius / Grid.TILE_SIZE));

		}

		private bool CanMove(Direction direction, Grid grid)
		{

			switch (direction)
			{

				case Direction.Up:
					if (grid.GetElementAtPacman((int)_iPos, (int)_jPos - 1) == PacmanElement.Empty 
						|| grid.GetElementAtPacman((int)_iPos, (int)_jPos - 1) == PacmanElement.Dot
						|| grid.GetElementAtPacman((int)_iPos, (int)_jPos - 1) == PacmanElement.Pellet)
						return true;
					break;

				case Direction.Down:
					if (grid.GetElementAtPacman((int)_iPos, (int)_jPos + 1) == PacmanElement.Empty 
						|| grid.GetElementAtPacman((int)_iPos, (int)_jPos + 1) == PacmanElement.Dot
						|| grid.GetElementAtPacman((int)_iPos, (int)_jPos + 1) == PacmanElement.Pellet)
						return true;
					break;

				case Direction.Left:
					if (grid.GetElementAtPacman((int)_iPos - 1, (int)_jPos) == PacmanElement.Empty 
						|| grid.GetElementAtPacman((int)_iPos - 1, (int)_jPos) == PacmanElement.Dot
						|| grid.GetElementAtPacman((int)_iPos - 1, (int)_jPos) == PacmanElement.Pellet)
						return true;
					break;

				case Direction.Right:
					if (grid.GetElementAtPacman((int)_iPos + 1, (int)_jPos) == PacmanElement.Empty 
						|| grid.GetElementAtPacman((int)_iPos + 1, (int)_jPos) == PacmanElement.Dot
						|| grid.GetElementAtPacman((int)_iPos + 1, (int)_jPos) == PacmanElement.Pellet)
						return true;
					break;

				default:
					return false;

			}

			return false;

		}

		private bool IsInBounds(Direction direction)
		{

			if (direction == Direction.Right || direction == Direction.Left)
			{
				for (float jPosTest = jSpritePos - tolarence; jPosTest <= jSpritePos + tolarence; jPosTest += tolarence)
				{

					if (Math.Round(jPosTest, 1) == (float) _jPos)
					{

						jSpritePos = _jPos;

						return true;

					}

				}

			}
			else
			{

				for (float iPosTest = iSpritePos - tolarence; iPosTest <= iSpritePos + tolarence; iPosTest += tolarence)
				{

					if (Math.Round(iPosTest, 1) == (float) _iPos)
					{

						iSpritePos = _iPos;

						return true;

					}

				}

			}

			return false;

		}

		public void ChangeDirection(Direction direction, Grid grid)
		{

			if (CanMove(direction, grid) && IsInBounds(direction))
				toMoveDirection = direction;

		}

	}
}
