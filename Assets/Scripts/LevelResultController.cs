using FineGameDesign.Utils;

namespace FineGameDesign.WordSizzle
{
    [System.Serializable]
    public sealed class LevelResultController
    {
        public bool isNextNow = false;
        internal LevelResultView view;
        public ButtonController input = new ButtonController();
        public AnagramModel model;
        public LetterInputModel letterInput;

        public void Setup()
        {
            input.view.Listen(view.nextButton);
        }

        public void Update()
        {
            input.Update();
            UpdateNext();
            AnimationView.SetState(view.animatorOwner, model.state);
            AnimationView.SetState(view.tutor, letterInput.isTutorKey ? "begin" : "none");
        }

        // Pressing next button or enter key advances to next word.
        private void UpdateNext()
        {
            isNextNow = model.state == model.winBeginState
                && (view.nextButton == input.view.target
                    || KeyInputSystem.InputString() == KeyInputSystem.newlineCharacter);
            if (isNextNow)
            {
                model.Populate();
            }
        }
    }
}
