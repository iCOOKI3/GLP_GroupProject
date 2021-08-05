using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    public AudioSource audioSource;

    public bool isTriggered;

    private ActivatableDoor activatableDoor;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();

        isTriggered = false;

        PlayerScript.KeyCount = 0;

    }

    public void SetActivatableKeyDoor(ActivatableDoor _activatableKeyDoor)
    {
        activatableDoor = _activatableKeyDoor;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            audioSource.Play();
        }

        if (other.gameObject.tag.Equals("Player"))
        {
            isTriggered = true;
            gameObject.SetActive(false);
        }
    }
}
