using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EyeAnimation : MonoBehaviour
{
    [SerializeField] 
    [Range(0,10)]
    int timeRepeating = 5;

    void Start()
    {
        InvokeRepeating("StartAnim", timeRepeating, timeRepeating);
    }

    void StartAnim()
    {
        var waitTime = Random.Range(timeRepeating, timeRepeating + 4);

        transform.DOScaleY(0.25f, 0.2f).SetDelay(waitTime).OnComplete(() => transform.DOScaleY(1, 0.2f));
    }
}
