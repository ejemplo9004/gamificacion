using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RespuestaLogin
{
    public Persona persona;
    public Nota[] notas;
    public Evaluacion[] evaluaciones;
    public Evaluacion[] evagrupo;
    public Persona[] compas;
    public Clan[] infoClan;
    public Persona[] clan;
}

[System.Serializable]
public class Persona
{
    public int      id;
    public string   nombre;
    public int      institucion;
    public string   grupo;
    public string   clan;
    public int      bonificadores;
    public string   codigo;
    public string   avatar;
}

[System.Serializable]
public class Nota
{
    public int      id;
    public string   nombre;
    public string   codigo;
    public int      porcentaje;
}
[System.Serializable]
public class Clan
{
    public int id;
    public string nombre;
    public int oro;
}

[System.Serializable]
public class Evaluacion
{
    public int      id;
    public int      id_estudiante;
    public int      id_nota;
    public float    nota;
}
