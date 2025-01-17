using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//可继承的管理器单例抽象基类
public abstract class Manager<T> : MonoBehaviour where T : Manager<T>
{
    public static T instance;

    protected virtual void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = (T)this;
    }
}