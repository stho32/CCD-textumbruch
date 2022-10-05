using NUnit.Framework;

namespace Textumbruch.Domain.Tests;

[TestFixture]
public class TokenExtractorTests
{
    [Test]
    public void Wenn_der_Rest_leer_ist_dann_ist_das_Ende_erreicht()
    {
        var extraktor = new TokenExtraktor();
        var result = extraktor.NaechstesOptimalesToken("", "", 10);
        
        Assert.AreEqual(true, result.EndeIstErreicht);
    }
    
    [Test]
    public void Wenn_noch_etwas_im_Rest_enthalten_ist_dann_ist_das_Ende_noch_nicht_erreicht()
    {
        var extraktor = new TokenExtraktor();
        var result = extraktor.NaechstesOptimalesToken("", "Hier ist noch etwas übrig.", 10);
        
        Assert.AreEqual(false, result.EndeIstErreicht);
    }
    
    [Test]
    public void Wenn_die_Zeile_bisher_schon_Daten_enthaelt_und_das_naechste_Wort_nicht_ganz_passt_dann_wird_die_Zeile_umgebrochen()
    {
        var extraktor = new TokenExtraktor();
        var result = extraktor.NaechstesOptimalesToken("Hallo", "01234567890123", 10);
        
        Assert.AreEqual(Environment.NewLine, result.OptimalesToken);
    }

    [Test]
    public void Wenn_die_Zeile_bisher_schon_Daten_enthaelt_und_das_naechste_Wort_passt_das_naechste_Wort_zurueckgegeben()
    {
        var extraktor = new TokenExtraktor();
        var result = extraktor.NaechstesOptimalesToken("Hallo", "du", 10);
        
        Assert.AreEqual("du", result.OptimalesToken);
    }
    
    [Test]
    public void Wenn_ein_naechstes_Wort_zurueckgegeben_wird_dann_wird_der_Rest_um_das_Wort_vermindert_zurueckgegeben()
    {
        var extraktor = new TokenExtraktor();
        var result = extraktor.NaechstesOptimalesToken("Hallo", "du da!", 10);
        
        Assert.AreEqual("da!", result.Rest);
    }
    
    [Test]
    public void Wenn_Wort_laenger_als_die_max_Zeilenbreite_und_aktuelle_Zeile_leer_ist_dann_wird_mit_Bindestrich_umgebrochen()
    {
        var extraktor = new TokenExtraktor();
        var result = extraktor.NaechstesOptimalesToken("", "01234567890", 10);
        
        Assert.AreEqual("012345678-", result.OptimalesToken);
        Assert.AreEqual("90", result.Rest);
    }
}
