using System;
using UnityEngine;

namespace FineGameDesign.Utils
{
    public sealed class Follower : MonoBehaviour
    {
        public Transform followerRoot;
        public TrailRenderer trail;
        public float startWidth = 10f;
        public Action<int, Vector3> onNextPosition;

        private void OnEnable()
        {
            Setup();
        }

        public void Setup()
        {
            onNextPosition = NextPosition;
            if (trail != null)
                trail.startWidth = startWidth;
        }

        private void NextPosition(int positionIndex, Vector3 position)
        {
            followerRoot.position = position;

            if (positionIndex <= 0)
                if (trail != null)
                    trail.Clear();
        }
    }
}
