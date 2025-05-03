using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject footstep;
    public bool blockInput = false;


    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        void Update()
        {
            if (blockInput) return;

            if (Input.GetKey("w"))
            {
                footsteps();
            }

            if (Input.GetKeyDown("s"))
            {
                footsteps();
            }

            if (Input.GetKeyDown("a"))
            {
                footsteps();
            }

            if (Input.GetKeyDown("d"))
            {
                footsteps();
            }

            if (Input.GetKeyUp("w"))
            {
                StopFootsteps();
            }

            if (Input.GetKeyUp("s"))
            {
                StopFootsteps();
            }

            if (Input.GetKeyUp("a"))
            {
                StopFootsteps();
            }

            if (Input.GetKeyUp("d"))
            {
                StopFootsteps();
            }

        }

        void footsteps()
        {
            footstep.SetActive(true);
        }

        void StopFootsteps()
        {
            footstep.SetActive(false);
        }
    }
}