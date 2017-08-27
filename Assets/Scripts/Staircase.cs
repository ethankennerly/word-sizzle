namespace Finegamedesign.Utils
{
	public sealed class Staircase
	{
		private int step = 1;
		private int index = 0;
		private int length = 0;

		public int GetNumber()
		{
			return index / step;
		}

		public int GetTotal()
		{
			return length / step;
		}

		public int GetIndex()
		{
			return index;
		}

		public void Setup(int nextStep, int nextLength)
		{
			length = nextLength;
			step = nextStep;
			index = 0;
		}

		// Random offset.  Number increases by one.
		public void Next()
		{
			int nextIndex = GetNumber() * step + step;
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