using System;
using System.Drawing;

using MouseLabyrinth.UI;

namespace MouseLabyrinth
{
	/// <summary>Интерефейс лабиринта.</summary>
	interface ILabyrinth
	{
		/// <summary>Возвращает число столбцов в лабиринте.</summary>
		int ColsCount { get; }

		/// <summary>Возвращает число строк в лабиринте.</summary>
		int RowsCount { get; }

		LabyrinthView View { get; set; }

		/// <summary>Устанавливает стену в указанную клетку лабиринта.</summary>
		/// <param name="row">Номер строки клетки (начиная с 1).</param>
		/// <param name="col">Номер столбца клетки (начиная с 1).</param>
		void SetWall(int row, int col);

		void PutCheese(Cheese cheese, int row, int col);

		/// <summary>Помещает мышь в лабиринт в указанную клетку.</summary>
		/// <param name="mouse">Мышь.</param>
		/// <param name="row">Номер строки клетки (начиная с 1).</param>
		/// <param name="col">Номер столбца клетки (начиная с 1).</param>
		void PutMouse(Mouse mouse, int row, int col);

		/// <summary>Устанавливат мышь в указанную клетку.</summary>
		/// <param name="row">Номер строки клетки.</param>
		/// <param name="col">Номер столбца клетки.</param>
		void SetMouse(int row, int col);

		int GetStones(int row, int col);

		void SetStones(int row, int col, int stones);

		void Write(string message, Color color);

		/// <summary>Возвращает тип клетки с указанными координатами.</summary>
		/// <param name="row"></param>
		/// <param name="col"></param>
		/// <returns></returns>
		Cell GetCell(int row, int col);

		/// <summary>Выполняет один шаг мыши.</summary>
		/// <returns>Если мышь достигла сыра, то <c>true</c>, иначе <c>false</c>.</returns>
		bool MouseDoStep();

		bool IsValidate(Coords coords);

		void Draw(Graphics g, Rectangle clip);
	}
}
