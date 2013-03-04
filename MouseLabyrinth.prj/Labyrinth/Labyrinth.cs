using System;
using System.Collections.Generic;
using System.Drawing;

using MouseLabyrinth.UI;

namespace MouseLabyrinth
{
	/// <summary>Лабиринт.</summary>
	sealed class Labyrinth<TFreeCell, TWall> : ILabyrinth
		where TFreeCell : FreeCell, new()
		where TWall : Wall, new()
	{
		private readonly int _colsCount;

		private readonly int _rowsCount;

		private readonly Dictionary<Coords, Cell> _staticCells = new Dictionary<Coords, Cell>();

		private LabyrinthView _view;

		private Mouse _mouse;

		private MouseContext _mouseContext;

		private Coords _cheeseCoords;

		/// <summary>Возвращает число столбцов в лабиринте.</summary>
		public int ColsCount
		{
			get { return _colsCount; }
		}

		/// <summary>Возвращает число строк в лабиринте.</summary>
		public int RowsCount
		{
			get { return _rowsCount; }
		}

		public LabyrinthView View
		{
			get { return _view; }
			set { _view = value; }
		}

		/// <summary>Создает пустой лабиринт указанного размера.</summary>
		/// <param name="colsCount">Количество строк.</param>
		/// <param name="rowsCount">Количество столбцов.</param>
		public Labyrinth(int rowsCount, int colsCount)
		{
			if(rowsCount < 1) throw new ArgumentException("Количество строк не может быть меньше 1.");
			if(colsCount < 1) throw new ArgumentException("Количество столбцов не может быть меньше 1.");

			_rowsCount = rowsCount;
			_colsCount = colsCount;
		}

		/// <summary>Устанавливает стену в указанную клетку лабиринта.</summary>
		/// <param name="row">Номер строки клетки (начиная с 1).</param>
		/// <param name="col">Номер столбца клетки (начиная с 1).</param>
		public void SetWall(int row, int col)
		{
			SetCell(CreateWall(), new Coords(row, col));
		}

		public void PutCheese(Cheese cheese, int row, int col)
		{
			_cheeseCoords = new Coords(row, col);
			SetCell(cheese, _cheeseCoords);
		}

		/// <summary>Помещает мышь в лабиринт в указанную клетку.</summary>
		/// <param name="mouse">Мышь.</param>
		/// <param name="row">Номер строки клетки (начиная с 1).</param>
		/// <param name="col">Номер столбца клетки (начиная с 1).</param>
		public void PutMouse(Mouse mouse, int row, int col)
		{
			var cell = GetCell(row, col);
			if(!(cell is FreeCell)) throw new ArgumentException("Мышь можно устанавливать только в пустую ячейку.");
			_mouse = mouse;
			SetMouse(row, col);
		}

		/// <summary>Устанавливат мышь в указанную клетку.</summary>
		/// <param name="row">Номер строки клетки.</param>
		/// <param name="col">Номер столбца клетки.</param>
		public void SetMouse(int row, int col)
		{
			_mouseContext = new MouseContext(this, new Coords(row, col));
			_mouse.Strategy.SetContext(_mouseContext);
		}

		/// <summary>Выполняет один шаг мыши.</summary>
		/// <returns>Если мышь достигла сыра, то <c>true</c>, иначе <c>false</c>.</returns>
		public bool MouseDoStep()
		{
			if(_mouse == null) throw new InvalidOperationException("Мышь не запущена в лабиринт.");
			var stepDir = _mouse.Strategy.NextStep();
			_mouseContext.Go(stepDir);
			return IsFoundCheese();
		}

		public int GetStones(int row, int col)
		{
			var cell = GetCell(row, col);
			var emptyCell = cell as FreeCell;
			if(emptyCell == null) throw new ArgumentException(string.Format("В ячейке ({0},{1}) не могут находится камни.", row, col));
			return emptyCell.Stones;
		}

		public void SetStones(int row, int col, int stones)
		{
			var cell = GetCell(row, col);
			var emptyCell = cell as FreeCell;
			if(emptyCell == null) throw new ArgumentException(string.Format("В ячейке ({0},{1}) не могут находится камни.", row, col));
			emptyCell.Stones = stones;
		}

		public bool IsValidate(Coords coords)
		{
			if(coords.Row < 1 || coords.Row > _rowsCount) return false;
			if(coords.Col < 1 || coords.Col > _colsCount) return false;
			return true;
		}

		public void Write(string message, Color color)
		{
			if(_view == null) return;
			_view.Write(message, color);
		}

		public void Draw(Graphics g, Rectangle clip)
		{
			g.FillRectangle(new SolidBrush(Color.Black), clip);

			lock(_staticCells)
			{
				foreach(var cell in _staticCells)
				{
					var cellClip = GetClip(cell.Key);
					cell.Value.Draw(g, cellClip);
				}
			}
			DrawMouse(g);
		}

		private void DrawMouse(Graphics g)
		{
			if(_mouse == null) return;
			var clip = GetClip(GetMouseCoords());
			if(IsFoundCheese()) _mouse.DrawHappy(g, clip);
			else _mouse.Draw(g, clip);
		}

		private Rectangle GetClip(Coords coords)
		{
			if(_view == null) return Rectangle.Empty;
			return _view.GetClip(coords);
		}

		private void SetCell(Cell cell, Coords coords)
		{
			Validate(coords);
			lock(_staticCells) _staticCells[coords] = cell;
		}

		/// <summary>Возвращает тип клетки с указанными координатами.</summary>
		/// <param name="row"></param>
		/// <param name="col"></param>
		/// <returns></returns>
		public Cell GetCell(int row, int col)
		{
			var coords = new Coords(row, col);
			Validate(coords);
			Cell cell;
			lock(_staticCells)
			{
				if(!_staticCells.TryGetValue(coords, out cell))
				{
					cell = CreateFreeCell();
					_staticCells[coords] = cell;
				}
			}
			return cell;
		}

		private Coords GetMouseCoords()
		{
			if(_mouseContext == null) throw new InvalidOperationException("В лабиринте нет мыши.");
			return _mouseContext.MouseCoords;
		}

		private void Validate(Coords coords)
		{
			if(coords.Row < 1 || coords.Row > _rowsCount) throw new ArgumentOutOfRangeException("coords", coords.Row, string.Format("Номер строки должен быть в пределах {0}..{1}.", 0, _rowsCount - 1));
			if(coords.Col < 1 || coords.Col > _colsCount) throw new ArgumentOutOfRangeException("coords", coords.Col, string.Format("Номер столбца должен быть в пределах {0}..{1}.", 0, _colsCount - 1));
		}

		private bool IsFoundCheese()
		{
			return _mouseContext.MouseCoords.Equals(_cheeseCoords);
		}

		private FreeCell CreateFreeCell()
		{
			return new TFreeCell();
		}

		private Wall CreateWall()
		{
			return new TWall();
		}
	}
}
