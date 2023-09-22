using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class DraggeableEditableObject : MonoBehaviour, IDraggeable
{
    [SerializeField] private UnityEvent onDragEvent;
    [SerializeField] private UnityEvent onDropEvent;

    BoxCollider2D _boxCollider;
    SpriteRenderer _sp;

    EditorTableManager.OffsetLimit offsetsPadding;
    Vector3 offset;
    Vector3 startPos;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _sp = GetComponent<SpriteRenderer>();

        offsetsPadding = EditorTableManager.Instance.offset;
    }

    public void OnStartDrag(Vector3 offset) 
    {
        startPos = transform.position;
        this.offset = offset;
        onDragEvent?.Invoke();
    }

    public void OnDrop()
    {
        onDropEvent?.Invoke();

        if (CheckLimits())
        {
            transform.DOMove(startPos, 0.5f);
            ChangeColor(Color.white);
        }
    }

    public void OnDrag(Vector3 pos)
    {
        pos.z += 10;

        transform.position = Camera.main.ScreenToWorldPoint(pos) + offset;

        if (CheckLimits())
        {
            ChangeColor(Color.red);
        }
        else
        {
            ChangeColor(Color.white);
        }
    }

    void ChangeColor(Color col)
    {
        _sp.color = col;
    }

    bool CheckLimits() => _boxCollider.bounds.min.x < offsetsPadding.left   || 
                          _boxCollider.bounds.max.x > offsetsPadding.right  ||
                          _boxCollider.bounds.min.y < offsetsPadding.bottom ||
                          _boxCollider.bounds.max.y > offsetsPadding.up;
}
