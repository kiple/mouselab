using System;
using System.Drawing;

namespace MouseLabyrinth
{
	/// <summary>Простой пример мыши.</summary>
	class UglyMouse : Mouse
	{
		private readonly Pen _pen = new Pen(Brushes.AliceBlue, 2);

		private readonly Pen _penHappy = new Pen(Brushes.MediumVioletRed, 2);

		public UglyMouse(MouseStrategy strategy) : base(strategy)
		{
		}

		/// <summary>Рисует мышь.</summary>
		/// <param name="g">Графический контекст.</param>
		/// <param name="clip">Кординаты области для рисования.</param>
		public override void Draw(Graphics g, Rectangle clip)
		{
			g.DrawEllipse(_pen, clip);
		}

		/// <summary>Рисует мышь, нашедшую сыр.</summary>
		/// <param name="g">Графический контекст.</param>
		/// <param name="clip">Кординаты области для рисования.</param>
		public override void DrawHappy(Graphics g, Rectangle clip)
		{
			g.DrawEllipse(_penHappy, clip);
		}
	}
}
