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

		public const int GRID_WIDTH = 29;
		public const int GRID_HEIGHT = 31;
		public const int TILE_SIZE = 16;

		private PacmanElement[,] grid;

		private static RectangleShape wall;

		/// <summary>
		/// Initializes the <see cref="Grid" /> class.
		/// </summary>
		static Grid()
		{

			wall = new RectangleShape(new Vector2f(TILE_SIZE, TILE_SIZE));
			wall.FillColor = Color.Blue;

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Grid" /> class.
		/// </summary>
		public Grid()
		{

			grid = new PacmanElement[GRID_WIDTH, GRID_HEIGHT];

			LoadLevel();

		}

		/// <summary>
		/// Updates the grid
		/// </summary>
		/// <param name="time">The time elapsed</param>
		public void Update(float time = 0)
		{



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

					if (grid[j, i] == PacmanElement.Wall)
					{

						wall.Position = new Vector2f(TILE_SIZE * j, TILE_SIZE * i);
						window.Draw(wall);

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

					string[] rows = line.Split('\n');

					for (int i = 0; i < GRID_HEIGHT; i++)
					{

						for (int j = 0; j < GRID_WIDTH; j++)
						{

							grid[j, i] = (PacmanElement)rows[i][j];

						}

					}

				}
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine("The file could not be found:");
				Console.WriteLine(e.Message);
			}

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
				
				throw new ArgumentOutOfRangeException();

			}

			return grid[i, j];

		}

	}
}
