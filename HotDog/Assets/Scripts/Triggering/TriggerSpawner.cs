using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : TriggeringBase
{
    [SerializeField] private IngredientType ingredientToSpawn;

    public void Configure(IngredientType react, IngredientType spawner)
    {
        ingredientToReact = react;
        ingredientToSpawn = spawner;
    }

    public override void Trigger()
    {
        IngredientsSpawnerManager.Instance.SpawnIngredient(ingredientToSpawn, transform.position, Quaternion.identity);
    }
}
