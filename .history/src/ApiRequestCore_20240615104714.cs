using Turism.DataFetch.Enums;

namespace Turism.DataFetch
{

  public abstract class ApiRequestCore
  {
    protected abstract void InitializeClient();
    protected abstract void JSONFormatToDTO<T>();
    protected abstract Task<string> Authenticate (AuthenticationTypes types, string url, string credentials); // returns a token
    protected abstract Task<string> UseAuthentication (string fileName);  // returns a token
    protected abstract void StoreAuthentication (string fileName, string token); // store the token to local file
  }


}