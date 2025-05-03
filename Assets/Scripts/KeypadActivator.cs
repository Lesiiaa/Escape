using UnityEngine;

public class KeypadActivator : MonoBehaviour
{
    public GameObject keypadUI;         // UI z keypadem (Canvas)
    public GameObject player;           // Obiekt gracza (FPSInput)
    public GameObject playerCamera;     // Kamera gracza (MouseLook)
    private bool isPlayerNearby = false;
    private bool isKeypadOpen = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (!isKeypadOpen)
            {
                OpenKeypad();
            }
            else
            {
                CloseKeypad();
            }
        }
    }

    void OpenKeypad()
    {
        keypadUI.SetActive(true);
        isKeypadOpen = true;

        // Zatrzymaj sterowanie i myszkê
        player.GetComponent<FPSInput>().enabled = false;
        player.GetComponent<MouseLook>().enabled = false;
        playerCamera.GetComponent<MouseLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CloseKeypad()
    {
        keypadUI.SetActive(false);
        isKeypadOpen = false;

        // Przywróæ sterowanie
        player.GetComponent<FPSInput>().enabled = true;
        player.GetComponent<MouseLook>().enabled = true;
        playerCamera.GetComponent<MouseLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
