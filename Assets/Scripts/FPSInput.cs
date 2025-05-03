using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float Speed = 6.0f;
	public float Gravity = -9.8f;
	public GameObject Object1;
	private CharacterController _charController;
	private Transform _trans;
     void Start() {
		_charController = GetComponent<CharacterController>();
	}

    
	void Update() {	
		float deltaX = Input.GetAxis("Horizontal") * Speed;
		float deltaZ = Input.GetAxis("Vertical") * Speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, Speed);
        Debug.Log("Input Horizontal " + deltaX);
        movement.y = Gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);
	}
}