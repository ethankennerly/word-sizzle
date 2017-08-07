using System.Collections.Generic;
using UnityEngine;
using Finegamedesign.Utils;

namespace Finegamedesign.WordSizzle
{
	public sealed class AnagramView : MonoBehaviour
	{
		public LetterInputView input;
		public LevelResultView result;
		public AnagramController controller = new AnagramController();
		public TimerView[] timers;

		private void Start()
		{
			Setup();
		}

		private void Setup()
		{
			if (input == null)
			{
				input = FindObjectOfType<LetterInputView>();
			}
			if (result == null)
			{
				result = FindObjectOfType<LevelResultView>();
			}
			result.Setup();
			timers = TimerView.Binds(controller.model.timer, timers);
			controller.view = this;
			controller.Setup();
		}

		private void Update()
		{
			controller.Update(Time.deltaTime);
		}
	}
}
