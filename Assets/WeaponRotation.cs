using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotationZ;
    public float rotationX;
    public Vector3 vector = new Vector3(0, 0, 0);
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(vector);
    }
}
