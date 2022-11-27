using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using M2MqttUnity.Examples;
using UnityEngine.UI;

public class mqttPublish : MonoBehaviour
{
    public Button button;
    public MQTTTest mqtt;

    // Start is called before the first frame update
    void Start()
    {
        //button = GetComponent<Button>();
        StartCoroutine(waiter());

    }

    IEnumerator waiter()
    {
            yield return new WaitForSeconds(2f);
       
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                //button = GetComponent<Button>();
                button.onClick.Invoke();

            }
        
       

    }

    // Update is called once per frame
    void Update()
    {
        //button = GetComponent<Button>();
        //button.onClick.Invoke();
    }
}
