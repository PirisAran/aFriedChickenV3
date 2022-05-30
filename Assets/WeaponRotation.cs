using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    // Start is called before the first frame update

    float rotationZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationZ = transform.parent.rotation.z;

        if (rotationZ > 90.0f && rotationZ < 180.0f)
        {
            transform.parent.rotation.Set(180, 0, rotationZ, 0);
        }
        else
        {
            transform.parent.rotation.Set(0, 0, rotationZ, 0);
        }
    }
}
