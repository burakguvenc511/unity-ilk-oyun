using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class menulevelManger : MonoBehaviour
{
    [SerializeField]
    private GameObject startbuton, exitbuton;

    void Start()
    {
        FadeOut();
    }

    void FadeOut()
    {
        startbuton.GetComponent<CanvasGroup>().DOFade(1, 2.0f);
        exitbuton.GetComponent<CanvasGroup>().DOFade(1, 2.0f).SetDelay(0.5f);
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void startGameLevel()
    {
        SceneManager.LoadScene("GameLevel");
    }

}
