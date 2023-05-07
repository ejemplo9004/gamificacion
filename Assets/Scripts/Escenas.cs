using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    public string autoCambiarEscena;
    public float tiempoCambiar;
    // Start is called before the first frame update
    void Start()
    {
		if (autoCambiarEscena.Length > 0)
		{
            Invoke("AutoCambiar", tiempoCambiar);
		}
    }

    public void AutoCambiar()
	{
        CambiarEscena(autoCambiarEscena);
	}

    public void CambiarEscena(string nombre)
	{
        SceneManager.LoadScene(nombre);
	}

    public void Salir()
	{
        Application.Quit();
	}

}
