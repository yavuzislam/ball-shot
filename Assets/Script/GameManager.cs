using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [Header("---UI AYARLARI")]
    public GameObject[] Paneller;
    public TextMeshProUGUI YildizSayisi;
    public TextMeshProUGUI Kazandin_LevelSayisi;
    public TextMeshProUGUI Kaybettin_LevelSayisi;
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
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("Yildiz", PlayerPrefs.GetInt("Yildiz") + 55);
            YildizSayisi.text = PlayerPrefs.GetInt("Yildiz").ToString();
            Kazandin_LevelSayisi.text = "LEVEL : "+SceneManager.GetActiveScene().name;
            Paneller[1].SetActive(true);
        }
        if (MevcutTopSayisi == 0 && GirenTopSayisi != HedefTopSayisi)
        {
            Paneller[2].SetActive(true);
            Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
        }
        if ((MevcutTopSayisi + GirenTopSayisi) < HedefTopSayisi)
        {
            Paneller[2].SetActive(true);
            Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
        }
    }
    public void TopGirmedi()
    {
        if (MevcutTopSayisi == 0)
        {
            Paneller[2].SetActive(true);
            Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
        }
        if ((MevcutTopSayisi + GirenTopSayisi) < HedefTopSayisi)
        {
            Paneller[2].SetActive(true);
            Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
        }
    }

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
    public void OyunDurdur()
    {
        Paneller[0].SetActive(true);
        Time.timeScale = 0;
    }
    public void PanellericinButonislemi(string islem)
    {
        switch (islem)
        {
            case "DevamEt":
                Time.timeScale = 1;
                Paneller[0].SetActive(false);
                break;
            case "Cikis":
                Application.Quit();
                break;
            case "Ayarlar":
                break;
            case "Tekrar":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                break;
            case "Next":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }
}
