using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPrompt : MonoBehaviour
{
    public OSC osc;

    public ReceiveOSC receiver;
    public string[] messages;

    //m_MyEvent.AddListener(onFinalResult);

    private void Start()
    {
        
    }

    public void Send(string transcript)
    {
        OscMessage message;



        message = new OscMessage();
        message.address = "/query";
        message.values.Add("{\"prompt\":\"" + transcript + "\"}");
        osc.Send(message);
        receiver.transcript = transcript;

        Debug.Log("sent");



    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("k"))
        {
            OscMessage connect;

            connect = new OscMessage();
            connect.address = "/server/connect";
            osc.Send(connect);
            Debug.Log("sent connect message");
        }



        if (Input.GetKeyDown("space"))
        {
          

        }


    }


}