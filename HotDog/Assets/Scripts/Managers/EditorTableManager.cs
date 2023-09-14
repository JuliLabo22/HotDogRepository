using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorTableManager : MonoBehaviour
{
    public static EditorTableManager Instance { get; private set; }

    public bool _isInEditMode = false;
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
        if (_isInEditMode) return;

        if (Input.GetMouseButtonDown(0))
        {
            OnDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnDrop();
        }

        FollowCursor();
    }

    void OnDrag()
    {
        var rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition), 100f);
        if (!rayHit.collider) return;

        IDraggeable obj = rayHit.transform.GetComponent<IDraggeable>();

        if (obj != null) obj.OnDrag();
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

        currentDragObject.OnFollow(Input.mousePosition);
    }
}
