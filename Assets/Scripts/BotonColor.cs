using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonColor : MonoBehaviour
{
    public UIPersonalizarColores uiPersonalizadorColores;

    public void Clickeado()
    {
        uiPersonalizadorColores.CambiarColor(int.Parse(gameObject.name));
    }
}
