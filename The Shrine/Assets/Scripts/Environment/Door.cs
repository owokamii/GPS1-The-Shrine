using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject levelLoader;
    public Rock1 Rune1;
    public Rock1 Rune2;
    public Rock1 Rune3;

    public SpriteRenderer[] doorGlyph;
    public Sprite[] doorGlyphUnlit;
    public Sprite[] doorGlyphLit;

    public Animator animator;
    public ParticleSystem dust;
    public bool doorSFX = false;
    private bool glyphSFX1 = false;
    private bool glyphSFX2 = false;
    private bool glyphSFX3 = false;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Rune1.activatedRune1)
        {
            doorGlyph[0].sprite = doorGlyphLit[0];
            if(!glyphSFX1)
            {
                GlyphLitSFX();
                glyphSFX1 = true;
            }
        }
        else
        {
            doorGlyph[0].sprite = doorGlyphUnlit[0];
            glyphSFX1 = false;
        }

        if (Rune2.activatedRune2)
        {
            doorGlyph[1].sprite = doorGlyphLit[1];
            if (!glyphSFX2)
            {
                GlyphLitSFX();
                glyphSFX2 = true;
            }
        }
        else
        {
            doorGlyph[1].sprite = doorGlyphUnlit[1];
            glyphSFX2 = false;
        }

        if (Rune3.activatedRune3)
        {
            doorGlyph[2].sprite = doorGlyphLit[2];
            if (!glyphSFX3)
            {
                GlyphLitSFX();
                glyphSFX3 = true;
            }
        }
        else
        {
            doorGlyph[2].sprite = doorGlyphUnlit[2];
            glyphSFX3 = false;
        }

        if (Rune1.activatedRune1 && Rune2.activatedRune2 && Rune3.activatedRune3)
        {
            levelLoader.SetActive(true);
            animator.SetBool("TempleDoorUnlocked", true);

            if (!doorSFX)
            {
                audioManager.PlaySFX(audioManager.sfx[11]);
                CreateDust();
                doorSFX = true;
            }
        }
        else
        {
            doorSFX = false;
        }
    }

    void GlyphLitSFX()
    {
        audioManager.PlaySFX(audioManager.sfx[8]);
    }

    void CreateDust()
    {
        dust.Play();
        Invoke("StopDust", 2.5f);
    }

    void StopDust()
    {
        dust.Stop();
    }
}
