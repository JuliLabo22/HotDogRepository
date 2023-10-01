using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EditorTableManager : MonoBehaviour
{
    public static EditorTableManager Instance { get; private set; }

    [Serializable]
    public class OffsetLimit
    {
        public float up;
        public float bottom;
        public float left;
        public float right;
    }

    public OffsetLimit offset;

    [SerializeField] private bool _isInEditMode = false;
    public bool IsInEditMode => _isInEditMode;

    IDraggeable currentDragObject;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    public void EditMode(bool value) => _isInEditMode = value;

    private void Update()
    {
        if (!_isInEditMode) return;

        if (Input.GetMouseButtonDown(0))
        {
            OnDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnDrop();
        }
    }

    private void FixedUpdate()
    {
        FollowCursor();
    }

    void OnDrag()
    {
        if (currentDragObject != null) return;

        var rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition), 100f);
        if (!rayHit.collider) return;

        var offset = rayHit.collider.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        IDraggeable obj = rayHit.transform.GetComponent<IDraggeable>();

        if (obj != null) obj.OnStartDrag(offset);

        currentDragObject = obj;
    }

    void OnDrop()
    {
        if (currentDragObject != null)
        {
            currentDragObject.OnDrop();
            currentDragObject = null;
        }
    }

    void FollowCursor()
    {
        if (currentDragObject == null) return;

        currentDragObject.OnDrag(Input.mousePosition);
    }
}
