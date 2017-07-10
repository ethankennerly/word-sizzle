using System.Collections.Generic;
using UnityEngine;
using Finegamedesign.Utils;

namespace Finegamedesign.WordSizzle
{
	public sealed class AnagramView : MonoBehaviour
	{
		public LetterInputView input;
		public AnagramController controller = new AnagramController();

		private void Start()
		{
			Setup();
		}

		private void Setup()
		{
			if (input == null)
			{
				input = (LetterInputView)FindObjectOfType(typeof(LetterInputView));
			}
			controller.view = this;
			controller.Setup();
		}

		private void Update()
		{
			controller.Update(Time.deltaTime);
		}
	}
}
