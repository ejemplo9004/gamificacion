using UnityEngine;
using UnityEngine.UI;

public class UILogoIntercambiable : MonoBehaviour
{
    public Image imLogo;
    public Sprite[] logos;
    void Start()
    {
        imLogo.sprite = logos[Random.Range(0, logos.Length)];
    }

}
