using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CookObject : StateChangerEditor
{
    [SerializeField] SpriteRenderer feedBackEffect;
    private BoxCollider2D boxCollider;

    [SerializeField] float speedCoock;
    public float SpeedCook => speedCoock;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        onEditorOn += () => boxCollider.enabled = false;
        onEditorOff += () => boxCollider.enabled = true;
    }

    public void OnDropSausage()
    {
        feedBackEffect.DOFade(0.8f, 0.5f);
    }

    public void OnTakeSausage()
    {
        feedBackEffect.DOFade(0, 0.3f);
    }
}
