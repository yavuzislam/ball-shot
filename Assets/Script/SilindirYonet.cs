using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SilindirYonet : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public GameObject SilindirObjesi;
    [SerializeField] private float DonucCapi;
    [SerializeField] private string Yon;
    bool ButtonPressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonPressed= true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ButtonPressed= false;
    }
    void Update()
    {
        if (ButtonPressed)
        {
            if (Yon=="Sol")
            {
                SilindirObjesi.transform.Rotate(0, DonucCapi * Time.deltaTime, 0, Space.Self);
            }
            else
            {
                SilindirObjesi.transform.Rotate(0, -DonucCapi * Time.deltaTime, 0, Space.Self);
            }
        }
    }
}
