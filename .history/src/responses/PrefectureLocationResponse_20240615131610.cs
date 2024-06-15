namespace Turism.DataFetch.Responses
{

  public class PrefectureLocationResponse
  {
      public string status { get; set; }
      public int code { get; set; }
      public PrefectureLocationData data { get; set; }

      public List<Dictionary<string, object>> ToDictionaryList()
      {
          var list = new List<Dictionary<string, object>>();

          // Assuming suggestions_extended contains the Greek and Greeklish names
          foreach (var suggestion in data.suggestions_extended)
          {
              var dict = new Dictionary<string, object>
              {
                  { "Id", Guid.NewGuid().ToString() },
                  { "Name", suggestion.original },
                  { "Greeklish", suggestion.greeklish }
              };
              list.Add(dict);
          }

          return list;
      }
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