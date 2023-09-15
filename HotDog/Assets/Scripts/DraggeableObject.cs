using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class DraggeableObject : MonoBehaviour, IDraggeable
{
    [SerializeField] private UnityEvent onDragEvent;
    [SerializeField] private UnityEvent onDropEvent;

    BoxCollider2D _boxCollider;
    SpriteRenderer _sp;

    EditorTableManager.OffsetLimit offset;
    Vector3 startPos;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _sp = GetComponent<SpriteRenderer>();

        offset = EditorTableManager.Instance.offset;
    }

    public void OnDrag() 
    {
        startPos = transform.position;
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

    public void OnFollow(Vector3 pos)
    {
        pos.z += 10;
        transform.position = Camera.main.ScreenToWorldPoint(pos);

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

    bool CheckLimits() => _boxCollider.bounds.min.x < offset.left   || 
                          _boxCollider.bounds.max.x > offset.right  ||
                          _boxCollider.bounds.min.y < offset.bottom ||
                          _boxCollider.bounds.max.y > offset.up;
}
