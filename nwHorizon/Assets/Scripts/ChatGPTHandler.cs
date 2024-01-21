using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using System;

public class ChatGPTHandler : MonoBehaviour
{
    public delegate void RequestComplete(Location location);
    public static event RequestComplete OnRequestComplete;

    private string openaiApiKey = Keys.chatgpt_api;

    public IEnumerator RequestLocation(string prompt)
    {
        string openaiEndpoint = "https://api.openai.com/v1/chat/completions";
        string systemContent = "You are a bot that finds a location that best matches the given prompt, and simply returns a JSON with a number representing the latitude, a number representing longitude in Decimal Degrees of the location, a number representing the altitude of the location in meters. Your response must only be a string representing a JSON object with the key values pairs that I have just specified.";
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

        Debug.Log("sent");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseJson = request.downloadHandler.text;
            ChatCompletionResponse response = JsonUtility.FromJson<ChatCompletionResponse>(responseJson);
            string contentString = response.choices[0].message.content;
            Location location = JsonUtility.FromJson<Location>(contentString);
            OnRequestComplete?.Invoke(location);
            Debug.Log("chatgpt complete");
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }
}
