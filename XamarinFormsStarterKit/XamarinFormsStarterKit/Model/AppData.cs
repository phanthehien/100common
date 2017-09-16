using System;
using Newtonsoft.Json;

namespace OneHundredCommonThings.Model
{
	public partial class AppData
	{
		[JsonProperty("englishSentence")]
		public EnglishSentence[] EnglishSentence { get; set; }
	}

    public abstract class BaseModel {
		[JsonProperty("id")]
		public long Id { get; set; }
	}

    public partial class EnglishSentence : BaseModel
	{
		[JsonProperty("sentenceId")]
		public string SentenceId { get; set; }

		[JsonProperty("meaning")]
		public string Meaning { get; set; }

		[JsonProperty("sentence")]
		public string Sentence { get; set; }
	}


	public partial class AppData
	{
		public static AppData FromJson(string json) => JsonConvert.DeserializeObject<AppData>(json, Converter.Settings);
	}

	public static class Serialize
	{
		public static string ToJson(this AppData self) => JsonConvert.SerializeObject(self, Converter.Settings);
	}

	public class Converter
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
		};
	}
}
