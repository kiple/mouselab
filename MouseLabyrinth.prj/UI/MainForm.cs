using System;
using System.Windows.Forms;

namespace MouseLabyrinth.UI
{
	/// <summary>Главная форма приложения.</summary>
	partial class MainForm : Form
	{
		private readonly Game _game;

		private readonly MouseRunner _mouseRunner;

		public MainForm(Game game)
		{
			_game = game;

			InitializeComponent();

			_labyrinthView.Attach(game.Labyrinth);

			_mouseRunner = new MouseRunner(game.Labyrinth) {MouseSpeed = game.MouseSpeed};
			_mouseRunner.RequestUpdated += MouseRunnerOnRequestUpdated;
			_mouseRunner.MouseCompleted += MouseRunnerOnMouseCompleted;
			UpdateUI();
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs args)
		{
			_mouseRunner.RequestUpdated -= MouseRunnerOnRequestUpdated;
			_mouseRunner.MouseCompleted -= MouseRunnerOnMouseCompleted;
			_mouseRunner.Stop();
		}

		private void UpdateUI()
		{
			_btnStartMouse.Enabled = !_mouseRunner.Running;
			_btnStopMouse.Enabled = _mouseRunner.Running;
			_txtMouseStepCount.Text = _mouseRunner.StepCount.ToString();
			_labyrinthView.Invalidate();
		}

		private void MouseRunnerOnRequestUpdated(object sender, EventArgs eventArgs)
		{
			MethodInvoker mi = () =>
				{
					_labyrinthView.Invalidate();
					_txtMouseStepCount.Text = _mouseRunner.StepCount.ToString();
				};
			if(_labyrinthView.InvokeRequired) _labyrinthView.BeginInvoke(mi);
			else mi();
		}

		private void MouseRunnerOnMouseCompleted(object sender, EventArgs eventArgs)
		{
			MethodInvoker mi = UpdateUI;
			if(InvokeRequired) BeginInvoke(mi);
			else mi();
		}

		private void _btnStartMouse_Click(object sender, EventArgs args)
		{
			_mouseRunner.Start();
			UpdateUI();
		}

		private void _btnStopMouse_Click(object sender, EventArgs args)
		{
			_mouseRunner.Stop();
			UpdateUI();
		}

		private void _btnResetGame_Click(object sender, EventArgs e)
		{
			_btnResetGame.Enabled = false;
			_mouseRunner.Stop();
			_mouseRunner.Reset();
			_game.Reset();
			UpdateUI();
			_btnResetGame.Enabled = true;
		}
	}
}
