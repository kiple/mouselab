using System;

namespace MouseLabyrinth
{
	/// <summary>Пустая ячейка лабиринта, в которой могут находится камни.</summary>
	abstract class FreeCell : Cell
	{
		/// <summary>Максимальное число камней в ячейке.</summary>
		private const int MAX_STONE = 4;

		private int _stones;

		public FreeCell() : base(true)
		{
		}

		/// <summary>Устанавливает и возвращает число "камней", котрое находится в ячейке.</summary>
		public int Stones
		{
			get { return _stones; }
			set
			{
				if(value < 0 || value > MAX_STONE) throw new ArgumentOutOfRangeException(string.Format("Число камней в ячейке должно быь в дипазоне {0}..{1}", 0, MAX_STONE));
				_stones = value;
			}
		}
	}
}
