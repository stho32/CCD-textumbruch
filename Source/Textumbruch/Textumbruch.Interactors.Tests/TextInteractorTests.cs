using NUnit.Framework;

namespace Textumbruch.Interactors.Tests;

[TestFixture]
public class TextInteractorTests
{
    [Test]
    public void Wenn_eine_leere_Zeile_angegeben_wird_wird_auch_eine_leere_Zeile_zurueckgegeben()
    {
        var result = TextInteractor.UmbrechenAufMaximaleBreiteVonZeichen("", 25);
        
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Wenn_eine_Zeile_aus_mehreren_kleinen_Worten_besteht_wird_vor_der_maximalen_Breite_umgebrochen()
    {
        var result = TextInteractor.UmbrechenAufMaximaleBreiteVonZeichen("Dies ist ein kleiner Test, mal sehen was daraus wird.", 25);
        
        Assert.AreEqual(@"Dies ist ein kleiner
Test, mal sehen was
daraus wird.".ReplaceLineEndings(), result);
    }
    
    [Test]
    public void Wenn_eine_Zeile_laenger_ist_als_die_maximale_Breite_wird_mit_hart_mit_Bindestrich_umgebrochen()
    {
        var result = TextInteractor.UmbrechenAufMaximaleBreiteVonZeichen("DiesIstEinGanzFurchtbarLangesWortDasSoGarnichtVorkommenSollte", 25);
        
        Assert.AreEqual(@"DiesIstEinGanzFurchtbarL-
angesWortDasSoGarnichtVo-
rkommenSollte".ReplaceLineEndings(), result);
    }
}