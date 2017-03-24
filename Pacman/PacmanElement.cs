using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{

	public enum PacmanElement
	{
		
		Pacman = 'P',
		//World
		Wall = 'W',
		Empty = 'E',
		//Ghosts
		Blinky = 'B',
		Pinky = 'G',
		Inky = 'I',
		Clyde = 'C',
		//Elements to pick up
		Dot = 'D',
		Pellet = 'S',
		Fruit = 'F'

	}

}
