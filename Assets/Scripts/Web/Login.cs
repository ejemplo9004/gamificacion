using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public Servidor servidor;
    public InputField inpUsuario;
    public InputField inpPass;
    public GameObject imLoading;
    public DBUsuario usuario;
    public Text txtLog;

    public RespuestaLogin respuestaLogin;


	private void Start()
	{
        string uss = PlayerPrefs.GetString("usuario", "");
		if (uss.Length > 1)
		{
            inpUsuario.text = uss;
            IniciarSesionFake();
        }
    }
	public void IniciarSesion()
    {
        StartCoroutine(Iniciar());
    }
    public void IniciarSesionFake()
    {
        StartCoroutine(IniciarSesionCodigo());
    }

    IEnumerator Iniciar()
    {
        imLoading.SetActive(true);
        string[] datos = new string[2];
        datos[0] = inpUsuario.text;
        datos[1] = inpPass.text;

        StartCoroutine(servidor.ConsumirServicio("login", datos, PosCargar));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        imLoading.SetActive(false);
    }

    void PosCargar()
    {
        switch (servidor.respuesta.codigo)
        {
            case 204: // El usuario o la contraseña son incorrectos
                print(servidor.respuesta.mensaje);
                txtLog.text = servidor.respuesta.mensaje;
                break;
            case 205: // Inicio de sesión correcto
                //SceneManager.LoadScene("SampleScene");
                usuario = JsonUtility.FromJson<DBUsuario>(servidor.respuesta.respuesta);
                txtLog.text = servidor.respuesta.respuesta;
                break;
            case 402: // Faltan datos para ejecutar la accion solicitada
                print(servidor.respuesta.mensaje);
                txtLog.text = servidor.respuesta.mensaje;
                break;
            case 404: // Error
                txtLog.text = "Error, no se puede conectar con el servidor.";
                print("Error, no se puede conectar con el servidor.");
                break;
            default:
                break;
        }
    }

    public IEnumerator IniciarSesionCodigo()
	{
        imLoading.SetActive(true);
        string[] datos = new string[1];
        datos[0] = inpUsuario.text;

        StartCoroutine(servidor.ConsumirServicioFake("login", datos, PosFake));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        imLoading.SetActive(false);
    }

    void PosFake()
	{
		if (servidor.fakeRespuesta != "Error")
		{
            respuestaLogin = JsonUtility.FromJson<RespuestaLogin>(servidor.fakeRespuesta);
            PlayerPrefs.SetString("datos", servidor.fakeRespuesta);
            PlayerPrefs.SetString("usuario", inpUsuario.text);
            SceneManager.LoadScene("Menu");
		}
	}
}
