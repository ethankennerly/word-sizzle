using UnityEngine;

namespace Finegamedesign.Utils
{
	[RequireComponent(typeof(Animator))]
	public sealed class TimerView : MonoBehaviour
	{
		public Timer model;
		public string state = "begin";

		private Animator animator;

		public static TimerView[] Binds(Timer model, TimerView[] timers)
		{
			if (timers == null || timers.Length == 0)
			{
				timers = FindObjectsOfType<TimerView>();
			}
			for (int index = 0, end = timers.Length; index < end; ++index)
			{
				timers[index].model = model;
			}
			return timers;
		}

		private void Start()
		{
			animator = GetComponent<Animator>();
		}

		private void Update()
		{
			animator.Play(state, -1, model.normal);
		}
	}
}
