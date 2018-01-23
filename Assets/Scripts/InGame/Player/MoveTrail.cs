using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour 
{
	public int moveSpeed = 230;

	void Update () 
	{
		transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
		if (transform.position.y > 6 ||
			transform.position.y < -6 ||
			transform.position.x < -6 ||
		    transform.position.x > 6) 
		{
			gameObject.SetActive(false);
		}
	}
}
