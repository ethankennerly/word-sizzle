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
			isNextNow = view.nextButton == input.view.target;
			if (isNextNow)
			{
				model.Populate();
			}
			AnimationView.SetState(view.animatorOwner, model.state);
		}
	}
}
