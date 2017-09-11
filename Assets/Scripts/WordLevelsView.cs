using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Finegamedesign.Utils
{
	public sealed class WordLevelsView : MonoBehaviour
	{
		public Text numberText;
		public Text totalText;

		public Button newGameButton;

		private WordLevels model;

		public static WordLevelsView[] Binds(WordLevels model, WordLevelsView[] views)
		{
			if (views == null || views.Length == 0)
			{
				views = FindObjectsOfType<WordLevelsView>();
			}
			for (int index = 0, end = views.Length; index < end; ++index)
			{
				views[index].model = model;
			}
			return views;
		}

		private void Start()
		{
			if (newGameButton == null)
			{
				return;
			}
			newGameButton.onClick.AddListener(NewGame);
		}

		private void Update()
		{
			numberText.text = model.Number.ToString();
			totalText.text = model.Total.ToString();
		}

		private void NewGame()
		{
			model.ResetLevel();
			SceneManager.LoadScene(0);
		}
	}
}
