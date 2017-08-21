namespace Finegamedesign.Utils
{
	public sealed class Timer
	{
		public float normal = 0.0f;
		public float time = 0.0f;
		public float min = 0.0f;
		// Was 20.0f;
		// 2017-08-13 Jennifer Russ: Burn awful quick!!!!!
		public float max = 40.0f;

		public bool isEnabled = true;

		public string state;

		private class StateNormal
		{
			public float normal;
			public string state;

			public StateNormal(float theNormal, string theState)
			{
				normal = theNormal;
				state = theState;
			}

			public static StateNormal Get(StateNormal[] stateNormals, float normal)
			{
				if (stateNormals.Length == 0)
				{
					return null;
				}
				StateNormal previousState = stateNormals[0];
				for (int index = 0, end = stateNormals.Length; index < end; ++index)
				{
					StateNormal stateNormal = stateNormals[index];
					if (stateNormal.normal > normal)
					{
						return previousState;
					}
					previousState = stateNormal;
				}
				return previousState;
			}
		}

		private StateNormal[] stateNormals = {
			new StateNormal(0.0f, "fast"),
			new StateNormal(0.75f, "slow")
		};

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
			state = StateNormal.Get(stateNormals, normal).state;
			return normal;
		}
	}
}
