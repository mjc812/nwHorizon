[System.Serializable]
public class ChatCompletionResponse
{
    public string id;
    public string objectName;
    public long created;
    public string model;
    public Choice[] choices;
    public Usage usage;
    public object system_fingerprint; // Assuming this field is nullable
}

[System.Serializable]
public class Choice
{
    public int index;
    public Message message;
    public object logprobs; // Assuming this field is nullable
    public string finish_reason;
}

[System.Serializable]
public class Message
{
    public string role;
    public string content;  
}

[System.Serializable]
public class Usage
{
    public int prompt_tokens;
    public int completion_tokens;
    public int total_tokens;
}
