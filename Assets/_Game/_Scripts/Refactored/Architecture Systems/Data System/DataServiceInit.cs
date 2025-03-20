using System;
using System.IO;
using DS.Configs;
using DS.Core.Storage;
using DS.Core.Storage.Cache;
using DS.Services;
using UnityEngine;

public class DataServiceInit
{
    public DataService InitDataService()
    {
        var config = new DSConfig
        {
            LocalSyncInterval = TimeSpan.FromSeconds(5),
            RemoteSyncInterval = TimeSpan.FromSeconds(10),
            LocalStoragePath = Path.Combine(
                Application.dataPath,
                "_Game", "_Saves"
            )
        };
        var dataService = new DataServiceBuilder()
            .WithConfig(config)
            .ChangeTypesStorages<MemoryCacheStorage, JsonStorage, MockRemoteStorage>()
            .Build();
        return dataService;
    }
}