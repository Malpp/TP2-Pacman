using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman;

namespace Pacman_Tests
{

	//<pmccormick>

	[TestClass]
	public class TestsPacman
	{
		/// <summary>
		/// Teste la création d'un pacman à une position donnée
		/// </summary>
		[TestMethod]
		public void TestConstructeur01()
		{
			// Mise en place des données
			// Appel de la méthode à tester
			Pacman.Pacman pacman = new Pacman.Pacman(20, 10);

			// Validation des résultats
			Assert.AreEqual(10, pacman.iPos);
			Assert.AreEqual(20, pacman.jPos);
			// Clean-up
		}


		/// <summary>
		/// Teste le déplacement invalide du pacman vers la gauche
		/// </summary>
		[TestMethod]
		public void TestMoveInvalid01()
		{
			// Mise en place des données      
			Grid grid = new Grid();

			//Top right of the map
			Pacman.Pacman pacman = new Pacman.Pacman(1, 1);

			// Appel de la méthode à tester
			Assert.AreEqual(false, pacman.ChangeDirection(Direction.Left, grid));
			// Clean-up
		}

		/// <summary>
		/// Teste le déplacement invalide du pacman vers le haut
		/// </summary>
		[TestMethod]
		public void TestMoveInvalid02()
		{
			// Mise en place des données      
			Grid grid = new Grid();

			//Top right of the map
			Pacman.Pacman pacman = new Pacman.Pacman(1, 1);

			// Appel de la méthode à tester
			Assert.AreEqual(false, pacman.ChangeDirection(Direction.Up, grid));
			// Clean-up
		}

		/// <summary>
		/// Teste le déplacement invalide du pacman vers le bas
		/// </summary>
		[TestMethod]
		public void TestMoveInvalid03()
		{
			// Mise en place des données      
			Grid grid = new Grid();

			//Bottom right of the map
			Pacman.Pacman pacman = new Pacman.Pacman(29, 26);

			// Appel de la méthode à tester
			Assert.AreEqual(false, pacman.ChangeDirection(Direction.Down, grid));
			// Clean-up
		}

		/// <summary>
		/// Teste le déplacement invalide du pacman vers le droit
		/// </summary>
		[TestMethod]
		public void TestMoveInvalid04()
		{
			// Mise en place des données      
			Grid grid = new Grid();

			//Bottom right of the map
			Pacman.Pacman pacman = new Pacman.Pacman(29, 26);

			// Appel de la méthode à tester
			Assert.AreEqual(false, pacman.ChangeDirection(Direction.Right, grid));
			// Clean-up
		}

		/// <summary>
		/// Teste le déplacement valide du pacman vers la gauche
		/// Vous devez positionner le pacman à un endroit où il lui
		/// sera possible d'aller vers la gauche puis appeler la 
		/// méthode Move avec la bonne direction (West).
		/// </summary>
		[TestMethod]
		public void TestMoveValid01()
		{
			// Mise en place des données      
			Grid grid = new Grid();
			Pacman.Pacman pacman = new Pacman.Pacman(29, 26);

			// Validation des résultats
			Assert.AreEqual(true, pacman.ChangeDirection(Direction.Left, grid));


			// Clean-up
		}


		/// <summary>
		/// Teste le déplacement valide du pacman vers un fantôme
		/// Vous devez positionner le pacman à côté d'un fantôme et appeler la 
		/// méthode Move avec la bonne direction pour "foncer" dans la fantôme
		/// </summary>
		[TestMethod]
		public void TestMoveValid02()
		{
			// Mise en place des données      
			Grid grid = new Grid();
			Pacman.Pacman pacman = new Pacman.Pacman(29, 26);
			Ghost ghost = new Ghost(29,25);

			// Appel de la méthode à tester
			ghost.Update(0,grid,pacman);

			// Validation des résultats
			Assert.AreEqual(true, pacman.ChangeDirection(Direction.Left, grid));


			// Clean-up
		}

	}

}
