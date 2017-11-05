using NUnit.Framework;

namespace Finegamedesign.Utils
{
	public sealed class TestLetterInputModel
	{
		[Test]
		public void PopulateTextsAndStates()
		{
			var input = SetupLetterInputModel();
			input.Populate("WIN");
			Assert.AreEqual(3, input.buttons.texts.Count);
			Assert.AreEqual("W", input.buttons.texts[0]);
			Assert.AreEqual("I", input.buttons.texts[1]);
			Assert.AreEqual("N", input.buttons.texts[2]);
			Assert.AreEqual(input.letterMax, input.buttons.states.Count);
			Assert.AreEqual(input.beginState, input.buttons.states[0]);
			Assert.AreEqual(input.beginState, input.buttons.states[1]);
			Assert.AreEqual(input.beginState, input.buttons.states[2]);

			AssertSelectsNone(input);
		}

		[Test]
		public void AddFirstThenRepeat()
		{
			var input = SetupLetterInputModel();
			input.Populate("WAN");
			input.Add("A");
			Assert.AreEqual(input.letterMax, input.buttons.states.Count);
			Assert.AreEqual(input.beginState, input.buttons.states[0]);
			Assert.AreEqual(input.selectBeginState, input.buttons.states[1]);
			Assert.AreEqual(input.beginState, input.buttons.states[2]);
			input.Add("A");
			Assert.AreEqual(input.beginState, input.buttons.states[0]);
			Assert.AreEqual(input.selectBeginState, input.buttons.states[1]);
			Assert.AreEqual(input.beginState, input.buttons.states[2]);

			Assert.AreEqual(input.selectBeginState, input.selects.states[0]);
			Assert.AreEqual(input.beginState, input.selects.states[1]);
			Assert.AreEqual(input.beginState, input.selects.states[2]);
			Assert.AreEqual("A", input.selects.texts[0]);
			Assert.AreEqual(input.emptyState, input.selects.texts[1]);
			Assert.AreEqual(input.emptyState, input.selects.texts[2]);
		}

		[Test]
		public void AddNoInput()
		{
			var input = SetupLetterInputModel();
			input.Populate("NOW");
			input.Add("");
			Assert.AreEqual(input.letterMax, input.buttons.states.Count);
			Assert.AreEqual(input.beginState, input.buttons.states[0]);
			Assert.AreEqual(input.beginState, input.buttons.states[1]);
			Assert.AreEqual(input.beginState, input.buttons.states[2]);

			AssertSelectsNone(input);
		}

		private void AssertSelectsNone(LetterInputModel input)
		{
			Assert.AreEqual(input.letterMax, input.selects.states.Count);
			Assert.AreEqual(input.beginState, input.selects.states[0]);
			Assert.AreEqual(input.beginState, input.selects.states[1]);
			Assert.AreEqual(input.beginState, input.selects.states[2]);
			Assert.AreEqual(input.letterMax, input.selects.texts.Count);
			Assert.AreEqual(input.emptyState, input.selects.texts[0]);
			Assert.AreEqual(input.emptyState, input.selects.texts[1]);
			Assert.AreEqual(input.emptyState, input.selects.texts[2]);
		}

		[Test]
		public void AddOther()
		{
			var input = SetupLetterInputModel();
			input.Populate("NEW");
			input.Add("A");
			Assert.AreEqual(input.letterMax, input.buttons.states.Count);
			Assert.AreEqual(input.beginState, input.buttons.states[0]);
			Assert.AreEqual(input.beginState, input.buttons.states[1]);
			Assert.AreEqual(input.beginState, input.buttons.states[2]);

			AssertSelectsNone(input);
		}

		[Test]
		public void AddWithRepetition()
		{
			var input = SetupLetterInputModel();
			input.Populate("EEL");
			input.Add("E");
			Assert.AreEqual(input.letterMax, input.buttons.states.Count);
			Assert.AreEqual(input.selectBeginState, input.buttons.states[0]);
			Assert.AreEqual(input.beginState, input.buttons.states[1]);
			Assert.AreEqual(input.beginState, input.buttons.states[2]);
			input.Add("E");
			Assert.AreEqual(input.selectBeginState, input.buttons.states[0]);
			Assert.AreEqual(input.selectBeginState, input.buttons.states[1]);
			Assert.AreEqual(input.beginState, input.buttons.states[2]);

			Assert.AreEqual(input.letterMax, input.selects.texts.Count);
			Assert.AreEqual("E", input.selects.texts[0]);
			Assert.AreEqual("E", input.selects.texts[1]);
			Assert.AreEqual(input.emptyState, input.selects.texts[2]);
			Assert.AreEqual(input.letterMax, input.selects.states.Count);
			Assert.AreEqual(input.selectBeginState, input.selects.states[0]);
			Assert.AreEqual(input.selectBeginState, input.selects.states[1]);
			Assert.AreEqual(input.beginState, input.selects.states[2]);
		}

		[Test]
		public void AddCaseInsensitive()
		{
			var input = SetupLetterInputModel();
			input.Populate("WON");
			input.Add("n");
			Assert.AreEqual(input.letterMax, input.buttons.states.Count);
			Assert.AreEqual("N", input.selects.texts[0]);
			Assert.AreEqual(input.selectBeginState, input.buttons.states[2]);
			Assert.AreEqual(input.beginState, input.buttons.states[0]);
			Assert.AreEqual(input.beginState, input.buttons.states[1]);
		}

		private static LetterInputModel SetupLetterInputModel()
		{
			var input = new LetterInputModel();
			input.isShuffleOnPopulate = false;
			return input;
		}
	}
}
