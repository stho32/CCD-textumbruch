using Textumbruch.Domain;

namespace Textumbruch.Interactors;

public static class TextInteractor
{
    public static string UmbrechenAufMaximaleBreiteVonZeichen(string text, int maximaleBreite)
    {
        var textWrapper = new TextWrapper(text, maximaleBreite, new TokenExtraktor());
        return textWrapper.Wrap();
    }
}
