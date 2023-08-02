using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public bool mainMenu;
    public bool inGame;

    void OnEnable()
    {
        if(inGame)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else if(mainMenu)
            SceneManager.LoadScene("MainMenu");
    }

    public void SkipButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}