

public interface ISyllableSplitter
{
    public int GetTotalVerseSyllables(BibleVerse verse);
    protected int GetSyllables(string Word);
}