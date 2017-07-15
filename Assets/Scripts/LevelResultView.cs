using UnityEngine;

namespace Finegamedesign.WordSizzle
{
	public sealed class LevelResultView : MonoBehaviour
	{
		public GameObject animatorOwner;

		public void Setup()
		{
			if (animatorOwner == null)
			{
				animatorOwner = gameObject;
			}
		}
	}
}
