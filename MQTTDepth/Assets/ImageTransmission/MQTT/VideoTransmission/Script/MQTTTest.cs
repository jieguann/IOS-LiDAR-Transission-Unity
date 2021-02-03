using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using M2MqttUnity;
using System.Diagnostics;
using System.Runtime.InteropServices;
//using LitJson;

/// <summary>
/// Examples for the M2MQTT library (https://github.com/eclipse/paho.mqtt.m2mqtt),
/// Explaration http://blog.jorand.io/2017/08/02/MQTT-on-Unity/
/// </summary>
namespace M2MqttUnity.Examples
{
    /// <summary>
    /// Script for testing M2MQTT with a Unity UI
    /// </summary>
    public class MQTTTest : M2MqttUnityClient
    {
        public getDepth depth;
        public byte[] DepthByte,ColorByte, HumanByte;
        [Tooltip("Set this to true to perform a testing cycle automatically on startup")]
        public bool autoTest = false;
       

        private List<string> eventMessages = new List<string>();
        private bool updateUI = false;
        //private JsonData Data;

        public string topic1;
        public string topic2;
        public string topic3;


        public float sensor1;
        public float sensor2;
        public float light;
        public byte[] receiveByte;


        public void TestPublish()
        {
            
            //client.Publish("M2MQTT_Unity/test", System.Text.Encoding.UTF8.GetBytes("Test message"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            client.Publish("teletouch/depthImage", DepthByte, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            client.Publish("teletouch/colorImage", ColorByte, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            client.Publish("teletouch/humanImage", HumanByte, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

            //print("Test message published");
            //AddUiMessage("Test message published.");
        }

        public void SetBrokerAddress(string brokerAddress)
        {/*
            if (addressInputField && !updateUI)
            {
                this.brokerAddress = brokerAddress;
            }
            */
        }

        public void SetBrokerPort(string brokerPort)
        {/*
            if (portInputField && !updateUI)
            {
                int.TryParse(brokerPort, out this.brokerPort);
            }
            */
        }

        public void SetEncrypted(bool isEncrypted)
        {
            this.isEncrypted = isEncrypted;
        }

        /*
        public void SetUiMessage(string msg)
        {
            if (consoleInputField != null)
            {
                consoleInputField.text = msg;
                updateUI = true;
            }
        }

        public void AddUiMessage(string msg)
        {
            if (consoleInputField != null)
            {
                consoleInputField.text += msg + "\n";
                updateUI = true;
            }
        }
        */
        protected override void OnConnecting()
        {
            base.OnConnecting();
            //SetUiMessage("Connecting to broker on " + brokerAddress + ":" + brokerPort.ToString() + "...\n");
            
        }

        protected override void OnConnected()
        {
            base.OnConnected();
            //while (true) { }
            //TestPublish();
            //client.Publish("jie/guan", byteToSend, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

            //SetUiMessage("Connected to broker on " + brokerAddress + "\n");
            /*
            if (autoTest)
            {
                TestPublish();
            }
            */
        }

        protected override void SubscribeTopics()
        {
            client.Subscribe(new string[] { "teletouch/depthImage" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "teletouch/colorImage" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "teletouch/humanImage" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

        }

        protected override void UnsubscribeTopics()
        {
            //client.Unsubscribe(new string[] { "M2MQTT_Unity/test" });
        }

        protected override void OnConnectionFailed(string errorMessage)
        {
            //AddUiMessage("CONNECTION FAILED! " + errorMessage);
        }

        protected override void OnDisconnected()
        {
            //AddUiMessage("Disconnected.");
        }

        protected override void OnConnectionLost()
        {
            //AddUiMessage("CONNECTION LOST!");
        }
        /*
        private void UpdateUI()
        {
            if (client == null)
            {
                if (connectButton != null)
                {
                    connectButton.interactable = true;
                    disconnectButton.interactable = false;
                    testPublishButton.interactable = false;
                }
            }
            else
            {
                if (testPublishButton != null)
                {
                    testPublishButton.interactable = client.IsConnected;
                }
                if (disconnectButton != null)
                {
                    disconnectButton.interactable = client.IsConnected;
                }
                if (connectButton != null)
                {
                    connectButton.interactable = !client.IsConnected;
                }
            }
            if (addressInputField != null && connectButton != null)
            {
                addressInputField.interactable = connectButton.interactable;
                addressInputField.text = brokerAddress;
            }
            if (portInputField != null && connectButton != null)
            {
                portInputField.interactable = connectButton.interactable;
                portInputField.text = brokerPort.ToString();
            }
            if (encryptedToggle != null && connectButton != null)
            {
                encryptedToggle.interactable = connectButton.interactable;
                encryptedToggle.isOn = isEncrypted;
            }
            if (clearButton != null && connectButton != null)
            {
                clearButton.interactable = connectButton.interactable;
            }
            updateUI = false;
        }
        */
        protected override void Start()
        {
            Connect();
            //SetUiMessage("Ready.");
            //updateUI = true;
            base.Start();
        }

        protected override void DecodeMessage(string topic, byte[] message)
        {
            string msg = System.Text.Encoding.UTF8.GetString(message);
            
            StoreMessage(msg);
            //Data = JsonMapper.ToObject(msg);

            if (topic == "teletouch/depthImage")
            {
                //print("1: " + Single.Parse(msg));
                //print(msg.GetType());


                receiveByte = message;
            }

            if (topic == "teletouch/colorImage")
            {
                //print("1: " + Single.Parse(msg));
                //print(msg.GetType());
                //sensor2 = Single.Parse(msg);
                //print("topic2: " + sensor2);

                //receiveByte = message;
            }

            if (topic == "teletouch/humanImage")
            {
                //print("1: " + Single.Parse(msg));
                //print(msg.GetType());
                //light = Single.Parse(msg);
                //print("light: " + light);

                //receiveByte = message;
            }

        }

        private void StoreMessage(string eventMsg)
        {
            eventMessages.Add(eventMsg);
        }

        private void ProcessMessage(string msg)
        {
            //AddUiMessage("Received: " + msg);
            print(msg);
        }
        
        protected override void Update()
        {
            base.Update(); // call ProcessMqttEvents()
            DepthByte = depth.depthByte;
            ColorByte = depth.colorByte;
            HumanByte = depth.humanByte;
            
            //TestPublish();
            //ProcessMessage(msg);
            /*
            if (eventMessages.Count > 0)
            {
                foreach (string msg in eventMessages)
                {
                    ProcessMessage(msg);
                }
                eventMessages.Clear();
            }
            */
            /*
            if (updateUI)
            {
                UpdateUI();
            }
            */
        }

        private void OnDestroy()
        {
            Disconnect();
        }

        private void OnValidate()
        {
            if (autoTest)
            {
                autoConnect = true;
            }
        }
    }
}