using System.Collections.Generic;

public class BibleVerse
{
    public int BibleVerseId;
    public int NumberOfWords {get; set;}
    public string Verse {get; set;}

    public decimal FleishKincaldResult{get; set;}
    public List<Word> WordData;

    private BibleVerse(){}

    public BibleVerse(string verse, FrequencyDictionary dict, ISyllableSplitter syllableSplitter)
    {
        Verse = verse; 
        GenerateWordData(dict);
        FleishKincald(syllableSplitter);       
    }

    public List<Word> GenerateWordData(FrequencyDictionary dict)
    {
        List<String>wordloop = Verse.Split(" ").ToList();
        NumberOfWords = wordloop.Count();
        return wordloop.Select(v => new Word(v, dict)).ToList();
    }
    public void CountWords()
    {
        NumberOfWords = WordData.Count();
    }
    public int LengthOfWords()
    {
        return WordData.Sum(v => v.Count);
    }
    public decimal AverageFrequencyOfWords()
    {
        return WordData.Sum(v => v.OverallFrequency) / NumberOfWords;
    }
    public int GetNumberOfSentences()
    {
        return Verse.Count(v => v == '.');
    }
    public int GetNumberOfClauses()
    {
        return Verse.Count(v =>
         v == ',' ||
         v == ';' ||
         v == ':' || 
         v == '?' ||
         v == '!'
         );
    }

    public decimal FleishKincald(ISyllableSplitter syllableSplitter)
    {
        FleishKincaldResult = (0.39m * (NumberOfWords / GetNumberOfSentences())) + 
        (11.8m * (syllableSplitter.GetTotalVerseSyllables(this) / NumberOfWords)) - 15.59m;

        return FleishKincaldResult;
    }
}