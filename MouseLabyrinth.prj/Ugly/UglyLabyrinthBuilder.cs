using System;

namespace MouseLabyrinth
{
	/// <summary>Пример построителя лабиринта.</summary>
	class UglyLabyrinthBuilder : LabyrinthBuilder
	{
		/// <summary>Строит и возвращает простой лабиринт.</summary>
		/// <returns>Построенный лабиринт.</returns>
		public override ILabyrinth CreateLabyrinth()
		{
			// Создаем лабиринт размером 10x10 и со свободными клетками класса UglyFreeCell
			int rowsCount = 10; // Число строк в лабиринте
			int colsCount = 10; // Число столбцов в лабиринте
			var labyrinth = new Labyrinth<UglyFreeCell, UglyWall>(rowsCount, colsCount);

			// Расставляем стены
			labyrinth.SetWall(3, 4);
			labyrinth.SetWall(3, 5);
			labyrinth.SetWall(3, 6);
			labyrinth.SetWall(4, 7);
			labyrinth.SetWall(2, 4);
			labyrinth.SetWall(9, 9);
			labyrinth.SetWall(1, 1);
			labyrinth.SetWall(1, 2);
			labyrinth.SetWall(1, 3);

			return labyrinth;
		}
	}
}
