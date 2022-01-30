using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    private float magnitude;
    public Vector3 spawnPoint; // where the user will spawn and respawn

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        magnitude = 1f;
        //Set up spawnpoint
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void FixedUpdate()
    {
        Movement();

    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _rb.velocity = new Vector2(0, magnitude * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _rb.velocity = new Vector2(0, magnitude * -speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.velocity = new Vector2(magnitude * -speed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.velocity = new Vector2(magnitude * speed, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hazard")
        {
            transform.position = spawnPoint;
        }
        if (collision.gameObject.tag == "goal")
        {
            transform.position = spawnPoint;
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
