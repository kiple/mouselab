using System;
using System.Collections.Generic;

namespace MouseLabyrinth
{
	/// <summary>Алгорититм поведения мыши.</summary>
	class MyMouseStrategy : MouseStrategy
	{
		/// <summary>Фиктивный метод с примерами кода возможностей мыши.</summary>
		private void Hint()
		{
			//-----------------------------------------------
			// Узнать, можно ли идти в указаном направлении
			if(Context.IsCanGo(Dir.Down))
			{
				// Можно идти
			}
			else
			{
				// Нельзя идти, там стена
			}
			//-----------------------------------------------
			// Операции с камнями
			var stones = Context.GetStones(); // Считать число камней в текущей клетке
			if(stones < 4) stones = stones + 1; // Если меньше 4-х, увеличить число камней на 1
			Context.PutStones(stones); // Положить новое значение числа камней в клетку
			//-----------------------------------------------
		}

		/// <summary>Выполняет один шаг алгоритма поведения мыши.</summary>
		public override Dir NextStep()
		{
			// Здесь должен быть алгоритм поведения мыши
			return Dir.None;
		}
	}
}
