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
            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
            {
                Debug.Log("Raycast hit: " + hit.collider.name);

                if (hit.collider.CompareTag("PasswordTrigger"))
                {
                    Debug.Log("There is an object");
                    passwordPanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    Debug.Log("No tag PasswordTrigger");
                }
            }
            else
            {
                Debug.Log("Raycast didnt hit");
            }
        }
    }

}
