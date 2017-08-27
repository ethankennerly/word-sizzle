using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Finegamedesign.Utils
{
	public sealed class WordLevelsView : MonoBehaviour
	{
		public Text numberText;
		public Text totalText;

		private WordLevels model;

		public static WordLevelsView[] Binds(WordLevels model, WordLevelsView[] timers)
		{
			if (timers == null || timers.Length == 0)
			{
				timers = FindObjectsOfType<WordLevelsView>();
			}
			for (int index = 0, end = timers.Length; index < end; ++index)
			{
				timers[index].model = model;
			}
			return timers;
		}

		private void Update()
		{
			numberText.text = model.Number.ToString();
			totalText.text = model.Total.ToString();
		}
	}
}
