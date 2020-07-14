using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPrompt : MonoBehaviour
{
    public OSC osc;


    public string[] messages;

    private void Start()
    {
        
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
            OscMessage message;



            message = new OscMessage();
            message.address = "/query";
            message.values.Add("{\"prompt\":\"" +  messages[Random.Range(0,4)] + "\"}");
            osc.Send(message);

            Debug.Log("sent");

        }


    }


}