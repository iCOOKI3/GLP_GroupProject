using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorScript : MonoBehaviour
{

    public int amountOfKeys;

    public DoorTrigger doorTrigger;

    public AudioClip doorSound;

    private AudioSource audioSource;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (meshRenderer.enabled)
        {
            // Check if this door has a DoorTrigger object //
            if (doorTrigger != null)
            {
                // check is triggered and enough score //
                if (doorTrigger.isTriggered && GameManager.Instance.GetKeys() >= amountOfKeys)
                {
                    StartCoroutine(RemoveDoor(2));
                }
            }
            else
            {
                // Only score based //
                if (GameManager.Instance.GetKeys() >= amountOfKeys)
                {
                    StartCoroutine(RemoveDoor(2));
                }
            }
        }
    }

    IEnumerator RemoveDoor(float _timeBeforeRemoval)
    {
        audioSource.PlayOneShot(doorSound);
        meshRenderer.enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<UnityEngine.AI.NavMeshObstacle>().enabled = false;

        yield return new WaitForSeconds(_timeBeforeRemoval);
        gameObject.SetActive(false);
    }
}
