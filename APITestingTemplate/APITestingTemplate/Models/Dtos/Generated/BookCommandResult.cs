namespace APITestingTemplate.Models.Dtos
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v13.0.1.0)")]
	public partial class BookCommandResult 
	{
	    [Newtonsoft.Json.JsonProperty("isSuccess", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public bool IsSuccess { get; set; }
	    [Newtonsoft.Json.JsonProperty("errors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public System.Collections.Generic.ICollection<string> Errors { get; set; }
	    [Newtonsoft.Json.JsonProperty("output", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public Book Output { get; set; }
	}
}
