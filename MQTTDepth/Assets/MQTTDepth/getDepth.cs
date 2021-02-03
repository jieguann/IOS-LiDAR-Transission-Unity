using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class getDepth : MonoBehaviour
{
    public DepthScript image;
    //Setup byte and texture2d
    public byte[] depthByte,colorByte,humanByte;
    public Texture2D depthImage, colorImage, humanImage;
    

    // Update is called once per frame
    void Update()
    {
        //For depth Image
        /*
        if (depthImage != null) {
            depthImage = new Texture2D(depthImage.width, depthImage.height, TextureFormat.RGB24, false);
        }
        */

        //depthImage = image.m_DepthTextureFloat;
        depthImage = image.m_DepthTextureBGRA;
        //rawImage.texture = depthImage;
        depthByte = depthImage.EncodeToJPG();


        //for color image -- 　Use this will use too much iphone ram and out of memory
        /*
        if(colorImage != null)
        {
            colorImage = new Texture2D(colorImage.width, colorImage.height, TextureFormat.RGB24, false);
        }
        */
        colorImage = image.m_CameraTexture;
        colorByte = colorImage.EncodeToJPG();
        
        

        //For human image
        /*
        if (humanImage != null)
        {
            humanImage = new Texture2D(humanImage.width, humanImage.height, TextureFormat.RGBA32, false);
        }
        */
       
        humanImage = image.humanDepthTexture;
        humanByte = humanImage.EncodeToJPG();



    }
}
