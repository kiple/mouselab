using System;
using System.Drawing;

namespace MouseLabyrinth
{
	interface IMouseContext
	{
		/// <summary>Возвращает количество камней в клетке, в которой находится мышь.</summary>
		/// <returns>Количество камней.</returns>
		int GetStones();

		/// <summary>Устанавливает указанное количество камней в клетку, в которой находится мышь.</summary>
		/// <param name="count">Количество камней.</param>
		void PutStones(int count);

		/// <summary>Возвращает значение, показывающее свободна ли клетка в указанном направлении.</summary>
		/// <param name="dir">Направление.</param>
		/// <returns>Если клетка свободна, то <c>true</c>, иначе <c>false</c>.</returns>
		bool IsCanGo(Dir dir);

		/// <summary>Выводит сообщение на экран.</summary>
		/// <param name="message">Текст сообщения.</param>
		/// <param name="color">Цвет сообщений.</param>
		void Write(string message, Color color);

		/// <summary>Возвращает массив направлений, в котроые может идти мышь.</summary>
		/// <returns>Массив направлений.</returns>
		Dir[] GetCanGoDirs();
	}
}
