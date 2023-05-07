using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5.0f;

    private PlayerAction controls;
    private InputAction move;
    private InputAction slow;
    private InputAction fire;

    public Transform firePoint;

    public GameObject projectilePrefab;
    public float fireRate = 0.25f;
    private float nextFire = 0.0f;
    public float projectileForce = 20f;
    Vector2 direction;

    Vector2 moveDirection = Vector2.zero;

    public float hitpoints;
    public float maxHitpoints;
    public TextMeshProUGUI healthUI;

    bool isSlow;
    bool isShooting;

    void Awake()
    {
        controls = new PlayerAction();
        hitpoints = maxHitpoints;
        healthUI.text = "Player HP: " + hitpoints.ToString();
    }

    public void TakeHit(float damage)
    {
        hitpoints -= damage;
        healthUI.text = "Player HP: " + hitpoints.ToString();
        if (hitpoints <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (hitpoints < 0)
        {
            hitpoints = 0;
        }
    }

    private void OnEnable()
    {
        move = controls.Player.Move;
        move.Enable();

        slow = controls.Player.Slow;
        slow.performed += Slow;
        slow.Enable();

        fire = controls.Player.Fire;
        fire.performed += Fire;
        fire.Enable();

    }

    private void OnDisable()
    {
        move.Disable();
        slow.Disable();
        fire.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

        if (slow.IsPressed())
        {
            moveSpeed = 3.0f;
        }
        else if (slow.WasReleasedThisFrame())
        {
            moveSpeed = 7.0f;
        }

        if (fire.IsPressed())
        {
            Shoot();
        }
        else if (fire.WasReleasedThisFrame())
        {
            isShooting = false;
        }

        direction = transform.position;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Slow(InputAction.CallbackContext context)
    {

    }

    private void Fire(InputAction.CallbackContext context)
    {

        isShooting = true;
    }

    void Shoot()
    {
        if (isShooting == true)
        {
            if (Time.time > nextFire)
            {
                if (!projectilePrefab)
                    return;
                nextFire = Time.time + fireRate;
                GameObject clone = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb2 = clone.GetComponent<Rigidbody2D>();
                clone.GetComponent<Rigidbody2D>().AddForce(Vector2.up * projectileForce);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeHit(5);
        }

    }
}
