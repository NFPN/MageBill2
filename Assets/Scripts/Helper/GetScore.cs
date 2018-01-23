using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    public float pontuacaoTotal;
    public Text ptFinalTexto;
    public Text hScoreTexto;
    public Image Best;
    public float timeScale;

    void Start()
    {
        pontuacaoTotal = 0;        
        pontuacaoTotal = PlayerPrefs.GetFloat("Score");
        ptFinalTexto.text = "Final Score: " + pontuacaoTotal.ToString("f0");
        hScoreTexto.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore").ToString("f0");
        if (pontuacaoTotal == PlayerPrefs.GetFloat("Highscore"))
        {
            Best.fillAmount = 1;
        }
        else
        {
            Best.fillAmount = 0;
        }        
    }
    void Update()
    {Time.timeScale = timeScale;}
}