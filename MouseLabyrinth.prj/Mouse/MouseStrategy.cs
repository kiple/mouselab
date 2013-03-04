using System;

namespace MouseLabyrinth
{
	/// <summary>Стратегия (алгоритм) поведения мыши в лабиринте.</summary>
	abstract class MouseStrategy
	{
		private MouseContext _context;

		public void SetContext(MouseContext context)
		{
			_context = context;
		}

		protected IMouseContext Context
		{
			get { return _context; }
		}

		/// <summary>Рассчитывает и возвращает направление следующего шага мыши.</summary>
		/// <returns>Направление следующего шага мыши.</returns>
		public abstract Dir NextStep();
	}
}
