using UnityEngine;
using System.Collections;

[AddComponentMenu("Control Script/Mouse Look")]
public class MouseLook : MonoBehaviour {
	public enum RotationAxes {
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;
	
	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float _rotationX = 0;
	
	void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        
		// Make the rigid body not change rotation
        Rigidbody body = GetComponent<Rigidbody>();
		if (body != null)
			body.freezeRotation = true;
	}

    void Update() {
		if (axes == RotationAxes.MouseX) {
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
		}
		else if (axes == RotationAxes.MouseY) {
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
			
			transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
		}
		else {
			float rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityHor;

			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}
	}
}

