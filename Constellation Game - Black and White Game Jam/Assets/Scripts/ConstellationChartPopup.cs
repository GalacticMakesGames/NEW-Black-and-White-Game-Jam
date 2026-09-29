using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationChartPopup : MonoBehaviour
{
    [SerializeField] GameObject constellationChart;
    [SerializeField] bool isActive = false;

    public TelescopeFollowMouse telescopeFollowMouse;
    public MouseMovementRestriction mouseMovementRestriction;

    // Start is called before the first frame update
    void Start()
    {
        constellationChart.SetActive(false);
        telescopeFollowMouse.enabled = true;
        mouseMovementRestriction.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && isActive == false)
        {
            constellationChart.SetActive(true);
            isActive = true;
            telescopeFollowMouse.enabled = false;
            mouseMovementRestriction.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isActive == true)
        {
            constellationChart.SetActive(false);
            isActive = false;
            telescopeFollowMouse.enabled = true;
            mouseMovementRestriction.enabled = true;
        }
    }
}
