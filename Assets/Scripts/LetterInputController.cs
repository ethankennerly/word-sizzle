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
		}

		public void Update()
		{
			UpdateInput();
			UpdateLetters();
		}

		private void UpdateInput()
		{
			model.Input(KeyView.InputList());
			button.Update();
			int addIndex = view.buttons.buttons.IndexOf(button.view.target);
			if (addIndex >= 0)
			{
				string letter = model.buttons.texts[addIndex];
				model.Add(letter, true);
			}
			int backspaceIndex = view.selects.buttons.IndexOf(button.view.target);
			if (backspaceIndex >= 0)
			{
				model.Backspace(true);
			}
			AnimationView.SetState(view.tutor, model.tutorState);
			TextView.SetText(view.tutorText, model.tutorText);
		}

		private void UpdateLetters()
		{
			AnimationView.SetStates(view.buttons.states, model.buttons.states);
			TextView.SetTexts(view.buttons.texts, model.buttons.texts);

			AnimationView.SetStates(view.selects.states, model.selects.states);
			TextView.SetTexts(view.selects.texts, model.selects.texts);
		}
	}
}
