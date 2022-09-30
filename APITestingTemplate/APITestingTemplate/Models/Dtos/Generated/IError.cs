namespace APITestingTemplate.Models.Dtos
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v13.0.1.0)")]
	public partial class IError 
	{
	    [Newtonsoft.Json.JsonProperty("propertyName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public string PropertyName { get; set; }
	    [Newtonsoft.Json.JsonProperty("errorMessage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public string ErrorMessage { get; set; }
	    [Newtonsoft.Json.JsonProperty("isToast", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public bool IsToast { get; set; }
	}
}
