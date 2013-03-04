using System;
using System.Drawing;

namespace MouseLabyrinth
{
	/// <summary>Клетка лабиринта.</summary>
	abstract class Cell
	{
		private readonly bool _isFree;

		protected Cell(bool isFree)
		{
			_isFree = isFree;
		}

		/// <summary>Возвращает признак клетки, показывающий может ли на эту клетку передвигаться мышь.</summary>
		/// <value>Если может, то <c>true</c>, иначе <c>false</c>.</value>
		public bool IsFree
		{
			get { return _isFree; }
		}

		public abstract void Draw(Graphics g, Rectangle clip);
	}
}
