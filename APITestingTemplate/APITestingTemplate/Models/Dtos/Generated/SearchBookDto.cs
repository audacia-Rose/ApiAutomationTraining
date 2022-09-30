namespace APITestingTemplate.Models.Dtos
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v13.0.1.0)")]
	public partial class SearchBookDto 
	{
	    [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public int Id { get; set; }
	    [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public string Title { get; set; }
	    [Newtonsoft.Json.JsonProperty("author", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public string Author { get; set; }
	    [Newtonsoft.Json.JsonProperty("publishedYear", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public int PublishedYear { get; set; }
	    [Newtonsoft.Json.JsonProperty("availableFrom", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public System.DateTimeOffset? AvailableFrom { get; set; }
	}
}
