using System;

namespace MouseLabyrinth
{
	/// <summary>Игра.</summary>
	class Game
	{
		private Coords _originMouseCoords;

		private int _mouseSpeed;

		/// <summary>Возвращает лабиринт.</summary>
		public ILabyrinth Labyrinth { get; private set; }

		/// <summary>
		/// <para>
		/// Устанавливает и возвращает скорость движения мыши по лабиринту.
		/// </para>
		/// <para>
		/// Значение от 1 до 100. 1 - минимальная скорость, 100 - максимальная.
		/// </para>
		/// </summary>
		public int MouseSpeed
		{
			set
			{
				if(value < 1 || value > 100) throw new ArgumentException("Некорректное значение скорости мыши.");
				_mouseSpeed = value;
			}
			get { return _mouseSpeed; }
		}

		/// <summary>Строит лабиринт при помощи указанного построителя.</summary>
		/// <param name="builder">Построитель лабиринта.</param>
		public void BuildLabyrinth(LabyrinthBuilder builder)
		{
			if(builder == null) throw new ArgumentNullException("builder");
			Labyrinth = builder.CreateLabyrinth();
		}

		/// <summary>Кладет сыр в указанную клетку лабиринта.</summary>
		/// <param name="cheese">Сыр.</param>
		/// <param name="row">Номер строки клетки (начиная с 1).</param>
		/// <param name="col">Номер столбца клетки (начиная с 1).</param>
		public void PutCheese(Cheese cheese, int row, int col)
		{
			CheckLabyrinth();
			Labyrinth.PutCheese(cheese, row, col);
		}

		/// <summary>Помещает мышь в указанную клетку лабиринта.</summary>
		/// <param name="mouse">Мышь.</param>
		/// <param name="row">Номер строки клетки (начиная с 1).</param>
		/// <param name="col">Номер столбца клетки (начиная с 1).</param>
		public void PutMouse(Mouse mouse, int row, int col)
		{
			CheckLabyrinth();
			Labyrinth.PutMouse(mouse, row, col);
			_originMouseCoords = new Coords(row, col);
		}

		/// <summary>Сбрасывает игру в начальное состояние.</summary>
		public void Reset()
		{
			CheckLabyrinth();
			CollectStones();
			Labyrinth.SetMouse(_originMouseCoords.Row, _originMouseCoords.Col);
		}

		private void CheckLabyrinth()
		{
			if(Labyrinth == null) throw new InvalidOperationException("Лабиринт не создан.");
		}

		/// <summary>Собирает все камни в лабиринте.</summary>
		private void CollectStones()
		{
			for(var row = 1; row <= Labyrinth.RowsCount; ++row)
			{
				for(var col = 1; col <= Labyrinth.ColsCount; ++col)
				{
					var emptyCell = Labyrinth.GetCell(row, col) as FreeCell;
					if(emptyCell != null) emptyCell.Stones = 0;
				}
			}
		}
	}
}
