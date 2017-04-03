using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman;

namespace Pacman_Tests
{
	//<pmccormick>

	[TestClass]
	public class TestPathFinder_MANDAT1
	{
		/// <summary>
		/// Test de l'initialisation des coûts.
		/// Vous devez vous assurer que la méthode InitCost initialise
		/// les valeurs du tableau à +infini partout sauf à l'endroit de départ
		/// (initialisation à 0)
		/// </summary>
		[TestMethod]
		public void TestInitCost_01()
		{

			int[,] couts = new int[Grid.GRID_WIDTH, Grid.GRID_HEIGHT];

			couts = PathFinding.InitMoves(couts, 1, 1);

			Assert.AreEqual(0, couts[1, 1]);

		}

		/// <summary>
		/// Test de calcul des coûts dans la grille de base.
		/// Vous devez vous assurer que le calcul des coûts se
		/// fait correctement. Pour cela, faites l'appel à la méthode
		/// InitCosts puis ComputeCosts et faites quelques validations
		/// pour différents scénarios: chemins existants, chemins 
		/// inexistants (ex. à partie ou dans un mur!)
		/// </summary>
		[TestMethod]
		public void TestComputeCost_01()
		{
			//jPos = 23, int iPos = 13
			int[,] couts = new int[Grid.GRID_WIDTH, Grid.GRID_HEIGHT];
			Grid grid = new Grid();

			couts = PathFinding.InitMoves(couts, 1, 1);

			PathFinding.CalculateMoves(grid, 1,1,13,23,ref couts);

			Assert.AreEqual(1, couts[2,1]);
			Assert.AreEqual(5, couts[6, 1]);

		}

		/// <summary>
		/// Test de calcul d'une direction lorsque le point de départ
		/// est le même que le point d'arrivée.
		/// </summary>
		[TestMethod]
		public void TestFindPath_NoDisplacement()
		{
			int[,] couts = new int[Grid.GRID_WIDTH, Grid.GRID_HEIGHT];
			Grid grid = new Grid();

			couts = PathFinding.InitMoves(couts, 1, 1);

			PathFinding.CalculateMoves(grid, 1, 1, 1, 1, ref couts);

			Assert.AreEqual(0, couts[1, 1]);

		}

		/// <summary>
		/// Test de calcul d'une direction lorsque le point de départ
		/// juste à gauche du point d'arrivée.
		/// </summary>
		[TestMethod]
		public void TestFindPath_ToEast()
		{
			int[,] couts = new int[Grid.GRID_WIDTH, Grid.GRID_HEIGHT];
			Grid grid = new Grid();

			couts = PathFinding.InitMoves(couts, 2, 1);

			PathFinding.CalculateMoves(grid, 2, 1, 1, 1, ref couts);

			Assert.AreEqual(0, couts[2, 1]);
			Assert.AreEqual(1, couts[1, 1]);

		}

		/// <summary>
		/// Test de calcul d'une direction lorsque le point de départ
		/// juste à droite du point d'arrivée.
		/// </summary>
		[TestMethod]
		public void TestFindPath_ToWest()
		{
			int[,] couts = new int[Grid.GRID_WIDTH, Grid.GRID_HEIGHT];
			Grid grid = new Grid();

			couts = PathFinding.InitMoves(couts, 1, 1);

			PathFinding.CalculateMoves(grid, 1, 1, 2, 1, ref couts);

			Assert.AreEqual(0, couts[1, 1]);
			Assert.AreEqual(1, couts[2, 1]);
		}

		/// <summary>
		/// Test de calcul d'une direction lorsque le point de départ
		/// est juste en dessous du point d'arrivée.
		/// </summary>
		[TestMethod]
		public void TestFindPath_ToNorth()
		{
			// Mise en place des données

			// Appel de la méthode à tester

			// Validations

			// Cleanup
		}
		/// <summary>
		/// Test de calcul d'une direction lorsque le point de départ
		/// est juste au dessus du point d'arrivée.
		/// </summary>
		[TestMethod]
		public void TestFindPath_ToSouth()
		{
			int[,] couts = new int[Grid.GRID_WIDTH, Grid.GRID_HEIGHT];
			Grid grid = new Grid();

			couts = PathFinding.InitMoves(couts, 1, 1);

			PathFinding.CalculateMoves(grid, 1, 1, 1, 2, ref couts);

			Assert.AreEqual(0, couts[1, 1]);
			Assert.AreEqual(1, couts[1, 2]);
		}



		/// <summary>
		/// Test de calcul d'une direction impossible (vers un mur).
		/// </summary>
		[TestMethod]
		public void TestFindPath_ImpossibleToWall()
		{
			int[,] couts = new int[Grid.GRID_WIDTH, Grid.GRID_HEIGHT];
			Grid grid = new Grid();

			couts = PathFinding.InitMoves(couts, 1, 1);

			PathFinding.CalculateMoves(grid, 1, 1, 0, 1, ref couts);

			Assert.AreEqual(0, couts[1, 1]);
			Assert.AreEqual(int.MaxValue, couts[0, 1]);
		}

		/// <summary>
		/// Test de calcul d'une direction impossible (à partie d'un mur).
		/// </summary>
		[TestMethod]
		public void TestFindPath_ImpossibleFromWall()
		{
			int[,] couts = new int[Grid.GRID_WIDTH, Grid.GRID_HEIGHT];
			Grid grid = new Grid();

			couts = PathFinding.InitMoves(couts, 0, 1);

			PathFinding.CalculateMoves(grid, 0, 1, 1, 1, ref couts);

			Assert.AreEqual(0, couts[0, 1]);
			Assert.AreEqual(1, couts[1, 1]);
		}

	}
}
