using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WaitTimeManager
{
    private static TaskBehaviour m_Task;

    static WaitTimeManager()
    {
        GameObject go = new GameObject("WaitTimeManager");
        GameObject.DontDestroyOnLoad(go);
        m_Task = go.AddComponent<TaskBehaviour>();
    }


    public static void CancelWait(ref Coroutine coroutine)
    {
        if (coroutine != null)
        {
            m_Task.StopCoroutine(coroutine);
        }
    }

    public static Coroutine WaitTime(float time, UnityAction callback)
    {
        return m_Task.StartCoroutine(Coroutine(time, callback));
    }

    private static IEnumerator Coroutine(float time, UnityAction callback)
    {
        yield return new WaitForSeconds(time);
        if (callback != null)
        {
            callback();
        }
    }

    //内部类
    class TaskBehaviour : MonoBehaviour
    {
    }
}
