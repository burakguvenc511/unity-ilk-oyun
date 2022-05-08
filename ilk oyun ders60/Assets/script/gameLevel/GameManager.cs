using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    public AudioClip butonsesdogru;
    public AudioClip butonsesyanlis;
    public AudioClip butonsesitebrik;
    [SerializeField]
    private GameObject sonucpanel; 

    [SerializeField]
    private GameObject KareFab;
    [SerializeField]
    private Transform karelerpaneli;
    [SerializeField]
    private Transform sorupanel;
    [SerializeField]
    private Text sorutext;
    private GameObject[] karelerdizi = new GameObject[25];

    [SerializeField]
    private Sprite[] kareSprite;

    bool butonabasildimi;
    
    List<int> bolumdegerliste = new List<int>();

    int bolen = 0, bolunen = 0;
    int kacincisoru;
    int dogrusonuc;
    int butondeger;
    int kalanhak;
    kalanhakManager kalanhaklarmanager;
    puanManager Puanlar;

    GameObject gecerlikare;

    string sorununzorlugu;

    private void Awake()
    {
        source = GetComponent<AudioSource>();


        sonucpanel.GetComponent<RectTransform>().localScale = Vector3.zero;

        kalanhak = 3;
        kalanhaklarmanager = Object.FindObjectOfType<kalanhakManager>();
        Puanlar = Object.FindObjectOfType<puanManager>();

        kalanhaklarmanager.KalanHaklariKontrolEt(kalanhak);
    }

    void Start()
    {
        butonabasildimi = false;


        sorupanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        kareOlustur();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void kareOlustur()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject kare = Instantiate(KareFab, karelerpaneli);
            kare.transform.GetChild(1).GetComponent<Image>().sprite = kareSprite[Random.Range(0, kareSprite.Length)];
            kare.transform.GetComponent<Button>().onClick.AddListener(() => butonabasildi());
            karelerdizi[i] = kare;
        }

        bolumdeger();
        StartCoroutine(DoFadeRoutine());
        Invoke("sorupanelac", 5.5f);
    }

    void butonabasildi()
    {
        if (butonabasildimi == true)
        {

            
            butondeger = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            
            gecerlikare= UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            sonucukontrolet();
        }

    }


    void sonucukontrolet()
    {
        if (butondeger == dogrusonuc)
        {
            if (butonabasildimi==true)
            {
                source.PlayOneShot(butonsesdogru);
            }
            

            Puanlar.puanartir(sorununzorlugu);
            gecerlikare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            gecerlikare.transform.GetChild(0).GetComponent<Text>().text = "";
            gecerlikare.transform.GetComponent<Button>().interactable = false;
            bolumdegerliste.RemoveAt(kacincisoru);

            if (bolumdegerliste.Count >0)
            {
                sorupanelac();
            }
            else
            {
                source.PlayOneShot(butonsesitebrik);
                Debug.Log("tebrik");
                GameOver();
            }
        }
        else
        {
            if (butonabasildimi == true)
            {
                source.PlayOneShot(butonsesyanlis);
            }
                kalanhak--;
            kalanhaklarmanager.KalanHaklariKontrolEt(kalanhak);
        }
        if (kalanhak <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        butonabasildimi = false;
        sonucpanel.GetComponent<RectTransform>().DOScale(1, 1.0f).SetEase(Ease.OutBack); 
        Debug.Log("oyun bitti");
    }


    IEnumerator DoFadeRoutine()
    {
        foreach (var item in karelerdizi)
        {
            item.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
            yield return new WaitForSeconds(0.2f);
        }
    }

    void bolumdeger()
    {
        foreach (var item in karelerdizi)
        {
            int random = Random.Range(1,13);
            bolumdegerliste.Add(random);
            item.transform.GetChild(0).GetComponent<Text>().text = random.ToString();
        }
    }
    void sorupanelac()
    {
        soruyuSor();
        butonabasildimi = true;
        sorupanel.GetComponent<RectTransform>().DOScale(1, 0.2f).SetEase(Ease.OutBack);
    }

    void soruyuSor()
    {
        bolen = Random.Range(2, 11);
        kacincisoru = Random.Range(0, bolumdegerliste.Count);
        dogrusonuc = bolumdegerliste[kacincisoru];
        bolunen = bolen * dogrusonuc;
        if (bolunen <= 40)
        {
            sorununzorlugu = "kolay";
        }
        else if (bolunen <= 80)
        {
            sorununzorlugu = "orta";
        }
        else
        {
            sorununzorlugu="zor";
        }
        sorutext.text = bolunen.ToString() + " / " + bolen.ToString();
    }

}
