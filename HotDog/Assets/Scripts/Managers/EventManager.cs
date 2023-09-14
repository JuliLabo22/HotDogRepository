using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    private Dictionary<string, Action<object[]>> dic = new Dictionary<string, Action<object[]>>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    public void AddEvent(string key, Action<object[]> callback)
    {
        if (dic.ContainsKey(key)) dic[key] += callback;
        else dic.Add(key, callback);
    }

    public void RemoveEvent(string key, Action<object[]> callback)
    {
        if (dic.ContainsKey(key)) dic[key] -= callback;
    }

    public void Trigger(string key, params object[] parameters)
    {
        if (dic.ContainsKey(key)) dic[key]?.Invoke(parameters);
    }
}
