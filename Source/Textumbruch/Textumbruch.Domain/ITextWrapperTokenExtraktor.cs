namespace Textumbruch.Domain;

public interface ITextWrapperTokenExtraktor
{
    TokenExtraktorResult NaechstesOptimalesToken(string zeileBisher, string restUrsprungsdaten, int maximaleZeilenbreite);
}