// See https://aka.ms/new-console-template for more information
using Turism.DataFetch;
using Turism.DataFetch.Enums;
using Turism.DataFetch.Types;

Console.WriteLine("Hello, World!");

Intergration18888 i = new Intergration18888("seed", "locations", "https://www.11888.gr");

i.Main(new Intergration18888Configuration(DataFetchTypes.PREFECTURES_AND_LOCATIONS)
{ 
  StoreDataFileName = "ΑΤΤΙΚΗΣ", 
  FetchPath="/search/suggest/postal_codes/municipalities/?county=ΑΤΤΙΚΗΣ",
  AdditionalData = new Dictionary<string, object>(){{ "Prefecture", "ΑΤΤΙΚΗΣ" }}
}).GetAwaiter().GetResult();
