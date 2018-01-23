using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour 
{
    public int lvNum;

    void Start()
    {
        lvNum = 1;
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
            StartCoroutine("SceneChangeInit");
    }

    public void SceneToChangeTo(int SceneToChangeTo)
    {
        lvNum = SceneToChangeTo;
        StartCoroutine("SceneChange");
    }

    public void ExitingGame()
    {
        StartCoroutine(ExitGame());
    }

    IEnumerator SceneChange()
    {
        float fadeTime = GameObject.Find("_Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);        
        SceneManager.LoadScene(lvNum);        
    }

    IEnumerator SceneChangeInit()
    {       
        yield return new WaitForSeconds(2);
        float fadeTime = GameObject.Find("_Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);        
        SceneManager.LoadScene(1);        
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(1);
        float fadeTime = GameObject.Find("_Manager").GetComponent<Fading>().BeginFade(1);
        Application.Quit();
        yield return new WaitForSeconds(fadeTime);        
    }
}
