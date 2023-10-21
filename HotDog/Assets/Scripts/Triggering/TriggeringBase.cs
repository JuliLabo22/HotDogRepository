using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class TriggeringBase : MonoBehaviour
{
    [SerializeField] protected IngredientType ingredientToReact;

    protected Action onTrigger;
    bool isTriggering;

    private void Awake()
    {
        onTrigger += Trigger;
    }

    private void OnDestroy()
    {
        onTrigger -= Trigger;
    }

    public abstract void Trigger();

    public virtual void OnTrigger()
    {
        if (isTriggering) onTrigger?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Ingredient>()) if (other.GetComponent<Ingredient>().IngredientType.Equals(ingredientToReact)) isTriggering = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Ingredient>()) if (other.GetComponent<Ingredient>().IngredientType.Equals(ingredientToReact)) isTriggering = false;
    }
}
