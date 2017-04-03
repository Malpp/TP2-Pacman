using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Pacman
{
	class Grid
	{

		//<pmccormick>

		#region Variables

		public const int GRID_WIDTH = 29;
		public const int GRID_HEIGHT = 31;
		public const int TILE_SIZE = 8 * Program.SCALE;
		public const int DRAW_OFFSET = TILE_SIZE * 3;

		private static readonly Texture sCornerTexture;
		private Sprite sCornerSprite;

		private static readonly Texture sWallTexture;
		private Sprite sWallSprite;

		private static readonly Texture dWallTexture;
		private Sprite dWallSprite;

		private static readonly Texture bCornerTexture;
		private Sprite bCornerSprite;

		private static readonly Texture dCornerTexture;
		private Sprite dCornerSprite;

		private static readonly Texture cCornerTexture;
		private Sprite cCornerSprite;

		private static readonly Texture jEndTexture;
		private Sprite jEndSprite;

		private static readonly Texture jDoorTexture;
		private Sprite jDoorSprite;

		private static readonly Texture dotTexture;
		private Sprite dotSprite;

		private static readonly Texture pelletTexture;
		private Sprite pelletSprite;

		private PacmanElement[,] grid;

		private static RectangleShape wall;

		private bool shouldBlink;
		private float totalTime;
        private bool isPelletActive;
        private float pelletTime;

		public bool IsPelletActive
		{
			get { return isPelletActive; }
		}

		public int Width
		{
			get { return grid.GetLength(0); }
		}

		public int Height
		{
			get { return grid.GetLength(1); }
		}

		#endregion
		/// <summary>
		/// Initializes the <see cref="Grid" /> class.
		/// </summary>
		static Grid()
		{

			wall = new RectangleShape(new Vector2f(TILE_SIZE, TILE_SIZE));
			wall.FillColor = Color.Blue;

			sCornerTexture = new Texture(new Image("Assets/Art/corner.png"));
			sWallTexture = new Texture(new Image("Assets/Art/swall.png"));
			dWallTexture = new Texture(new Image("Assets/Art/dwall.png"));
			bCornerTexture = new Texture(new Image("Assets/Art/bcorner.png"));
			dCornerTexture = new Texture(new Image("Assets/Art/dcorner.png"));
			cCornerTexture = new Texture(new Image("Assets/Art/cCorner.png"));
			jEndTexture = new Texture(new Image("Assets/Art/jEnd.png"));
			jDoorTexture = new Texture(new Image("Assets/Art/jdoor.png"));
			dotTexture = new Texture(new Image("Assets/Art/pacdot.png"));
			pelletTexture = new Texture(new Image("Assets/Art/pellet.png"));

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Grid" /> class.
		/// </summary>
		public Grid()
		{

			grid = new PacmanElement[GRID_WIDTH, GRID_HEIGHT];

			LoadLevel();

			sCornerSprite = new Sprite(sCornerTexture);
			sCornerSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);
			
			sWallSprite = new Sprite(sWallTexture);
			sWallSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);

			dWallSprite = new Sprite(dWallTexture);
			dWallSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);

			dCornerSprite = new Sprite(dCornerTexture);
			dCornerSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);

			bCornerSprite = new Sprite(bCornerTexture);
			bCornerSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);

			cCornerSprite = new Sprite(cCornerTexture);
			cCornerSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);

			jEndSprite = new Sprite(jEndTexture);
			jEndSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);

			jDoorSprite = new Sprite(jDoorTexture);
			jDoorSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);

			dotSprite = new Sprite(dotTexture);
			dotSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);

			pelletSprite = new Sprite(pelletTexture);
			pelletSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);

			shouldBlink = true;
			totalTime = 0;

		}

		/// <summary>
		/// Updates the grid
		/// </summary>
		/// <param name="time">The time elapsed</param>
		public void Update(float time, Pacman pacman)
		{

			totalTime += time;
            pelletTime += time;

			if (totalTime > 0.2f)
			{

				shouldBlink = !shouldBlink;
				totalTime = 0;

			}

			if (grid[pacman.iPos, pacman.jPos] == PacmanElement.Dot)
			{

				grid[pacman.iPos, pacman.jPos] = PacmanElement.Empty;
				Score.EatDot();

			}
			if (grid[pacman.iPos, pacman.jPos] == PacmanElement.Pellet)
			{

				grid[pacman.iPos, pacman.jPos] = PacmanElement.Empty;
				Score.EatPellet();
                isPelletActive = true;
			}

            if (isPelletActive && pelletTime > 10f)
            {
                
                isPelletActive = false;
                pelletTime = 0;
            }

		}

		/// <summary>
		/// Draws the grid.
		/// </summary>
		/// <param name="window">The window.</param>
		public void Draw(RenderWindow window)
		{

			for (int i = 0; i < GRID_HEIGHT; i++)
			{
				for (int j = 0; j < GRID_WIDTH; j++)
				{

					switch(grid[j, i])
					{

						case PacmanElement.Wall:
							wall.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * i + DRAW_OFFSET);
							window.Draw(wall);
							break;

						case PacmanElement.Dot:
							dotSprite.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * i + DRAW_OFFSET);
							window.Draw(dotSprite);
							break;

						case PacmanElement.Pellet:
							pelletSprite.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * i + DRAW_OFFSET);
							if(shouldBlink)
								window.Draw(pelletSprite);
							break;

						#region Small Corner
						case PacmanElement.SCornerBL:
							sCornerSprite.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * i + DRAW_OFFSET);
							sCornerSprite.Rotation = 0;
							window.Draw(sCornerSprite);
							break;

						case PacmanElement.SCornerTL:
							sCornerSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * i + DRAW_OFFSET);
							sCornerSprite.Rotation = 90;
							window.Draw(sCornerSprite);
							break;

						case PacmanElement.SCornerTR:
							sCornerSprite.Position = new Vector2f(TILE_SIZE * (j+1), TILE_SIZE * (i + 1) + DRAW_OFFSET);
							sCornerSprite.Rotation = 180;
							window.Draw(sCornerSprite);
							break;

						case PacmanElement.SCornerBR:
							sCornerSprite.Position = new Vector2f(TILE_SIZE * (j), TILE_SIZE * (i + 1) + DRAW_OFFSET);
							sCornerSprite.Rotation = 270;
							window.Draw(sCornerSprite);
							break;
						#endregion

						#region Single Wall
						case PacmanElement.SWallB:
							sWallSprite.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * i + DRAW_OFFSET);
							sWallSprite.Rotation = 0;
							window.Draw(sWallSprite);
							break;

						case PacmanElement.SWallL:
							sWallSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * i + DRAW_OFFSET);
							sWallSprite.Rotation = 90;
							window.Draw(sWallSprite);
							break;

						case PacmanElement.SWallT:
							sWallSprite.Position = new Vector2f(TILE_SIZE*(j + 1), TILE_SIZE * (i + 1) + DRAW_OFFSET);
							sWallSprite.Rotation = 180;
							window.Draw(sWallSprite);
							break;

						case PacmanElement.SWallR:
							sWallSprite.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * (i + 1) + DRAW_OFFSET);
							sWallSprite.Rotation = 270;
							window.Draw(sWallSprite);
							break;
						#endregion

						#region Double Wall
						case PacmanElement.DWallB:
							dWallSprite.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * i + DRAW_OFFSET);
							dWallSprite.Rotation = 0;
							window.Draw(dWallSprite);
							break;

						case PacmanElement.DWallL:
							dWallSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * i + DRAW_OFFSET);
							dWallSprite.Rotation = 90;
							window.Draw(dWallSprite);
							break;

						case PacmanElement.DWallT:
							dWallSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * (i + 1) + DRAW_OFFSET);
							dWallSprite.Rotation = 180;
							window.Draw(dWallSprite);
							break;

						case PacmanElement.DWallR:
							dWallSprite.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * (i + 1) + DRAW_OFFSET);
							dWallSprite.Rotation = 270;
							window.Draw(dWallSprite);
							break;
						#endregion

						#region Big Corner
						case PacmanElement.BCornerBL:
							bCornerSprite.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * i + DRAW_OFFSET);
							bCornerSprite.Rotation = 0;
							window.Draw(bCornerSprite);
							break;

						case PacmanElement.BCornerTL:
							bCornerSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * i + DRAW_OFFSET);
							bCornerSprite.Rotation = 90;
							window.Draw(bCornerSprite);
							break;

						case PacmanElement.BCornerTR:
							bCornerSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * (i + 1) + DRAW_OFFSET);
							bCornerSprite.Rotation = 180;
							window.Draw(bCornerSprite);
							break;

						case PacmanElement.BCornerBR:
							bCornerSprite.Position = new Vector2f(TILE_SIZE * (j), TILE_SIZE * (i + 1) + DRAW_OFFSET);
							bCornerSprite.Rotation = 270;
							window.Draw(bCornerSprite);
							break;
						#endregion

						#region Double Corner
						case PacmanElement.DCornerBL:
							dCornerSprite.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * i + DRAW_OFFSET);
							dCornerSprite.Rotation = 0;
							window.Draw(dCornerSprite);
							break;

						case PacmanElement.DCornerTL:
							dCornerSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * i + DRAW_OFFSET);
							dCornerSprite.Rotation = 90;
							window.Draw(dCornerSprite);
							break;

						case PacmanElement.DCornerTR:
							dCornerSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * (i + 1) + DRAW_OFFSET);
							dCornerSprite.Rotation = 180;
							window.Draw(dCornerSprite);
							break;

						case PacmanElement.DCornerBR:
							dCornerSprite.Position = new Vector2f(TILE_SIZE * (j), TILE_SIZE * (i + 1) + DRAW_OFFSET);
							dCornerSprite.Rotation = 270;
							window.Draw(dCornerSprite);
							break;
						#endregion

						#region Corner Corner
						case PacmanElement.CCornerBL:
							cCornerSprite.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * i + DRAW_OFFSET);
							cCornerSprite.Rotation = 0;
							cCornerSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);
							window.Draw(cCornerSprite);
							break;

						case PacmanElement.CCornerTL:
							cCornerSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * i + DRAW_OFFSET);
							cCornerSprite.Rotation = 90;
							cCornerSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);
							window.Draw(cCornerSprite);
							break;

						//case PacmanElement.CCornerTR:
						//	cCornerSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * (i + 1));
						//	cCornerSprite.Rotation = 180;
						//	window.Draw(cCornerSprite);
						//	break;

						case PacmanElement.CCornerBR:
							cCornerSprite.Position = new Vector2f(TILE_SIZE * (j), TILE_SIZE * (i + 1) + DRAW_OFFSET);
							cCornerSprite.Rotation = 270;
							cCornerSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);
							window.Draw(cCornerSprite);
							break;

						case PacmanElement.CCornerBLFlipped:
							cCornerSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * i + DRAW_OFFSET);
							cCornerSprite.Rotation = 0;
							cCornerSprite.Scale = new Vector2f(-TILE_SIZE / 8f, TILE_SIZE / 8f);
							window.Draw(cCornerSprite);
							break;

						case PacmanElement.CCornerTLFlipped:
							cCornerSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * (i + 1) + DRAW_OFFSET);
							cCornerSprite.Rotation = 90;
							cCornerSprite.Scale = new Vector2f(-TILE_SIZE / 8f, TILE_SIZE / 8f);
							window.Draw(cCornerSprite);
							break;

						//case PacmanElement.CCornerTR:
						//	cCornerSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * (i + 1));
						//	cCornerSprite.Rotation = 180;
						//	window.Draw(cCornerSprite);
						//	break;

						case PacmanElement.CCornerBRFlipped:
							cCornerSprite.Position = new Vector2f(TILE_SIZE * (j), TILE_SIZE * (i) + DRAW_OFFSET);
							cCornerSprite.Rotation = 270;
							cCornerSprite.Scale = new Vector2f(-TILE_SIZE / 8f, TILE_SIZE / 8f);
							window.Draw(cCornerSprite);
							break;

						#endregion

						#region Jail End
						case PacmanElement.JEndL:
							jEndSprite.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * i + DRAW_OFFSET);
							jEndSprite.Scale = new Vector2f(TILE_SIZE / 8f, TILE_SIZE / 8f);
							window.Draw(jEndSprite);
							break;

						case PacmanElement.JEndR:
							jEndSprite.Position = new Vector2f(TILE_SIZE * (j + 1), TILE_SIZE * (i) + DRAW_OFFSET);
							jEndSprite.Scale = new Vector2f(-TILE_SIZE / 8f, TILE_SIZE / 8f);
							window.Draw(jEndSprite);
							break;
						#endregion

						//Jail door
						case PacmanElement.Jail:
							jDoorSprite.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * i + DRAW_OFFSET);
							window.Draw(jDoorSprite);
							break;

					}

				}
			}

		}

		/// <summary>
		/// Loads the level.
		/// </summary>
		private void LoadLevel()
		{

			//https://msdn.microsoft.com/en-us/library/db5x7c0d(v=vs.110).aspx
			try
			{
				using (StreamReader sr = new StreamReader("Assets/Level.txt"))
				{
					// Read the stream to a string, and write the string to the console.
					String line = sr.ReadToEnd();

					LoadLevelFromString(line);

				}
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine("The file could not be found:");
				Console.WriteLine(e.Message);
			}

		}

		/// <summary>
		/// Loads the level from a string.
		/// </summary>
		/// <param name="line">The line.</param>
		/// <returns></returns>
		public bool LoadLevelFromString(string line)
		{
			bool toReturn = true;

			if (line == "")
				toReturn = false;

			string[] rows = line.Split(new char[] {'\r','\n'});

			if (rows.Length != GRID_HEIGHT)
				toReturn = false;

			foreach (string row in rows)
			{

				if (row.Length != Grid.GRID_WIDTH - 1 && row.Length != Grid.GRID_WIDTH)
					toReturn = false;

			}

			if (toReturn)
			{

				for (int i = 0; i < GRID_HEIGHT; i++)
				{

					for (int j = 0; j < GRID_WIDTH; j++)
					{

						grid[j, i] = (PacmanElement) rows[i][j];

					}

				}

			}

			return toReturn;
		}

		/// <summary>
		/// Gets the PacmanElement at the specific location of the grid
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="j">The j.</param>
		/// <returns>The PacmanElement</returns>
		/// <exception cref="System.ArgumentOutOfRangeException"></exception>
		public PacmanElement GetElementAt(int i, int j)
		{

			if (i >= GRID_WIDTH || i < 0 || j >= GRID_HEIGHT || j < 0)
			{
				
				//throw new ArgumentOutOfRangeException();
				return PacmanElement.Wall;

			}

			return grid[i, j];

		}

		/// <summary>
		/// Gets the element for the pacman.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="j">The j.</param>
		/// <returns></returns>
		public PacmanElement GetElementAtPacman(int i, int j)
		{

			if (i >= GRID_WIDTH || i < 0 || j >= GRID_HEIGHT || j < 0)
			{

				//throw new ArgumentOutOfRangeException();
				return PacmanElement.Empty;

			}

			return grid[i, j];

		}

	}
}
