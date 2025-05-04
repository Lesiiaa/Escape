using UnityEngine;
using System.Collections;

public class JumpUnlocker : MonoBehaviour
{
    public GameObject jumpMessageUI;
    public float messageDuration = 3f;

    private void OnTriggerEnter(Collider other)
    {
        FPSInput player = other.GetComponent<FPSInput>();
        if (player != null)
        {
            player.CanJump = true;

            if (jumpMessageUI != null)
            {
                jumpMessageUI.SetActive(true);
                StartCoroutine(HideMessageAfterDelay());
            }

            // Ukryj tylko obiekt wizualny skoku (np. Mesh Renderer), ale nie niszcz jeszcze skryptu
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }

    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDuration);
        if (jumpMessageUI != null)
            jumpMessageUI.SetActive(false);

        Destroy(gameObject); // teraz można bezpiecznie zniszczyć obiekt
    }
}
