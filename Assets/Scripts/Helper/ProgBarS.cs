using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgBarS : MonoBehaviour 
{
	private Image pBar;
	void Start () 
	{
		pBar = GameObject.Find ("progress_bar").GetComponent<Image> ();
	}

	void Update () 
	{
		if (SpawnControllerX.isBossActive == true)
			pBar.fillAmount = 0;
	}
}
