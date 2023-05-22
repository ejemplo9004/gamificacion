using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour
{
    public ProtoCarta protoCarta;
    public Image imCarta;
    public Text txtNombre;
    public Text txtPrecio;

    public void Inicializar(ProtoCarta p)
    {
        protoCarta = p;
        imCarta.sprite = protoCarta.imagen;
        txtNombre.text = protoCarta.nombre;
        txtPrecio.text = protoCarta.oro.ToString();
    }

    public void Mostrar()
	{
        InicializadorCartas.singleton.Mostrar(protoCarta);
	}
}
