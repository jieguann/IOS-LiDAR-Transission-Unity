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
<<<<<<< HEAD

    //For camera color image
    public byte[] colorByte;
    public Texture2D colorImage;

    //For human depth image
    public byte[] humanByte;
    public Texture2D humanImage;

=======
>>>>>>> parent of f5d22e2... Add color image to getpixel
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


<<<<<<< HEAD
        //For camera color image
        if(colorImage != null)
        {
            colorImage = new Texture2D(colorImage.width, colorImage.height, TextureFormat.RGBA32, false);
        }
        colorImage = image.m_CameraTexture;
        colorByte = colorImage.EncodeToPNG();


        //For human depth image
        if (humanImage != null)
        {
            humanImage = new Texture2D(humanImage.width, humanImage.height, TextureFormat.RGBA32, false);
        }
        humanImage = image.humanDepthTexture;
        humanByte = humanImage.EncodeToPNG();


=======
>>>>>>> parent of f5d22e2... Add color image to getpixel
    }
}
