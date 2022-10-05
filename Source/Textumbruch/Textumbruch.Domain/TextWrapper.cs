using System.Text;

namespace Textumbruch.Domain;

public class TextWrapper
{
    private readonly string _text;
    private readonly int _maximaleBreite;
    private readonly TokenExtraktor _tokenExtraktor;

    public TextWrapper(string text, int maximaleBreite, TokenExtraktor tokenExtraktor)
    {
        _text = text;
        _maximaleBreite = maximaleBreite;
        _tokenExtraktor = tokenExtraktor;
    }

    public string Wrap()
    {
        StringBuilder ergebnis = new StringBuilder();
        string rest = _text;

        var aktuelleZeile = "";
        while(true)
        {
            var naechstesWort = _tokenExtraktor.NaechstesOptimalesToken(aktuelleZeile, rest, _maximaleBreite);
            
            if (naechstesWort.EndeIstErreicht)
                break;

            if (naechstesWort.OptimalesToken == Environment.NewLine)
            {
                ergebnis.AppendLine(aktuelleZeile);
                rest = naechstesWort.Rest;
                aktuelleZeile = ""; 
                continue;
            }
            
            aktuelleZeile += " " + naechstesWort.OptimalesToken;
            aktuelleZeile = aktuelleZeile.Trim();
            rest = naechstesWort.Rest;
        }

        if (!string.IsNullOrWhiteSpace(aktuelleZeile))
            ergebnis.Append(aktuelleZeile);

        return ergebnis.ToString();
    }

}