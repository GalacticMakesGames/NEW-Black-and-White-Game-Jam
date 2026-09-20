using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarClickDetection : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
    Transform clickObject;

    [SerializeField] float scaleMultiplier = 1.8f;

    [SerializeField] bool isStarClicked = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;

        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);

        if (Input.GetMouseButtonDown(0) && isStarClicked == false)
        {
            raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            clickObject = raycastHit2D ? raycastHit2D.collider.transform : null;

            if (clickObject == transform)
            {
                isStarClicked = true;
                transform.localScale *= scaleMultiplier;
            }
        }

        if (Input.GetMouseButtonDown(1) && isStarClicked == true)
        {
            raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            clickObject = raycastHit2D ? raycastHit2D.collider.transform : null;

            if (clickObject == transform)
            {
                isStarClicked = false;
                transform.localScale /= scaleMultiplier;
            }
        }
    }
}
