
using UnityEngine;

using M2MqttUnity.Examples;
public class ByteToImage : MonoBehaviour
{
    public MQTTTest mqtt;
    
    // Start is called before the first frame update
    private void Start()
    {
        
        //Texture2D tex = new Texture2D(16, 16, TextureFormat.PVRTC_RGBA4, false);
    }
    public void Update()
    {

        // Create a 16x16 texture with PVRTC RGBA4 format
        // and fill it with raw PVRTC bytes.

        // Raw PVRTC4 data for a 16x16 texture. This format is four bits
        // per pixel, so data should be 16*16/2=128 bytes in size.
        // Texture that is encoded here is mostly green with some angular
        // blue and red lines.
        Texture2D tex = new Texture2D(16, 16, TextureFormat.RGBA32, false);
        tex.LoadRawTextureData(mqtt.receiveByte);
        tex.Apply();
        // Assign texture to renderer's material.
        GetComponent<Renderer>().material.mainTexture = tex;
    }
}
