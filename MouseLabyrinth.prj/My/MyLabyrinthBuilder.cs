using System;

namespace MouseLabyrinth
{
	/// <summary>Пример построителя лабиринта.</summary>
	class MyLabyrinthBuilder : LabyrinthBuilder
	{
		/// <summary>Строит и возвращает построенный лабиринт.</summary>
		/// <returns>Построенный лабиринт.</returns>
		public override ILabyrinth CreateLabyrinth()
		{
			// Создаем пустой лабиринт размером 10 x 10 клеток
			var labyrinth = new Labyrinth<MyFreeCell, MyWall>(10, 10);

			// Устанавливаем стену в клетку с координатами (3, 4)
			labyrinth.SetWall(3, 4);

			return labyrinth;
		}
	}
}
