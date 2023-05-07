using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Basic movement code courtesy of Alexander Zotov, May 18, 2021.
// https://www.youtube.com/watch?v=NbA95f1FlXQ

public class EnemyController : MonoBehaviour
{
    public float hitpoints;
    public float maxHitpoints;
    public TextMeshProUGUI healthUI;
    public HitpointBar hitpointBar;
    private float directionX;
    public float moveSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        hitpoints = maxHitpoints;
        healthUI.text = "HP: " + hitpoints.ToString();
        hitpointBar.SetHealth(hitpoints, maxHitpoints);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        directionX = -1.0f;
    }

    public void TakeHit(float damage)
    {
        hitpoints -= damage;
        healthUI.text = "HP: " + hitpoints.ToString();
        hitpointBar.SetHealth(hitpoints, maxHitpoints);
        if (hitpoints <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            directionX *= -1.0f;
        }

    }
}
