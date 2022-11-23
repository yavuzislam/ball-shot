using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("---TOP AYARLARI")]
    public GameObject[] Toplar;
    public GameObject FirePoint;
    [SerializeField] private float TopGucu;
    int AktifTopIndex = 0;

    [Header("---LEVEL AYARLARI")]
    [SerializeField] private int HedefTopSayisi;
    [SerializeField] private int MevcutTopSayisi;
    int GirenTopSayisi;
    public Slider LevelSlider;
    public TextMeshProUGUI KalanTopSayisiText;
    //bool kitle=false;
    void Start()
    {
        LevelSlider.maxValue = HedefTopSayisi;
        KalanTopSayisiText.text = MevcutTopSayisi.ToString();
    }
    public void TopGirdi()
    {
        GirenTopSayisi++;
        LevelSlider.value = GirenTopSayisi;
        
        if (GirenTopSayisi == HedefTopSayisi)
        {
            //kitle = true;
            //kazandin();
        }
        if (MevcutTopSayisi == 0 && GirenTopSayisi != HedefTopSayisi)
        {
            //kaybettin();
        }
        if ((MevcutTopSayisi + GirenTopSayisi) < HedefTopSayisi)
        {
            //kaybettin();
        }
    }
    public void TopGirmedi()
    {
        if (MevcutTopSayisi==0)
        {
            //kaybettin();
        }
        if ((MevcutTopSayisi+GirenTopSayisi)<HedefTopSayisi)
        {
            //kaybettin();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (kitle!)
        //{

        //}
        if (Input.GetKeyDown(KeyCode.G))
        {
            MevcutTopSayisi--;
            KalanTopSayisiText.text = MevcutTopSayisi.ToString();
            Toplar[AktifTopIndex].transform.SetPositionAndRotation(FirePoint.transform.position, FirePoint.transform.rotation);
            Toplar[AktifTopIndex].SetActive(true);
            Toplar[AktifTopIndex].GetComponent<Rigidbody>().AddForce(Toplar[AktifTopIndex].transform.TransformDirection(90, 90, 0) * TopGucu, ForceMode.Force);//açý verildi
            if (AktifTopIndex == Toplar.Length - 1)
            {
                AktifTopIndex = 0;
            }
            else
            {
                AktifTopIndex++;
            }
        }
    }
}
