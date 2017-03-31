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
        public GhostState state;

        public const float UPDATE_TICKRATE = 0.3f;

        private int iPos;
        private int jPos;

		private float totalTime;

        public Direction direction = Direction.Down;

        public Ghost()
        {
            state = GhostState.Chase;
        }

        virtual public void Draw(RenderWindow window)
        {

        }

        virtual public void Update(float time, Grid grid)
        {

	        totalTime += time;

            if (state == GhostState.Scatter)
            {

            }

            else if (state == GhostState.Frightened)
            {

            }

            //Chase
            else
            {
	            if (totalTime > 0.2f)
	            {
		            totalTime = 0;
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
}
