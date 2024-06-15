using Turism.DataFetch.Enums;

namespace Turism.DataFetch
{

  public class Intergration18888 : ApiRequestCore
  {
    protected readonly HttpClient Client;
    protected readonly string DataRoot;
    public Intergration18888(string dataRoot)
    {
        this.DataRoot = "seed/data";
        this.Client = new HttpClient();
        InitializeRoot();
        InitializeClient();
    }

    async Task Main ()
    {
      
    }

    protected override void InitializeRoot()
    {
        if (!Directory.Exists(this.DataRoot))
        {
            Directory.CreateDirectory(this.DataRoot);
        }
    }

    protected override void InitializeClient() 
    {

    }

    protected override void JSONFormatToDTO<T>(object data) {}
    protected override string Authenticate (AuthenticationTypes types, string url, string credentials) { return "Not implemented"; } // returns a token
    protected override string UseAuthentication (string fileName) { return "Not implemented"; }  // returns a token
    protected override void StoreAuthentication (string fileName, string token) {} 
    protected override void StoreData (string fileName, Dictionary<string, object>[] data) {} // will store that data to local file as := value1 <%> value2 <%> ... <%> valueN    -- for each element of the list
    protected async Task<T> HttpGet<T> (string path, Dictionary<string, string> headers) where T : class, new()
    {
        foreach (var header in headers) { this.Client.DefaultRequestHeaders.Add(header.Key, header.Value); }
        HttpResponseMessage response = await this.Client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            return new T();
        }
        else
        {
            throw new Exception($"HTTP GET request failed with status code: {response.StatusCode}");
        }
    } // the primary get request to fetch data..


  }


}