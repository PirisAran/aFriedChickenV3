using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poof : MonoBehaviour
{
    [SerializeField] AudioSource audioSource1;

    void Poof()
    {
        SoundManager.PlaySound("Witch_Poof", audioSource1);
    }
}
