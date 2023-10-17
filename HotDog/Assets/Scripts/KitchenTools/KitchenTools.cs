using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class KitchenTools : DraggeableElement
{
    protected Action onAction;

    protected Ingredient ingredientToReact;

    [SerializeField] IngredientType ingredientTypeToReact;

    protected override void Awake()
    {
        canBeDrop = true;
    }

    protected override void Start()
    {
        lastPos = transform.position;
    }

    public override void OnDrop()
    {
        if (!canBeDrop) transform.DOMove(lastPos, 0.2f).SetEase(Ease.InOutQuad);
        else lastPos = transform.position;

        if(ingredientToReact && ingredientToReact.IngredientType.Equals(ingredientTypeToReact)) onAction?.Invoke();

        IsDragging = false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SupportObj")) canBeDrop = false;

        if(collision.GetComponent<Ingredient>()) ingredientToReact = collision.GetComponent<Ingredient>();
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SupportObj")) canBeDrop = true;

        if(collision.GetComponent<Ingredient>()) ingredientToReact = null;
    }
}
