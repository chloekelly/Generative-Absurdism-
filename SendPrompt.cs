using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPrompt : MonoBehaviour
{
    public OSC osc;


    // Start is called before the first frame update
    void Start()
    {
        osc.SetAddressHandler("/data", OnReceiveText);
    }


    void OnReceiveText(OscMessage message)
    {
        Debug.Log("received!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            OscMessage message;

            message = new OscMessage();
            message.address = "/server/connect";
            osc.Send(message);


            message = new OscMessage();
            message.address = "/query";
            message.values.Add("{\"prompt\":\"I have no pennies.\"}");
            osc.Send(message);

            Debug.Log("sent");

            OscMessage recievee;

            recievee = new OscMessage();
            recievee.address = "/data";
            recievee.("generated_text" );
            osc.Send(message);

            Debug.Log("generated_text");

        }


    }

 
}
