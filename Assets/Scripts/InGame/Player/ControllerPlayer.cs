using UnityEngine;

[System.Serializable]
public class Player_Boundary 
{
	public float xMin, xMax, yMin, yMax;
}

public class ControllerPlayer : MonoBehaviour
{
	public float speed;
	public int rotationOffset;
	public Player_Boundary boundary;	
	
	void Start()
	{
		speed = 4;
	}
	
	void Update ()
	{
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();
		
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
		
		
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A) && transform.position.x != boundary.xMin) {
			transform.position += new Vector3 (-speed * Time.deltaTime, 0.0f, 0.0f);
		}
		
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D) && transform.position.x != boundary.xMax) {
			transform.position += new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f);
		}
		
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W) && transform.position.y != boundary.yMax) {
			transform.position += new Vector3 (0.0f, speed * Time.deltaTime, 0.0f);
		}
		
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S) && transform.position.y != boundary.yMin) {
			transform.position += new Vector3 (0.0f, -speed * Time.deltaTime, 0.0f);
		}
		
		GetComponent<Rigidbody2D>().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
				Mathf.Clamp (GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax),
				0.0f
			);
	}
}
