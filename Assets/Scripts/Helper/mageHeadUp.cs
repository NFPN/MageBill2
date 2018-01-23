using UnityEngine;
using UnityEngine.UI;

public class mageHeadUp : MonoBehaviour 
{
	public Image mageHead;	
    public float timeToReachGoal;
    public float calcMove;
    public SpawnControllerBoss boss;

	void Start () 
	{
        timeToReachGoal = boss.timeToSpawnBoss;
		mageHead = GameObject.Find ("Mage_head").GetComponent<Image> ();
        calcMove = mageHead.rectTransform.anchoredPosition.y / timeToReachGoal;
	}	

	void Update () 
	{
        mageHead.rectTransform.anchoredPosition -= (new Vector2(0.0f, calcMove)) * Time.deltaTime;			
		if (SpawnControllerX.isBossActive == true)
			mageHead.fillAmount = 0;
	}
}
