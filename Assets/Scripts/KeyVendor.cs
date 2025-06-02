using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyVendor : MonoBehaviour
{
    public int cost = 2;
    public Vector3 pressOffset = new Vector3(0, -0.1f, 0);
    public GameObject keyIconUI;
    public TMP_Text coinTextUI;
    public GameObject notEnoughCoinsUI;
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

        if (CollectibleCoin.coinCount >= cost)  //pay for the key, players echnages coins for a key
        {
            transform.position = initialPosition + pressOffset;
            CollectibleCoin.coinCount -= cost;
            keyIconUI.SetActive(true);
            alreadyPurchased = true;

            if (coinTextUI != null)
                coinTextUI.text = CollectibleCoin.coinCount.ToString();

            Debug.Log("Player got a key");
        }
        else
        {
            if (notEnoughCoinsUI != null)   //not enough coins message
            {
                StopAllCoroutines(); 
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
