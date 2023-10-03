using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BoxIngredient : StateChangerEditor
{
    [SerializeField] Ingredient ingredient;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        onEditorOn += () => boxCollider.enabled = false;
        onEditorOff += () => boxCollider.enabled = true;
    }

    public Ingredient SpawnIngredient()
    {
        return Instantiate(ingredient, transform.position, Quaternion.identity);
    }
}
