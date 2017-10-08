using UnityEngine;
using System.Collections;

public class CharacterControler : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	public float gravity;
	public float rotSpeed;

	private Vector3 moveDirection = Vector3.zero;


	void FixedUpdate ()
	{
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
		}
		transform.Rotate(0, Input.GetAxis("Mouse X") * rotSpeed, 0, Space.Self );
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

	}
}