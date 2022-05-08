using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class gameLevel : MonoBehaviour
{
    public GameObject AlphaPanel;

    void Start()
    {
        AlphaPanel.GetComponent<CanvasGroup>().DOFade(0, 2.0f);
    }

}
