﻿using System.Text.Json.Serialization;

namespace CloudMusicPlayer.Infrastructure.Services.Dropbox.Args;

internal record TemporaryLinkArg
{
    [JsonPropertyName("path")]
    public required string Path { get; init; }
}
