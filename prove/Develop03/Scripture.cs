    public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    public Scripture(string referenceText, string scriptureText)
    {
        _reference = new Reference(referenceText);
        _words = CreateWordList(scriptureText);
    }

    private List<Word> CreateWordList(string scriptureText)
    {
        List<Word> _wordList = new List<Word>();
        string[] _wordArray = scriptureText.Split(' ');

        foreach (string wordText in _wordArray)
        {
            Word word = new Word(wordText);
            _wordList.Add(word);
        }

        return _wordList;
    }

    public void HideWords()
    {
        int _wordsHidden = 0;
        while (_wordsHidden < 3 & !this.IsCompletelyHidden())
        {
            int random = new Random().Next(0, _words.Count());
            if (!_words[random].IsHidden())
            {
                _words[random].Hide();
                _wordsHidden++;
            }
        }
    }

    public string GetRenderedText()
    {
        string _renderedText = $"{_reference.GetText()}\n";

        foreach (Word word in _words)
        {
            _renderedText += word.GetRenderedText() + " ";
        }

        return _renderedText;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}