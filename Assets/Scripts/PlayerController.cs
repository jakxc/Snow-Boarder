using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private SurfaceEffector2D surfaceEffector;

    [SerializeField]
    private float baseSpeed = 30f;

    [SerializeField]
    private float torqueAmount = 1f;

    [SerializeField]
    private float boostAmount = 15f;

    private bool playerEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (playerEnabled) {
            RotatePlayer();
            BoostPlayer();
        }
    }

    public void DisablePlayer() {
        playerEnabled = false;
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerBody.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerBody.AddTorque(-torqueAmount);
        }
    }

    private void BoostPlayer() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            surfaceEffector.speed = baseSpeed + boostAmount;
        } else {
            surfaceEffector.speed = baseSpeed;
        }
    }
}
