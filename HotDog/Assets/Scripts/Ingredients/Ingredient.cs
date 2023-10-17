using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : DraggeableElement
{
    [SerializeField] IngredientType ingredientType;

    public IngredientType IngredientType => ingredientType;

    public void SetIngredientType(IngredientType type) => ingredientType = type;
}
