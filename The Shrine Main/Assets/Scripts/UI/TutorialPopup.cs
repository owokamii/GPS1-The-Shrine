using UnityEngine;

public class TutorialPopup : MonoBehaviour
{
    public GameObject thirstTutorial;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            thirstTutorial.SetActive(true);
        }
    }
}
