using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
public class Fade : MonoBehaviour
{
    public Animator FadeAnim;
    public GameObject PainelFade;
    void Start()
    {
        PainelFade.SetActive(true);
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        FadeAnim.SetTrigger("Fade");
        yield return new WaitForSeconds(0.45f);
        PainelFade.SetActive(false);
    }
    public void FadeOut(string name)
    {
        StartCoroutine(ChangeScene(name));
    }
    IEnumerator ChangeScene(string n)
    {
        //Firebase.Analytics.FirebaseAnalytics.LogEvent("tela", "atual", SceneManager.GetActiveScene().name.ToString());
        FadeAnim.SetTrigger("FadeExit");
        
        yield return new WaitForSeconds(0.2f);

        // Verficando se é a primeira vez do jogador, caso seja é mandado para tela de historia
        if (n == "SeletionFase1" && PlayerPrefs.GetInt("PrimeiraVez") != 1)
        {
            SceneManager.LoadScene("StoryTelling");
        }
        else
        {
            SceneManager.LoadScene(n);
        }
    }
}
