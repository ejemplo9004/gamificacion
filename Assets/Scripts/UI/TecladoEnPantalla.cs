using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TecladoEnPantalla : MonoBehaviour
{
    public InputField inpTexto;

    public void EscribrLetra(string cual)
	{
		inpTexto.text = inpTexto.text + cual;
	}

	public void Borrar()
	{
		inpTexto.text = "";
	}
}
