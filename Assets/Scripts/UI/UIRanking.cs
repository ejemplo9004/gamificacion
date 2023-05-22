using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRanking : MonoBehaviour
{
    public Text txtNombre;
    public Text txtPuntos;
    public RawImage imagen;
    public CuerpoPersonalizable cuerpo;

    public void Inicializar(Persona p)
	{
        cuerpo.Cargar(p.avatar);
        txtNombre.text = p.nombre;
        txtPuntos.text = p.bonificadores.ToString("0000");
	}
}
