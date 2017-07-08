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

		public void Setup()
		{
		}

		public void Update()
		{
			UpdateButtons();
		}

		private void UpdateButtons()
		{
			AnimationView.SetStates(view.buttons.states, model.buttons.states);
			TextView.SetTexts(view.buttons.texts, model.buttons.texts);
		}
	}
}
