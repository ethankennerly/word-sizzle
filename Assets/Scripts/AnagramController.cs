using Finegamedesign.Utils;

namespace Finegamedesign.WordSizzle
{
	[System.Serializable]
	public sealed class AnagramController
	{
		public AnagramModel model = new AnagramModel();
		internal AnagramView view;

		public void Setup()
		{
			view.input.Setup();
			model.Setup();
			Populate();
		}

		private void Populate()
		{
			model.Populate();
			view.input.controller.model.Populate(model.word);
		}

		public void Update(float deltaTime)
		{
			view.input.controller.Update();
			model.selection = view.input.controller.model.selection;
			model.Update(deltaTime);
			AnimationView.SetState(view.result.animatorOwner, model.state);
		}
	}
}
