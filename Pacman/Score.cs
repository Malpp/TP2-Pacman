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
	class Score
	{

		public const int TOTAL_DOTS = 240;
		public const int TOTAL_PELLET = 4;
		public const int SCORE_DOTS = 10;
		public const int SCORE_PELLETS = 50;
		public const int SCORE_GHOST = 200;

		public static readonly Font textFont;

		private int dotsEaten;
		private int pelletsEaten;
		private bool dotCompleteFlag;
		private bool pelletCompleteFlag;
		private int score;
		private Text scoreText;
		private int ghostMultiplier;
		private int currentScoreLength;
		private Text highScoreText;
		private Text highScoreScoreText;
		private int highScore;
		private int currentHighScoreLength;

		static Score()
		{
			
			textFont = new Font("Assets/emulogic.ttf");

		}

		public Score()
		{

			dotsEaten = 0;
			pelletsEaten = 0;
			dotCompleteFlag = false;
			pelletCompleteFlag = false;
			score = 0;
			scoreText = new Text("00", textFont, Grid.TILE_SIZE);
			scoreText.Origin = new Vector2f(-Grid.TILE_SIZE * 5,-Grid.TILE_SIZE);
			ghostMultiplier = 1;
			highScoreText = new Text("HIGH SCORE", textFont, Grid.TILE_SIZE);
			highScoreText.Position = new Vector2f(Grid.TILE_SIZE * 9, 0);

			GetHighScoreFromFile();

			highScoreScoreText = new Text(highScore.ToString(), textFont, Grid.TILE_SIZE);
			UpdateHighScoreText();

		}

		public void Draw(RenderWindow window)
		{
			
			window.Draw(scoreText);
			window.Draw(highScoreText);
			window.Draw(highScoreScoreText);

		}

		public void EatDot()
		{

			dotsEaten++;
			score += SCORE_DOTS;
			UpdateScoreText();
			if (dotsEaten >= TOTAL_DOTS)
				dotCompleteFlag = true;

		}

		public void EatPellet()
		{

			pelletsEaten++;
			score += SCORE_PELLETS;
			UpdateScoreText();
			if (pelletsEaten >= TOTAL_PELLET)
				pelletCompleteFlag = true;

		}

		public int EatGhost()
		{

			score += SCORE_GHOST * ghostMultiplier;
			ghostMultiplier *= 2;
			UpdateScoreText();

			return SCORE_GHOST * ghostMultiplier;

		}

		public void ResetMultipler()
		{

			ghostMultiplier = 1;

		}

		public bool IsBoardCleared()
		{

			return dotCompleteFlag && pelletCompleteFlag;

		}

		private void UpdateScoreText()
		{

			if (score > highScore)
			{
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

		private void UpdateHighScoreText()
		{

			highScoreScoreText.DisplayedString = highScore.ToString();
			if (highScoreScoreText.DisplayedString.Length > currentHighScoreLength)
			{
				currentHighScoreLength = highScoreScoreText.DisplayedString.Length;
				highScoreScoreText.Origin = new Vector2f(-Grid.TILE_SIZE * (17 - currentHighScoreLength), -Grid.TILE_SIZE);
			}

		}

		private void GetHighScoreFromFile()
		{

			string text = File.ReadAllText(@"Assets\highscore.txt");

			highScore = int.Parse(text);


		}

	}
}
