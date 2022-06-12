using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroy : MonoBehaviour
{
    public float LifeTime = 2;

    private void Start()
    {
        Destroy(gameObject,LifeTime);
    }
}
