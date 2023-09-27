using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class Ingredient : MonoBehaviour, IDraggeable
{
    public IngredientType ingredientType;
   
    Vector3 originalScale;

    protected bool IsDragging { get; set; }

    private void Awake()
    {
        originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void Start()
    {
        IsDragging = true;
        transform.DOScale(originalScale, 0.3f).SetEase(Ease.InOutQuad);
    }

    public void OnDrag(Vector3 pos)
    {
        if (!IsDragging) return;

        pos.z += 10;

        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    public virtual void OnDrop()
    {
        IsDragging = false;
    }

    public virtual void OnStartDrag(Vector3 offset)
    {
        IsDragging = true;
    }
}
