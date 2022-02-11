using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator anim;
    public float speed = 2f;
    private float hMovement = 0f;
    private float vMovement = 0f;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        hMovement = Input.GetAxisRaw("Horizontal");
        vMovement = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));
        
        if (hMovement > 0f && vMovement == 0f) {
            rigidBody.velocity = new Vector2 (hMovement * speed, rigidBody.velocity.y);
        }
        else if (hMovement < 0f && vMovement == 0f) {
            rigidBody.velocity = new Vector2 (hMovement * speed, rigidBody.velocity.y);
        }
        else if (vMovement > 0f && hMovement == 0f) {
            rigidBody.velocity = new Vector2 (rigidBody.velocity.x, vMovement * speed);
        }
        else if (vMovement < 0f && hMovement == 0f) {
            rigidBody.velocity = new Vector2 (rigidBody.velocity.x, vMovement * speed);
        }  
        else {
            rigidBody.velocity = new Vector2 (0,rigidBody.velocity.y);
            rigidBody.velocity = new Vector2 (rigidBody.velocity.x,0);
        } 
    }
}
