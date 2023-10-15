using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementManager : MonoBehaviour
{
    public static ObjectPlacementManager Instance { get; private set; }

    IDraggeable currentIngredient;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        currentIngredient = null;
    }

    private void Update()
    {
        if (EditorTableManager.Instance.IsInEditMode) return;

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
        var rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition), 100f);
        if (!rayHit.collider) return;

        currentIngredient = CheckElement(rayHit);

        if (currentIngredient != null)
        {
            Vector3 offset = rayHit.collider.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentIngredient.OnStartDrag(offset);
        }
    }

    void OnDrop()
    {
        if (currentIngredient == null) return;

        currentIngredient.OnDrop();
        currentIngredient = null;
    }

    void FollowCursor()
    {
        if (currentIngredient == null) return;

        currentIngredient.OnDrag(Input.mousePosition);
    }

    IDraggeable CheckElement(RaycastHit2D ray)
    {
        if (ray.collider.GetComponent<BoxIngredient>())
            return ray.collider.GetComponent<BoxIngredient>().SpawnIngredient();

        if (ray.collider.GetComponent<IDraggeable>() != null)
            return ray.collider.GetComponent<IDraggeable>();

        return null;
    }
}
