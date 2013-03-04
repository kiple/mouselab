using System;
using System.Drawing;
using System.Threading;

namespace MouseLabyrinth
{
	/// <summary>Отвечает за передвижение мыши в лабиринте.</summary>
	sealed class MouseRunner
	{
		/// <summary>Генерируется при необходимости обновить изображение лабиринта.</summary>
		public event EventHandler<EventArgs> RequestUpdated;

		public event EventHandler<EventArgs> MouseCompleted;

		private readonly ILabyrinth _labyrinth;

		private bool _running;

		private int _stepCount;

		private readonly EventWaitHandle _event = new AutoResetEvent(true);

		private Thread _thread;

		/// <summary>Устанавливает и возвращает скорость движения мыши по лабиринту.</summary>
		/// <value>Значение от 1 до 100. 1 - минимальная скорость, 100 - максимальная.</value>
		public int MouseSpeed { set; get; }

		public bool Running
		{
			get { return _running; }
		}

		/// <summary>Возвращает количество шагов, сделанных мышью.</summary>
		public int StepCount
		{
			get { return _stepCount; }
		}

		public MouseRunner(ILabyrinth labyrinth)
		{
			if(labyrinth == null) throw new ArgumentNullException("labyrinth");

			_labyrinth = labyrinth;
			MouseSpeed = 100;
		}

		public void Reset()
		{
			_stepCount = 0;
		}

		/// <summary>Запускает мышь в лабиринте.</summary>
		public void Start()
		{
			if(_running) throw new InvalidOperationException("Мышь уже запущена.");
			_labyrinth.Write("Мышь ищет сыр...", Color.Aquamarine);
			_event.Reset();
			_running = true;
			_thread = new Thread(ThreadProcess);
			_thread.Start();
		}

		/// <summary>Останавливает мышь в лабиринте.</summary>
		public void Stop()
		{
			if(!_running) return;
			_event.Set();
			if(_thread.IsAlive) _thread.Join(3000);
			if(_thread.IsAlive) _thread.Abort();
			if(_thread.IsAlive) _thread.Join(1000);
			_running = false;
		}

		private void ThreadProcess()
		{
			var wait = GetWait();
			var cheeseFounded = false;
			try
			{
				while(!cheeseFounded)
				{
					if(_event.WaitOne(wait)) break;
					cheeseFounded = _labyrinth.MouseDoStep();
					++_stepCount;
					var hander = RequestUpdated;
					if(hander != null) hander(this, EventArgs.Empty);
				}
				if(cheeseFounded) _labyrinth.Write(string.Format("Мышь нашла сыр за {0} ходов!", _stepCount), Color.Lime);
				else _labyrinth.Write("Уже не ищет.", Color.Thistle);
				_running = false;
				var hander1 = MouseCompleted;
				if(hander1 != null) hander1(this, EventArgs.Empty);
			}
			catch(ThreadAbortException)
			{
			}
		}

		private int GetWait()
		{
			return -20 * MouseSpeed + 2010;
		}
	}
}
