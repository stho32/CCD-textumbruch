namespace Textumbruch.Domain;

public interface TextWrapperTokenExtraktor
{
    TokenExtraktorResult NaechstesOptimalesToken(string zeileBisher, string restUrsprungsdaten, int maximaleZeilenbreite);
}