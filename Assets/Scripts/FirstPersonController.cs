using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	public float jumpSpeed = 20.0f;
	float verticalRotation =0;
	public float upDownRange = 60.0f;
	float verticalVelocity =0;
	CharacterController cc;
	// Use this for initialization
	void Start ()
	{

		Cursor.lockState = CursorLockMode.Locked;
		cc = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update () {

		//rotation
		float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate(0, rotLeftRight, 0);

		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

		//movement
		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		if(cc.isGrounded && Input.GetButtonDown("Jump"))
		{
			verticalVelocity = jumpSpeed;
		}
		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);

		speed = transform.rotation * speed;
		cc.Move(speed *Time.deltaTime);


	}
}