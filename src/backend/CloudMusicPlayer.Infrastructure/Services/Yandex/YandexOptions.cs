﻿namespace CloudMusicPlayer.Infrastructure.Services.Yandex;

internal record YandexOptions
{
    public const string SectionName = "yandex";

    public required string ClientId { get; set; }
    public required string ClientSecret { get; set; }
}
