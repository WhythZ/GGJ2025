using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ɼ̳еĹ����������������
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