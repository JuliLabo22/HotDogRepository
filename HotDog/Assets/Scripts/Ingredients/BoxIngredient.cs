using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BoxIngredient : StateChangerEditor
{
    [SerializeField] IngredientType ingredientToSpawn;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        onEditorOn += () => boxCollider.enabled = false;
        onEditorOff += () => boxCollider.enabled = true;
    }

    public Ingredient SpawnIngredient()
    {
        return IngredientsSpawnerManager.Instance.SpawnIngredientRet(ingredientToSpawn, transform.position, Quaternion.identity);
    }
}
