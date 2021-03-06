using UnityEngine;
using System.Collections;

namespace KryTween.Effects
{
    public class TweenScale : ITweenEffect
    {
        private RectTransform RectTransform { get; }
        private Vector3 MaxSize { get; }
        private float ScaleSpeed { get; }

        public TweenScale(RectTransform rectTransform, Vector3 maxSize, float scaleSpeed)
        {
            RectTransform = rectTransform;
            MaxSize = maxSize;
            ScaleSpeed = scaleSpeed;
        }

        public IEnumerator Execute()
        {
            //scale
            var time = 0f;
            var currentScale = RectTransform.localScale;

            while(RectTransform.localScale != MaxSize)
            {
                time += Time.deltaTime;
                var scale = Vector2.Lerp(currentScale, MaxSize, time / ScaleSpeed);
                RectTransform.localScale = scale;
                yield return null;
            }

            RectTransform.localScale = MaxSize;
        }
    }
}

