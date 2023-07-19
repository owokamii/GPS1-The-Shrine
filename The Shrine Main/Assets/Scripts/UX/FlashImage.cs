using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class FlashImage : MonoBehaviour
{
    Image _image = null;
    Coroutine _currentFlashRoutine = null;

    private void Awake()
    {
        
        _image = GetComponent<Image>();
    }

    public void StartFlash(float secondsForOneFlash, float maxAplha, Color newColor)
    {
        _image.color = newColor;

        //ensure maxAplha isn't above 1
        maxAplha = Mathf.Clamp(maxAplha, 0, 1);


        if (_currentFlashRoutine != null)

            StopCoroutine(_currentFlashRoutine);
        _currentFlashRoutine = StartCoroutine(Flash(secondsForOneFlash, maxAplha));

    }

    //IEnumerator Flash(float secondsForOneFlash, float maxAlpha)
    //{

    //        //animate the flash in
    //        float flashInDuration = secondsForOneFlash / 2;
    //        for (float t = 0; t <= flashInDuration; t += Time.deltaTime)
    //        {
    //            //create a new color change
    //            Color colorThisFrame = _image.color;
    //            colorThisFrame.a = Mathf.Lerp(0, maxAlpha, t / flashInDuration);
    //            //apply it
    //            _image.color = colorThisFrame;
    //            //wait until the next frame 
    //            yield return null;
    //        }
    //        //animate the flash out
    //        float flashOutDuration = secondsForOneFlash / 2;
    //        for (float t = 0; t <= flashOutDuration; t += Time.deltaTime)
    //        {
    //            Color colorThisFrame = _image.color;
    //            colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, t / flashOutDuration);
    //            _image.color = colorThisFrame;
    //            yield return null;
    //        }

    //        //ensure alpha is set to 0
    //        _image.color = new Color32(0, 0, 0, 0);

    //}
    IEnumerator Flash(float secondsForOneFlash, float maxAlpha)
    {
        //while (true)
        //{
            // animate the flash in
            float flashInDuration = secondsForOneFlash / 2;
            for (float t = 0; t <= flashInDuration; t += Time.deltaTime)
            {
                Color colorThisFrame = _image.color;
                colorThisFrame.a = Mathf.Lerp(0, maxAlpha, t / flashInDuration);
                _image.color = colorThisFrame;
                yield return null;
            }

            // animate the flash out
            float flashOutDuration = secondsForOneFlash / 2;
            for (float t = 0; t <= flashOutDuration; t += Time.deltaTime)
            {
                Color colorThisFrame = _image.color;
                colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, t / flashOutDuration);
                _image.color = colorThisFrame;
                yield return null;
            }

            _image.color = new Color32(0, 0, 0, 0);

            yield return new WaitForSeconds(4f); // Wait for 3 seconds before starting the next flash
        //}
         //FindObjectOfType<AudioManager>().Play("Heartbeat");
    }


}
