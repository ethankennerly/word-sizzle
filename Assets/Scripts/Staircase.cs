namespace Finegamedesign.Utils
{
	public sealed class Staircase
	{
		public int defaultIndex = 0;
		private int step = 1;
		private int index = 0;
		private int length = 0;

		public int GetNumber()
		{
			return index / step + 1;
		}

		private int GetRound()
		{
			return index / step * step;
		}

		public int GetTotal()
		{
			return length / step;
		}

		public int GetIndex()
		{
			return index;
		}

		public void SetIndex(int nextIndex)
		{
			index = nextIndex;
		}

		public void Setup(int nextStep, int nextLength)
		{
			length = nextLength;
			step = nextStep;
			index = defaultIndex;
		}

		// Random offset.  Number increases by one.
		public void Next()
		{
			int nextIndex = GetRound() + step;
			int offset = UnityEngine.Random.Range(0, step);
			int nextIndexOffset = nextIndex + offset;
			if (nextIndexOffset >= length)
			{
				nextIndexOffset = length - 1;
			}
			index = nextIndexOffset;
		}
	}
}
