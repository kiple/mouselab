using System;
using System.Drawing;
using System.Linq;

namespace MouseLabyrinth
{
	/// <summary>Объект взаимодействия мыши с лабиринтом.</summary>
	sealed class MouseContext : IMouseContext
	{
		private readonly ILabyrinth _labyrinth;

		private Coords _mouseCoords;

		public Coords MouseCoords
		{
			get { return _mouseCoords; }
		}

		public MouseContext(ILabyrinth labyrinth, Coords mouseCoords)
		{
			_labyrinth = labyrinth;
			_mouseCoords = mouseCoords;
		}

		/// <summary>Возвращает количество камней в клетке, в которой находится мышь.</summary>
		/// <returns>Количество камней.</returns>
		public int GetStones()
		{
			return _labyrinth.GetStones(_mouseCoords.Row, _mouseCoords.Col);
		}

		/// <summary>Устанавливает указанное количество камней в клетку, в которой находится мышь.</summary>
		/// <param name="count">Количество камней.</param>
		public void PutStones(int count)
		{
			_labyrinth.SetStones(_mouseCoords.Row, _mouseCoords.Col, count);
		}

		/// <summary>Возвращает значение, показывающее свободна ли клетка в указанном направлении.</summary>
		/// <param name="dir">Направление.</param>
		/// <returns>Если клетка свободна, то <c>true</c>, иначе <c>false</c>.</returns>
		public bool IsCanGo(Dir dir)
		{
			switch(dir)
			{
				case Dir.Left:
					return GetSafeCell(_mouseCoords.Row, _mouseCoords.Col - 1).IsFree;
				case Dir.Right:
					return GetSafeCell(_mouseCoords.Row, _mouseCoords.Col + 1).IsFree;
				case Dir.Up:
					return GetSafeCell(_mouseCoords.Row - 1, _mouseCoords.Col).IsFree;
				case Dir.Down:
					return GetSafeCell(_mouseCoords.Row + 1, _mouseCoords.Col).IsFree;
			}
			throw new ArgumentException("Некорректное направление.", "dir");
		}

		/// <summary>Возвращает массив направлений, в котроые может идти мышь.</summary>
		/// <returns>Массив направлений.</returns>
		public Dir[] GetCanGoDirs()
		{
			return new[] { Dir.Left, Dir.Right, Dir.Up, Dir.Down, }.Where(IsCanGo).ToArray();
		}

		/// <summary>Выводит сообщение на экран.</summary>
		/// <param name="message"></param>
		public void Write(string message, Color color)
		{
			if(color == default(Color)) color = Color.White;
			_labyrinth.Write(message, color);
		}

		/// <summary>Передвигает мышь в указанном направлении.</summary>
		/// <param name="dir">Направление.</param>
		public void Go(Dir dir)
		{
			switch(dir)
			{
				case Dir.Left:
					_mouseCoords = new Coords(_mouseCoords.Row, _mouseCoords.Col - 1);
					break;
				case Dir.Right:
					_mouseCoords = new Coords(_mouseCoords.Row, _mouseCoords.Col + 1);
					break;
				case Dir.Up:
					_mouseCoords = new Coords(_mouseCoords.Row - 1, _mouseCoords.Col);
					break;
				case Dir.Down:
					_mouseCoords = new Coords(_mouseCoords.Row + 1, _mouseCoords.Col);
					break;
				default:
					Write("Мышь не двигается.", Color.Brown);
					break;
			}
		}

		private Cell GetSafeCell(int row, int col)
		{
			return _labyrinth.IsValidate(new Coords(row, col)) ? _labyrinth.GetCell(row, col) : new BorderWall();
		}

		private class BorderWall : Wall
		{
			public override void Draw(Graphics g, Rectangle clip)
			{
			}
		}
	}
}
