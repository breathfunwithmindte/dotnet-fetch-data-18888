namespace Turism.DataFetch
{

  public class Intergration18888 : ApiRequestCore
  {

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


  }


}