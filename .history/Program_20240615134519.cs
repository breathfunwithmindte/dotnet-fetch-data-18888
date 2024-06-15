// See https://aka.ms/new-console-template for more information
using Turism.DataFetch;
using Turism.DataFetch.Enums;
using Turism.DataFetch.Types;

Console.WriteLine("Hello, World!");

Intergration18888 i = new Intergration18888("seed", "locations", "https://www.11888.gr");

List<string> prefectures = new List<string>
{
    "ΑΙΤΩΛΟΑΚΑΡΝΑΝΙΑΣ", "ΑΝΔΡΙΤΣΑΙΝΑ", "ΑΡΓΟΛΙΔΑΣ", "ΑΡΓΟΛΙΔΟΣ", "ΑΡΚΑΔΙΑΣ", "ΑΡΤΑΣ", "ΑΤΤΙΚΗΣ", // continue with all other entries...
};

foreach (var prefecture in prefectures)
{
    var config = new Intergration18888Configuration(DataFetchTypes.PREFECTURES_AND_LOCATIONS)
    {
        StoreDataFileName = prefecture,
        FetchPath = $"/search/suggest/postal_codes/municipalities/?county={prefecture}",
        AdditionalData = new Dictionary<string, object>() { { "Prefecture", prefecture } }
    };

    i.Main(config).GetAwaiter().GetResult();
}
