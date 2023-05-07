using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdle : MonoBehaviour
{
    public Animator animator;
    public int maximo;

    void Start()
    {
        CambiarAnimacion();
    }
    public void CambiarAnimacion()
	{
        animator.SetInteger("animacion", Random.Range(0, maximo));
        animator.SetTrigger("activar");
	}
}
