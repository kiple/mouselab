using System;

namespace MouseLabyrinth
{
	static class MyGameCreater
	{
		public static Game CreateGame()
		{
			var game = new Game();

			// Строим лабиринт
			game.BuildLabyrinth(new MyLabyrinthBuilder());

			// Кладем сыр в лабиринт
			game.PutCheese(new MyCheese(), 8, 5);

			// Запускам мышь в лабиринт с указанным алгоритмом поведением
			game.PutMouse(new MyMouse(new MyMouseStrategy()), 2, 6);

			// Устанавливаем скорость движения мыши
			game.MouseSpeed = 70;

			return game;
		}
	}
}
