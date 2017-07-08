using System.Collections.Generic;
using UnityEngine;
using Finegamedesign.Utils;

namespace Finegamedesign.WordSizzle
{
	public sealed class AnagramView : MonoBehaviour
	{
		public LetterInputView input;

		private void Start()
		{
			if (input == null)
			{
				input = (LetterInputView)FindObjectOfType(typeof(LetterInputView));
			}
			input.Setup();
			TestWord();
		}

		private void TestWord()
		{
			input.controller.model.Populate("WIN");
		}

		private void Update()
		{
			input.controller.Update();
		}
	}
}
