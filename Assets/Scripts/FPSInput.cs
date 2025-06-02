using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float Speed = 6.0f;
    public float JumpForce = 5.0f;
    public float Gravity = -9.8f;
    public bool CanJump = false;
    public GameObject passwordPanel;


    private AudioManager audioManager;
    private CharacterController _charController;
    private Animator animator;

    private float _verticalSpeed = 0f;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
        audioManager = Object.FindFirstObjectByType<AudioManager>();

        //find animator (child) in capsule, because we have player model as a child of capsule
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (passwordPanel != null && passwordPanel.activeSelf)
            return;

        float deltaX = Input.GetAxis("Horizontal") * Speed;
        float deltaZ = Input.GetAxis("Vertical") * Speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        //set animataion (walk)
        float currentSpeed = new Vector2(deltaX, deltaZ).magnitude;
        if (animator != null)
        {
            animator.SetFloat("Speed", currentSpeed);
        }

        //jump animation
        if (CanJump && _charController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _verticalSpeed = JumpForce;
            animator?.SetBool("IsJumping", true);
            audioManager?.PlaySFX(audioManager.jump);
        }

        _verticalSpeed += Gravity * Time.deltaTime;
        movement.y = _verticalSpeed;

        movement = transform.TransformDirection(movement);
        _charController.Move(movement * Time.deltaTime);

        //land, jump has ended info
        if (_charController.isGrounded && _verticalSpeed < 0)
        {
            _verticalSpeed = 0f;
            animator?.SetBool("IsJumping", false);
        }
    }
}
