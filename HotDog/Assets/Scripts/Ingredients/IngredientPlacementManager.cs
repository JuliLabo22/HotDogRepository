using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientPlacementManager : MonoBehaviour
{
    public static IngredientPlacementManager Instance { get; private set; }

    Ingredient currentIngredient;

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

        if (rayHit.collider.GetComponent<BoxIngredient>()) currentIngredient = rayHit.collider.GetComponent<BoxIngredient>().SpawnIngredient();
        if (rayHit.collider.GetComponent<Ingredient>())
        {
            currentIngredient = rayHit.collider.GetComponent<Ingredient>();
            currentIngredient.OnStartDrag(Vector3.zero);
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
}
