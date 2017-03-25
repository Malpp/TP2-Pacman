﻿using System;
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
		Empty = '0',
		//Ghosts
		Blinky = 'B',
		Pinky = 'G',
		Inky = 'I',
		Clyde = 'C',
		//Elements to pick up
		Dot = 'D',
		Pellet = 'S',
		Fruit = 'F',

		//Small corner
		//bottom left
		SCornerBL = 'a',
		//top left
		SCornerTL = 'b',
		//top right
		SCornerTR = 'c',
		//bottom right
		SCornerBR = 'd',

		//Single Wall
		//bottom
		SWallB = 'e',
		//left
		SWallL = 'f',
		//top
		SWallT = 'g',
		//right
		SWallR = 'h',

		//Double Wall
		//bottom
		DWallB = 'i',
		//left
		DWallL = 'j',
		//top
		DWallT = 'k',
		//right
		DWallR = 'l',

		//Big Corner
		//bottom left
		BCornerBL = 'm',
		//top left
		BCornerTL = 'n',
		//top right
		BCornerTR = 'o',
		//bottom right
		BCornerBR = 'p',

		//Double Corner
		//bottom left
		DCornerBL = 'q',
		//top left
		DCornerTL = 'r',
		//top right
		DCornerTR = 's',
		//bottom right
		DCornerBR = 't'

	}

}
