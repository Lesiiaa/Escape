using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float Speed = 6.0f;
    public float JumpForce = 5.0f;
    public float Gravity = -9.8f;
    public bool CanJump = false;
    private AudioManager audioManager;


    private CharacterController _charController;
    private float _verticalSpeed = 0f;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
        audioManager = FindObjectOfType<AudioManager>();

    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * Speed;
        float deltaZ = Input.GetAxis("Vertical") * Speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        if (CanJump && _charController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _verticalSpeed = JumpForce;
            if (audioManager != null)
                {
                    audioManager.PlaySFX(audioManager.jump);
                }
        }

        _verticalSpeed += Gravity * Time.deltaTime;
        movement.y = _verticalSpeed;

        movement = transform.TransformDirection(movement);
        _charController.Move(movement * Time.deltaTime);

       
        if (_charController.isGrounded && _verticalSpeed < 0)
        {
            _verticalSpeed = 0f;
        }
    }
}
