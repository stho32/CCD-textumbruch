namespace Textumbruch.Domain;
public class TextWrapper
{
    private readonly string _text;
    private readonly int _maximaleBreite;
    private List<string> _aktuellerPuffer;
    
    public TextWrapper(string text, int maximaleBreite)
    {
        _text = text;
        _maximaleBreite = maximaleBreite;
        _aktuellerPuffer = new List<string>();
    }

    public string[] Wrap()
    {
        var einzelneWorte = TextInWorteZerlegen(_text);
        var aktuelleZeile = "";
        var gesamtergebnis = new List<string>();

        foreach (var wort in einzelneWorte)
        {
            // GetNextTeilwort ...
            
            //     var potenzielleLaengeMitWort = (aktuelleZeile + " " + wort).Trim().Length;
            //     if (BreiteReichtAusFuerNeuesWort(wort))
            //     {
            //         ErweitereZeileAktuelleZeileUmWort(wort);
            //         gesamtergebnis.Add(aktuelleZeile.Trim());
            //         aktuelleZeile = "";
            //     }
            //
            //     var restwort = wort;
            //     while (restwort.Length > 0)
            //     {
            //         if (restwort.Length > maximaleBreite)
            //         {
            //             var teilwort = restwort.Substring(0, maximaleBreite - 1);
            //             teilwort += "-";
            //             aktuelleZeile += teilwort;
            //         }
            //         aktuelleZeile += " " + wort;                
            //     }
            //     
            // }
            //
            // if (!string.IsNullOrEmpty(aktuelleZeile))
            // {
            //     gesamtergebnis.Add(aktuelleZeile.Trim());            
            // }
            //     
            // return string
            //     .Join("\n", gesamtergebnis)
            //     .ReplaceLineEndings()
            //     .Trim();
        }
    }

    private string[] TextInWorteZerlegen(string text)
    {
        return text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    }
}
