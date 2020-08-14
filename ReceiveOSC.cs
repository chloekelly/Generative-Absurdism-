using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ReceiveOSC : MonoBehaviour
{

    public OSC osc;
    public TextToSpeech tts;
    public string transcript;
    public string split;
    string phrase;
    public int timer;
    bool u1 = true;
    bool u2 = true;
    public int messageno;
    string input;
    public string output;
    public TextMeshProUGUI caption;
    public float captiontime;
    bool noone = false;
   

    // Start is called before the first frame update
    void Start()
    {
        osc.SetAddressHandler("/data", OnData);
        osc.SetAllMessageHandler(OnReceiveAnything);
        timer = 0;
        messageno = 2;
    }

    private void Update()
    {
        captiontime -= Time.deltaTime;
        if(captiontime < 0)
        {
            caption.text = "";
        }

        tts.noone = noone;

    }

    // Update is called once per frame
    void OnReceiveAnything(OscMessage message)
    {
        Debug.Log("I GOT ONE!!!");

        
        timer++;
        Debug.Log("Recieved Message " + timer + " of " + messageno);

        if (timer >= messageno)
        {
            messageno = Random.Range(3, 9);

           
            if (Random.Range(0, 100) > 50)
            {

                if (u1)
                {
                    tts.dialogue = "User 1 leaves the stage";
                    u1 = false;

                }

                else
                {
                    tts.dialogue = "User 1 enters the stage";
                    u1 = true;
                    noone = false;
                }
            }

            else
            {
                if (u2)
                {
                    tts.dialogue = "User 2 leaves the stage";
                    u2 = false;

                }

                else
                {
                    tts.dialogue = "User 2 enters the stage";
                    u2 = true;
                    noone = false;
                    
                }

            }

            

            tts.Speak();
            timer = 0;
        }
        if (!u1 && !u2)
        {
            tts.dialogue = "Where has everybody gone";
            tts.noone = true;
            tts.Speak();
            noone = true;

        }
        
    }

    void OnData(OscMessage message)

    {
       

       
        string words = message.ToString();
        words = words.Substring(words.IndexOf(transcript) + transcript.Length);
        words = words.Replace("\\n", "");
        words = words.Replace("\"", "");
        words = words.Replace("}", "");
        words = words.Replace("{", "");

        output = words;
        if (output.Contains("("))
        {
            string[] input = output.Split('(', ')');
            output = input[1];
            caption.text = "(" + output + ")";
            captiontime = 8f;

        }

        string[] phrase = words.Split("."[0]);
        words = phrase[0];
     

        if (words.Length < 10)
        {
            words = phrase[1];
        }

        words = words.Replace(".", " ");
        words = words.Replace("Hamm", " ");
        words = words.Replace("ESTRAGON", "    ");
        words = words.Replace("VLADIMIR", "    ");
        words = words.Replace("GUIL", "     ");
        words = words.Replace("ROS", "     ");
        words = words.Replace("Pause", " ");
        words = words.Replace("Mr Paradock", "     ");
        words = words.Replace("Mrs Paradock", " ");
        words = words.Replace("no, no, no, no,", "no");
        words = words.Replace("no, no, no, no,", "no");
        words = words.Replace("no, no, no, no,", "no");
        words = words.Replace("no, no, no, no,", "no");


        tts.dialogue = words;
        tts.Speak();
        Debug.Log(words);
    }

}

