using UnityEngine;

namespace GAF.Core
{
    [RequireComponent(typeof(GAFBakedMovieClip))]
    public sealed class GAFPlayOnEnable : MonoBehaviour
    {
        private GAFBakedMovieClip clip;

        private void OnEnable()
        {
            clip = GetComponent<GAFBakedMovieClip>();
            clip.gotoAndPlay(1);
        }
    }
}
