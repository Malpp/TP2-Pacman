using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman;

namespace Pacman_Tests
{
    [TestClass]
    public class TestsPathFinder
    {
        #region MANDAT 2
        //Comme j'ai incorporé les 2 méthodes dans une seule méthode, les tests seront probablement assez différents.
        int[,] simpleCostArray1 = new int[,]{
      {int.MaxValue,  int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue },
      {int.MaxValue,  int.MaxValue, 7,            6,            7,            8,            int.MaxValue },
      {int.MaxValue,  3,            int.MaxValue, 5,            int.MaxValue, 9,            int.MaxValue },
      {int.MaxValue,  2,            int.MaxValue, 4,            int.MaxValue, int.MaxValue, int.MaxValue },
      {int.MaxValue,  1,            2,            3,            int.MaxValue, 7,            int.MaxValue },
      {int.MaxValue,  0,            int.MaxValue, 4,            int.MaxValue, 6,            int.MaxValue },
      {int.MaxValue,  1,            2,            3,            4,            5,            int.MaxValue },
      {int.MaxValue,  int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue }
    };
        /// <summary>
        /// Test de l'intéraction lorsque/si le fantôme se retrouve à la même position que le pacman
        /// </summary>
        [TestMethod]
        public void TestFindFirstMove_GhostOnPacman()
        {
            Assert.AreEqual(Direction.None, PathFinding.FindFirstMove(simpleCostArray1, 5, 1, 5, 1, Direction.None));
        }

        /// <summary>
        /// Test de calcul du premier déplacement vers le nord.
        /// </summary>
        [TestMethod]
        public void TestRecurseFindDirection_Up01()
        {
            Assert.AreEqual(Direction.Up, PathFinding.FindFirstMove(simpleCostArray1, 5, 1, 4, 1, Direction.None));
        }

        /// <summary>
        /// Test de calcul du second déplacement vers le nord.
        /// Vous devez choisir une cible "vers le nord" plus complexe que celle juste 
        /// au-dessus.  La direction retournée par PathFinder.RecurseFindDirection 
        /// devrait être le "nord".
        /// Utilisez le tableau simpleCostArray1 comme tableau des coûts.
        /// </summary>
        [TestMethod]
        public void TestRecurseFindDirection_North02()
        {



        }

        /// <summary>
        /// Test de calcul du troisième déplacement vers le nord
        /// Vous devez choisir une cible "vers le nord" plus complexe que celle juste 
        /// au-dessus et autre que pour le test précédent.  La direction 
        /// retournée par PathFinder.RecurseFindDirection devrait être le "nord".
        /// Utilisez le tableau simpleCostArray1 comme tableau des coûts.
        /// </summary>
        [TestMethod]
        public void TestRecurseFindDirection_North03()
        {

        }
        /// <summary>
        /// Test de calcul du premier déplacement vers le sud
        /// Vous devez choisir une cible vers la bas (ex. (x=1, y=6)).  La direction
        /// retournée par PathFinder.RecurseFindDirection devrait
        /// être le "sud".
        /// Utilisez le tableau simpleCostArray1 comme tableau des coûts.
        /// </summary>
        [TestMethod]
        public void TestRecurseFindDirection_South01()
        {

        }

        /// <summary>
        /// Test de calcul du second déplacement vers le sud
        /// Vous devez choisir une cible "vers le bas" plus complexe que celle juste 
        /// en-dessous.  La direction retournée par PathFinder.RecurseFindDirection 
        /// devrait être le "sud".
        /// Utilisez le tableau simpleCostArray1 comme tableau des coûts.    
        /// </summary>
        [TestMethod]
        public void TestRecurseFindDirection_South02()
        {

        }

        /// <summary>
        /// Test de calcul du troisième déplacement vers le sud
        /// Vous devez choisir une cible "vers le bas" plus complexe que celle juste 
        /// en-dessous et autre que pour le test précédent.  La direction 
        /// retournée par PathFinder.RecurseFindDirection devrait être le "sud".
        /// Utilisez le tableau simpleCostArray1 comme tableau des coûts.
        /// </summary>
        [TestMethod]
        public void TestRecurseFindDirection_South03()
        {


        }

        int[,] simpleCostArray2 = new int[,]{
      {int.MaxValue,  int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue,  int.MaxValue, int.MaxValue },
      {int.MaxValue,  int.MaxValue, int.MaxValue, 7,            int.MaxValue, 13,           12,            11,           int.MaxValue },
      {int.MaxValue,  8,            int.MaxValue, 6,            int.MaxValue, 14,           int.MaxValue,  10,           int.MaxValue },
      {int.MaxValue,  7,            int.MaxValue, 5,            int.MaxValue, 15,           int.MaxValue,  9,            int.MaxValue },
      {int.MaxValue,  6,            5,            4,            int.MaxValue, 16,           int.MaxValue,  8,            int.MaxValue },
      {int.MaxValue,  5,            4,            3,            int.MaxValue, 17,           int.MaxValue,  7,            int.MaxValue },
      {int.MaxValue,  4,            int.MaxValue, 2,            int.MaxValue, 18,           int.MaxValue,  6,            int.MaxValue },
      {int.MaxValue,  3,            int.MaxValue, 1,            int.MaxValue, int.MaxValue, int.MaxValue,  5,            int.MaxValue },
      {int.MaxValue,  2,            1,            0,            1,            2,            3,             4,            int.MaxValue },
      {int.MaxValue,  int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue,  int.MaxValue, int.MaxValue }
    };
        /// <summary>
        /// Test de calcul du premier déplacement vers l'ouest
        /// Vous devez aller vers la gauche (ex. (x=1, y=6)).  La direction
        /// retournée par PathFinder.RecurseFindDirection devrait
        /// être l'"ouest".
        /// Utilisez le tableau simpleCostArray2 comme tableau des coûts.
        /// </summary>
        [TestMethod]
        public void TestRecurseFindDirection_West01()
        {



        }
        /// <summary>
        /// Test de calcul du premier déplacement vers l'est
        /// Vous devez aller vers la droite (ex. (x=5, y=6)).  La direction
        /// retournée par PathFinder.RecurseFindDirection devrait
        /// être l'"est".
        /// Utilisez le tableau simpleCostArray2 comme tableau des coûts.
        /// </summary>
        [TestMethod]
        public void TestRecurseFindDirection_East01()
        {



        }



        // Les tests de FindPath ne s'appliquent pas parce que 1.La méthode n'existe pas 2.La méthode FindFirstMove fait déjà le processus à petite échelle/par récursivité
        // et c'est donc impossible à tester à grande échelle.

        #endregion
    }
}
