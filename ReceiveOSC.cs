using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveOSC : MonoBehaviour
{

    public OSC osc;

    // Start is called before the first frame update
    void Start()
    {
        osc.SetAddressHandler("/data", OnData);
        osc.SetAllMessageHandler(OnReceiveAnything);
    }

    // Update is called once per frame
    void OnReceiveAnything(OscMessage message)
    {
        Debug.Log("I GOT ONE!!!");
    }

    void OnData(OscMessage message)
    {
        string words = message.ToString();
        words = words.Substring(words.IndexOf("\\n"));
        words = words.Replace("\\n", "");
        words = words.Replace("\"", "");
        words = words.Replace("}", "");
        words = words.Replace("{", "");

        Debug.Log(words);
    }

}
