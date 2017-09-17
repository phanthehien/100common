using System;
using Newtonsoft.Json;

namespace OneHundredCommonThings.Model
{
	public abstract class BaseModel
	{
        [JsonIgnore]
		public long Id { get; set; }
	}

	public partial class AppData
	{
		[JsonProperty("content")]
		public Content[] Content { get; set; }

		[JsonProperty("category")]
		public Category[] Category { get; set; }

		[JsonProperty("topic")]
		public Topic[] Topic { get; set; }
	}

    public partial class Content : BaseModel
	{
		[JsonProperty("sentence")]
		public string Sentence { get; set; }

		[JsonProperty("meaning")]
		public string Meaning { get; set; }

		[JsonProperty("sentenceId")]
		public long SentenceId { get; set; }

		[JsonProperty("children")]
		public string Children { get; set; }

		[JsonProperty("link")]
		public string Link { get; set; }
	}

	public partial class Category : BaseModel
	{
		[JsonProperty("categoryId")]
		public long CategoryId { get; set; }

		[JsonProperty("category")]
		public string CategoryName { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("children")]
		public string Children { get; set; }
	}

    public partial class Topic : BaseModel
	{
		[JsonProperty("topic")]
		public string TopicName { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("topicId")]
		public long TopicId { get; set; }

		[JsonProperty("link")]
		public string Link { get; set; }

		[JsonProperty("children")]
		public string Children { get; set; }
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
