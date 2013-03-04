using System;

namespace MouseLabyrinth
{
	/// <summary>Базовый класс стены.</summary>
	abstract class Wall : Cell
	{
		protected Wall() : base(false)
		{
		}
	}
}
