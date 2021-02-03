using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class getDepth : MonoBehaviour
{   
    public DepthScript image;

    //For depth environment image
    public byte[] depthByte;
    public Texture2D depthImage;

    //For camera color image
    public byte[] colorByte;
    public Texture2D colorImage;

    // Start is called before the first frame update
    void Start()
    {
        //depthImage = new Texture2D(depthImage.width, depthImage.width, TextureFormat.RGB24, false);
    }

    // Update is called once per frame
    void Update()
    {
        //For depth environment depth
        if(depthImage != null) {
            depthImage = new Texture2D(depthImage.width, depthImage.height, TextureFormat.RGBA32, false);
        }

        //depthImage = image.m_DepthTextureFloat;
        depthImage = image.m_DepthTextureBGRA;
        //rawImage.texture = depthImage;
        depthByte = depthImage.EncodeToPNG();


        //For camera color image
        if(colorImage != null)
        {
            colorImage = new Texture2D(colorImage.width, depthImage.height, TextureFormat.RGBA32, false);
        }
        colorImage = image.m_CameraTexture;


    }
}
