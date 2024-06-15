namespace Turism.DataFetch.Responses
{

  public class PrefectureLocationResponse
  {
      public string Status { get; set; }
      public int Code { get; set; }
      public PrefectureLocationData Data { get; set; }
  }

  public class PrefectureLocationData
  {
      public List<string> Suggestions { get; set; }
      public List<SuggestionExtended> SuggestionsExtended { get; set; }
  }

  public class SuggestionExtended
  {
      public string Greeklish { get; set; }
      public string Original { get; set; }
  }


}