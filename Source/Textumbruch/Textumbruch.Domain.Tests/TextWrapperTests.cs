using NUnit.Framework;

namespace Textumbruch.Domain.Tests;

[TestFixture]
public class TextWrapperTests
{
    [Test]
    public void Wenn_das_Wort_laenger_ist_als_die_Zeilenbreite_wird_es_in_mehrere_Zeilen_umgebrochen()
    {
        var textWrapper = new TextWrapper("01234567890", 5, new TokenExtraktor());
        
        Assert.AreEqual(@"0123-
4567-
890".ReplaceLineEndings(), textWrapper.Wrap());
    }
}
