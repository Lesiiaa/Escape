using UnityEngine;

public class InteractionRaycast : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;
    public GameObject passwordPanel;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Naciœniêto E!");

            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
            {
                Debug.Log("Raycast trafi³ w: " + hit.collider.name);

                if (hit.collider.CompareTag("PasswordTrigger"))
                {
                    Debug.Log("Wykryto obiekt do interakcji!");
                    passwordPanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    Debug.Log("Obiekt nie ma tagu PasswordTrigger");
                }
            }
            else
            {
                Debug.Log("Raycast niczego nie trafi³");
            }
        }
    }

}
