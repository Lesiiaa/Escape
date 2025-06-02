using UnityEngine;
using TMPro;
using System.Collections;

public class PasswordChecker : MonoBehaviour
{
    public TMP_InputField inputField;         
    public GameObject panelToHide;            
    public string correctPassword = "MOON";   
    public GameObject doorToOpen;             
    public TextMeshProUGUI errorText;         
    public NotebookManager notebookManager;   
    public DoorScript.Door doorScript;       

    void Start()
    {
        //Hide and lock cursor at the start
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Hide error message on start
        if (errorText != null)
            errorText.gameObject.SetActive(false);
    }

    public void CheckPassword()
    {
        //Compare user input (converted to uppercase) with the correct password
        if (inputField.text.ToUpper() == correctPassword)
        {
            Debug.Log("Correct password");

            //Hide the password UI and lock the cursor
            panelToHide.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //Re-enable notebook (if it was disabled externally)
            if (notebookManager != null)
                notebookManager.enabled = true;

            //Trigger door open animation or logic
            if (doorScript != null)
                doorScript.OpenDoor();
        }
        else
        {
            Debug.Log("Wrong password");

            //Show error text and start coroutine to hide it after delay
            if (errorText != null)
            {
                errorText.text = "Invalid Password";
                errorText.gameObject.SetActive(true);
                StartCoroutine(ClearError());
            }
        }
    }

    public void ShowPanel()
    {
        //Show password input panel and unlock cursor
        panelToHide.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HidePanel()
    {
        //Hide password panel and lock cursor again
        panelToHide.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    IEnumerator ClearError()
    {
        //Wait 2 seconds and clear error message
        yield return new WaitForSeconds(2f);

        if (errorText != null)
        {
            errorText.gameObject.SetActive(false);
            errorText.text = "";
        }
    }
}
