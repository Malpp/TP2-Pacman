using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman;

namespace Pacman_Tests
{
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

		private const string INVALID_LEVEL_04 = "tkkkkkkkkkkkkuUkkkkkkkkkkkkq\n" +
												"jDDDDDDDDDDDDhfDDDDDDDDDDDDl\n" +
												"jDdeeaDdeeeaDhfDdeeeaDdeeaDl\n" +
												"jSh00fDh000fDhfDh000fDh00fSl\n" +
												"jDcggbDcgggbDcbDcgggbDcggbDl\n" +
												"jDDDDDDDDDDDDDDDDDDDDDDDDDDl\n" +
												"jDdeeaDdaDdeeeeeeaDdaDdeeaDl\n" +
												"jDcggbDhfDcggmpggbDhfDcggbDl\n" +
												"jDDDDDDhfDDDDhfDDDDhfDDDDDDl\n" +
												"siiiiaDhoeea0hf0deenfDdiiiir\n" +
												"00000jDhpggb0cb0cggmfDl00000\n" +
												"00000jDhf0000000000hfDl00000\n" +
												"00000jDhf0diyJJzia0hfDl00000\n" +
												"kkkkkbDcb0l000000j0cbDckkkkk\n" +
												"000000D000l000000j000D000000\n" +
												"iiiiiaDda0l000000j0daDdiiiii\n" +
												"00000jDhf0ckkkkkkb0hfDl00000\n" +
												"00000jDhf0000000000hfDl00000\n" +
												"00000jDhf0deeeeeea0hfDl00000\n" +
												"tkkkkbDcb0cggmpggb0cbDckkkkq\n" +
												"jDDDDDDDDDDDDhfDDDDDDDDDDDDl\n" +
												"jDdeeaDdeeeaDhfDdeeeaDdeeaDl\n" +
												"jScgmfDcgggbDcbDcgggbDhpgbSl\n" +
												"jDDDhfDDDDDDD00DDDDDDDhfDDDl\n" +
												"XeaDhfDdaDdeeeeeeaDdaDhfDdev\n" +
												"xgbDcbDhfDcggmpggbDhfDcbDcgV\n" +
												"jDDDDDDhfDDDDhfDDDDhfDDDDDDl\n" +
												"jDdeeeenoeeaDhfDdeenoeeeeaDl\n" +
												"jDcggggggggbDcbDcggggggggbDl\n" +
												"jDDDDDDDDDDDDDDDDDDDDDDDDDDl\n" +
												"siiiiiiiiiiiiiiiiiiiiiiiiiir\n";

		/// <summary>
		/// Manque de colonne
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
												"jDDDhfDDDDDDD00DDDDDDDhfDDDl\n" +
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

	}
}
