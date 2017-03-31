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
        public GhostState state = GhostState.Chase;

        public const float UPDATE_TICKRATE = 0.3f;

        private int iPos;
        private int jPos;

        public Direction direction = Direction.Down;

        virtual public void Update(float time, Grid grid)
        {
            if (state == GhostState.Scatter)
            {

            }

            else if (state == GhostState.Frightened)
            {

            }

            //Chase
            else
            {
                switch (direction)
                {
                    case Direction.Down:
                        iPos++;
                        break;

                    case Direction.Left:
                        jPos--;
                        break;

                    case Direction.Right:
                        jPos++;
                        break;

                    case Direction.Up:
                        iPos++;
                        break;
                }
            }
        }
    }
}
