using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausedTime : MonoBehaviour 
{
	static public float fill;
	public Image tp;
	public float regenFill;	
	static public float currentTime;
	public float timeCurrent;
	static public bool changeOrNot;
	public int tme;

	void Start()
	{
		tme = 2;
		changeOrNot = false;
		Time.timeScale = 1;
	}

	void Update()
	{
		fill = tp.fillAmount;
		tp.fillAmount = fill;
		currentTime += Time.deltaTime;
		timeCurrent = currentTime;
        if (changeOrNot == false)
        {
            if (Input.GetMouseButtonDown(1) && tp.fillAmount != 0)
            {
                Time.timeScale = 0.3f;
            }
            if (Time.timeScale == 0.3f && currentTime >= regenFill)
            {
                tp.fillAmount -= 2 * Time.fixedDeltaTime;
                currentTime = 0;
                ManagerS.pontuacao += Random.Range(500, 25000);
            }
            if (Input.GetMouseButtonUp(1) || tp.fillAmount == 0)
                Time.timeScale = 1;
        }

		if (changeOrNot == true) 
		{
			if(currentTime >= tme)
			{
                SceneManager.LoadScene(2);				
			}            
		}
	}

	static public void PlayerDeath()
	{
		currentTime = 0;
		Time.timeScale = 0.25f;
		GameObject.Find("_Manager").GetComponent<Fading>().BeginFade(1);
		changeOrNot = true;	
	}
}
