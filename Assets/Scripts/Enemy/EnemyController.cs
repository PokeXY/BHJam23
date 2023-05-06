using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{

    public float hitpoints;
    public float maxHitpoints;
    public TextMeshProUGUI healthUI;
    public HitpointBar hitpointBar;

    // Start is called before the first frame update
    void Start()
    {
        hitpoints = maxHitpoints;
        hitpointBar.SetHealth(hitpoints, maxHitpoints);
    }

    public void TakeHit(float damage)
    {
        hitpoints -= damage;
        healthUI.text = "HP: " + hitpoints.ToString();
        hitpointBar.SetHealth(hitpoints, maxHitpoints);
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
