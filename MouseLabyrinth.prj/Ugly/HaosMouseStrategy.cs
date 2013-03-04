using System;
using System.Drawing;
using System.Linq;

namespace MouseLabyrinth
{
	/// <summary>Алгорититм поведения с хаотичным движением мыши.</summary>
	/// <remarks>Мышь ставит камни в ячейки, в которых уже была и идет в тех направлениях, где еще нет камней.</remarks>
	class HaosMouseStrategy : MouseStrategy
	{
		// Генератор случайных чисел
		#region Helpers

		private enum Status
		{
			Forward,
			Back
		}

		#endregion

		#region Data

		private readonly Random _rnd = new Random();

		private Status _status = Status.Forward;

		private Dir _prevDir = Dir.None;

		private int _prevStones;

		#endregion

		#region Methods

		/// <summary>Выполняет один шаг алгоритма поведения мыши.</summary>
		/// <returns>Направление следующего шага мыши.</returns>
		public override Dir NextStep()
		{
			// Находим все доступные направления куда может пойти мышь из текущей клетки
			var canGoDirs = Context.GetCanGoDirs();

			// Если нет направлений в которые можно идти, то мышь окружена стенами. А-а-а!!!
			if(canGoDirs.Count() == 0)
			{
				Context.Write("Некуда идти! Мышь окружена.", Color.Coral);
				return Dir.None;
			}

			if(_prevDir != Dir.None && _status != Status.Back && Context.GetStones() != 0 && _prevStones < 4)
			{
				_status = Status.Back;
				return _prevDir.Reverse();
			}

			var index = _rnd.Next(canGoDirs.Count());
			_prevDir = canGoDirs.ElementAt(index);
			var stones = Context.GetStones();
			if(stones < 4) ++stones;
			Context.PutStones(stones);
			_prevStones = stones;
			_status = Status.Forward;
			return _prevDir;
		}

		#endregion
	}
}
