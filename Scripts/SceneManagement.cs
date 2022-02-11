using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] string sceneName = null;
    public static int numLevel = 1;

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Mushroom"){
            StartCoroutine(WaitSceneChange());
        }
    }

    private IEnumerator WaitSceneChange(){
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
        numLevel += 1;
    }
}
