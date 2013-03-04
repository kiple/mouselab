using System;
using System.Collections.Generic;

namespace MouseLabyrinth
{
	/// <summary>Направление движения/взгляда.</summary>
	enum Dir
	{
		None,

		Left,

		Right,

		Up,

		Down
	}

	static class Extensions
	{
		private static readonly Dictionary<Dir, Dir> REVRSES =
			new Dictionary<Dir, Dir>
				{
					{Dir.Left, Dir.Right},
					{Dir.Right, Dir.Left},
					{Dir.Up, Dir.Down},
					{Dir.Down, Dir.Up},
				};

		public static Dir Reverse(this Dir dir)
		{
			return REVRSES[dir];
		}
	}
}
