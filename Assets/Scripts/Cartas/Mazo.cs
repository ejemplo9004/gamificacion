using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Morion/Mazo")]
public class Mazo : ScriptableObject
{
    public List<ProtoCarta> cartas;
    public void Ordenar()
	{
		List<ProtoCarta> cartasOrdenadas = new List<ProtoCarta>();
		while (cartas.Count > 0)
		{
			int indice = 0;
			int precio = cartas[0].oro;
			for (int i = 1; i < cartas.Count; i++)
			{
				if (cartas[i].oro < precio)
				{
					indice = i;
					precio = cartas[i].oro;
				}
			}
			cartasOrdenadas.Add(cartas[indice]);
			cartas.RemoveAt(indice);
		}
		cartas = cartasOrdenadas;
	}
}
