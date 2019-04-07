using System;
using UnityEngine;

namespace FineGameDesign.Utils
{
    public sealed class Follower : MonoBehaviour
    {
        public Transform followerRoot;
        public TrailRenderer trail;
        [Header("Trail render editor clamps at 1.")]
        public float startWidth = 40f;

        public Action<int, Vector3> onNextPosition;
        public Action onClear;

        private void OnEnable()
        {
            Setup();
        }

        public void Setup()
        {
            onNextPosition = NextPosition;
            onClear = Clear;
            if (trail != null)
                trail.startWidth = startWidth;
        }

        private void NextPosition(int positionIndex, Vector3 position)
        {
            followerRoot.position = position;
            trail.time = float.MaxValue;

            if (positionIndex <= 0)
                if (trail != null)
                    trail.Clear();
        }

        private void Clear()
        {
            if (trail == null)
                return;

            trail.Clear();
        }
    }
}
