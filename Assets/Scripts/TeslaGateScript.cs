using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaGateScript : MonoBehaviour
{
    public PlayerScript PlayerHealth;

    bool DmgOnStart = false;

    public GameManager Manager;

    // Start is called before the first frame update
    void Start()
    {
        DmgOnStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(DmgOnStart == true)
        {
            //StartCoroutine(TimeEntervalBetweenDmg());
            Debug.Log("Its working");
            Debug.Log(PlayerHealth.HealthPoint);
        }

        GameManager.Instance.UpdateHealth(PlayerHealth.HealthPoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //PlayerHealth.HealthPoint -= 5;

            StartCoroutine(TimeEntervalBetweenDmg());
        }
    }

    public IEnumerator TimeEntervalBetweenDmg()
    {
        PlayerHealth.HealthPoint -= 5;

        yield return new WaitForSeconds(5f);
    }
}
