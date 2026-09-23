using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightDaySkyTransition : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color[] colors;
    private int currentColorIndex = 0;
    private int targetColorIndex = 1;
    private float targetPoint;
    public float time;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Transition();
    }

    void Transition()
    {
        targetPoint += Time.deltaTime / time;
        spriteRenderer.color = Color.Lerp(colors[currentColorIndex], colors[targetColorIndex], targetPoint);

        if (targetPoint >= 1f)
        {
            targetPoint = 0f;
            currentColorIndex = targetColorIndex;
            targetColorIndex++;
            if (targetColorIndex == colors.Length)
                targetColorIndex = 0;
        }
    }
}
