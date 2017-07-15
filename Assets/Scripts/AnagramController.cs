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
			TestWord();
		}

		private void TestWord()
		{
			model.Populate("WIN");
			view.input.controller.model.Populate(model.word);
		}

		public void Update(float deltaTime)
		{
			view.input.controller.Update();
			model.selection = view.input.controller.model.selection;
			model.Update(deltaTime);
		}
	}
}
