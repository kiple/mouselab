using System;
using System.Drawing;

namespace MouseLabyrinth
{
	/// <summary>Сыр.</summary>
	class UglyCheese : Cheese
	{
		private readonly Pen _pen = new Pen(Brushes.Yellow, 2);

		public override void Draw(Graphics g, Rectangle clip)
		{
			var points = new[]
				{
					new Point(clip.X, clip.Y),
					new Point(clip.Right - 1, clip.Y + 2 * clip.Height / 3),
					new Point(clip.X + 2 * clip.Width / 3, clip.Bottom - 1),
				};
			g.DrawPolygon(_pen, points);
		}
	}
}
