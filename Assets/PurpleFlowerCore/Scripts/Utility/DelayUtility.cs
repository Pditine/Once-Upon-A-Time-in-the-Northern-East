using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace PurpleFlowerCore.Utility
{
    public static class DelayUtility
    {
        /// <summary>
        /// 延迟执行
        /// </summary>
        /// <param name="time">延时时间</param>
        /// <param name="canScale">是否受到TimeScale影响</param>
        public static void Delay(float time,UnityAction action,bool canScale = true)
        {
            MonoSystem.Start_Coroutine(DoDelay(time, action,canScale));
        }

        private static IEnumerator DoDelay(float time,UnityAction action,bool canScale)
        {
            float waitTime = canScale ? time * Time.timeScale : time;
            yield return new WaitForSeconds(waitTime);
            action?.Invoke();
        }
    }
}