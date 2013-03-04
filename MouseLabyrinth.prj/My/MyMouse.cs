using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MouseLabyrinth
{
	/// <summary>Простой пример мыши.</summary>
	class MyMouse : Mouse
	{
		public MyMouse(MouseStrategy strategy) : base(strategy)
		{
		}

		/// <summary>Рисует мышь.</summary>
		/// <param name="g">Графический контекст.</param>
		/// <param name="clip">Кординаты области для рисования.</param>
		public override void Draw(Graphics g, Rectangle clip)
		{
			// Рисуем мышь
		}

		/// <summary>Рисует мышь, нашедшую сыр.</summary>
		/// <param name="g">Графический контекст.</param>
		/// <param name="clip">Кординаты области для рисования.</param>
		public override void DrawHappy(Graphics g, Rectangle clip)
		{
			// Рисуем мышь, нашедшую сыр
		}
	}
}
