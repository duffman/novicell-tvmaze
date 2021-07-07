//
//   Written by Patrik Forsberg 2021 <patrik.forsberg@coldmind.com>
//   This file is part of the TvMaze Work Sample Project
//

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TvMazeWebApp.DataProvider.Types
{
	public partial class CastMember
	{
		[JsonPropertyName("person")] public Person Person { get; set; }
		[JsonPropertyName("character")] public Character Character { get; set; }
		[JsonPropertyName("self")] public bool Self { get; set; }
		[JsonPropertyName("voice")] public bool Voice { get; set; }
	}

	public partial class Character
	{
		[JsonPropertyName("id")] public long Id { get; set; }
		[JsonPropertyName("url")] public Uri Url { get; set; }
		[JsonPropertyName("name")] public string Name { get; set; }
		[JsonPropertyName("image")] public Image Image { get; set; }
		[JsonPropertyName("_links")] public Links Links { get; set; }
	}

	public partial class Image
	{
		[JsonPropertyName("medium")] public Uri Medium { get; set; }
		[JsonPropertyName("original")] public Uri Original { get; set; }
	}

	public partial class Links
	{
		[JsonPropertyName("self")] public Self Self { get; set; }
	}

	public partial class Self
	{
		[JsonPropertyName("href")] public Uri Href { get; set; }
	}

	public partial class Person
	{
		[JsonPropertyName("id")] public long Id { get; set; }
		[JsonPropertyName("url")] public Uri Url { get; set; }
		[JsonPropertyName("name")] public string Name { get; set; }
		[JsonPropertyName("country")] public Country Country { get; set; }
		[JsonPropertyName("birthday")] public DateTimeOffset Birthday { get; set; }
		[JsonPropertyName("deathday")] public object Deathday { get; set; }
		[JsonPropertyName("gender")] public string Gender { get; set; }
		[JsonPropertyName("image")] public Image Image { get; set; }
		[JsonPropertyName("_links")] public Links Links { get; set; }
	}

	public partial class Country
	{
		[JsonPropertyName("name")] public string Name { get; set; }
		[JsonPropertyName("code")] public string Code { get; set; }
		[JsonPropertyName("timezone")] public string Timezone { get; set; }
	}

	public partial class Deserialize
	{
		static readonly JsonSerializerOptions Options = new JsonSerializerOptions
		{
			AllowTrailingCommas = true
		};

		public static List<CastMember> FromJson(string jsonString)
		{
			return JsonSerializer.Deserialize<List<CastMember>>(jsonString, Options);
		}
	}

	public static class CastMemberFactory
	{
		public static string ToJson(this List<CastMember> self)
		{
			return JsonSerializer.Serialize(self);
		}

		public static CastMember CreateFakeMember()
		{
			var member = new CastMember
			{
				Character = new Character()
				{
					Id = 1,
					Name = "Axl Rose",
					Image = new Image()
					{
						Medium	= new Uri(""),
						Original = new Uri("")
					},
					Links = new Links(),
				},
				Person = new Person()
				{
					Id	=  10,
					Name = "Patrik Forsberg"
				},
				Self = true,
				Voice = true
			};

			return member;
		}
	}

	internal static class Converter
	{
/*
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
*/
	}
}