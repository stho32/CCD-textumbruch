namespace Textumbruch.Domain;

public class TokenExtraktor : ITextWrapperTokenExtraktor
{
    public TokenExtraktorResult NaechstesOptimalesToken(string zeileBisher, string restUrsprungsdaten, int maximaleZeilenbreite)
    {
        if (string.IsNullOrWhiteSpace(restUrsprungsdaten))
            return DasEndeIstErreichtTokenExtraktorResult();

        var naechstesWort = ExtrahiereBisZumNaechstenWhitespace(restUrsprungsdaten);

        if (IstWortBreiterAlsUnsereMaximaleBreite(naechstesWort, maximaleZeilenbreite))
            return ExtrabreitesWortBehandeln(zeileBisher, restUrsprungsdaten, maximaleZeilenbreite);

        if (ZeileWaereMitNeuemWortZuLang(naechstesWort.Wort, zeileBisher, maximaleZeilenbreite))
            return ZeilenUmbruchErzeugenTokenExtraktorResult(restUrsprungsdaten);

        return new TokenExtraktorResult(naechstesWort.Wort, naechstesWort.Rest.Trim(), false);
    }

    private TokenExtraktorResult ExtrabreitesWortBehandeln(string zeileBisher, string restUrsprungsdaten,
        int maximaleZeilenbreite)
    {
        if (IstSchonEtwasInDerErgebniszeile(zeileBisher))
            return ZeilenUmbruchErzeugenTokenExtraktorResult(restUrsprungsdaten);

        return StueckVomWortTokenExtraktorResult(restUrsprungsdaten, maximaleZeilenbreite);
    }

    private TokenExtraktorResult StueckVomWortTokenExtraktorResult(string restUrsprungsdaten,
        int maximaleZeilenbreite)
    {
        var naechstesWortGekuerzt = ExtrahiereBisMaximaleBreite(restUrsprungsdaten, maximaleZeilenbreite);
        return new TokenExtraktorResult(naechstesWortGekuerzt.Wort, naechstesWortGekuerzt.Rest, false);
    }

    private static TokenExtraktorResult ZeilenUmbruchErzeugenTokenExtraktorResult(string restUrsprungsdaten)
    {
        return new TokenExtraktorResult(Environment.NewLine, restUrsprungsdaten, false);
    }

    private static TokenExtraktorResult DasEndeIstErreichtTokenExtraktorResult()
    {
        return new TokenExtraktorResult("", "", true);
    }

    private static bool IstSchonEtwasInDerErgebniszeile(string zeileBisher)
    {
        return zeileBisher.Length > 0;
    }

    private static bool IstWortBreiterAlsUnsereMaximaleBreite(NaechstesWortResult naechstesWort, int maximaleZeilenbreite)
    {
        return naechstesWort.Wort.Length > maximaleZeilenbreite;
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