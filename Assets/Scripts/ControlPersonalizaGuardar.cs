using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPersonalizaGuardar : MonoBehaviour
{
    public Servidor servidor;
    public RespuestaLogin respuestaLogin;
    public CuerpoPersonalizable cuerpo;
    void Start()
    {
        string d = PlayerPrefs.GetString("datos");
        respuestaLogin = JsonUtility.FromJson<RespuestaLogin>(d);
        cuerpo.Cargar(respuestaLogin.persona.avatar);
    }

    public void Guardar()
	{
        StartCoroutine(Iniciar());
    }
    IEnumerator Iniciar()
    {
        string[] datos = new string[2];
        datos[0] = respuestaLogin.persona.id.ToString();
        datos[1] = cuerpo.ToTexto();

        StartCoroutine(servidor.ConsumirPersonalizacion("avatar", datos, CambioEscena));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);

    }

    public void CambioEscena()
	{
        SceneManager.LoadScene("Login");
	}
}
