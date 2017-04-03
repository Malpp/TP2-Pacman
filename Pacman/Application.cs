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
		private Ghost blinky;
        private Ghost inky;
        private Ghost pinky;
        private Ghost clyde;
		private GameState gameState;
		private Text readyText;
		private float readyTime;
		private Text gameOverText;
		private float gameOverTime;
		private float winTime;

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

			readyText = new Text("READY!", Score.textFont, Grid.TILE_SIZE);
			readyText.Position = new Vector2f(Grid.TILE_SIZE * 11, Grid.TILE_SIZE * 20);
			readyText.Color = Color.Yellow;

			gameOverText = new Text("GAME  OVER", Score.textFont, Grid.TILE_SIZE);
			gameOverText.Position = new Vector2f(Grid.TILE_SIZE * 9, Grid.TILE_SIZE * 20);
			gameOverText.Color = Color.Red;

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
			if (gameState == GameState.Playing)
			{
				if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
				{

					pacman.ChangeDirection(Direction.Up, grid);

				}
				else if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
				{

					pacman.ChangeDirection(Direction.Left, grid);

				}
				else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
				{

					pacman.ChangeDirection(Direction.Down, grid);

				}
				else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
				{

					pacman.ChangeDirection(Direction.Right, grid);

				}
			}

			if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
			{

				window.Close();

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

			if (gameState == GameState.Ready)
			{
				readyTime += gameTime.AsSeconds();

				if(readyTime > 2f)
					gameState = GameState.Playing;

			}
			else if (gameState == GameState.Playing)
			{
				pacman.Update(gameTime.AsSeconds(), grid);
				grid.Update(gameTime.AsSeconds(), pacman);
				blinky.Update(gameTime.AsSeconds(), grid, pacman, GhostNames.blinky);
                inky.Update(gameTime.AsSeconds(), grid, pacman, GhostNames.inky);
                pinky.Update(gameTime.AsSeconds(), grid, pacman, GhostNames.pinky);
                clyde.Update(gameTime.AsSeconds(), grid, pacman, GhostNames.clyde);

                if (pacman.IsDead)
				{
					Score.LostLife();
					if (Score.GameOver)
						gameState = GameState.Lose;
					else
						Init_Game();
				}else if (Score.IsBoardCleared())
				{
					gameState = GameState.Win;
				}

			}
			else if(gameState == GameState.Lose)
			{

				grid.Update(gameTime.AsSeconds(), pacman);

				gameOverTime += gameTime.AsSeconds();

				if (gameOverTime > 2f)
				{
					Init_Game();
					Score.Reset();
				}

			}
			else
			{

				winTime += gameTime.AsSeconds();

				if (winTime > 2f)
				{
					Init_Game();
					Score.WinReset();
				}

			}


		}

		/// <summary>
		/// Draw code of the program
		/// </summary>
		private void Draw()
		{

			window.Clear();

			Score.Draw(window);

			if (gameState == GameState.Ready)
				window.Draw(readyText);

			if (gameState == GameState.Lose)
			{
				window.Draw(gameOverText);
			}

			grid.Draw(window);
			pacman.Draw(window);
			blinky.Draw(window);
            inky.Draw(window);
            pinky.Draw(window);
            clyde.Draw(window);

            window.Display();

		}

		private void Init_Game()
		{
			
			grid = new Grid();
			pacman = new Pacman();
            blinky = new Ghost(GhostNames.blinky);
            inky = new Ghost(GhostNames.inky);
            pinky = new Ghost(GhostNames.pinky);
            clyde = new Ghost(GhostNames.clyde);
			gameState = GameState.Ready;
			readyTime = 0;
			gameOverTime = 0;
			winTime = 0;

		}

	}
}
