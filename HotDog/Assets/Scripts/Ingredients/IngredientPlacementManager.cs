using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientPlacementManager : MonoBehaviour
{
    public static IngredientPlacementManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }
}
