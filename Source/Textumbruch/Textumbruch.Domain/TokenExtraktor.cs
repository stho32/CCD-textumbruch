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
        var trennzeichenInnerhalbEinerZeile = " ";
        return (zeileBisher + trennzeichenInnerhalbEinerZeile + naechstesWort).Trim().Length > maximaleZeilenbreite;
    }

    private NaechstesWortResult ExtrahiereBisMaximaleBreite(string restUrsprungsdaten, int maximaleZeilenbreite)
    {
        var trennzeichen = "-";
        var maximalerIndexMinusPlatzFuerTrennzeichen = maximaleZeilenbreite - trennzeichen.Length;
        
        var result = restUrsprungsdaten.Substring(0, maximalerIndexMinusPlatzFuerTrennzeichen) + trennzeichen;
        
        return new NaechstesWortResult(result, restUrsprungsdaten.Substring(maximalerIndexMinusPlatzFuerTrennzeichen));
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