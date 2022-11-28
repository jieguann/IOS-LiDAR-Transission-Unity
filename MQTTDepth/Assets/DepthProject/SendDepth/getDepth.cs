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

    public int depthImagePixelWidth;
    public int depthImagePixelHeight;
    public Slider depthSlider;



    void Start()
    {
        depthImagePixelWidth = 200;
        //colorImage = new Texture2D(256, 256, TextureFormat.RGBA4444, false);
    }
    // Update is called once per frame
    void Update()
    {
        //For depth Image
        /*
        if (depthImage != null) {
            depthImage = new Texture2D(depthImage.width, depthImage.height, TextureFormat.RGBA4444, false);
        }
        */

        //depthImage = image.m_DepthTextureFloat;
        depthImage = image.m_DepthTextureBGRA;
        //rawImage.texture = depthImage;
        //depthByte = depthImage.EncodeToJPG();
        depthImagePixelWidth = (int)depthSlider.value;
        depthImagePixelHeight = depthImagePixelWidth / 2;
        depthByte = Resize(depthImage, depthImagePixelWidth, depthImagePixelHeight).EncodeToJPG();

        //for color image -- 　Use this will use too much iphone ram and out of memory
        /*
        if(colorImage != null)
        {
            colorImage = new Texture2D(colorImage.width, colorImage.height, TextureFormat.RGBA4444, false);
        }
        */
        colorImage = image.m_CameraTexture;
        
        //colorByte = colorImage.EncodeToJPG();
        colorByte = Resize(colorImage, 50, 25).EncodeToJPG();



        //For human image
        /*
        if (humanImage != null)
        {
            humanImage = new Texture2D(humanImage.width, humanImage.height, TextureFormat.RGBA4444, false);
        }
        */

        humanImage = image.humanDepthTexture;
        //humanByte = humanImage.EncodeToJPG();
        humanByte = Resize(humanImage, depthImagePixelWidth, depthImagePixelHeight).EncodeToJPG();



    }

    //For reduce the size of the texture
    Texture2D Resize(Texture2D texture2D,int targetX,int targetY)
    {
        RenderTexture rt=new RenderTexture(targetX, targetY,24);
        RenderTexture.active = rt;
        Graphics.Blit(texture2D,rt);
        Texture2D result=new Texture2D(targetX,targetY);
        result.ReadPixels(new Rect(0,0,targetX,targetY),0,0);
        result.Apply();
        return result;
    }
}
