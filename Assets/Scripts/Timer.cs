namespace Finegamedesign.Utils
{
	public sealed class Timer
	{
		public float normal = 0.0f;
		public float time = 0.0f;
		public float min = 0.0f;
		public float max = 20.0f;

		public bool isEnabled = true;

		public void Reset()
		{
			time = 0.0f;
			normal = Normalize(time);
		}

		public void Update(float deltaTime)
		{
			if (!isEnabled)
			{
				return;
			}
			time += deltaTime;
			normal = Normalize(time);
		}

		private float Normalize(float time)
		{
			float normal = (time - min) / (max - min);
			if (normal < min)
			{
				normal = min;
			}
			else if (normal > max)
			{
				normal = max;
			}
			return normal;
		}
	}
}