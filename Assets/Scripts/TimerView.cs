using System.Collections.Generic;
using UnityEngine;

namespace Finegamedesign.Utils
{
	public sealed class TimerView : MonoBehaviour
	{
		public Timer model;
		public string state = "begin";
		public bool isChangeState = false;
		public bool isSyncNormal = true;
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
			Setup();
		}

		private void Setup()
		{
			if (animators == null || animators.Count == 0)
			{
				animators = new List<Animator>();
				animators.Add(GetComponent<Animator>());
			}
		}

		private void OnEnable()
		{
			if (!isSyncNormal)
			{
				Setup();
				if (model == null)
				{
					return;
				}
				state = model.State;
				PlayNormal(0.0f);
			}
		}

		private void Update()
		{
			normal = model.normal;
			if (isChangeState && state != model.State)
			{
				state = model.State;
				if (!isSyncNormal)
				{
					PlayNormal(0.0f);
				}
			}
			if (isSyncNormal)
			{
				PlayNormal(model.normal);
			}
		}

		private void PlayNormal(float normal)
		{
			for (int index = 0, end = animators.Count; index < end; ++index)
			{
				Animator animator = animators[index];
				animator.Play(state, -1, normal);
			}
		}
	}
}
