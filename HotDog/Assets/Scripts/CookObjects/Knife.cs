using UnityEngine;

public class Knife : KitchenTools
{
    [SerializeField] IngredientType ingredientToSpawn;

    protected override void Awake()
    {
        base.Awake();

        onAction += SliceBread;
    }

    private void SliceBread()
    {
        if (ingredientToReact)
        {
            IngredientsSpawnerManager.Instance.SpawnIngredient(ingredientToSpawn, ingredientToReact.transform.position, Quaternion.identity);
            Destroy(ingredientToReact.gameObject);
        }
    }
}
