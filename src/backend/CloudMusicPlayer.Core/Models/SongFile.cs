﻿using CloudMusicPlayer.Core.Enums;

namespace CloudMusicPlayer.Core.Models;

public record SongFile : BaseEntity
{
    public DataProvider DataProvider { get; set; } = null!;
    public Guid DataProviderId { get; set; }
    public required string Name { get; set; }
    public required string FileId { get; set; }
    public required string Hash { get; set; }
    public required string Path { get; set; }
    public required AudioTypes Type { get; set; }
    public required ulong Size { get; set; }
}
