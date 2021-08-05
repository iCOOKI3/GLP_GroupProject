using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaGateScript : MonoBehaviour
{
    public PlayerScript PlayerHealth;

    bool DmgOnStart = false;

    public float period = 0.0f;

    public GameManager Manager;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DmgOnStart = true;
    }

    // Update is called once per frame
    void Update()
    {

        audioSource.Play();

        //if(DmgOnStart == true)
        //{
        //    //StartCoroutine(TimeEntervalBetweenDmg());
        //    Debug.Log("Its working");
        //    Debug.Log(PlayerHealth.HealthPoint);
        //}

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
