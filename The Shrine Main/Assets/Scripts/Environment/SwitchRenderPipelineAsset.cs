using UnityEngine;
using UnityEngine.Rendering;

public class SwitchRenderPipelineAsset : MonoBehaviour
{
    public RenderPipelineAsset urp2D;

    void Start()
    {
        GraphicsSettings.renderPipelineAsset = urp2D;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("s key entered");
            GraphicsSettings.renderPipelineAsset = urp2D;
            Debug.Log("Active render pipeline asset is: " + GraphicsSettings.renderPipelineAsset.name);
            Debug.Log("bla blah blah");
        }
    }
}
