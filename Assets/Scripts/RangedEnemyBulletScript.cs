using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBulletScript : MonoBehaviour
{

    public float speed;

    public Transform player;

    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            DestroyBullet();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyBullet();

        if(other.gameObject.tag == "Wall")
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
