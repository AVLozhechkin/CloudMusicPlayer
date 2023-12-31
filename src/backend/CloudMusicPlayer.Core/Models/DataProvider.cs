﻿using CloudMusicPlayer.Core.Enums;

namespace CloudMusicPlayer.Core.Models;

public record DataProvider : BaseEntity
{
    public DataProvider() { }

    public DataProvider(
        string name,
        Guid userId,
        ProviderTypes providerType,
        byte[] accessToken,
        byte[] refreshToken,
        DateTimeOffset expiresAt)
    {
        var currentDate = DateTimeOffset.UtcNow;

        UserId = userId;
        ProviderType = providerType;
        Name = name;
        AddedAt = currentDate;
        UpdatedAt = currentDate;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        AccessTokenExpiration = expiresAt;
    }

    public User? User { get; init; } = null!;
    public Guid UserId { get; init; }
    public ProviderTypes ProviderType { get; init; }
    public string Name { get; init; } = string.Empty;
    public DateTimeOffset AddedAt { get; init; }
    public DateTimeOffset UpdatedAt { get; set; }
    public byte[] AccessToken { get; set; } = null!;
    public DateTimeOffset AccessTokenExpiration { get; set; }
    public byte[] RefreshToken { get; set; } = null!;
    public IReadOnlyList<SongFile> SongFiles { get; init; } = null!;

    public void UpdateAccessToken(byte[] accessToken, DateTimeOffset expirationDate)
    {
        AccessToken = accessToken;
        AccessTokenExpiration = expirationDate;
    }
}
