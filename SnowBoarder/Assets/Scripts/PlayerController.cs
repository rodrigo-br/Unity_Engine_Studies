using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 2f;
    [SerializeField] float normalSpeed = 10f;
    [SerializeField] float boostSpeed = 20f;
    SurfaceEffector2D surfaceEffector2D;
    Rigidbody2D rb2d;
    bool canMove = true;
    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
       surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            BoostPlayer();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void BoostPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
