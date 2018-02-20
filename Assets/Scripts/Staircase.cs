using System;

namespace Finegamedesign.Utils
{
	public sealed class Staircase
	{
        public event Action<int> onNumberChanged;
        public event Action<int> onTotalChanged;

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
            if (onNumberChanged == null)
            {
                return;
            }
            onNumberChanged(GetNumber());
		}

		public void Setup(int nextStep, int nextLength)
		{
			length = nextLength;
			step = nextStep;
			index = defaultIndex;
            if (onTotalChanged == null)
            {
                return;
            }
            onTotalChanged(GetTotal());
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
			SetIndex(nextIndexOffset);
		}
	}
}
