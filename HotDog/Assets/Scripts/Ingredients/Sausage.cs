using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sausage : Ingredient
{
    private bool isOverOven;

    [Space(5)]
    [SerializeField] private SpriteRenderer spCoocked;
    [SerializeField] private SpriteRenderer spBurned;

    private Color alphaColor = new Color(0, 0, 0, 1);

    float speedCooking;

    CookObject cookObj;

    public override void OnDrop()
    {
        base.OnDrop();

        if (isOverOven)
        {
            StopAllCoroutines();
            StartCoroutine(StartCookingCO());

            if (cookObj) cookObj.OnDropSausage();
        }
    }

    public override void OnStartDrag(Vector3 offset)
    {
        base.OnStartDrag(offset);

        ResetSprites();
        if(cookObj) cookObj.OnTakeSausage();
    }

    private IEnumerator StartCookingCO()
    {
        while (isOverOven && !IsDragging)
        {
            switch (ingredientType)
            {
                case IngredientType.RawSausage:
                    CookingAlpha(spCoocked, IngredientType.CoockedSausage);
                    break;
                case IngredientType.CoockedSausage:

                    if(spBurned.color.a == 0) yield return new WaitForSeconds(0.5f);

                    CookingAlpha(spBurned, IngredientType.BurnedSausage);
                    break;
                case IngredientType.BurnedSausage:
                    isOverOven = false;
                    break;
            }

            yield return null;
        }

        yield break;
    }

    private void CookingAlpha(SpriteRenderer sp, IngredientType it)
    {
        sp.color += alphaColor * Time.deltaTime * speedCooking;

        if (sp.color.a >= 1) ingredientType = it;
    }

    void ResetSprites()
    {
        switch (ingredientType)
        {
            case IngredientType.RawSausage:
                spCoocked.color -= new Color(0, 0, 0, spCoocked.color.a);
                break;
            case IngredientType.CoockedSausage:
                spBurned.color -= new Color(0, 0, 0, spBurned.color.a);
                break;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.GetComponent<CookObject>())
        {
            cookObj = collision.GetComponent<CookObject>();

            isOverOven = true;
            speedCooking = cookObj.SpeedCook;
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);

        if (collision.GetComponent<CookObject>())
        {
            isOverOven = false;
        }
    }
}
