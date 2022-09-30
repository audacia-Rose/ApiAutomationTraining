namespace APITestingTemplate.Models.Dtos
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v13.0.1.0)")]
	public partial class PagingRequest 
	{
	    [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public int? PageSize { get; set; }
	    [Newtonsoft.Json.JsonProperty("pageNumber", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public int PageNumber { get; set; }
	}
}
