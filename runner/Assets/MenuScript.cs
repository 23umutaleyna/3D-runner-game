using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    float counter = 0f;
    void Start()
    {
        scoreText.text = "0";
    }

    void Update()
    {
        counter += Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(counter).ToString();
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }
}

