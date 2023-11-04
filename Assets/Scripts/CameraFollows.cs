using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollows : MonoBehaviour
{
	public Transform player;
	public float smoothing = 5f;
	public Vector3 offset;

	void FixedUpdate () {
		Vector3 targetCamPos = player.position + offset;
		this.transform.position = Vector3.Lerp (this.transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}

