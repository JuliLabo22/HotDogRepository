using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class CookObject : MonoBehaviour
{
    [SerializeField] SpriteRenderer feedBackEffect;

    [SerializeField] float speedCoock;
    public float SpeedCook => speedCoock;

    public void OnDropSausage()
    {
        feedBackEffect.DOFade(1, 0.5f);
    }

    public void OnTakeSausage()
    {
        feedBackEffect.DOFade(0, 0.3f);
    }
}
