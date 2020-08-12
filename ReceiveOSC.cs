using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveOSC : MonoBehaviour
{

    public OSC osc;
    public TextToSpeech tts;
    public string transcript;
    public string split;
    string phrase;
    

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
       
        words = words.Substring(words.IndexOf(transcript) + transcript.Length);
        words = words.Replace("\\n", "");
        words = words.Replace("\"", "");
        words = words.Replace("}", "");
        words = words.Replace("{", "");

        string[] phrase = words.Split("."[0]);
        words = phrase[0];

        words = words.Replace(".", " ");
        words = words.Replace("ESTRAGON", "    ");
        words = words.Replace("VLADIMIR", "    ");
        words = words.Replace("GUIL", "     ");
        words = words.Replace("ROS", "     ");
        words = words.Replace("Pause", " ");
        words = words.Replace("Mr Paradock", "     ");
        words = words.Replace("Mrs Paradock", " ");
 


        tts.dialogue = words;
        tts.Speak();
        Debug.Log(words);
    }

}
