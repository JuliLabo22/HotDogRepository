using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class DraggeableObject : MonoBehaviour, IDraggeable
{
    [SerializeField] private UnityEvent onDragEvent;
    [SerializeField] private UnityEvent onDropEvent;

    public void OnDrag() 
    {
        onDragEvent?.Invoke();
    }

    public void OnDrop()
    {
        onDropEvent?.Invoke();
    }

    public void OnFollow(Vector3 pos)
    {
        pos.z += 10;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }
}
