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
            GraphicsSettings.renderPipelineAsset = urp2D;
    }
}
