

public class Word 
{
    public string Content {get; set;}
    public int Count {get; set;}

    public int OverallFrequency {get; set;}

    public Word(string content, FrequencyDictionary dict)
    {
        Content = content;
        Count = content.Length;
        FindFrequency(dict);
    }
    public void FindFrequency(FrequencyDictionary freq)
    {
        if(freq.Positions.ContainsKey(Content))
        {
            OverallFrequency = freq.Positions[Content];
        }
        else 
        {
            throw new Exception("Word not found in frequency list!");
        }
    }
}