using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class getDepth : MonoBehaviour
{
    public DepthScript image;
    public byte[] depthByte;
    //public RawImage rawImage;
    public Texture2D depthImage;
    // Start is called before the first frame update
    void Start()
    {
        //depthImage = new Texture2D(depthImage.width, depthImage.width, TextureFormat.RGB24, false);
    }

    // Update is called once per frame
    void Update()
    {if(depthImage != null) {
            depthImage = new Texture2D(depthImage.width, depthImage.height, TextureFormat.RGBA32, false);
        }

        //depthImage = image.m_DepthTextureFloat;
        depthImage = image.m_DepthTextureBGRA;
        //rawImage.texture = depthImage;
        depthByte = depthImage.EncodeToPNG();


    }
}
