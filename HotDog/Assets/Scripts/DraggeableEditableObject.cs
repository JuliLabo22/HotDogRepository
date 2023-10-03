using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class DraggeableEditableObject : StateChangerEditor, IDraggeable
{
    [SerializeField] private UnityEvent onDragEvent;
    [SerializeField] private UnityEvent onDropEvent;

    BoxCollider2D boxCollider;
    SpriteRenderer _sp;

    EditorTableManager.OffsetLimit offsetsPadding;
    Vector3 offset;
    Vector3 startPos;

    bool isColliderOverOther;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        onEditorOn += () => boxCollider.enabled = true;
        onEditorOff += () => boxCollider.enabled = false;

        _sp = GetComponent<SpriteRenderer>();
    }

    private new void Start()
    {
        base.Start();
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

        if (CheckLimits() || isColliderOverOther)
        {
            transform.DOMove(startPos, 0.5f);
            ChangeColor(Color.white);
        }
    }

    public void OnDrag(Vector3 pos)
    {
        pos.z += 10;

        transform.position = Camera.main.ScreenToWorldPoint(pos) + offset;

        if (CheckLimits() || isColliderOverOther)
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

    bool CheckLimits() => boxCollider.bounds.min.x < offsetsPadding.left   || 
                          boxCollider.bounds.max.x > offsetsPadding.right  ||
                          boxCollider.bounds.min.y < offsetsPadding.bottom ||
                          boxCollider.bounds.max.y > offsetsPadding.up;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DraggeableEditableObject>()) isColliderOverOther = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<DraggeableEditableObject>()) isColliderOverOther = false;
    }
}
