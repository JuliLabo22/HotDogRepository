using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsSpawnerManager : MonoBehaviour
{
    public static IngredientsSpawnerManager Instance { get; private set; }

    [SerializeField] private List<Ingredient> ingredients = new List<Ingredient>();
    private Dictionary<IngredientType, Ingredient> ingredientsDic = new Dictionary<IngredientType, Ingredient>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        foreach (Ingredient ingredient in ingredients)
        {
            if (!ingredientsDic.ContainsKey(ingredient.IngredientType))
                ingredientsDic.Add(ingredient.IngredientType, ingredient);
        }
    }

    public Ingredient SpawnIngredientRet(IngredientType type, Vector3 pos, Quaternion quat)
    {
        Ingredient ing = null;
        if(ingredientsDic.ContainsKey(type)) ing = Instantiate(ingredientsDic[type], pos, quat);
        return ing;
    }

    public void SpawnIngredient(IngredientType type, Vector3 pos, Quaternion quat)
    {
        if(ingredientsDic.ContainsKey(type)) Instantiate(ingredientsDic[type], pos, quat);
    }
}
