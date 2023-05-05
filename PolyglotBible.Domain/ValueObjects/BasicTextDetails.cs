

public class BasicTextDetails 
{
    public int Hapaxlegomena {get; set;}
    public int NumberOfSentences {get; set;}
    public int NumberOfWords {get; set;}
    public int NumberOfClauses {get; set;}
    public int NumberOfUniqueWords {get; set;}
    public decimal AverageClauseLength {get; set;}
    public decimal AverageSentenceLength {get; set;}
    public decimal AverageLengthOfWords {get; set;}
    public decimal AverageNumberOfSyllables {get; set;} 
    public int NumberOfSyllables {get; set;}
    public decimal OverallFrequencyOfWords {get; set;}
    public decimal AverageFrequencyOfWords {get; set;}
    public int LengthOfWords {get; set;}
    public decimal FleishKincaldResult {get; set;}
    public ISyllableSplitter SyllableSplitter {get; set;}
    public Dictionary<string, int> WordDataCorrelation {get; set;}

    public void UpdateTotals(BibleChapter chapter)
    {
        foreach(var verse in chapter.Verses)
        {
            UpdateTotals(verse);
        }
    }
    public void UpdateTotals(BibleVerse verse)
    {
        NumberOfSyllables +=  SyllableSplitter.GetTotalVerseSyllables(verse);
        NumberOfWords += verse.NumberOfWords;
        LengthOfWords += verse.LengthOfWords();
        OverallFrequencyOfWords += verse.AverageFrequencyOfWords();
        NumberOfClauses += verse.GetNumberOfClauses();
        NumberOfSentences += verse.GetNumberOfSentences();
        verse.FleishKincald(SyllableSplitter);
        UpdateCorrelation(verse.WordData);
    }

    public void ModelDetails()
    {
        AverageClauseLength = NumberOfWords / NumberOfClauses;
        AverageSentenceLength = NumberOfWords / NumberOfSentences;
        AverageNumberOfSyllables = NumberOfWords / NumberOfSyllables;
        AverageLengthOfWords = NumberOfWords / LengthOfWords;
        AverageFrequencyOfWords = OverallFrequencyOfWords / NumberOfWords;

        Hapaxlegomena = WordDataCorrelation.Select(v => v.Value == 1).Count();
        NumberOfUniqueWords = WordDataCorrelation.Count();
        FleishKincald();
    }

    public decimal FleishKincald()
    {
        FleishKincaldResult = (0.39m * (NumberOfWords / NumberOfSentences)) + (11.8m * (NumberOfSyllables / NumberOfWords)) - 15.59m;

        return FleishKincaldResult;
    }

    public void UpdateCorrelation(List<Word> words)
    {
        foreach(var word in words)
        {
            if(WordDataCorrelation.ContainsKey(word.Content))
            {
                WordDataCorrelation[word.Content] += word.Count;
            }
            else
            {
                WordDataCorrelation[word.Content] = word.Count;
            }
        }
    }
}