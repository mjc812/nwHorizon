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
        string systemContent = "You are a bot that finds a location that best matches the user's description, and simply returns a JSON with a number reprsenting the latitude, a number representing longitude in Decimal Degrees of the location, a number representing the altitude of the city, a string representing the city of the location, and a string representing the country of the location, and a string with between 100 to 200 characters representing a fact about the location. Your response must only be a string representing a JSON object with the key values pairs that I have specified.";

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
            Debug.Log(contentString);
            Location location = JsonUtility.FromJson<Location>(contentString);
            //if (location.altitude > 1000f) {
                //location.altitude = 3000f;
            //}
            OnRequestComplete?.Invoke(location);
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }
}
