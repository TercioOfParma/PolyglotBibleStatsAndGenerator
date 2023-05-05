using System.Collections.Generic;


public class BibleChapter 
{
    public int BibleChapterId;
    public List<BibleVerse> Verses;
    public BasicTextDetails TextDetails {get; set;}

    public void CalculateAllFields()
    {
        foreach(var verse in Verses)
        {
            TextDetails.UpdateTotals(verse);
        }
        TextDetails.ModelDetails();
    }


}

