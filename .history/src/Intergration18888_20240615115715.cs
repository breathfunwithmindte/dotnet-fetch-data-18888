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

    protected override void InitializeRoot()
    {
        if (!Directory.Exists(this.DataRoot))
        {
            Directory.CreateDirectory(this.DataRoot);
        }
    }

    async Task Main ()
    {
      
    }

    protected override void InitializeClient() {}
    protected override void JSONFormatToDTO<T>(object data) {}
    protected override string Authenticate (AuthenticationTypes types, string url, string credentials) { return "Not implemented"; } // returns a token
    protected override string UseAuthentication (string fileName) { return "Not implemented"; }  // returns a token
    protected override void StoreAuthentication (string fileName, string token) {} 
    protected override void StoreData (string fileName, Dictionary<string, object>[] data) {} // will store that data to local file as := value1 <%> value2 <%> ... <%> valueN    -- for each element of the list
    protected override Task<T> HttpGet<T> (string path, Dictionary<string, string> headers) { return "Not implemented"; } // the primary get request to fetch data..


  }


}