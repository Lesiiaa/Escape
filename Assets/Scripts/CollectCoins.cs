using UnityEngine;
using TMPro;

public class CollectibleCoin : MonoBehaviour
{
    public string coinID;
    public AudioClip collectSound;
    public TMP_Text coinTextUI;
    public static int coinCount = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(coinID, 1);
            PlayerPrefs.Save();

            AudioManager audioManager = Object.FindFirstObjectByType<AudioManager>();

            if (audioManager != null && collectSound != null)
                audioManager.PlaySFX(collectSound);

            coinCount++;    //add coins, change ui number
            UpdateCoinUI();

            Destroy(gameObject);
        }
    }

    void UpdateCoinUI()
    {
        if (coinTextUI != null)
            coinTextUI.text = coinCount.ToString();
    }
}
