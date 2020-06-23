using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools
{
    /// <summary>
    /// 通过递归调用，实现在root中递归查找名字等于name的子物体
    /// </summary>
    /// <param name="root"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Transform FindRecursively(this Transform root, string name)
    {
        if (root.name == name) { return root; }
        foreach (Transform child in root)
        {
            Transform t = FindRecursively(child, name);
            if (t != null)
            {
                return t;
            }
        }
        return null;
    }
    public static T FindRecursively<T>(this Transform root, string name) where T : MonoBehaviour
    {
        Transform t = root.transform.FindRecursively(name);
        if (t == null)
        {
            //Debug.LogError(string.Format("root{0}下没有子物体{1}", root.name, name));
            return null;
        }
        T t2 = t.GetComponent<T>();
        if (t2 == null)
        {
            //Debug.LogError(string.Format("root{0}下子物体{1}没有组件", root.name, name));
        }
        else
        {
            return t2;
        }
        return null;
    }

    /// <summary>
    /// 高效查找子物体（递归查找）,建议采用此种方式  
    /// </summary> 
    /// <param name="trans">父物体</param>
    /// <param name="goName">子物体的名称</param>
    /// <returns>找到的相应子物体</returns>
    public static Transform FindChild(Transform trans, string goName)
    {
        Transform child = trans.Find(goName);
        if (child != null)
            return child;

        Transform go = null;
        for (int i = 0; i < trans.childCount; i++)
        {
            child = trans.GetChild(i);
            go = FindChild(child, goName);
            if (go != null)
                return go;
        }
        return null;
    }

    /// <summary>
    /// 查找子物体组件（递归查找子物体组件）  where T : UnityEngine.Object
    /// </summary> 
    /// <param name="trans">父物体</param>
    /// <param name="goName">子物体的名称</param>
    /// <returns>找到的相应子物体</returns>
    public static T FindChild<T>(Transform trans, string goName) where T : Object
    {
        Transform child = trans.Find(goName);
        if (child != null)
        {
            return child.GetComponent<T>();
        }

        Transform go = null;
        for (int i = 0; i < trans.childCount; i++)
        {
            child = trans.GetChild(i);
            go = FindChild(child, goName);
            if (go != null)
            {
                return go.GetComponent<T>();
            }
        }
        return null;
    }

 }

