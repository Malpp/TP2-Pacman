using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private float iOffset;
        private float jOffset;

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

        override public void Draw(RenderWindow window)
        {

            body.Position = new Vector2f(iPos * Grid.TILE_SIZE + iOffset, jPos * Grid.TILE_SIZE + jOffset + Grid.DRAW_OFFSET);
            window.Draw(body);

        }
    }
}
