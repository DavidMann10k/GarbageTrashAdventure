using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashy_method : MonoBehaviour
{
    //boolean soundCheck = true;

    public void trash_Sound()
    {
        //AudioClip trashSound = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/trashSound.wav", typeof(AudioClip));

        AudioClip trashSound = Resources.Load<AudioClip>("Assets/_sounds/trashSound.wav");

        var garbagePickup = GetComponent<AudioSource>();

        garbagePickup.clip = trashSound;

        //if (soundCheck = true){
            garbagePickup.Play();
            //soundCheck = false;
        //}
    }
}