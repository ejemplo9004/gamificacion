using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitadorFrames : MonoBehaviour
{
    public int limiteFrames;
    void Start()
    {
        Application.targetFrameRate = limiteFrames;
    }
}
