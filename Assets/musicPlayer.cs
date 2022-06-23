using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    public float time = 60f;
    public float DeltaTime=0f;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlaySound("Music", musicSource);
    }

    // Update is called once per frame
    void Update()
    {
        while(DeltaTime <= time && DeltaTime > -1)
        {
            DeltaTime += Time.deltaTime;
        }
        
        if (DeltaTime >= time)
        {
            SoundManager.PlaySound("Music", musicSource);
            DeltaTime = -10f;
        }
    }
}
