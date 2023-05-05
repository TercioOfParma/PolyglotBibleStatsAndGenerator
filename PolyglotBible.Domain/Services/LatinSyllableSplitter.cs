using NHunspell;

public class LatinSyllableSplitter : ISyllableSplitter
{

    public Hyphen Dictionary{get; set;}
    public LatinSyllableSplitter(string filename)
    {
        Dictionary = new Hyphen("Latin.dic");
    }
    public int GetSyllables(string word)
    {
        return Dictionary.Hyphenate(word).HyphenatedWord.ToList().Count(v => v == '-');
    }

    public int GetTotalVerseSyllables(BibleVerse verse)
    {
        return verse.WordData.Sum(v => GetSyllables(v.Content));
    }
}