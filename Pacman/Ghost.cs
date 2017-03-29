using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Pacman
{
    class Ghost
    {
        /// <summary>
        /// Indicates the state ghosts are in.
        /// </summary>
        GhostState state = GhostState.Chase;

        public const float UPDATE_TICKRATE = 0.3f;

        private static CircleShape body;

        private int iPos;
        private int jPos;

        private float iOffset;
        private float jOffset;

        public Ghost()
        {
            jPos = 11;
            iPos = 13;
        }

         virtual public void Draw(RenderWindow window)
        {

            body.Position = new Vector2f(iPos * Grid.TILE_SIZE + iOffset, jPos * Grid.TILE_SIZE + jOffset + Grid.DRAW_OFFSET);
            window.Draw(body);

        }

        virtual public void Update(float time, Grid grid)
        {

        }
    }
}
