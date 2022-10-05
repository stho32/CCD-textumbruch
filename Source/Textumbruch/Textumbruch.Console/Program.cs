using Textumbruch.Interactors;

var text = @"Vor einem großen Walde wohnte ein armer Holzhacker mit seiner Frau und seinen zwei Kindern; das Bübchen hieß Hänsel und das Mädchen Gretel.";
var interactor = new TextInteractor(text);
var ergebnis = interactor.UmbrechenAufMaximaleBreiteVonZeichen(10);

Console.WriteLine(ergebnis);