using UnityEngine;
using System.Collections;

public class JumpUnlocker : MonoBehaviour
{
    public GameObject jumpMessageUI;
    public float messageDuration = 3f;
    private const string jumpUnlockKey = "JumpUnlocked";


    private void OnTriggerEnter(Collider other) //enable jump after collecting an item
    {
        FPSInput player = other.GetComponent<FPSInput>();   
        if (player != null)
        {
            player.CanJump = true;

            PlayerPrefs.SetInt(jumpUnlockKey, 1);
            PlayerPrefs.Save();

            if (jumpMessageUI != null)
            {
                jumpMessageUI.SetActive(true);
                StartCoroutine(HideMessageAfterDelay());
            }

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }

    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDuration);
        if (jumpMessageUI != null)
            jumpMessageUI.SetActive(false);

        Destroy(gameObject);
    }
}
