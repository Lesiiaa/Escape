using UnityEngine;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator;
    public string openTrigger = "Open";
    public GameObject promptUI;            // np. "Press E to open"
    public GameObject keyIconUI;           // ikona klucza – aktywna = gracz ma klucz
    public GameObject needKeyMessageUI;    // np. "You need a key!" UI
    public float messageDuration = 2f;

    private bool playerInZone = false;

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
            if (keyIconUI != null && keyIconUI.activeSelf)
            {
                doorAnimator.SetTrigger(openTrigger);
                promptUI.SetActive(false);
                keyIconUI.SetActive(false); // "zużyj" klucz
                Destroy(this); // opcjonalnie: drzwi już otwarte
            }
            else
            {
                ShowNeedKeyMessage();
            }
        }
    }

    void ShowNeedKeyMessage()
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
