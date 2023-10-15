using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Knife : KitchenTools
{
    [SerializeField] Ingredient slicedBread;

    protected override void Awake()
    {
        base.Awake();

        onAction += SliceBread;
    }

    private void SliceBread()
    {
        if (ingredientToReact)
        {
            Instantiate(slicedBread, ingredientToReact.transform.position, Quaternion.identity);
            Destroy(ingredientToReact.gameObject);
        }
    }
}
