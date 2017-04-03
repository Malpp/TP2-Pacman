using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman;

namespace Pacman_Tests
{
	//<pmccormick>

	[TestClass]
	public class TestsGrid
	{

		/// <summary>
		/// Tests le constructeur.
		/// </summary>
		[TestMethod]
		public void TestConstructeur()
		{

			Grid grid = new Grid();

			Assert.AreEqual(Grid.GRID_HEIGHT, grid.Height);
			Assert.AreEqual(Grid.GRID_WIDTH, grid.Width);
			//Pas de cage spawner

		}

		[TestMethod]
		public void TestInvalidLoadContent1()
		{

			Grid grid = new Grid();

			bool result = grid.LoadLevelFromString("");
			
			Assert.IsFalse(result);

		}

		private const string INVALID_LEVEL_01 = "1231241\n" +
												"12312\n" +
												"21312412\n" +
												"";

		/// <summary>
		/// Teste si le chargement d'un fichier au format totalement invalide échoue
		/// </summary>
		[TestMethod]
		public void TestInvalidLoadContent2()
		{

			Grid grid = new Grid();

			bool result = grid.LoadLevelFromString(INVALID_LEVEL_01);

			Assert.IsFalse(result);

		}

		private const string INVALID_LEVEL_02 = "tkkkkkkkkkkkkuUkkkkkkkkkkkkqW\n" +
												"jDDDDDDDDDDDDhfDDDDDDDDDDDDlW\n" +
												"jDdeeaDdeeeaDhfDdeeeaDdeeaDlW\n" +
												"jSh00fDh000fDhfDh000fDh00fSlW\n" +
												"jDcggbDcgggbDcbDcgggbDcggbDlW\n" +
												"jDDDDDDDDDDDDDDDDDDDDDDDDDDlW\n" +
												"jDdeeaDdaDdeeeeeeaDdaDdeeaDlW\n" +
												"jDcggbDhfDcggmpggbDhfDcggbDlW" +
												"siiiiiiiiiiiiiiiiiiiiiiiiiirW\n";

		/// <summary>
		/// Mauvais format
		/// </summary>
		[TestMethod]
		public void TestInvalidLoadContent3()
		{

			Grid grid = new Grid();

			bool result = grid.LoadLevelFromString(INVALID_LEVEL_02);

			Assert.IsFalse(result);

		}

		private const string INVALID_LEVEL_03= "tkkkkkkkkkkkkuUkkkkkkkkkkkkqW\n" +
												"jDDDDDDDDDDDDhfDDDDDDDDDDDDlW\n" +
												"jDdeeaDdeeeaDhfDdeeeaDdeeaDlW\n" +
												"jSh00fDh000fDhfDh000fDh00fSlW\n" +
												"jDcggbDcgggbDcbDcgggbDcggbDlW\n" +
												"jDDDDDDDDDDDDDDDDDDDDDDDDDDlW\n" +
												"jDdeeaDdaDdeeeeeeaDdaDdeeaDlW\n" +
												"jDcggbDhfDcggmpggbDhfDcggbDlW\n" +
												"jDDDDDDhfDDDDhfDDDDhfDDDDDDlW\n" +
												"siiiiaDhoeea0hf0deenfDdiiiirW\n" +
												"00000jDhpggb0cb0cggmfDl00000W\n" +
												"00000jDhf0000000000hfDl00000W\n" +
												"00000jDhf0diyJJzia0hfDl00000W\n" +
												"kkkkkbDcb0l000000j0cbDckkkkkW\n" +
												"000000D000l000000j000D0000000\n" +
												"iiiiiaDda0l000000j0daDdiiiiiW\n" +
												"00000jDhf0ckkkkkkb0hfDl00000W\n" +
												"00000jDhf0000000000hfDl00000W\n" +
												"jDdeeeenoeeaDhfDdeenoeeeeaDlW\n" +
												"jDcggggggggbDcbDcggggggggbDlW\n" +
												"jDDDDDDDDDDDDDDDDDDDDDDDDDDlW\n" +
												"siiiiiiiiiiiiiiiiiiiiiiiiiirW\n";

		/// <summary>
		/// Manque de ligne
		/// </summary>
		[TestMethod]
		public void TestInvalidLoadContent4()
		{

			Grid grid = new Grid();

			bool result = grid.LoadLevelFromString(INVALID_LEVEL_03);

			Assert.IsFalse(result);

		}

		private const string INVALID_LEVEL_04 = "tkkkkkkkkkkkkuUkkkkkkkkkkkk\n" +
												"jDDDDDDDDDDDDhfDDDDDDDDDDDD\n" +
												"jDdeeaDdeeeaDhfDdeeeaDdeeaD\n" +
												"jSh00fDh000fDhfDh000fDh00fS\n" +
												"jDcggbDcgggbDcbDcgggbDcggbD\n" +
												"jDDDDDDDDDDDDDDDDDDDDDDDDDD\n" +
												"jDdeeaDdaDdeeeeeeaDdaDdeeaD\n" +
												"jDcggbDhfDcggmpggbDhfDcggbD\n" +
												"jDDDDDDhfDDDDhfDDDDhfDDDDDD\n" +
												"siiiiaDhoeea0hf0deenfDdiiii\n" +
												"00000jDhpggb0cb0cggmfDl0000\n" +
												"00000jDhf0000000000hfDl0000\n" +
												"00000jDhf0diyJJzia0hfDl0000\n" +
												"kkkkkbDcb0l000000j0cbDckkkk\n" +
												"000000D000l000000j000D00000\n" +
												"iiiiiaDda0l000000j0daDdiiii\n" +
												"00000jDhf0ckkkkkkb0hfDl0000\n" +
												"00000jDhf0000000000hfDl0000\n" +
												"00000jDhf0deeeeeea0hfDl0000\n" +
												"tkkkkbDcb0cggmpggb0cbDckkkk\n" +
												"jDDDDDDDDDDDDhfDDDDDDDDDDDD\n" +
												"jDdeeaDdeeeaDhfDdeeeaDdeeaD\n" +
												"jScgmfDcgggbDcbDcgggbDhpgbS\n" +
												"jDDDhfDDDDDDD00DDDDDDDhfDDD\n" +
												"XeaDhfDdaDdeeeeeeaDdaDhfDde\n" +
												"xgbDcbDhfDcggmpggbDhfDcbDcg\n" +
												"jDDDDDDhfDDDDhfDDDDhfDDDDDD\n" +
												"jDdeeeenoeeaDhfDdeenoeeeeaD\n" +
												"jDcggggggggbDcbDcggggggggbD\n" +
												"jDDDDDDDDDDDDDDDDDDDDDDDDDD\n" +
												"siiiiiiiiiiiiiiiiiiiiiiiiii\n";

		/// <summary>
		/// Manque de colonnes
		/// </summary>
		[TestMethod]
		public void TestInvalidLoadContent5()
		{

			Grid grid = new Grid();

			bool result = grid.LoadLevelFromString(INVALID_LEVEL_04);

			Assert.IsFalse(result);

		}

		private const string INVALID_LEVEL_05 = "tkkkkkkkkkkkkuUkkkkkkkkkkkkqW\n" +
												"jDDDDDDDDDDDDhfDDDDDDDDDDDDlW\n" +
												"jDdeeaDdeeeaDhfDdeeeaDdeeaDlW\n" +
												"jSh00fDh000fDhfDh000fDh00fSlW\n" +
												"jDcggbDcgggbDcbDcgggbDcggbDlW\n" +
												"jDDDDDDDDDDDDDDDDDDDDDDDDDDlW\n" +
												"jDdeeaDdaDdeeeeeeaDdaDdeeaDlW\n" +
												"jDcggbDhfDcggmpggbDhfDcggbDlW\n" +
												"jDDDDDDhfDDDDhfDDDDhfDDDDDDlW\n" +
												"siiiiaDhoeea0hf0deenfDdiiiirW\n" +
												"00000jDhpggb0cb0cggmfDl00000W\n" +
												"00000jDhf0000000000hfDl00000W\n" +
												"00000jDhf0diyJJzia0hfDl00000W\n" +
												"kkkkkbDcb0l000000j0cbDckkkkkW\n" +
												"000000D000l000000j000D0000000\n" +
												"iiiiiaDda0l000000j0daDdiiiiiW\n" +
												"00000jDhf0ckkkkkkb0hfDl00000W\n" +
												"00000jDhf0000000000hfDl00000W\n" +
												"00000jDhf0deeeeeea0hfDl00000W\n" +
												"tkkkkbDcb0cggmpggb0cbDckkkkqW\n" +
												"jDDDDDDDDDDDDhfDDDDDDDDDDDDlW\n" +
												"jDdeeaDdeeeaDhfDdeeeaDdeeaDlW\n" +
												"jScgmfDcgggbDcbDcgggbDhpgbSlW\n" +
												"jDDDhfDDDDDDD00DDDDDDDhDDl\n" +
												"XeaDhfDdaDdeeeeeeaDdaDhfDdevW\n" +
												"xgbDcbDhfDcggmpggbDhfDcbDcgVW\n" +
												"jDDDDDDhfDDDDhfDDDDhfDDDDDDlW\n" +
												"jDdeeeenoeeaDhfDdeenoeeeeaDlW\n" +
												"jDcggggggggbDcbDcggggggggbDlW\n" +
												"jDDDDDDDDDDDDDDDDDDDDDDDDDDlW\n" +
												"siiiiiiiiiiiiiiiiiiiiiiiiiirW\n";

		/// <summary>
		/// Elements dans colonne manquant
		/// </summary>
		[TestMethod]
		public void TestInvalidLoadContent6()
		{

			Grid grid = new Grid();

			bool result = grid.LoadLevelFromString(INVALID_LEVEL_05);

			Assert.IsFalse(result);

		}

		[TestMethod]
		public void TestInvalidLoadContent7()
		{

			//Nous avons pas de spawnpoint pour Pacman
			//Lire document Word de remise

		}

		[TestMethod]
		public void TestInvalidLoadContent8()
		{

			//Nous avons pas de spawnpoint pour Pacman
			//Lire document Word de remise

		}

		[TestMethod]
		public void TestInvalidLoadContent9()
		{

			//Nous avons pas de spawnpoint pour la cage a phantome
			//Lire document Word de remise

		}

		[TestMethod]
		public void TestInvalidLoadContent10()
		{

			//Nous avons pas de spawnpoint pour la cage a phantome
			//Lire document Word de remise

		}

		private const string VALID_LEVEL =  "tkkkkkkkkkkkkuUkkkkkkkkkkkkqW\n" +
											"jDDDDDDDDDDDDhfDDDDDDDDDDDDlW\n" +
											"jDdeeaDdeeeaDhfDdeeeaDdeeaDlW\n" +
											"jSh00fDh000fDhfDh000fDh00fSlW\n" +
											"jDcggbDcgggbDcbDcgggbDcggbDlW\n" +
											"jDDDDDDDDDDDDDDDDDDDDDDDDDDlW\n" +
											"jDdeeaDdaDdeeeeeeaDdaDdeeaDlW\n" +
											"jDcggbDhfDcggmpggbDhfDcggbDlW\n" +
											"jDDDDDDhfDDDDhfDDDDhfDDDDDDlW\n" +
											"siiiiaDhoeea0hf0deenfDdiiiirW\n" +
											"00000jDhpggb0cb0cggmfDl00000W\n" +
											"00000jDhf0000000000hfDl00000W\n" +
											"00000jDhf0diyJJzia0hfDl00000W\n" +
											"kkkkkbDcb0l000000j0cbDckkkkkW\n" +
											"000000D000l000000j000D0000000\n" +
											"iiiiiaDda0l000000j0daDdiiiiiW\n" +
											"00000jDhf0ckkkkkkb0hfDl00000W\n" +
											"00000jDhf0000000000hfDl00000W\n" +
											"00000jDhf0deeeeeea0hfDl00000W\n" +
											"tkkkkbDcb0cggmpggb0cbDckkkkqW\n" +
											"jDDDDDDDDDDDDhfDDDDDDDDDDDDlW\n" +
											"jDdeeaDdeeeaDhfDdeeeaDdeeaDlW\n" +
											"jScgmfDcgggbDcbDcgggbDhpgbSlW\n" +
											"jDDDhfDDDDDDD00DDDDDDDhfDDDlW\n" +
											"XeaDhfDdaDdeeeeeeaDdaDhfDdevW\n" +
											"xgbDcbDhfDcggmpggbDhfDcbDcgVW\n" +
											"jDDDDDDhfDDDDhfDDDDhfDDDDDDlW\n" +
											"jDdeeeenoeeaDhfDdeenoeeeeaDlW\n" +
											"jDcggggggggbDcbDcggggggggbDlW\n" +
											"jDDDDDDDDDDDDDDDDDDDDDDDDDDlW\n" +
											"siiiiiiiiiiiiiiiiiiiiiiiiiirW";

		/// <summary>
		/// Test de chargement d'un niveau valide, sans erreur
		/// </summary>
		[TestMethod]
		public void TestValidLoadContent()
		{

			Grid grid = new Grid();

			bool result = grid.LoadLevelFromString(VALID_LEVEL);

			Assert.IsTrue(result);

		}

		/// <summary>
		/// Teste si les éléments chargés sont corrects
		/// Ici la position de la cage des fantômes
		/// </summary>
		[TestMethod]
		public void TestGetElementAt01()
		{
			//Pas de cage de fantomes
		}

		/// <summary>
		/// Teste si les éléments chargés sont corrects
		/// Ici quelques super-pills à l'aide de GetGridElementAt
		/// Vous devez vous assurer que les super-pastilles sont aux bons endroits
		/// à l'aide de la méthode GetGridElementAt
		/// </summary>
		[TestMethod]
		public void TestGetElementAt02()
		{
		
			Grid grid = new Grid();

			grid.LoadLevelFromString(VALID_LEVEL);

			Assert.AreEqual(PacmanElement.Pellet,grid.GetElementAt(1,3));
			Assert.AreEqual(PacmanElement.Pellet, grid.GetElementAt(1, 22));
			Assert.AreEqual(PacmanElement.Pellet, grid.GetElementAt(26, 3));
			Assert.AreEqual(PacmanElement.Pellet, grid.GetElementAt(26, 22));

		}

		/// <summary>
		/// Teste si les éléments chargés sont corrects
		/// Ici  quelques pastilles "régulières".
		/// Vous devez vous assurer que les pastilles sont aux bons endroits
		/// à l'aide de la méthode GetGridElementAt. Faites 5-4 vérifications.
		/// </summary>
		[TestMethod]
		public void TestGetElementAt03()
		{
			Grid grid = new Grid();

			grid.LoadLevelFromString(VALID_LEVEL);

			Assert.AreEqual(PacmanElement.Dot, grid.GetElementAt(1, 2));
			Assert.AreEqual(PacmanElement.Dot, grid.GetElementAt(1, 21));
			Assert.AreEqual(PacmanElement.Dot, grid.GetElementAt(26, 4));
			Assert.AreEqual(PacmanElement.Dot, grid.GetElementAt(26, 21));
		}

		/// <summary>
		/// Teste l'accès à un élément inexistant à l'extérieur de la grille
		///                                       --------------------------
		/// Attention!  Votre méthode GetGridElementAt doit lancer une exception
		/// de type ArgumentOutOfRangeException si l'on tente d'accéder à un élément
		/// à l'extérieur de la grille. 
		/// </summary>
		[TestMethod]
		public void TestGetElementAt04()
		{
			Grid grid = new Grid();

			grid.LoadLevelFromString(VALID_LEVEL);

			Assert.AreEqual(PacmanElement.Wall, grid.GetElementAt(-1, -2));
			Assert.AreEqual(PacmanElement.Empty, grid.GetElementAtPacman(-1, -21));
		}

		/// <summary>
		/// Teste la modification valide d'un élément de votre
		/// choix avec la méthode SetGridElementAt.
		/// Vous devez faire un SetGridElementAt avec une position
		/// et un type d'élément de votre choix et vous assurer
		/// par la suite que la modification a été faite dans la grille.
		/// </summary>
		[TestMethod]
		public void TestSetElementAt01()
		{
			//Nous avon pas besoin de cette fonction
			//Voir document word de remise
		}
		/// <summary>
		/// Teste la modification invalide d'un élément à l'extérieur de la grille
		///                                               ------------------------
		/// Attention!  Votre méthode SetGridElementAt doit lancer une exception
		/// de type ArgumentOutOfRangeException si l'on tente d'accéder à un élément
		/// à l'extérieur de la grille.                                              
		/// </summary>
		[TestMethod]
		public void TestSetElementAt02()
		{
			//Nous avon pas besoin de cette fonction
			//Voir document word de remise
		}

	}
}
