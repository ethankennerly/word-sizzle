using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Finegamedesign.Utils
{
    public sealed class WordLevelsView : MonoBehaviour
    {
        public TextMeshProUGUI numberText;
        public TextMeshProUGUI totalText;

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
                views[index].SetModel(model);
            }
            return views;
        }

        private void SetModel(WordLevels nextModel)
        {
            model = nextModel;
            if (nextModel == null)
            {
                return;
            }
            UpdateNumber(model.Level.GetNumber());
            UpdateTotal(model.Level.GetTotal());

            model.Level.onNumberChanged += UpdateNumber;
            model.Level.onTotalChanged += UpdateTotal;
        }

        private void UpdateNumber(int number)
        {
            numberText.text = number.ToString();
        }

        private void UpdateTotal(int total)
        {
            totalText.text = total.ToString();
        }

        private void Start()
        {
            if (newGameButton == null)
            {
                return;
            }
            newGameButton.onClick.AddListener(NewGame);
        }

        private void NewGame()
        {
            model.ResetLevel();
            SceneManager.LoadScene(0);
        }
    }
}
