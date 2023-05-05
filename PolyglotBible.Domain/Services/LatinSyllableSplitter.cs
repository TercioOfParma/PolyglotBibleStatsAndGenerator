

public class LatinSyllableSplitter : ISyllableSplitter
{
    public int GetSyllables(string word)
    {
        throw new NotImplementedException();
    }

    public int GetTotalVerseSyllables(BibleVerse verse)
    {
        return verse.WordData.Sum(v => GetSyllables(v.Content));
    }
}