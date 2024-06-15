namespace Turism.DataFetch.Types
{

  public class PrefectureLocationResponse
  {
      public string Status { get; set; }
      public int Code { get; set; }
      public PrefectureLocationData Data { get; set; }
  }

  class PrefectureLocationData
  {
      public List<string> Suggestions { get; set; }
      public List<SuggestionExtended> SuggestionsExtended { get; set; }
  }

  class SuggestionExtended
  {
      public string Greeklish { get; set; }
      public string Original { get; set; }
  }


}