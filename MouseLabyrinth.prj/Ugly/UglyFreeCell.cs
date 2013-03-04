using System;
using System.Drawing;

namespace MouseLabyrinth
{
	class UglyFreeCell : FreeCell
	{
		private readonly Pen _pen = new Pen(Color.LimeGreen, 2);

		public override void Draw(Graphics g, Rectangle clip)
		{
			var stoneWidth = clip.Width / 3;
			int stoneHeight = clip.Height / 3;
			if(Stones >= 1) g.DrawEllipse(_pen, new Rectangle(clip.X + 1, clip.Y + 1, stoneWidth, stoneHeight));
			if(Stones >= 2) g.DrawEllipse(_pen, new Rectangle(clip.Right - stoneWidth - 1, clip.Y + 1, stoneWidth, stoneHeight));
			if(Stones >= 3) g.DrawEllipse(_pen, new Rectangle(clip.X + 1, clip.Bottom - stoneHeight - 1, stoneWidth, stoneHeight));
			if(Stones >= 4) g.DrawEllipse(_pen, new Rectangle(clip.Right - stoneWidth - 1, clip.Bottom - stoneHeight - 1, stoneWidth, stoneHeight));
		}
	}
}
