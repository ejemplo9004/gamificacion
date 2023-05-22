using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InicializadorClan : MonoBehaviour
{
    public CuerpoPersonalizable[] cuerpos;
    public RespuestaLogin respuestaLogin;
    public int indice = 0;
    public Transform camara;

    public GameObject prNotas;
    public Transform padreNotas;
    public Text txtNombreClan;
    public Text txtNombreSujeto;
    public Text txtOro;

    List<GameObject> notasInstanciadas = new List<GameObject>();

    void Start()
    {
        string d = PlayerPrefs.GetString("datos");
        respuestaLogin = JsonUtility.FromJson<RespuestaLogin>(d);
        Inicializar();
        txtNombreClan.text = respuestaLogin.persona.clan;
    }

    void Inicializar()
    {
		for (int i = 0; i < cuerpos.Length; i++)
		{
			if (i < respuestaLogin.clan.Length)
			{
                cuerpos[i].Cargar(respuestaLogin.clan[i].avatar);
			}
			else
			{
                cuerpos[i].gameObject.SetActive(false);
			}
		}
        IniciarNotas();
		for (int i = 0; i < respuestaLogin.infoClan.Length; i++)
		{
			if (respuestaLogin.infoClan[i].nombre == respuestaLogin.persona.clan)
			{
                txtOro.text = respuestaLogin.infoClan[i].oro.ToString();
            }
		}
    }

	private void Update()
	{
        camara.position = Vector3.Lerp(camara.position, Vector3.right * indice, 5 * Time.deltaTime);
	}

    public void Siguiente()
    {
        indice = Mathf.Clamp(indice + 1, 0, respuestaLogin.clan.Length - 1);
        IniciarNotas();
    }
    public void Anterior()
    {
        indice = Mathf.Clamp(indice - 1, 0, respuestaLogin.clan.Length - 1);
        IniciarNotas();
    }


    void IniciarNotas()
    {
        txtNombreSujeto.text = respuestaLogin.clan[indice].nombre;

        for (int i = 0; i < notasInstanciadas.Count; i++)
		{
            Destroy(notasInstanciadas[i]);
		}
        notasInstanciadas = new List<GameObject>();
        List<Evaluacion> evas = new List<Evaluacion>();
		for (int i = 0; i < respuestaLogin.evagrupo.Length; i++)
		{
			if (respuestaLogin.evagrupo[i].id_estudiante == respuestaLogin.clan[indice].id)
			{
                evas.Add(respuestaLogin.evagrupo[i]);
			}
		}
        for (int i = 0; i < evas.Count; i++)
        {
            UINota uin = Instantiate(prNotas, padreNotas).GetComponent<UINota>();
            notasInstanciadas.Add(uin.gameObject);
            uin.Inicializar(ExtraerNota(evas[i].id_nota), evas[i]);
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
}
