﻿using System;
using Newtonsoft.Json;

namespace OneHundredCommonThings.Model
{
	public abstract class BaseModel
	{
		[JsonProperty("id")]
		public long Id { get; set; }
	}

	public partial class AppData
	{
		[JsonProperty("commonEnglishSentence")]
		public CommonEnglishSentence[] CommonEnglishSentence { get; set; }

		[JsonProperty("categegory")]
		public Categegory[] Categegory { get; set; }

		[JsonProperty("english")]
		public English[] English { get; set; }
	}

    public partial class CommonEnglishSentence : BaseModel
	{
		[JsonProperty("sentence")]
		public string Sentence { get; set; }

		[JsonProperty("meaning")]
		public string Meaning { get; set; }

		[JsonProperty("sentenceId")]
		public long SentenceId { get; set; }
	}

	public partial class Categegory : BaseModel
	{
		[JsonProperty("categegoryId")]
		public long CategegoryId { get; set; }

		[JsonProperty("categegory")]
		public string OtherCategegory { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }
	}

	public partial class English : BaseModel
	{
		[JsonProperty("categegoryId")]
		public long? CategegoryId { get; set; }

		[JsonProperty("topic")]
		public string Topic { get; set; }

		[JsonProperty("categegory")]
		public string Categegory { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("topicId")]
		public long? TopicId { get; set; }
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
