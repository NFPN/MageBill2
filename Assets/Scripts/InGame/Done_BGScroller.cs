using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
	//line renderer lde1
	public float scrollSpeed;
	public float tileSizeZ;

	private Vector3 startPosition;

	void Start ()
	{
		startPosition = transform.position;
	}

	void Update ()
	{
		//if (!PausedTime.Instance.Paused) {
			float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
			transform.position = startPosition + Vector3.up * newPosition;
		//}
	}
}