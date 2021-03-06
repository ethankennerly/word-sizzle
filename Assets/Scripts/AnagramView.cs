using System.Collections.Generic;
using UnityEngine;
using FineGameDesign.Utils;

namespace FineGameDesign.WordSizzle
{
    public sealed class AnagramView : MonoBehaviour
    {
        public LetterInputView input;
        public PauseSystemView pause;
        public LevelResultView result;
        public AnagramController controller = new AnagramController();

        public TimerView[] timers;
        public TimerTextDeckView[] timerTexts;

        public WordLevelsView[] wordLevels;

        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            if (pause == null)
            {
                pause = FindObjectOfType<PauseSystemView>();
            }
            if (input == null)
            {
                input = FindObjectOfType<LetterInputView>();
            }
            if (result == null)
            {
                result = FindObjectOfType<LevelResultView>();
            }
            result.Setup();

            wordLevels = WordLevelsView.Binds(controller.model.levels, wordLevels);
            timers = TimerView.Binds(controller.model.timer, timers);
            timerTexts = TimerTextDeckView.Binds(controller.model.textDeck, timerTexts);

            controller.view = this;
            controller.Setup();
        }

        private void Update()
        {
            AnimationView.UpdateDisableOnEnd();
            controller.Update(Time.deltaTime);
        }
    }
}
