using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInicializadorRanking : MonoBehaviour
{
    public UIRanking[] uiRankings;
    public RespuestaLogin respuestaLogin;

    public List<Persona> pDesordenadas;
    public List<Persona> pOrdenadas;

    void Start()
    {
        string d = PlayerPrefs.GetString("datos");
        respuestaLogin = JsonUtility.FromJson<RespuestaLogin>(d);
        Ordenar();
        Inicializar();
    }

    void Inicializar()
	{
		for (int i = 0; i < pOrdenadas.Count; i++)
		{
			if (i<uiRankings.Length)
			{
                uiRankings[i].Inicializar(pOrdenadas[i]);
			}
		}
	}

    void Ordenar()
    {
        pDesordenadas = new List<Persona>();
        pOrdenadas = new List<Persona>();

		///////////////// Pasar los datos a la nueva lista
		for (int i = 0; i < respuestaLogin.compas.Length; i++)
		{
            pDesordenadas.Add(respuestaLogin.compas[i]);
		}

		///////////////// Recalcular los puntajes
		for (int i = 0; i < pDesordenadas.Count; i++)
		{
            float nota = 0;
			for (int j = 0; j < respuestaLogin.evagrupo.Length; j++)
			{
				if (pDesordenadas[i].id == respuestaLogin.evagrupo[j].id_estudiante)
				{
                    nota += GetNotaPonderada(respuestaLogin.evagrupo[j]);
				}
			}
            pDesordenadas[i].bonificadores += Mathf.RoundToInt(100 * nota);
		}

		///////////////// Extraer Ordenadas
		while (pDesordenadas.Count > 0)
		{
            int maximo = pDesordenadas[0].bonificadores;
            int indice = 0;
			for (int i = 1; i < pDesordenadas.Count; i++)
			{
				if (pDesordenadas[i].bonificadores > maximo)
				{
                    maximo = pDesordenadas[i].bonificadores;
                    indice = i;
                }
			}
            pOrdenadas.Add(pDesordenadas[indice]);
            pDesordenadas.RemoveAt(indice);
		}
    }

    public float GetNotaPonderada(Evaluacion e)
	{
        Nota n = ExtraerNota(e.id_nota);
        float notaAcumulada = e.nota * (n.porcentaje / 100f);
        return notaAcumulada;
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
}
