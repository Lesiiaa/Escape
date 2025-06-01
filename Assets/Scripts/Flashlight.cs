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
        if (Input.GetKeyDown(KeyCode.F))    //use flashlight, activate
        {
            flashlight.enabled = !flashlight.enabled;
            flashlightItem.SetActive(flashlight.enabled);
        }
    }
}
