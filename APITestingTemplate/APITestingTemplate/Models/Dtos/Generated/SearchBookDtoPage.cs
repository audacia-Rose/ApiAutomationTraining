namespace APITestingTemplate.Models.Dtos
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v13.0.1.0)")]
	public partial class SearchBookDtoPage 
	{
	    [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public int TotalPages { get; set; }
	    [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public int TotalRecords { get; set; }
	    [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public System.Collections.Generic.ICollection<SearchBookDto> Data { get; set; }
	}
}
