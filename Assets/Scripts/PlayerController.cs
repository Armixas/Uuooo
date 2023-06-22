using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string fireButton = "Fire1";
    [SerializeField]
    private string xAxisName = "Horizontal";
    [SerializeField]
    private string yAxisName = "Vertical";

    private ProjectileController projectileController;
    private TankController tankController;

    void Awake()
    {
        projectileController = GetComponent<ProjectileController>();
        tankController = GetComponent<TankController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(fireButton))
        {
            projectileController.Fire();
        }
        tankController.Move(new Vector2
        {
            x = Input.GetAxis(xAxisName),
            y = Input.GetAxis(yAxisName),
        });
    }
}
