using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MouseLabyrinth
{
	/// <summary>Пустая клетка лабиринта, в которой могут находится камни.</summary>
	class MyFreeCell : FreeCell
	{
		/// <summary>Рисует клетку.</summary>
		/// <param name="g"></param>
		/// <param name="clip"></param>
		public override void Draw(Graphics g, Rectangle clip)
		{
			// Рисуем клетку
		}
	}
}
