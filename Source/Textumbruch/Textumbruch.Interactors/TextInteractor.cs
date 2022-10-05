using Textumbruch.Domain;

namespace Textumbruch.Interactors;

public class TextInteractor
{
    private readonly string _text;

    public TextInteractor(string text)
    {
        _text = text;
    }

    public string UmbrechenAufMaximaleBreiteVonZeichen(int maximaleBreite)
    {
        var textWrapper = new TextWrapper(_text, maximaleBreite, new TokenExtraktor());
        return textWrapper.Wrap();
    }
}
