using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoisionScript : MonoBehaviour
{
    public int HP = 100;

    public float totaltime = 0;

    void OnTriggerStay(Collider other)
    {
        totaltime += Time.deltaTime;
        if(totaltime>1)
        {
            HP -= 5;
            Debug.Log("HP is " + HP + " total time is " + totaltime);
                totaltime = 0;
        }
    }
}
