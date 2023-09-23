using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class Ingredient : MonoBehaviour, IDraggeable
{
    Vector3 originalScale;

    bool isDragging;

    private void Awake()
    {
        originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void Start()
    {
        isDragging = true;
        transform.DOScale(originalScale, 0.3f).SetEase(Ease.InOutQuad);
    }

    public void OnDrag(Vector3 pos)
    {
        if (!isDragging) return;

        pos.z += 10;

        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    public void OnDrop()
    {
        isDragging = false;
    }

    public void OnStartDrag(Vector3 offset)
    {
        isDragging = true;
    }
}
