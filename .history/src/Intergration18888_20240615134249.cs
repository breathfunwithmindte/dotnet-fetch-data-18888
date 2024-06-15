using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Turism.DataFetch.Enums;
using Turism.DataFetch.Responses;
using Turism.DataFetch.Types;

namespace Turism.DataFetch
{

  public class Intergration18888 : ApiRequestCore
  {
    protected readonly HttpClient Client;
    protected readonly string BaseRoot;
    protected readonly string DataRoot;
    public Intergration18888(string rootFolder, string dataFolder, string baseDomain)
    {
        this.BaseRoot = rootFolder;
        this.DataRoot = rootFolder + "/data/" + dataFolder;
        this.Client = new HttpClient();
        InitializeRoot();
        InitializeClient(baseDomain);
    }

    public async Task Main (Intergration18888Configuration config)
    {
      if(config.FetchType == DataFetchTypes.PREFECTURES_AND_LOCATIONS)
      {
        Console.WriteLine("FetchType = " + DataFetchTypes.PREFECTURES_AND_LOCATIONS.ToString());
        PrefectureLocationResponse prefectureLocationResponse = await this.HttpGet<PrefectureLocationResponse>(config.FetchPath, new Dictionary<string, string>());
        Console.WriteLine(JsonSerializer.Serialize(prefectureLocationResponse.ToDictionaryList(config.AdditionalData), new JsonSerializerOptions{ Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.GreekandCoptic)}));

        //prefectureLocationResponse from that i want get it as list of dictionary<string, object> as: Id: Random Guid as string, Name: The Greek Text, GreekList: the greek list

        this.StoreData(config.StoreDataFileName + "__" + config.StoreDataFileNameDate + ".perf.seed", prefectureLocationResponse.ToDictionaryList(config.AdditionalData) );
      }
    }

    protected override void InitializeRoot()
    {
        if (!Directory.Exists(this.BaseRoot)) { Directory.CreateDirectory(this.BaseRoot); }
        if (!Directory.Exists(this.BaseRoot + "/auth")) { Directory.CreateDirectory(this.BaseRoot + "/auth"); }
        if (!Directory.Exists(this.BaseRoot + "/data")) { Directory.CreateDirectory(this.BaseRoot + "/data"); }
        if (!Directory.Exists(this.DataRoot)) { Directory.CreateDirectory(this.DataRoot); }
    }

    protected override void InitializeClient(string baseDomain) 
    {
      this.Client.BaseAddress = new Uri(baseDomain);
      this.Client.Timeout = TimeSpan.FromSeconds(30);
    }

    protected override void JSONFormatToDTO<T>(object data) {}
    protected override string Authenticate (AuthenticationTypes types, string url, string credentials) { return "Not implemented"; } // returns a token
    protected override string UseAuthentication (string fileName) { return "Not implemented"; }  // returns a token
    protected override void StoreAuthentication (string fileName, string token) {} 
    protected override void StoreData (string fileName, List<Dictionary<string, object>> data) 
    {
        var filePath = this.DataRoot + $"/{fileName}";
        var lines = new List<string>();
        lines.Add("active:=true");
        foreach (var record in data)
        {
            var line = string.Join(" <%> ", record.Values);
            lines.Add(line);
        }
        File.WriteAllLines(filePath, lines);
    } // will store that data to local file as := value1 <%> value2 <%> ... <%> valueN    -- for each element of the list
    protected async Task<T> HttpGet<T> (string path, Dictionary<string, string> headers) where T : class, new()
    {
        foreach (var header in headers) { this.Client.DefaultRequestHeaders.Add(header.Key, header.Value); }
        HttpResponseMessage response = await this.Client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
          // Ensure the response content type is JSON
          if (response.Content.Headers.ContentType?.MediaType != "application/json")
          {
              throw new InvalidOperationException("Expected application/json response but received a different type.");
          }

          string jsonResponse = await response.Content.ReadAsStringAsync();

          try
          {
              return JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions{ Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.GreekandCoptic) });
          }
          catch (JsonException ex)
          {
              throw new Exception("Failed to deserialize JSON to type " + typeof(T).Name, ex);
          }
        }
        else
        {
            throw new Exception($"HTTP GET request failed with status code: {response.StatusCode}");
        }
    } // the primary get request to fetch data..


  }


}