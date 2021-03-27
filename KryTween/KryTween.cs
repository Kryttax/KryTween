using KryTween.Scripts.Effects;
using System.Collections;
using UnityEngine;

namespace KryTween.Scripts
{
    
    public static class KryTween
    {

        public static void Move(MonoBehaviour owner, RectTransform rectTransform, Vector2 finalPosition, float moveSpeed)
        {
            MoveRectEffect newEffect = new MoveRectEffect(rectTransform, finalPosition, moveSpeed);
            ExecuteEffect(owner, newEffect);
        }

        public static void MoveAndReturn(MonoBehaviour owner, RectTransform rectTransform, Vector2 finalPosition, float moveSpeed, float time)
        {
            YieldInstruction wait = new WaitForSeconds(time);
            MoveAndReturnEffect newEffect = new MoveAndReturnEffect(rectTransform, finalPosition, moveSpeed, wait);
            ExecuteEffect(owner, newEffect);
        }

        public static void ScaleAndReturn(MonoBehaviour owner, RectTransform rectTransform, Vector3 finalScale, float scaleSpeed, float time)
        {
            YieldInstruction wait = new WaitForSeconds(time);
            ScaleRectEffect newEffect = new ScaleRectEffect(rectTransform, finalScale, scaleSpeed, wait);
            ExecuteEffect(owner, newEffect);
        }

        private static void ExecuteEffect(MonoBehaviour owner, IUIEffect newEffect)
        {
            owner.StartCoroutine(newEffect.Execute());
        }
    }
}

