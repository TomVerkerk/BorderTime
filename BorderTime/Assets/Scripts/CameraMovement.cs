using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	public float cameraSpeed;
	public float maxLeft;
	public float maxRight;
	private Vector3 cameraVel;
	
	void Update()
	{	
		cameraVel.x = 0;
		if(Input.GetKey(KeyCode.A) && transform.position.x < maxLeft)
		{
			cameraVel.x += cameraSpeed;
		}
		else if(Input.GetKey(KeyCode.D) && transform.position.x > maxRight)
		{
			cameraVel.x -= cameraSpeed;
		}
		transform.localPosition += cameraVel;
	}
}