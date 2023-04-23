using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public Color mainColor;
    public Color redColor;
    Renderer mat;
    public void hitEffect(){
        mat = GetComponent<Renderer>();
        mat.material.color = redColor;
        StartCoroutine(reverseColor());
    }
    IEnumerator reverseColor(){
        yield return new WaitForSeconds(0.2f);
        mat.material.color = mainColor;
    }
}
