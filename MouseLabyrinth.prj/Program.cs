using System;
using System.Windows.Forms;

using MouseLabyrinth.UI;

namespace MouseLabyrinth
{
	static class Program
	{
		/// <summary>Метод запуска программы.</summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Создаем игру (выбрать одну из строк)
			//var game = MyGameCreater.CreateGame();
			var game = UglyGameCreater.CreateGame();

			Application.Run(new MainForm(game));
		}
	}
}
