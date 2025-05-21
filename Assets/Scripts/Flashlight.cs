using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlight;
    public GameObject flashlightItem;

    void Start()
    {
        flashlight.enabled = false;
        flashlightItem.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
            flashlightItem.SetActive(flashlight.enabled);
        }
    }
}
