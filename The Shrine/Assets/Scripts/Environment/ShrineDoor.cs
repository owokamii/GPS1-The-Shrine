using UnityEngine;

public class ShrineDoor : MonoBehaviour
{
    public GameObject Door;
    public Torch[] torch;
    public GameObject[] torches;
    int pos, pos1, pos2, pos3, pos4, order = 0;
    bool torch1Triggered, torch2Triggered, torch3Triggered, torch4Triggered;
    bool shrineDoorTriggered;
    public Transform target;
    public ParticleSystem dust;
    float doorSpeed = 1.1f;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        Torch torch1 = torches[0].GetComponent<Torch>();
        Torch torch2 = torches[1].GetComponent<Torch>();
        Torch torch3 = torches[2].GetComponent<Torch>();
        Torch torch4 = torches[3].GetComponent<Torch>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pos 1: " + pos1);
            Debug.Log("pos 2: " + pos2);
            Debug.Log("pos 3: " + pos3);
            Debug.Log("pos 4: " + pos4);
        }

        if (pos >= 0 && pos < torches.Length)
        {
            if (torch3.isTriggered)
            {
                if (!torch3Triggered)
                {
                    order++;
                    pos1 = order;
                    torch3Triggered = true;
                }
            }
            if (torch2.isTriggered)
            {
                if (!torch2Triggered)
                {
                    order++;
                    pos2 = order;
                    torch2Triggered = true;
                }
            }
            if (torch4.isTriggered)
            {
                if (!torch4Triggered)
                {
                    order++;
                    pos3 = order;
                    torch4Triggered = true;
                }
            }
            if (torch1.isTriggered)
            {
                if (!torch1Triggered)
                {
                    order++;
                    pos4 = order;
                    torch1Triggered = true;
                }
            }

            if (torch1Triggered && torch2Triggered && torch3Triggered && torch4Triggered)
            {
                if (pos3 == 3 && pos2 == 2 && pos4 == 4 && pos1 == 1)
                {
                    Debug.Log("everything correct");
                    Door.SetActive(true);
                    Vector3 closed = transform.position;
                    Vector3 opened = target.position;
                    float ds = doorSpeed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(closed, opened, ds); //0.0054
                    if(!shrineDoorTriggered)
                    {
                        audioManager.PlaySFX(audioManager.sfx[6]);
                        CreateDust();
                        shrineDoorTriggered = true;
                    }

                }
                else
                {
                    ResetTorchPuzzle();
                    pos1 = pos2 = pos3 = pos4 = order = 0;
                }

            }
        }
    }

    void ResetTorchPuzzle()
    {
        torch[0].TriggerTorch();
        torch[1].TriggerTorch();
        torch[2].TriggerTorch();
        torch[3].TriggerTorch();
        torch1Triggered = false;
        torch2Triggered = false;
        torch3Triggered = false;
        torch4Triggered = false;
    }

    void CreateDust()
    {
        dust.Play();
        Invoke("StopDust", 5f);
    }

    void StopDust()
    {
        dust.Stop();
    }
}
