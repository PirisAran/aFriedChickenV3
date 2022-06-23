using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlaySound("Music", musicSource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
