using UnityEngine;

public class TutorialPopup : MonoBehaviour
{
    public GameObject tutorialMenu;
    bool tutorialScreenOn = false;
    bool isTriggered = false;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (tutorialScreenOn)
            if (Input.GetButtonDown("Interact"))
                TutorialScreenOff();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Immortal")) && !isTriggered)
        {
            isTriggered = true;
            TutorialScreenOn();
        }
    }

    void TutorialScreenOn()
    {
        Time.timeScale = 0f;
        tutorialScreenOn = true;
        tutorialMenu.SetActive(true);
        audioManager.PlaySFX(audioManager.sfx[4]);
    }

    void TutorialScreenOff()
    {
        Time.timeScale = 1f;
        tutorialScreenOn = false;
        tutorialMenu.SetActive(false);
        audioManager.PlaySFX(audioManager.sfx[1]);
    }
}
