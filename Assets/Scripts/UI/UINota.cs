using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINota : MonoBehaviour
{
    public Text txtPorcentaje;
    public Text txtNota;
    public Text txtNombre;
    public void Inicializar(Nota nota, Evaluacion evaluacion)
	{
        txtPorcentaje.text = nota.porcentaje.ToString() + "%";
        txtNota.text = evaluacion.nota.ToString("0.0");
        txtNombre.text = nota.nombre;
	}
}
