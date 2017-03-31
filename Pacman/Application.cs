using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Diagnostics;

namespace Pacman
{
	class Application
	{

		#region Global vars

		//The window of application
		private RenderWindow window;

		public const int WINDOW_HEIGHT = 248 * Program.SCALE + Grid.TILE_SIZE * 5;
		public const int WINDOW_WIDTH = 224 * Program.SCALE;
		//Used to time the movement of the objects on screen
		Clock clock = new Clock();
		Time gameTime = new Time();

		#endregion

		private Grid grid;
		private Pacman pacman;
		private Ghost ghost;

		/// <summary>
		/// Constructor of the window
		/// </summary>
		/// <param name="windowHeight">Height of the window</param>
		/// <param name="windowWidth">Width of the window</param>
		/// <param name="title">Title of the window</param>
		/// <param name="style">Style of the window</param>
		public Application(uint windowHeight = WINDOW_HEIGHT, uint windowWidth = WINDOW_WIDTH, string title = "Pacman", Styles style = Styles.Close)
		{

			window = new RenderWindow(new VideoMode(windowWidth, windowHeight), title, style);

			window.SetFramerateLimit(60);
			window.SetActive(true);
			window.SetMouseCursorVisible(false);

			//Add the keypressed function to the window

			//Add the Closed function to the window
			window.Closed += window_Closed;

		}


		/// <summary>
		/// Main loop of the program
		/// </summary>
		public void Run()
		{

			window.SetVisible(true);

			Init_Game();

			while (window.IsOpen)
			{

				//Call the Events
				window.DispatchEvents();
				KeyPressed();

				//Update the game
				Update();

				//Draw the updated app
				Draw();

			}


		}

		#region Input functions

		/// <summary>
		/// Called whenever a key is pressed
		/// </summary>
		void KeyPressed()
		{

			if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
			{
				
				window.Close();

			}
			if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
			{

				pacman.ChangeDirection(Direction.Up, grid);

			}
			if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
			{

				pacman.ChangeDirection(Direction.Left, grid);

			}
			if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
			{

				pacman.ChangeDirection(Direction.Down, grid);

			}
			if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
			{

				pacman.ChangeDirection(Direction.Right, grid);

			}

		}

		/// <summary>
		/// Called when the window "X" is clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void window_Closed(object sender, EventArgs e)
		{

			window.Close();

		}

		#endregion

		/// <summary>
		/// Update code of the program
		/// </summary>
		private void Update()
		{

			gameTime = clock.Restart();

			pacman.Update(gameTime.AsSeconds(), grid);
			grid.Update(gameTime.AsSeconds(), pacman);
			ghost.Update(gameTime.AsSeconds(), grid, pacman);

		}

		/// <summary>
		/// Draw code of the program
		/// </summary>
		private void Draw()
		{

			window.Clear();

			grid.Draw(window);
			pacman.Draw(window);
			ghost.Draw(window);

            window.Display();

		}

		private void Init_Game()
		{
			
			grid = new Grid();
			pacman = new Pacman();
            ghost = new Ghost();

		}

	}
}
