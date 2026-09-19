using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeFollowMouse : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField]
    private float maxSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        FollowMousePosition();
    }

    private void FollowMousePosition()
    {
        transform.position = GetWorldPositionFromMouse();
    }

    private Vector2 GetWorldPositionFromMouse() 
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition); // input.mouse position needs to be converted to world coordinates
    }
}
