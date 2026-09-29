using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementRestriction : MonoBehaviour
{
    Vector3 pos;

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        pos.x += Input.GetAxis("Horizontal");
        pos.x = Mathf.Clamp(pos.x, -7f, 3.2f);

        pos.y += Input.GetAxis("Vertical");
        pos.y = Mathf.Clamp(pos.y, -3.1f, 3.1f);

        transform.position = pos;
    }
}
