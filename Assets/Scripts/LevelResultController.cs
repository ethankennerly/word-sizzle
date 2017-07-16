using Finegamedesign.Utils;

namespace Finegamedesign.WordSizzle
{
	[System.Serializable]
	public sealed class LevelResultController
	{
		public bool isNextNow = false;
		internal LevelResultView view;
		public ButtonController input = new ButtonController();
		public AnagramModel model;

		public void Setup()
		{
			input.view.Listen(view.nextButton);
		}

		public void Update()
		{
			input.Update();
			UpdateNext();
			AnimationView.SetState(view.animatorOwner, model.state);
		}

		// Pressing next button or enter key advances to next word.
		private void UpdateNext()
		{
			isNextNow = model.state == model.winBeginState
				&& (view.nextButton == input.view.target
					|| KeyView.InputString() == KeyView.newlineCharacter);
			if (isNextNow)
			{
				model.Populate();
			}
		}
	}
}
