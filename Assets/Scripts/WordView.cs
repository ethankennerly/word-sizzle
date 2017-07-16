using System.Collections.Generic;
using UnityEngine;

namespace Finegamedesign.Utils
{
	[System.Serializable]
	public sealed class WordView
	{
		public List<GameObject> buttons;
		public List<GameObject> states;
		public List<GameObject> texts;

		public string statePathSuffix = "LetterContainer_{0}";
		public string buttonPathSuffix = "LetterContainer_{0}/LetterButton";
		public string textPathSuffix = "LetterContainer_{0}/LetterButton/Text";

		public void MayFindObjects(GameObject parent, string pathPrefix, int letterMax)
		{
			if (states == null || states.Count == 0)
			{
				states = SceneNodeView.GetChildrenByPattern(
					parent, pathPrefix + statePathSuffix,
					letterMax);
			}
			if (buttons == null || buttons.Count == 0)
			{
				buttons = SceneNodeView.GetChildrenByPattern(
					parent, pathPrefix + buttonPathSuffix,
					letterMax);
			}
			if (texts == null || texts.Count == 0)
			{
				texts = SceneNodeView.GetChildrenByPattern(
					parent, pathPrefix + textPathSuffix,
					letterMax);
			}
		}
	}
}
