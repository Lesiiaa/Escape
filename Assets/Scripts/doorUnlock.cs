using UnityEngine;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator;
    public string openTrigger = "Open";
    public GameObject promptUI;
    public GameObject keyIconUI;
    public GameObject needKeyMessageUI;
    public float messageDuration = 2f;
    private bool playerInZone = false;

    private const string doorOpenKey = "DoorOpened";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptUI.SetActive(true);
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptUI.SetActive(false);
            playerInZone = false;
        }
    }

    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            if (keyIconUI != null && keyIconUI.activeSelf)  //activate the door if player has a key
            {
                doorAnimator.SetTrigger(openTrigger);
                PlayerPrefs.SetInt(doorOpenKey, 1); 
                PlayerPrefs.Save();

                promptUI.SetActive(false);
                keyIconUI.SetActive(false);
                Destroy(this);
            }
            else
            {
                ShowNeedKeyMessage();
            }
        }
    }

    void ShowNeedKeyMessage()   //message to show if player doesn't have a key
    {
        if (needKeyMessageUI != null)
        {
            needKeyMessageUI.SetActive(true);
            CancelInvoke(nameof(HideNeedKeyMessage));
            Invoke(nameof(HideNeedKeyMessage), messageDuration);
        }
    }

    void HideNeedKeyMessage()
    {
        if (needKeyMessageUI != null)
            needKeyMessageUI.SetActive(false);
    }
}
