using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camAnimation : MonoBehaviour
{
    public CharacterController player;
    public Animation anim;
    private bool isMoving;
    private bool left;
    private bool right;

    void CameraAnimations()
    {
        if (isMoving == true)
        {
            if (!anim.isPlaying)
            {
                anim.Play("walkLeft");
                left = false;
                right = true;
            }

            if (right == true)
            {
                if (!anim.isPlaying)
                {
                    anim.Play("walkRight");
                    right = false;
                    left = true;
                }
            }
        }
    }

    void Start()
    {
        left = true;
        right = false;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        if(inputX != 0 || inputZ != 0)
        {
            isMoving = true;
        }

        else if(inputX == 0 && inputZ == 0)
        {
            isMoving = false;
        }
        CameraAnimations();
    }
}
