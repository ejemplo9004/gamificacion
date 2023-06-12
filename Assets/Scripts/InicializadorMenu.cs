using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InicializadorMenu : MonoBehaviour
{

    public RespuestaLogin respuestaLogin;
    public GameObject prNotas;
    public Transform padreNotas;
    public Text txtNombre;
    public Text txtNotaFinal;
    public Text txtNotaParcial;
    public Text txtGrupo;
    public CuerpoPersonalizable cuerpo;
    void Start()
    {
        string d = PlayerPrefs.GetString("datos");
        respuestaLogin = JsonUtility.FromJson<RespuestaLogin>(d);

        IniciarNotas();
        txtNombre.text = respuestaLogin.persona.nombre;
        CalcularNotas();
        txtGrupo.text = "Equipo: " + respuestaLogin.persona.clan;
        cuerpo.Cargar(respuestaLogin.persona.avatar);
    }

    void IniciarNotas()
    {
		for (int i = 0; i < respuestaLogin.evaluaciones.Length; i++)
		{
            UINota uin = Instantiate(prNotas, padreNotas).GetComponent<UINota>();
            uin.Inicializar(ExtraerNota(respuestaLogin.evaluaciones[i].id_nota), respuestaLogin.evaluaciones[i]);
		}
    }

    public Nota ExtraerNota(int id)
	{
		for (int i = 0; i < respuestaLogin.notas.Length; i++)
		{
			if (respuestaLogin.notas[i].id == id)
			{
                return respuestaLogin.notas[i];
            }
		}
        return null;
	}

    public void CalcularNotas()
	{
        float porcentaje = 0;
        float notaAcumulada = 0;
        for (int i = 0; i < respuestaLogin.evaluaciones.Length; i++)
        {
            Nota n = ExtraerNota(respuestaLogin.evaluaciones[i].id_nota);
            Evaluacion e = respuestaLogin.evaluaciones[i];
            notaAcumulada += e.nota * (n.porcentaje / 100f);
            porcentaje += n.porcentaje;
        }
        txtNotaFinal.text = "Nota Final: " + notaAcumulada.ToString("0.0");
        txtNotaParcial.text = "Nota Parcial: " + ((porcentaje>0)?(notaAcumulada / (porcentaje / 100f)).ToString("0.0"):"0.0");
    }

    public void CerrarSesion()
	{
        PlayerPrefs.SetString("usuario", "");
    }
}
