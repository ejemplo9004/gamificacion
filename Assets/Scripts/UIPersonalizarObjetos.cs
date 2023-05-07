using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPersonalizarObjetos : MonoBehaviour
{
    public CuerpoPersonalizable cuerpoPersonalizable;
    public Text txtUnidades;
    public Text txtNombre;
    public int indice;
    void Start()
    {
        ActualizarTexto();
        txtNombre.text = cuerpoPersonalizable.partes[indice].nombre;
    }

    public void Siguiente()
    {
        cuerpoPersonalizable.partes[indice].Siguiente();
        ActualizarTexto();
        cuerpoPersonalizable.Guardar();

    }

    public void Anterior()
    {
        cuerpoPersonalizable.partes[indice].Anterior();
        ActualizarTexto();
        cuerpoPersonalizable.Guardar();
    }

    void ActualizarTexto()
    {
        txtUnidades.text = (cuerpoPersonalizable.partes[indice].indice + 1).ToString() + "/" + cuerpoPersonalizable.partes[indice].objetos.Length;
    }
}
