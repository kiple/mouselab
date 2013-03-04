using System;

namespace MouseLabyrinth
{
	/// <summary>Координаты объекта в лабиринте.</summary>
	struct Coords : IEquatable<Coords>
	{
		private readonly int _row;

		private readonly int _col;

		public int Row
		{
			get { return _row; }
		}

		public int Col
		{
			get { return _col; }
		}

		public Coords(int row, int col)
		{
			_row = row;
			_col = col;
		}

		public bool Equals(Coords other)
		{
			return other._row == _row && other._col == _col;
		}

		public override bool Equals(object obj)
		{
			if(ReferenceEquals(null, obj)) return false;
			if(obj.GetType() != typeof(Coords)) return false;
			return Equals((Coords)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (_row * 397) ^ _col;
			}
		}
	}
}
