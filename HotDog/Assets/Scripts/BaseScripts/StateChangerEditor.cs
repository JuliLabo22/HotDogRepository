using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class StateChangerEditor : MonoBehaviour
{
    protected Action onEditorOn;
    protected Action onEditorOff;

    protected virtual void Start()
    {
        EventManager.Instance.AddEvent("OnStateEditorChange", OnChangeState);
    }

    void OnChangeState(params object[] parameters)
    {
        if ((bool)parameters[0]) onEditorOn?.Invoke();
        else onEditorOff?.Invoke();
    }

    private void OnDestroy()
    {
        EventManager.Instance.RemoveEvent("OnStateEditorChange", OnChangeState);
    }
}
