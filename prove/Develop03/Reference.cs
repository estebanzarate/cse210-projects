public class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    public Reference(string referenceText)
    {
        string[] parts = referenceText.Split(' ');
        _book = parts[0];

        string chapterVerseText = parts[1];
        if (chapterVerseText.Contains("-"))
        {
            string[] chapterVerseArray = chapterVerseText.Split('-');
            _chapter = int.Parse(chapterVerseArray[0].Split(':')[0]);
            _verseStart = int.Parse(chapterVerseArray[0].Split(':')[1]);
            _verseEnd = int.Parse(chapterVerseArray[1]);
        }
        else
        {
            string[] chapterVerseArray = chapterVerseText.Split(':');
            _chapter = int.Parse(chapterVerseArray[0]);
            _verseStart = int.Parse(chapterVerseArray[1]);
            _verseEnd = _verseStart;
        }
    }

    public string GetText()
    {
        if (_verseStart == _verseEnd)
        {
            return $"{_book} {_chapter}:{_verseStart}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        }
    }
}