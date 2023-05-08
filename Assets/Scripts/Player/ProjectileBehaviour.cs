using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ProjectileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource sfx;
    Vector3 shrink = new Vector3(0f, 0f, 0f);

    void Awake()
    {
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<EnemyController>();
        if (enemy)
        {
            sfx.Play();
            enemy.TakeHit(3);
            gameObject.transform.localScale = shrink;
            Destroy(gameObject, 0.2f);
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }
}
