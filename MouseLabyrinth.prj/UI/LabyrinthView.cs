using System;
using System.Drawing;
using System.Windows.Forms;

namespace MouseLabyrinth.UI
{
	/// <summary>Визуальный компонент для отображения лабиринта.</summary>
	partial class LabyrinthView : UserControl
	{
		private const int MESSAGE_HEIGHT = 40;

		private ILabyrinth _labyrinth;

		private Rectangle _messageRect;

		private readonly Font _messageFont = new Font(FontFamily.GenericSansSerif, 18);

		private readonly StringFormat _messageFormat = new StringFormat();

		private string _message;

		private Color _messageColor = Color.White;

		private readonly object _messageSync = new object();

		public LabyrinthView()
		{
			InitializeComponent();

			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);

			_messageFormat.Alignment = StringAlignment.Center;
			_messageFormat.LineAlignment = StringAlignment.Center;
		}

		/// <summary>Подключает лабиринт к визульному компоненту для отображения.</summary>
		/// <param name="labyrinth"></param>
		public void Attach(ILabyrinth labyrinth)
		{
			if(labyrinth == null) throw new ArgumentNullException("labyrinth");

			_labyrinth = labyrinth;
			_labyrinth.View = this;
		}

		public Rectangle GetClip(Coords coords)
		{
			if(_labyrinth == null || !IsHandleCreated) return Rectangle.Empty;
			var xFactor = Width / (double)_labyrinth.ColsCount;
			var yFactor = (Height - MESSAGE_HEIGHT) / (double)_labyrinth.RowsCount;
			var x = (int)(xFactor * (coords.Col - 1));
			var y = (int)(yFactor * (coords.Row - 1));
			return new Rectangle(x, y, (int)xFactor, (int)yFactor);
		}

		public void Write(string message, Color color)
		{
			lock(_messageSync)
			{
				_message = message;
				_messageColor = color;
			}
			Invalidate();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			_messageRect = new Rectangle(0, Height - MESSAGE_HEIGHT, Width, MESSAGE_HEIGHT);
		}

		protected override void OnPaintBackground(PaintEventArgs args)
		{
			if(_labyrinth == null)
			{
				base.OnPaintBackground(args);
				return;
			}
			var clip = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height - MESSAGE_HEIGHT);
			_labyrinth.Draw(args.Graphics, clip);
			DrawMessage(args.Graphics);
		}

		private void DrawMessage(Graphics g)
		{
			string message;
			Color color;
			lock(_messageSync)
			{
				message = string.IsNullOrEmpty(_message) ? string.Empty : _message;
				color = _messageColor;
			}
			using(var brush = new SolidBrush(color))
			{
				g.DrawString(message, _messageFont, brush, _messageRect, _messageFormat);
			}
		}
	}
}
