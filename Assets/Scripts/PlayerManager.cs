using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    private void Awake() 
    {
        if (!instance)
        {
            instance = this;
        }    
    }

    public GameObject player;
}
