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
    public void IniciarSesion()
    {
        StartCoroutine(Iniciar());
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
            case 204: // El usuario o la contrase�a son incorrectos
                print(servidor.respuesta.mensaje);
                txtLog.text = servidor.respuesta.mensaje;
                break;
            case 205: // Inicio de sesi�n correcto
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
}
