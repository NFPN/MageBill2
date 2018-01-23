using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float timeToDestroy;
	void Start () 
	{
		Destroy (gameObject, timeToDestroy);
	}
}
