using UnityEngine;

public class LevelReset : MonoBehaviour
{
    public GameObject crate1;
    Vector2 crate1SpawnPoint;
    Vector2 crate1CurrentPoint;

    private bool activated1;

    void Start()
    {
        crate1SpawnPoint = transform.position;
    }

    void Update()
    {
        crate1CurrentPoint = transform.position;
    }
}
