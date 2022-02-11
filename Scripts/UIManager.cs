using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText = null;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Level: " + SceneManagement.numLevel.ToString() +
                         "       Score: " + PickingItems.gameScore.ToString() + 
                         "       Lives: " + PickingItems.numLives.ToString();
    }
}
