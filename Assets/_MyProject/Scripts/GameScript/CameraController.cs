using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            //Kamera��s�ndan d��ar� ��kan enemy ise 
            //Oku belirgin et ok d��man� takip etsin d��man kareye girince tekrardan ok kaybolsun
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //d��man karede oldu�u s�rece ok kaybolsun
        }
    }
}
