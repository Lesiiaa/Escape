using TMPro;
using UnityEngine;

public class CollectibleCoin : MonoBehaviour
{
    public AudioClip collectSound;
    public TMP_Text coinTextUI; // ← Przypisz w Inspectorze
    public static int coinCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (audioManager != null && collectSound != null)
                audioManager.PlaySFX(collectSound);

            coinCount++;
            UpdateCoinUI();
            Destroy(gameObject);
        }
    }

    void UpdateCoinUI()
    {
        if (coinTextUI != null)
        {
            coinTextUI.text = coinCount.ToString();
        }
    }
}
