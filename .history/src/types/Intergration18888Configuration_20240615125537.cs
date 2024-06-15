using Turism.DataFetch.Enums;

namespace Turism.DataFetch.Types
{

  public class Intergration18888Configuration
  {

    public DataFetchTypes FetchType { get; set; }
    public bool StoreData { get; set; } = false;
    public bool UseAuthentication { get; set; } = false;
    public bool SaveAuthentication { get; set; } = false;
    public string FetchPath { get; set; } = string.Empty;
    public string StoreDataFileName { get; set; } = string.Empty;
    public string StoreDataFileNameDate { get; set; } = string.Empty;

    public Intergration18888Configuration (DataFetchTypes fetchType)
    {
      this.FetchType = fetchType;
      this.StoreDataFileNameDate = DateTime.Now.ToString("dd-MM-yyyy");
    }

  }


}