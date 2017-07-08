using NUnit.Framework;

namespace Finegamedesign.Utils
{
	public sealed class TestLetterInputModel
	{
		[Test]
		public void PopulateTextsAndStates()
		{
			var input = new LetterInputModel();
			input.Populate("WIN");
			Assert.AreEqual(3, input.buttons.texts.Count);
			Assert.AreEqual("W", input.buttons.texts[0]);
			Assert.AreEqual("I", input.buttons.texts[1]);
			Assert.AreEqual("N", input.buttons.texts[2]);
			Assert.AreEqual(3, input.buttons.states.Count);
			Assert.AreEqual(input.beginState, input.buttons.states[0]);
			Assert.AreEqual(input.beginState, input.buttons.states[1]);
			Assert.AreEqual(input.beginState, input.buttons.states[2]);
		}

		[Test]
		public void AddFirstThenRepeat()
		{
			var input = new LetterInputModel();
			input.Populate("WAN");
			input.Add("A");
			Assert.AreEqual(input.beginState, input.buttons.states[0]);
			Assert.AreEqual(input.selectedState, input.buttons.states[1]);
			Assert.AreEqual(input.beginState, input.buttons.states[2]);
			input.Add("A");
			Assert.AreEqual(input.beginState, input.buttons.states[0]);
			Assert.AreEqual(input.selectedState, input.buttons.states[1]);
			Assert.AreEqual(input.beginState, input.buttons.states[2]);
		}

		[Test]
		public void AddNone()
		{
			var input = new LetterInputModel();
			input.Populate("NOW");
			input.Add("");
			Assert.AreEqual(input.beginState, input.buttons.states[0]);
			Assert.AreEqual(input.beginState, input.buttons.states[1]);
			Assert.AreEqual(input.beginState, input.buttons.states[2]);
		}

		[Test]
		public void AddOther()
		{
			var input = new LetterInputModel();
			input.Populate("NEW");
			input.Add("A");
			Assert.AreEqual(input.beginState, input.buttons.states[0]);
			Assert.AreEqual(input.beginState, input.buttons.states[1]);
			Assert.AreEqual(input.beginState, input.buttons.states[2]);
		}
	}
}
