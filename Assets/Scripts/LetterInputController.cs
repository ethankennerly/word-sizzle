using System.Collections.Generic;

namespace Finegamedesign.Utils
{
	// View displays letter texts and animations in model:
	//	Buttons
	//	Selected
	//	Submitted
	//	Hints
	// Each letter has:
	//	Animation state
	//	Text
	// Unity Toykit makes it convenient
	// to wire lists of states to to lists of animator owners,
	// And to wire lists of texts to lists of text owners.
	[System.Serializable]
	public sealed class LetterInputController
	{
		public LetterInputModel model = new LetterInputModel();
		internal LetterInputView view;
		private ButtonController button = new ButtonController();

		public void Setup()
		{
			model.backspaceCharacter = KeyView.backspaceCharacter;
			button.view.Listens(view.buttons.buttons);
			button.view.Listens(view.selects.buttons);
			button.view.Listen(view.backspaceButton);
			button.view.Listen(view.hintButton);
			button.view.Listen(view.shuffleButton);
			UpdateButtonKeyText();
		}

		public void UpdateButtonKeyText()
		{
			if (model.isTutorKey)
			{
				TextView.SetText(view.backspaceButton, model.backspaceButtonKeyText);
				TextView.SetText(view.shuffleButton, model.shuffleButtonKeyText);
				TextView.SetText(view.hintButton, model.hint.buttonKeyText);
			}
		}

		public void Update()
		{
			UpdateInput();
			UpdateLetters();
			AnimationView.SetState(view.tutor, model.tutorState);
			TextView.SetText(view.tutorText, model.tutorText);
		}

		private void UpdateInput()
		{
			model.Input(KeyView.InputList());
			button.Update();
			var target = button.view.target;
			if (target == null)
			{
				return;
			}
			int addIndex = view.buttons.buttons.IndexOf(target);
			if (addIndex >= 0)
			{
				string letter = model.buttons.texts[addIndex];
				model.Add(letter, true);
				return;
			}
			int backspaceIndex = view.selects.buttons.IndexOf(target);
			if (backspaceIndex >= 0 || target == view.backspaceButton)
			{
				model.Backspace(true);
				return;
			}
			if (target == view.hintButton)
			{
				model.HintButton();
				return;
			}
			if (target == view.shuffleButton)
			{
				model.Shuffle(true);
				return;
			}
		}

		private void UpdateLetters()
		{
			AnimationView.SetStates(view.buttons.states, model.buttons.states);
			TextView.SetTexts(view.buttons.texts, model.buttons.texts);

			AnimationView.SetStates(view.selects.states, model.selects.states);
			TextView.SetTexts(view.selects.texts, model.selects.texts);

			AnimationView.SetStates(view.hints.states, model.hint.selects.states);
			TextView.SetTexts(view.hints.texts, model.hint.selects.texts);
		}
	}
}
