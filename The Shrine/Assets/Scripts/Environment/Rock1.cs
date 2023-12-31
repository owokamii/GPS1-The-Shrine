using System.Collections.Generic;
using UnityEngine;

public class Rock1 : MonoBehaviour
{
    public Sprite[] runes;
    public Sprite[] glyphLit;
    public SpriteRenderer currentSprite;
    public int currentIndex = 0;

    private bool isTriggered;
    public bool activatedRune1 = false;
    public bool activatedRune2 = false;
    public bool activatedRune3 = false;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void TriggerRock1()
    {
        if (!isTriggered)
        {
            if (currentIndex != 2)
            {
                currentIndex += 1;
            }
            else
            {
                currentIndex = 0;
            }

            currentSprite.sprite = runes[currentIndex];

            if (currentIndex != 0)
            {
                activatedRune1 = false;
            }

            else
            {
                activatedRune1 = true;
                currentSprite.sprite = glyphLit[currentIndex];
            }
        }
    }

    public void TriggerRunePillar2()
    {
        if (!isTriggered)
        {
            if (currentIndex != 2)
            {
                currentIndex += 1;
            }
            else
            {
                currentIndex = 0;
            }

            currentSprite.sprite = runes[currentIndex];

            if (currentIndex != 1)
            {
                activatedRune2 = false;
            }

            else
            {
                activatedRune2 = true;
                currentSprite.sprite = glyphLit[currentIndex];
            }
        }
    }

    public void TriggerRunePillar3()
    {
        if (!isTriggered)
        {
            if (currentIndex != 2)
            {
                currentIndex += 1;
            }
            else
            {
                currentIndex = 0;
            }

            currentSprite.sprite = runes[currentIndex];


            if (currentIndex != 2)
            {
                activatedRune3 = false;          }

            else
            {
                activatedRune3 = true;
                currentSprite.sprite = glyphLit[currentIndex];
            }
        }
    }
}
