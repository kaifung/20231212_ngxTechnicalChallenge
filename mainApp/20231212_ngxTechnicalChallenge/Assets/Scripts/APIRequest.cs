using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

namespace extOSC.Examples
{
    public class APIRequest : MonoBehaviour
    {
        public OSCMessageTransmitter OSC_Transmitter;
        public GameObject TestLog;
        private string apiContent;
        private string publicAPIURL_1 ;
        private string publicAPIURL_2 ;
    void Start()
        {
            // A correct website page.
            // StartCoroutine(GetRequest("https://catfact.ninja/fact"));
            publicAPIURL_1 = "https://catfact.ninja/fact";
            publicAPIURL_2 = "https://official-joke-api.appspot.com/random_joke";
        }

        IEnumerator GetRequest(string uri, int apiNumber)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                string[] pages = uri.Split('/');
                int page = pages.Length - 1;

                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                        apiContent = "webRequest Error";
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                        apiContent = "HTTP Error";
                        break;
                    case UnityWebRequest.Result.Success:
                        Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                        apiContent = webRequest.downloadHandler.text;
                        break;
                }
            }

            if(apiNumber == 1 ){
                OSC_Transmitter.SendMessageKeyOne(apiContent);
                TestLog.GetComponent<UnityEngine.UI.Text>().text = apiContent.ToString();
            }

            if(apiNumber == 2){
                OSC_Transmitter.SendMessageKeyTwo(apiContent);
                TestLog.GetComponent<UnityEngine.UI.Text>().text = apiContent.ToString();
            }
        }

        public void apiGetRequest(){
            StartCoroutine(GetRequest(publicAPIURL_1,1));        
        }

        public void apiGetRequestSec(){
            StartCoroutine(GetRequest(publicAPIURL_2,2));        
        }
    }
}
