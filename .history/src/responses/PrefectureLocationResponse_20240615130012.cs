namespace Turism.DataFetch.Responses
{

  public class PrefectureLocationResponse
  {
      public string status { get; set; }
      public int code { get; set; }
      public PrefectureLocationData data { get; set; }
  }

  public class PrefectureLocationData
  {
      public List<string> suggestions { get; set; }
      public List<SuggestionExtended> suggestions_extended { get; set; }
  }

  public class SuggestionExtended
  {
      public string greeklish { get; set; }
      public string original { get; set; }
  }


}