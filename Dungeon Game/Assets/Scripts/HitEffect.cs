using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    Material mainColor;
    public Material redColor;
    Renderer mat;
    public AudioClip hit;
    public AudioSource audio;
    void Start(){
        mat = GetComponent<Renderer>();
        if(mat!=null){
            mainColor = mat.material;
        }
    }
    public void hitEffect(){
        hitSound();
        if(mat != null && redColor != null){
            mat.material = redColor;
            StartCoroutine(reverseColor());
        }
    }
    public void hitSound(){
        audio.PlayOneShot(hit);
    }
    IEnumerator reverseColor(){
        yield return new WaitForSeconds(0.2f);
        mat.material = mainColor;
    }
}
