using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class ChatGPT : MonoBehaviour
{
    private string openaiApiKey = Keys.chatgpt_api;

    //TODO: remove
    void Update() {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(RequestLocation("give me a cool city in france"));
        }
    }

    public IEnumerator RequestLocation(string prompt)
    {
        string openaiEndpoint = "https://api.openai.com/v1/chat/completions";
        string systemContent = "You are a useful bot.";
        string modelName = "gpt-3.5-turbo";
        string requestData = $"{{" +
                             $"\"model\":\"{modelName}\"," +
                             $"\"messages\":[" +
                             $"{{\"role\":\"system\",\"content\":\"{systemContent}\"}}," +
                             $"{{\"role\":\"user\",\"content\":\"{prompt}\"}}" +
                             $"]}}";


        UnityWebRequest request = new UnityWebRequest(openaiEndpoint, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(requestData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + openaiApiKey);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseJson = request.downloadHandler.text;
            Debug.Log(responseJson);
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }
}
