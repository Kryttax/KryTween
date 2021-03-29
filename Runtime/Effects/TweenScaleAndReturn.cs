using UnityEngine;
using System.Collections;

namespace KryTween.Effects
{
    public class TweenScaleAndReturn : ITweenEffect
    {
        private RectTransform RectTransform { get; }
        private Vector3 MaxSize { get; }
        private float ScaleSpeed { get; }
        private YieldInstruction Wait { get; }

        public TweenScaleAndReturn(RectTransform rectTransform, Vector3 maxSize, float scaleSpeed, YieldInstruction wait)
        {
            RectTransform = rectTransform;
            MaxSize = maxSize;
            ScaleSpeed = scaleSpeed;
            Wait = wait;
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
            yield return Wait;

            //scale back
            currentScale = RectTransform.localScale;
            time = 0f;

            while (RectTransform.localScale != Vector3.one)
            {
                time += Time.deltaTime;
                var scale = Vector2.Lerp(currentScale, Vector3.one, time / ScaleSpeed);
                RectTransform.localScale = scale;
                yield return null;
            }
        }
    }
}

