using System.Collections.Generic;
using UnityEngine;

namespace Finegamedesign.Utils
{
	public sealed class TimerView : MonoBehaviour
	{
		public Timer model;
		public string state = "begin";
		public bool isChangeState = false;
		public float normal;

		public List<Animator> animators;

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
			if (animators == null || animators.Count == 0)
			{
				animators = new List<Animator>();
				animators.Add(GetComponent<Animator>());
			}
		}

		private void Update()
		{
			normal = model.normal;
			if (isChangeState)
			{
				state = model.State;
			}
			for (int index = 0, end = animators.Count; index < end; ++index)
			{
				Animator animator = animators[index];
				animator.Play(state, -1, model.normal);
			}
		}
	}
}
