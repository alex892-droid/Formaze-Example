using System.Collections.Concurrent;
using Formaze.Blazor.Mudblazor.Data;
using Formaze.Blazor.Mudblazor.Interfaces;

namespace Formaze.Examples.CustomStore.Stores;

/// <summary>
/// A hand-written <see cref="IFormazeStore"/> showing how to plug Formaze into any backend.
/// This one keeps configs in a <see cref="ConcurrentDictionary{TKey,TValue}"/> and logs every
/// operation — swap the dictionary for Redis, Dapper, a REST call, etc. and the contract is the same.
/// </summary>
public sealed class InMemoryLoggingStore(ILogger<InMemoryLoggingStore> logger) : IFormazeStore
{
    private readonly ConcurrentDictionary<string, Form> _configs = new();

    public Task<Form?> LoadAsync(string key, CancellationToken ct = default)
    {
        _configs.TryGetValue(key, out var form);
        logger.LogInformation("Formaze LOAD '{Key}' -> {Result}", key, form is null ? "miss" : "hit");
        return Task.FromResult(form);
    }

    public Task SaveAsync(string key, Form Formaze, CancellationToken ct = default)
    {
        _configs[key] = Formaze;
        var fieldCount = Formaze.Groups.Sum(g => g.Fields.Count);
        logger.LogInformation("Formaze SAVE '{Key}' ({Groups} group(s), {Fields} field(s))",
            key, Formaze.Groups.Count, fieldCount);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(string key, CancellationToken ct = default)
    {
        _configs.TryRemove(key, out _);
        logger.LogInformation("Formaze DELETE '{Key}'", key);
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<string>> ListKeysAsync(CancellationToken ct = default)
    {
        IReadOnlyList<string> keys = _configs.Keys.ToList();
        logger.LogInformation("Formaze LIST -> {Count} key(s)", keys.Count);
        return Task.FromResult(keys);
    }
}
