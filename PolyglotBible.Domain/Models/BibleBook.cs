using System.Collections.Generic;


public class BibleBook
{
    public int BibleBookId;
    public List<BibleChapter> Chapters{get; set;}
    BasicTextDetails TextDetails {get; set;}


    public void CalculateAllFields()
    {
        foreach(var verse in Chapters)
        {
            TextDetails.UpdateTotals(verse);
        }
        TextDetails.ModelDetails();
    }
}