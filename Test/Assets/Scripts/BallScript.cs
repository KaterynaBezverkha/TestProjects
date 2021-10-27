using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public static BallScript instance;

    GameObject player;
    Rigidbody rb;

    Vector3 direction;
    float magnitude;
    public bool isBallThrown;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        isBallThrown = false;
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBallThrown)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 ballPos = transform.position;

            direction = playerPos - ballPos;
            magnitude = Mathf.Abs(playerPos.x = ballPos.x);
        }
    }

    public void ThrowBall()
    {
        rb.AddForce(direction * magnitude);
        rb.velocity = direction * magnitude;
        isBallThrown = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Block")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
    }

}
