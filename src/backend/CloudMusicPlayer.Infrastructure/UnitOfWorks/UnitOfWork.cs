﻿using CloudMusicPlayer.Core.Interfaces;
using CloudMusicPlayer.Core.Interfaces.Repositories;
using CloudMusicPlayer.Infrastructure.Database;
using CloudMusicPlayer.Infrastructure.Repositories;

namespace CloudMusicPlayer.Infrastructure.UnitOfWorks;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _applicationContext;

    private IDataProviderRepository? _dataProviderRepository;
    private IPlaylistRepository? _playlistRepository;
    private ISongFileRepository? _songFileRepository;
    private IUserRepository? _userRepository;
    private IPlaylistItemRepository? _playlistItemRepository;
    private IHistoryRepository? _historyRepository;
    private IHistoryItemRepository? _historyItemRepository;

    public UnitOfWork(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public IDataProviderRepository DataProviderRepository =>
        _dataProviderRepository ??= new DataProviderRepository(_applicationContext);
    public IHistoryItemRepository HistoryItemRepository =>
        _historyItemRepository ??= new HistoryItemRepository(_applicationContext);
    public IPlaylistItemRepository PlaylistItemRepository =>
        _playlistItemRepository ??= new PlaylistItemRepository(_applicationContext);
    public IPlaylistRepository PlaylistRepository =>
        _playlistRepository ??= new PlaylistRepository(_applicationContext);
    public ISongFileRepository SongFileRepository =>
        _songFileRepository ??= new SongFileRepository(_applicationContext);
    public IUserRepository UserRepository =>
        _userRepository ??= new UserRepository(_applicationContext);
    public IHistoryRepository HistoryRepository =>
        _historyRepository ??= new HistoryRepository(_applicationContext);

    public async Task CommitAsync()
    {
        await using var dbContextTransaction = await _applicationContext.Database.BeginTransactionAsync();

        try
        {
            await _applicationContext.SaveChangesAsync();
            await dbContextTransaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await dbContextTransaction.RollbackAsync();
        }
    }
}
