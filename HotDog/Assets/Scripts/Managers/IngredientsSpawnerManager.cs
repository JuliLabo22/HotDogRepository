using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsSpawnerManager : MonoBehaviour
{
    public static IngredientsSpawnerManager Instance { get; private set;}

    private void Awake() {
        if(Instance == null) Instance = this;
        else Destroy(this);
    }
}