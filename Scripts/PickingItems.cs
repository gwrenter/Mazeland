using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickingItems : MonoBehaviour
{
    [SerializeField] GameObject VFXFlower;
    [SerializeField] GameObject VFXMushroom = null;
    [SerializeField] GameObject fireworks = null;
    [SerializeField] Transform flowerPos;
    [SerializeField] GameObject congratsText;
    [SerializeField] GameObject scoreText;
    [SerializeField] AudioClip flowerSound;
    [SerializeField] AudioClip heartSound;
    public static int gameScore = 0;
    public static int numLives = 0;
    private AudioSource audioSrc;
    
    void Start(){
        audioSrc = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        VFXFlower.SetActive(false);
        if(collision.gameObject.tag == "Flower"){
            flowerPos.transform.position = collision.gameObject.transform.position;
            VFXFlower.SetActive(true);
            audioSrc.PlayOneShot(flowerSound);
            Destroy(collision.gameObject);
            Debug.Log(gameScore);
            gameScore += 5;
        }
        if(collision.gameObject.tag == "Life"){
            audioSrc.PlayOneShot(heartSound);
            Destroy(collision.gameObject);
            Debug.Log(gameScore);
            numLives += 1;
        }
        VFXMushroom.SetActive(false);
        if(collision.gameObject.tag == "Mushroom"){
            audioSrc.PlayOneShot(flowerSound);
            VFXMushroom.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Congrats"){
            fireworks.SetActive(true);
            congratsText.SetActive(true);
            scoreText.SetActive(false);
        }   
    }
}
