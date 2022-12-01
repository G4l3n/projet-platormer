using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompteurDeMort : MonoBehaviour
{
    private Kill kill;
    private Player player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        kill = gameObject.GetComponent<Kill>();
    }

    public void IsDead()
    {
        if (kill.Death == true)
        {
            Debug.Log("IsDead");
        }
    }

}
