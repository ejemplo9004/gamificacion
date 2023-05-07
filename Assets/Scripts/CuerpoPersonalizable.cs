using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerpoPersonalizable : MonoBehaviour
{
    public GrupoObjetos[] partes;
    public Material material;
    public Gradient coloresPiel;
    public Gradient coloresCabello;
    public Gradient coloresRopa1;
    public Gradient coloresRopa2;
    public int opcionesColor;
    public int iColorPiel;
    public int iColorCabello;
    public int iColorRopa1;
    public int iColorRopa2;

    private void Awake()
    {
        Cargar();
        AplicarColores();
    }

    public void Guardar()
    {
        string texto = "";
        for (int i = 0; i < partes.Length; i++)
        {
            texto += partes[i].indice.ToString() + "|";
        }
        texto += iColorPiel.ToString() + "|";
        texto += iColorCabello.ToString() + "|";
        texto += iColorRopa1.ToString() + "|";
        texto += iColorRopa2.ToString() + "|";
        //print(texto);
        PlayerPrefs.SetString("personaje", texto);
    }

    public void Cargar()
    {
        string texto = PlayerPrefs.GetString("personaje", "0|0|0|0|0|0|0|0|0|0|0|");
        string[] arreglo = texto.Split('|');
        for (int i = 0; i < partes.Length; i++)
        {
            partes[i].indice = int.Parse(arreglo[i]);
            partes[i].Activar();
        }

        iColorPiel      = int.Parse(arreglo[partes.Length + 0]);
        iColorCabello   = int.Parse(arreglo[partes.Length + 1]);
        iColorRopa1     = int.Parse(arreglo[partes.Length + 2]);
        iColorRopa2     = int.Parse(arreglo[partes.Length + 3]);
        //print(texto);
    }

    public void AplicarColores()
    {
        material.SetColor("_ColorPiel", coloresPiel.Evaluate((float)iColorPiel / (float)(opcionesColor - 1)));
        material.SetColor("_ColorCabello", coloresCabello.Evaluate((float)iColorCabello / (float)(opcionesColor - 1)));
        material.SetColor("_ColorRopa1", coloresRopa1.Evaluate((float)iColorRopa1 / (float)(opcionesColor - 1)));
        material.SetColor("_ColorRopa2", coloresRopa2.Evaluate((float)iColorRopa2 / (float)(opcionesColor - 1)));
    }

    public Gradient GetGradiente(int cual)
    {
        switch (cual)
        {
            case 0:
                return coloresPiel;
            case 1:
                return coloresCabello;
            case 2:
                return coloresRopa1;
            default:
                break;
        }
        return coloresRopa2;
    }

    public void CambiarColor(int cual, int valor)
    {
        switch (cual)
        {
            case 0:
                iColorPiel = valor;
                break;
            case 1:
                iColorCabello = valor;
                break;
            case 2:
                iColorRopa1 = valor;
                break;
            case 3:
                iColorRopa2 = valor;
                break;
            default:
                break;
        }
        
        AplicarColores();
        Guardar();
    }

}

[System.Serializable]
public class GrupoObjetos
{
    public string nombre = "Default";
    public GameObject[] objetos;
    public int indice;

    public void Activar()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].SetActive(i == indice);
        }
    }

    public void Siguiente()
    {
        indice = (indice + 1) % objetos.Length;
        Activar();
    }

    public void Anterior()
    {
        indice = (indice - 1 + objetos.Length) % objetos.Length;
        Activar();
    }
}
