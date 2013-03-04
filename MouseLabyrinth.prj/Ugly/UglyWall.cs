using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MouseLabyrinth
{
	/// <summary>Простая стена.</summary>
	class UglyWall : Wall
	{
		public override void Draw(Graphics g, Rectangle clip)
		{
			g.FillRectangle(new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Coral), clip);
			g.DrawRectangle(new Pen(Color.Coral, 2), clip);
		}
	}
}
