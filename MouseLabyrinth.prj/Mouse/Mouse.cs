using System;
using System.Drawing;

namespace MouseLabyrinth
{
	/// <summary>Мышь.</summary>
	abstract class Mouse : Cell
	{
		private readonly MouseStrategy _strategy;

		protected Mouse(MouseStrategy strategy) : base(true)
		{
			if(strategy == null) throw new ArgumentNullException("strategy");
			_strategy = strategy;
		}

		public MouseStrategy Strategy
		{
			get { return _strategy; }
		}

		public abstract void DrawHappy(Graphics g, Rectangle clip);
	}
}
