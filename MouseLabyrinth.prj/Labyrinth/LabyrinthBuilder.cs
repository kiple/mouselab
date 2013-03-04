using System;

namespace MouseLabyrinth
{
	/// <summary>Базовый класс построителя лабиринтов.</summary>
	abstract class LabyrinthBuilder
	{
		/// <summary>Строит и возвращает лабиринт.</summary>
		/// <returns>Построенный лабиринт.</returns>
		public abstract ILabyrinth CreateLabyrinth();
	}
}
