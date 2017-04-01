using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Pacman
{
    class Clyde : Ghost
    {

        private static CircleShape body;

        private int iPos;
        private int jPos;

        static Clyde()
        {
            body = new CircleShape(Grid.TILE_SIZE / 2f);
            body.FillColor = Color.Green;
        }

        public Clyde()
        {
            iPos = 15;
            jPos = 14;
        }

    }
}
