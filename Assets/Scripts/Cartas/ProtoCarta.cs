using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Morion/Carta")]
public class ProtoCarta : ScriptableObject
{
    public string nombre;
    public Sprite imagen;
    [TextArea(2,3)]
    public string descripcion;
    public int oro;
}
