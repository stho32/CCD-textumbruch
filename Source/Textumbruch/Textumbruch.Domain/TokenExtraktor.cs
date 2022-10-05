namespace Textumbruch.Domain;

public class TokenExtraktor : TextWrapperTokenExtraktor
{
    public TokenExtraktorResult NaechstesOptimalesToken(string zeileBisher, string restUrsprungsdaten, int maximaleZeilenbreite)
    {
        if (string.IsNullOrWhiteSpace(restUrsprungsdaten))
            return new TokenExtraktorResult("", "", true);

        var naechstesWort = ExtrahiereBisZumNaechstenWhitespace(restUrsprungsdaten);
        if (naechstesWort.Wort.Length > maximaleZeilenbreite)
        {
            if (zeileBisher.Length > 0)
                return new TokenExtraktorResult(Environment.NewLine, restUrsprungsdaten, false);
            
            var naechstesWortGekuerzt = ExtrahiereBisMaximaleBreite(restUrsprungsdaten, maximaleZeilenbreite);
            return new TokenExtraktorResult(naechstesWortGekuerzt.Wort, naechstesWortGekuerzt.Rest, false);
        }

        if (ZeileWaereMitNeuemWortZuLang(naechstesWort.Wort, zeileBisher, maximaleZeilenbreite))
            return new TokenExtraktorResult(Environment.NewLine, restUrsprungsdaten, false);
        
        return new TokenExtraktorResult(naechstesWort.Wort, naechstesWort.Rest.Trim(), false);
    }

    private bool ZeileWaereMitNeuemWortZuLang(string naechstesWort, string zeileBisher, int maximaleZeilenbreite)
    {
        return naechstesWort.Length + zeileBisher.Length + 1 > maximaleZeilenbreite;
    }

    private NaechstesWortResult ExtrahiereBisMaximaleBreite(string restUrsprungsdaten, int maximaleZeilenbreite)
    {
        var result = restUrsprungsdaten.Substring(0, maximaleZeilenbreite -1) + "-";
        return new NaechstesWortResult(result, restUrsprungsdaten.Substring(maximaleZeilenbreite -1));
    }

    private NaechstesWortResult ExtrahiereBisZumNaechstenWhitespace(string restUrsprungsdaten)
    {
        var whitespaces = " \t";
        var result = "";

        for (int i = 0; i < restUrsprungsdaten.Length; i++)
        {
            if (whitespaces.Contains(restUrsprungsdaten[i]))
                break;
            
            result += restUrsprungsdaten[i];
        }

        return new NaechstesWortResult(result, restUrsprungsdaten.Substring(result.Length));
    }
}