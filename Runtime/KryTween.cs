using KryTween.Effects;
using System.Collections;
using UnityEngine;

namespace KryTween
{
    
    public static class KryTween
    {

        public static void Move(MonoBehaviour owner, RectTransform rectTransform, Vector2 finalPosition, float moveSpeed)
        {
            TweenMove newEffect = new TweenMove(rectTransform, finalPosition, moveSpeed);
            ExecuteEffect(owner, newEffect);
        }

        public static void MoveAndReturn(MonoBehaviour owner, RectTransform rectTransform, Vector2 finalPosition, float moveSpeed, float waitTime)
        {
            YieldInstruction wait = new WaitForSeconds(waitTime);
            TweenMoveAndReturn newEffect = new TweenMoveAndReturn(rectTransform, finalPosition, moveSpeed, wait);
            ExecuteEffect(owner, newEffect);
        }

        public static void Scale(MonoBehaviour owner, RectTransform rectTransform, Vector3 finalScale, float scaleSpeed)
        {
            TweenScale newEffect = new TweenScale(rectTransform, finalScale, scaleSpeed);
            ExecuteEffect(owner, newEffect);
        }

        public static void ScaleAndReturn(MonoBehaviour owner, RectTransform rectTransform, Vector3 finalScale, float scaleSpeed, float waitTime)
        {
            YieldInstruction wait = new WaitForSeconds(waitTime);
            TweenScaleAndReturn newEffect = new TweenScaleAndReturn(rectTransform, finalScale, scaleSpeed, wait);
            ExecuteEffect(owner, newEffect);
        }

        private static void ExecuteEffect(MonoBehaviour owner, ITweenEffect newEffect)
        {
            owner.StartCoroutine(newEffect.Execute());
        }
    }
}

