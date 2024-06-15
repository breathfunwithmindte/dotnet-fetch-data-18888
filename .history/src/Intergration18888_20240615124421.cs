using Turism.DataFetch.Enums;
using Turism.DataFetch.Types;

namespace Turism.DataFetch
{

  public class Intergration18888 : ApiRequestCore
  {
    protected readonly HttpClient Client;
    protected readonly string DataRoot;
    public Intergration18888(string dataRoot, string baseDomain)
    {
        this.DataRoot = dataRoot;
        this.Client = new HttpClient();
        InitializeRoot();
        InitializeClient(baseDomain);
    }

    public async Task Main (Intergration18888Configuration config)
    {
      if(config.FetchType == DataFetchTypes.PREFECTURES_AND_LOCATIONS)
      {
        Console.WriteLine("FetchType = " + DataFetchTypes.PREFECTURES_AND_LOCATIONS.ToString());
        this.StoreData(config.StoreDataFileName + "__" + config.StoreDataFileNameDate + ".perf.seed", [new Dictionary<string, object>() { { "id", 123 }, { "username", "mike" } }] );
      }
    }

    protected override void InitializeRoot()
    {
        if (!Directory.Exists(this.DataRoot)) { Directory.CreateDirectory(this.DataRoot); }
        if (!Directory.Exists(this.DataRoot + "/auth")) { Directory.CreateDirectory(this.DataRoot + "/auth"); }
        if (!Directory.Exists(this.DataRoot + "/data")) { Directory.CreateDirectory(this.DataRoot + "/data"); }
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
    protected override void StoreData (string fileName, Dictionary<string, object>[] data) 
    {
        var filePath = Path.Combine(this.DataRoot, $"/data/{fileName}");
        var lines = new List<string>();
        lines.Add("active:=true");
        foreach (var record in data)
        {
            var line = string.Join(" <%> ", record.Values);
            lines.Add(line);
        }

        Console.WriteLine(filePath.ToString());

        File.WriteAllLines(filePath, lines);
    } // will store that data to local file as := value1 <%> value2 <%> ... <%> valueN    -- for each element of the list
    protected async Task<T[]> HttpGet<T> (string path, Dictionary<string, string> headers) where T : class, new()
    {
        foreach (var header in headers) { this.Client.DefaultRequestHeaders.Add(header.Key, header.Value); }
        HttpResponseMessage response = await this.Client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            return [new T()];
        }
        else
        {
            throw new Exception($"HTTP GET request failed with status code: {response.StatusCode}");
        }
    } // the primary get request to fetch data..


  }


}