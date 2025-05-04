using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepAudio;
    public NotebookManager notebookManager;

    private CharacterController charController;

    void Start()
    {
        charController = GetComponentInParent<CharacterController>();

    }

    void Update()
    {
        if (notebookManager != null && notebookManager.IsOpen())
        {
            if (footstepAudio.isPlaying)
                footstepAudio.Stop();
            return;
        }

        if (!charController.isGrounded)
        {
            if (footstepAudio.isPlaying)
                footstepAudio.Stop();
            return;
        }

        if ((Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")))
        {
            if (!footstepAudio.isPlaying)
                footstepAudio.Play();
        }
        else
        {
            if (footstepAudio.isPlaying)
                footstepAudio.Stop();
        }
    }
}
