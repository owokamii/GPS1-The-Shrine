using UnityEngine;

public class ShrineDoor : MonoBehaviour
{
    public Torch torch;
    public GameObject[] torches;
    int pos, pos1, pos2, pos3, pos4, order = 0;
    bool torch1Triggered, torch2Triggered, torch3Triggered, torch4Triggered;

    void Update()
    {
        Torch torch1 = torches[0].GetComponent<Torch>();
        Torch torch2 = torches[1].GetComponent<Torch>();
        Torch torch3 = torches[2].GetComponent<Torch>();
        Torch torch4 = torches[3].GetComponent<Torch>();

        if(Input.GetKeyDown(KeyCode.Space))
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
            
            if(torch1Triggered && torch2Triggered && torch3Triggered && torch4Triggered)
            {
                if (pos3 == 3 && pos2 == 2 && pos4 == 4 && pos1 == 1)
                {
                    Debug.Log("everything correct");
                    pos1 = pos2 = pos3 = pos4 = order = 0;
                    torch1Triggered = false;
                    torch2Triggered = false;
                    torch3Triggered = false;
                    torch4Triggered = false;

                    torch1.isTriggered = false;
                    torch2.isTriggered = false;
                    torch3.isTriggered = false;
                    torch4.isTriggered = false;
                    torch.TriggerTorch();

                }
            }

/*            if (torch2.isTriggered)
            {
                Debug.Log("correct2");
            }
            if (torch4.isTriggered)
            {
                Debug.Log("correct4");
            }
            if (torch1.isTriggered)
            {
                Debug.Log("correct1");
            }*/

            /*if(order == 3)
            {
                order++;
                if(pos2 == 2)
                {
                    if(pos3 == 4)
                    {
                        if(pos4 == 1)
                        {

                        }
                    }
                }
            }*/
        }
    }

    /* void Update()
     {
         if (torch.)
         {
             doorGlyph[0].sprite = doorGlyphLit[0];
             if (!glyphSFX1)
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
             doorSprite.sprite = doorOpen;
             door.enabled = false;

             if (!doorSFX)
             {
                 Invoke("DoorSFX", 0.5f);
                 doorSFX = true;
             }
         }*/
}
