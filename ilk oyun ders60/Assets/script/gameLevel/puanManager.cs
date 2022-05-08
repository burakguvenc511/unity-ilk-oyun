using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puanManager : MonoBehaviour
{
    private int toplampuan;
    private int puanartis;

    [SerializeField]
    private Text puantext;

    void Start()
    {
        puantext.text = toplampuan.ToString();
    }
    public void puanartir(string zorlukseviye)
    {
        switch (zorlukseviye)
        {
            case "kolay":  puanartis = 5;         break;
            case "orta":   puanartis = 10;        break;
            case "zor":    puanartis = 15;        break;
        }
        toplampuan += puanartis;
        puantext.text = toplampuan.ToString();
    }
}
