namespace Textumbruch.Interactors.Tests;

public class TextInteractor
{
    private readonly string _text;

    public TextInteractor(string text)
    {
        _text = text;
    }

    public string UmbrechenAufMaximaleBreiteVonZeichen(int maximaleBreite)
    {
        var einzelneWorte = TextInWorteZerlegen(_text);
        var aktuelleZeile = "";
        var gesamtergebnis = new List<string>();

        foreach (var wort in einzelneWorte)
        {
            var potenzielleLaengeMitWort = (aktuelleZeile + " " + wort).Trim().Length;
            if (potenzielleLaengeMitWort > maximaleBreite)
            {
                gesamtergebnis.Add(aktuelleZeile.Trim());
                aktuelleZeile = "";
            }

            aktuelleZeile += " " + wort;
        }

        if (!string.IsNullOrEmpty(aktuelleZeile))
        {
            gesamtergebnis.Add(aktuelleZeile.Trim());            
        }
            
        return string
            .Join("\n", gesamtergebnis)
            .ReplaceLineEndings()
            .Trim();
    }

    private string[] TextInWorteZerlegen(string text)
    {
        return text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    }
}
