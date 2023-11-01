﻿using System.Text.Json.Serialization;

namespace CloudMusicPlayer.Infrastructure.DataProviders.Yandex;

public record FilesResponse
{
    [JsonPropertyName("items")]
    public IReadOnlyList<YandexFile> Items { get; set; } = null!;

    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; }
}