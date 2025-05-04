using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyVendor : MonoBehaviour
{
    public int cost = 2;
    public Vector3 pressOffset = new Vector3(0, -0.1f, 0);
    public GameObject keyIconUI;
    public TMP_Text coinTextUI;
    public GameObject notEnoughCoinsUI; // ← UI tekstu "za mało monet"
    public float messageDuration = 2f;

    private bool alreadyPurchased = false;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        keyIconUI.SetActive(false);
        if (notEnoughCoinsUI != null)
            notEnoughCoinsUI.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (alreadyPurchased) return;

        if (CollectibleCoin.coinCount >= cost)
        {
            transform.position = initialPosition + pressOffset;
            CollectibleCoin.coinCount -= cost;
            keyIconUI.SetActive(true);
            alreadyPurchased = true;

            if (coinTextUI != null)
                coinTextUI.text = CollectibleCoin.coinCount.ToString();

            Debug.Log("Gracz otrzymał klucz!");
        }
        else
        {
            if (notEnoughCoinsUI != null)
            {
                StopAllCoroutines(); // zatrzymaj poprzednie wywołania
                StartCoroutine(ShowMessageTemporarily());
            }
        }
    }

    private System.Collections.IEnumerator ShowMessageTemporarily()
    {
        notEnoughCoinsUI.SetActive(true);
        yield return new WaitForSeconds(messageDuration);
        notEnoughCoinsUI.SetActive(false);
    }
}
