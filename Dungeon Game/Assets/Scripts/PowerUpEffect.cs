using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffect : MonoBehaviour
{
    public void Activate(){
        gameObject.SetActive(true);
        Debug.Log("ACTIVATED");
    }

    public void Deactivate(){
        gameObject.SetActive(false);
        Debug.Log("DEACTIVATED");
    }
}
