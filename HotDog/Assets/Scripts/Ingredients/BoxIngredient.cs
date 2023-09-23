using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BoxIngredient : MonoBehaviour
{
    [SerializeField] Ingredient ingredient;

    public Ingredient SpawnIngredient()
    {
        return Instantiate(ingredient, transform.position, Quaternion.identity);
    }
}
