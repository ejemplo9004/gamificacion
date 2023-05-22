using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InicializadorCartas : MonoBehaviour
{
    public GameObject objCarta;
    public Image imCarta;
    public Text txtNombre;
    public Text txtDescripcion;
    public Mazo mazo;
    public GameObject prCarta;
    public Transform padreCartas;
    
    public static InicializadorCartas singleton;

    void Awake()
    {
        singleton = this;
    }
	private void Start()
	{
        mazo.Ordenar();
		for (int i = 0; i < mazo.cartas.Count; i++)
		{
            Carta c = Instantiate(prCarta, padreCartas).GetComponent<Carta>();
            c.Inicializar(mazo.cartas[i]);
		}
	}

	public void Mostrar(ProtoCarta p)
	{
        txtNombre.text = p.nombre;
        txtDescripcion.text = p.descripcion;
        imCarta.sprite = p.imagen;
        objCarta.SetActive(true);
	}
}
