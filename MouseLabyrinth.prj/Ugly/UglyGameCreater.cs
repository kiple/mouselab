using System;

namespace MouseLabyrinth
{
	static class UglyGameCreater
	{
		public static Game CreateGame()
		{
			var game = new Game();

			// Строим лабиринт
			game.BuildLabyrinth(new UglyLabyrinthBuilder());

			// Кладем сыр в лабиринт
			game.PutCheese(new UglyCheese(), 8, 5);

			// Запускам мышь в лабиринт с указанным алгоритмом поведением
			game.PutMouse(new UglyMouse(new HaosMouseStrategy()), 2, 6);

			// Устанавливаем скорость движения мыши
			game.MouseSpeed = 70;

			return game;
		}

	}
}
