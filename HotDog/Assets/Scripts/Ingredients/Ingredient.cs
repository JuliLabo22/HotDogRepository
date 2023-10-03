using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class Ingredient : MonoBehaviour, IDraggeable
{
    public IngredientType ingredientType;
   
    private Vector3 originalScale;
    private Vector3 lastPos = Vector3.zero;

    protected bool IsDragging { get; set; }

    private bool canBeDrop;

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
        if (!canBeDrop && lastPos == Vector3.zero) transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InOutQuad).OnComplete(() => Destroy(this.gameObject));
        else if (!canBeDrop && lastPos != Vector3.zero) transform.DOMove(lastPos, 0.2f).SetEase(Ease.InOutQuad);
        else lastPos = transform.position;

        IsDragging = false;
    }

    public virtual void OnStartDrag(Vector3 offset)
    {
        IsDragging = true;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SupportObj")) canBeDrop = true;
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SupportObj")) canBeDrop = false;
    }
}
