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
			view.result.controller.model = model;
			view.result.controller.letterInput = view.input.controller.model;
			view.input.Setup();
			model.Setup();
		}

		private void Populate()
		{
			view.input.controller.model.Populate(model.word);
		}

		public void Update(float deltaTime)
		{
			view.input.controller.Update();
			model.selection = view.input.controller.model.selection;
			view.result.controller.Update();
			model.Update(deltaTime);
			if (model.isPopulateNow)
			{
				Populate();
			}
		}
	}
}
