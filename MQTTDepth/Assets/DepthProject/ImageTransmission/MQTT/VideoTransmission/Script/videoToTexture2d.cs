using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class videoToTexture2d : MonoBehaviour
{
    public RawImage m_RawImage;


    //Textrure initialize
    //For video Testing value
    public RenderTexture renderTexture;
    Texture2D videoTexture;

    public Texture2D textureToSend;
    public byte[] ImageBytes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_RawImage.texture = textureToSend;
        videoTexture = toTexture2D(renderTexture);

        //Enable this when testing video
        textureToSend = videoTexture;

        ImageBytes = textureToSend.EncodeToPNG();
    }

    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(512, 512, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }

}
