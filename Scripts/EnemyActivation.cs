using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyActivation : MonoBehaviour
{
    [SerializeField] SpriteRenderer sp = null;
    [SerializeField] Sprite awakeEnemy = null;
    [SerializeField] Sprite eatingEnemy = null;
    [SerializeField] Sprite sleepingEnemy = null;
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject enemy = null;
    [SerializeField] GameObject VFXDead = null;
    [SerializeField] GameObject VFXLostLife = null;
    [SerializeField] GameObject VFXBomb = null;
    [SerializeField] AudioClip eatingApple;
    [SerializeField] AudioClip bombSound;
    [SerializeField] bool firstActivation;
    [SerializeField] Vector2 playerPos;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] Transform bombPos;
    [SerializeField] GameObject retryScreen;
    bool secondActivation = false;
    bool eating = false;
    private AudioSource audioSrc;
    

    void Start(){
        audioSrc = GetComponent<AudioSource>();
        if(firstActivation){
            sp.sprite = awakeEnemy;
            secondActivation = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player" && !eating){
            firstActivation = true;
            if(firstActivation && !secondActivation){
                Debug.Log("Here now");
                sp.sprite = awakeEnemy;
                secondActivation = true;
            }
            else if(firstActivation && secondActivation){
                Debug.Log("Here");
                StartCoroutine(WaitToChangeState());
            }
        }

        if(firstActivation && collision.gameObject.tag == "Apple"){
            audioSrc.PlayOneShot(eatingApple);
            Destroy(collision.gameObject, 0.05f);
            firstActivation = true;
            secondActivation = true;
            sp.sprite = eatingEnemy;
            StartCoroutine(WaitWhileEating());
        }

        VFXBomb.SetActive(false);
        if(collision.gameObject.tag == "Bomb"){
            Destroy(enemy, 5f);
            StartCoroutine(WaitToExplode());
            bombPos.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject, 5f);
        }
    }
    private IEnumerator WaitToChangeState(){
        yield return new WaitForSeconds(0.5f);
        //Destroy player after colliding again with enemy trigger
        player.SetActive(false);

        if(PickingItems.numLives > 0){
            VFXLostLife.SetActive(true);
            PickingItems.numLives--;
            player.transform.position = playerPos;
            Debug.Log(playerPos);
            player.SetActive(true);
        }
        else{
            VFXDead.SetActive(true);
            scoreText.SetActive(false);
            gameOverText.SetActive(true);
            Debug.Log("Game Over!");
            retryScreen.SetActive(true);
        }
    }

    private IEnumerator WaitWhileEating(){
        eating = true;
        Debug.Log("eating is true");
        yield return new WaitForSeconds(10);
        eating = false;
        Debug.Log("eating is false");
        sp.sprite = awakeEnemy;
    }

    private IEnumerator WaitToExplode(){
        audioSrc.PlayDelayed(4.6f);
        yield return new WaitForSeconds(4.9f);
        VFXBomb.SetActive(true);
    }

    public void PlayGame(){
        SceneManager.LoadScene("Level 1");
        PickingItems.gameScore = 0;
        SceneManagement.numLevel = 1;
    }

    public void QuitGame(){
        Application.Quit();
    }
}
