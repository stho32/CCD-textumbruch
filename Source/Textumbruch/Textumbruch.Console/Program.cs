using Textumbruch.Interactors;

var text = @"Vor einem großen Walde wohnte ein armer Holzhacker mit seiner Frau und seinen zwei Kindern; das Bübchen hieß Hänsel und das Mädchen Gretel.";

var ergebnis = TextInteractor.UmbrechenAufMaximaleBreiteVonZeichen(text, 10);

Console.WriteLine(ergebnis);