using UnityEngine;

public class Door : MonoBehaviour
{
    public BoxCollider2D door;
    public Rock1 Rune1;
    public Rock1 Rune2;
    public Rock1 Rune3;

    public SpriteRenderer[] doorGlyph;
    public Sprite[] doorGlyphUnlit;
    public Sprite[] doorGlyphLit;

    public SpriteRenderer doorSprite;
    public Sprite doorOpen;
    private bool doorSFX = false;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Rune1.activatedRune1)
        {
            Debug.Log("rune 1 correct");
            doorGlyph[0].sprite = doorGlyphLit[0];
        }
        else
        {
            doorGlyph[0].sprite = doorGlyphUnlit[0];
        }

        if (Rune2.activatedRune2)
        {
            Debug.Log("rune 2 correct");
            doorGlyph[1].sprite = doorGlyphLit[1];
        }
        else
        {
            doorGlyph[1].sprite = doorGlyphUnlit[1];
        }

        if (Rune3.activatedRune3)
        {
            Debug.Log("rune 3 correct");
            doorGlyph[2].sprite = doorGlyphLit[2];
        }
        else
        {
            doorGlyph[2].sprite = doorGlyphUnlit[2];
        }

        if (Rune1.activatedRune1 && Rune2.activatedRune2 && Rune3.activatedRune3)
        {
            doorSprite.sprite = doorOpen;
            door.enabled = false;

            if(!doorSFX)
            {
                Invoke("DoorSFX", 1);
                doorSFX = true;
            }
        }
    }

    void DoorSFX()
    {
        audioManager.PlaySFX(audioManager.sfx[9]);
    }
}
