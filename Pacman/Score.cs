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
	static class Score
	{

		public const int TOTAL_DOTS = 240;
		public const int TOTAL_PELLET = 4;
		public const int SCORE_DOTS = 10;
		public const int SCORE_PELLETS = 50;
		public const int SCORE_GHOST = 200;

		public static readonly Font textFont;

		private static int dotsEaten;
		private static int pelletsEaten;
		private static bool dotCompleteFlag;
		private static bool pelletCompleteFlag;
		private static int score;
		private static Text scoreText;
		private static int ghostMultiplier;
		private static int currentScoreLength;
		private static Text highScoreText;
		private static Text highScoreScoreText;
		private static int highScore;
		private static int currentHighScoreLength;
		private static int lives;
		private static Sprite lifeSprite;
		private static bool gameOver;
		private static bool beatHighScore;

		static Score()
		{
			
			textFont = new Font("Assets/emulogic.ttf");
			dotsEaten = 0;
			pelletsEaten = 0;
			dotCompleteFlag = false;
			pelletCompleteFlag = false;
			score = 0;
			scoreText = new Text("00", textFont, Grid.TILE_SIZE);
			scoreText.Origin = new Vector2f(-Grid.TILE_SIZE * 5, -Grid.TILE_SIZE);
			ghostMultiplier = 1;
			highScoreText = new Text("HIGH SCORE", textFont, Grid.TILE_SIZE);
			highScoreText.Position = new Vector2f(Grid.TILE_SIZE * 9, 0);

			GetHighScoreFromFile();

			highScoreScoreText = new Text(highScore.ToString(), textFont, Grid.TILE_SIZE);
			UpdateHighScoreText();

			lifeSprite  = new Sprite(Pacman.PacmanTexture, new IntRect(Pacman.TEXTURE_SIZE, Pacman.TEXTURE_SIZE, Pacman.TEXTURE_SIZE, Pacman.TEXTURE_SIZE));
			lifeSprite.Scale = new Vector2f(Grid.TILE_SIZE / 8f * 0.8f, Grid.TILE_SIZE / 8f * 0.8f);

			lives = 2;
			gameOver = false;
			beatHighScore = false;

		}

		public static bool GameOver
		{
			get { return gameOver; }
		}

		public static void Draw(RenderWindow window)
		{
			
			window.Draw(scoreText);
			window.Draw(highScoreText);
			window.Draw(highScoreScoreText);

			for (int i = lives; i > 0; i--)
			{
				lifeSprite.Position = new Vector2f(Grid.TILE_SIZE * i * 1.7f + Grid.TILE_SIZE, Grid.TILE_SIZE * 34);
				window.Draw(lifeSprite);
			}

		}

		public static void EatDot()
		{

			dotsEaten++;
			score += SCORE_DOTS;
			UpdateScoreText();
			if (dotsEaten >= TOTAL_DOTS)
				dotCompleteFlag = true;

		}

		public static void EatPellet()
		{

			pelletsEaten++;
			score += SCORE_PELLETS;
			UpdateScoreText();
			if (pelletsEaten >= TOTAL_PELLET)
				pelletCompleteFlag = true;

		}

		public static int EatGhost()
		{

			score += SCORE_GHOST * ghostMultiplier;
			ghostMultiplier *= 2;
			UpdateScoreText();

			return SCORE_GHOST * ghostMultiplier;

		}

		public static void ResetMultipler()
		{

			ghostMultiplier = 1;

		}

		public static bool IsBoardCleared()
		{

			return dotCompleteFlag && pelletCompleteFlag;

		}

		private static void UpdateScoreText()
		{

			if (score > highScore)
			{
				beatHighScore = true;
				highScore = score;
				UpdateHighScoreText();
			}

			scoreText.DisplayedString = score.ToString();
			if (scoreText.DisplayedString.Length > currentScoreLength)
			{
				currentScoreLength = scoreText.DisplayedString.Length;
				scoreText.Origin = new Vector2f(-Grid.TILE_SIZE * (7 - currentScoreLength), -Grid.TILE_SIZE);
			}

		}

		private static void UpdateHighScoreText()
		{

			highScoreScoreText.DisplayedString = highScore.ToString();
			if (highScoreScoreText.DisplayedString.Length > currentHighScoreLength)
			{
				currentHighScoreLength = highScoreScoreText.DisplayedString.Length;
				highScoreScoreText.Origin = new Vector2f(-Grid.TILE_SIZE * (17 - currentHighScoreLength), -Grid.TILE_SIZE);
			}

		}

		public static void LostLife()
		{
			lives--;

			if (lives < 0)
				gameOver = true;

		}

		public static void Reset()
		{
			if (beatHighScore)
			{
				SetHighScoreToFile();
				GetHighScoreFromFile();
			}
			beatHighScore = false;
			lives = 2;
			gameOver = false;
			score = 0;
			scoreText.DisplayedString = "00";
			dotCompleteFlag = false;
			pelletCompleteFlag = false;
			pelletsEaten = 0;
			dotsEaten = 0;
		}

		public static void WinReset()
		{
			dotCompleteFlag = false;
			pelletCompleteFlag = false;
			pelletsEaten = 0;
			dotsEaten = 0;
		}

		private static void SetHighScoreToFile()
		{
			File.WriteAllText(@"Assets\highscore.txt", highScore.ToString());
		}

		private static void GetHighScoreFromFile()
		{

			string text = File.ReadAllText(@"Assets\highscore.txt");

			highScore = int.Parse(text);


		}

	}
}
