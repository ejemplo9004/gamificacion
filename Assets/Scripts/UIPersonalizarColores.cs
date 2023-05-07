using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPersonalizarColores : MonoBehaviour
{
    public CuerpoPersonalizable cuerpoPersonalizable;
    public GameObject botonesCrear;
    public Transform padreBotones;
    public int indice;
    void Start()
    {
        CrearBotones();
    }

    void CrearBotones()
    {
        for (int i = 0; i < cuerpoPersonalizable.opcionesColor; i++)
        {
            GameObject btnNuevo = Instantiate(botonesCrear, padreBotones);
            btnNuevo.name = i.ToString();
            btnNuevo.GetComponent<Image>().color = 
                cuerpoPersonalizable.GetGradiente(indice).Evaluate
                (
                    (float)i / (float)(cuerpoPersonalizable.opcionesColor - 1)
                );
        }
        botonesCrear.SetActive(false);
    }

    public void CambiarColor(int cual)
    {
        cuerpoPersonalizable.CambiarColor(indice, cual);
    }
}
