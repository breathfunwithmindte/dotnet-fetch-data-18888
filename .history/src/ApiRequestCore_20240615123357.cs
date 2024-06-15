using Turism.DataFetch.Enums;

namespace Turism.DataFetch
{

  public abstract class ApiRequestCore
  {
    protected abstract void InitializeRoot(); // will set initial root where will be stored data... like: /seed/auth for authentication and /seed/data for the rest data; All file names will be <fieldname>-<current date>.perf.seed
    protected abstract void InitializeClient(string baseDomain);
    protected abstract void JSONFormatToDTO<T>(object data);
    protected abstract string Authenticate (AuthenticationTypes types, string url, string credentials); // returns a token
    protected abstract string UseAuthentication (string fileName);  // returns a token
    protected abstract void StoreAuthentication (string fileName, string token); // store the token to local file
    protected abstract void StoreData (string fileName, Dictionary<string, object>[] data); // will store that data to local file as := value1 <%> value2 <%> ... <%> valueN    -- for each element of the list

  }


}