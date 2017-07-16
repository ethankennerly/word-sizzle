using UnityEngine;
using Finegamedesign.Utils;

namespace Finegamedesign.WordSizzle
{
	public sealed class LevelResultView : MonoBehaviour
	{
		public GameObject animatorOwner;
		public GameObject nextButton;
		public string nextButtonPath = "LevelResultContainer/Panel/NextButton";
		public LevelResultController controller;

		public void Setup()
		{
			if (animatorOwner == null)
			{
				animatorOwner = gameObject;
			}
			nextButton = SceneNodeView.GetChild(gameObject, nextButtonPath, nextButton);
			controller.view = this;
			controller.Setup();
		}
	}
}
