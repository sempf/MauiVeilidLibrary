using System.Collections.Generic;

public enum VeilidConfigLogLevel
{
    Off,
    Error,
    Warn,
    Info,
    Debug,
    Trace
}

public class ConfigBase
{
    public static T FromJson<T>(Dictionary<string, object> json) where T : ConfigBase, new()
    {
        var instance = new T();
        foreach (var property in typeof(T).GetProperties())
        {
            var key = property.Name;
            if (json.TryGetValue(key, out var value))
            {
                if (property.PropertyType.IsEnum)
                {
                    property.SetValue(instance, Enum.Parse(property.PropertyType, value.ToString()));
                }
                else
                {
                    property.SetValue(instance, value);
                }
            }
        }
        return instance;
    }

    public Dictionary<string, object> ToJson()
    {
        var json = new Dictionary<string, object>();
        foreach (var property in GetType().GetProperties())
        {
            var key = property.Name;
            var value = property.GetValue(this);
            json[key] = value;
        }
        return json;
    }
}

public class VeilidConfigCapabilities : ConfigBase
{
    public List<Capability> Disable { get; set; }
}

public class VeilidConfigProtectedStore : ConfigBase
{
    public bool AllowInsecureFallback { get; set; }
    public bool AlwaysUseInsecureStorage { get; set; }
    public string Directory { get; set; }
    public bool Delete { get; set; }
    public string DeviceEncryptionKeyPassword { get; set; }
    public string NewDeviceEncryptionKeyPassword { get; set; }
}

public class VeilidConfigTableStore : ConfigBase
{
    public string Directory { get; set; }
    public bool Delete { get; set; }
}

public class VeilidConfigBlockStore : ConfigBase
{
    public string Directory { get; set; }
    public bool Delete { get; set; }
}

public class VeilidConfigRoutingTable : ConfigBase
{
    public List<TypedKey> NodeId { get; set; }
    public List<TypedSecret> NodeIdSecret { get; set; }
    public List<string> Bootstrap { get; set; }
    public int LimitOverAttached { get; set; }
    public int LimitFullyAttached { get; set; }
    public int LimitAttachedStrong { get; set; }
    public int LimitAttachedGood { get; set; }
    public int LimitAttachedWeak { get; set; }
}

public class VeilidConfigRPC : ConfigBase
{
    public int Concurrency { get; set; }
    public int QueueSize { get; set; }
    public int? MaxTimestampBehindMs { get; set; }
    public int? MaxTimestampAheadMs { get; set; }
    public int TimeoutMs { get; set; }
    public int MaxRouteHopCount { get; set; }
    public int DefaultRouteHopCount { get; set; }
}

public class VeilidConfigDHT : ConfigBase
{
    public int MaxFindNodeCount { get; set; }
    public int ResolveNodeTimeoutMs { get; set; }
    public int ResolveNodeCount { get; set; }
    public int ResolveNodeFanout { get; set; }
    public int GetValueTimeoutMs { get; set; }
    public int GetValueCount { get; set; }
    public int GetValueFanout { get; set; }
    public int SetValueTimeoutMs { get; set; }
    public int SetValueCount { get; set; }
    public int SetValueFanout { get; set; }
    public int MinPeerCount { get; set; }
    public int MinPeerRefreshTimeMs { get; set; }
    public int ValidateDialInfoReceiptTimeMs { get; set; }
    public int LocalSubkeyCacheSize { get; set; }
    public int LocalMaxSubkeyCacheMemoryMb { get; set; }
    public int RemoteSubkeyCacheSize { get; set; }
    public int RemoteMaxRecords { get; set; }
    public int RemoteMaxSubkeyCacheMemoryMb { get; set; }
    public int RemoteMaxStorageSpaceMb { get; set; }
    public int PublicWatchLimit { get; set; }
    public int MemberWatchLimit { get; set; }
    public int MaxWatchExpirationMs { get; set; }
}

public class VeilidConfigTLS : ConfigBase
{
    public string CertificatePath { get; set; }
    public string PrivateKeyPath { get; set; }
    public int ConnectionInitialTimeoutMs { get; set; }
}

public class VeilidConfigHTTPS : ConfigBase
{
    public bool Enabled { get; set; }
    public string ListenAddress { get; set; }
    public string Path { get; set; }
    public string Url { get; set; }
}

public class VeilidConfigHTTP : ConfigBase
{
    public bool Enabled { get; set; }
    public string ListenAddress { get; set; }
    public string Path { get; set; }
    public string Url { get; set; }
}

public class VeilidConfigApplication : ConfigBase
{
    public VeilidConfigHTTPS Https { get; set; }
    public VeilidConfigHTTP Http { get; set; }
}

public class VeilidConfigUDP : ConfigBase
{
    public bool Enabled { get; set; }
    public int SocketPoolSize { get; set; }
    public string ListenAddress { get; set; }
    public string PublicAddress { get; set; }
}

public class VeilidConfigTCP : ConfigBase
{
    public bool Connect { get; set; }
    public bool Listen { get; set; }
    public int MaxConnections { get; set; }
    public string ListenAddress { get; set; }
    public string PublicAddress { get; set; }
}

public class VeilidConfigWS : ConfigBase
{
    public bool Connect { get; set; }
    public bool Listen { get; set; }
    public int MaxConnections { get; set; }
    public string ListenAddress { get; set; }
    public string Path { get; set; }
    public string Url { get; set; }
}

public class VeilidConfigWSS : ConfigBase
{
    public bool Connect { get; set; }
    public bool Listen { get; set; }
    public int MaxConnections { get; set; }
    public string ListenAddress { get; set; }
    public string Path { get; set; }
    public string Url { get; set; }
}

public class VeilidConfigProtocol : ConfigBase
{
    public VeilidConfigUDP Udp { get; set; }
    public VeilidConfigTCP Tcp { get; set; }
    public VeilidConfigWS Ws { get; set; }
    public VeilidConfigWSS Wss { get; set; }
}

public class VeilidConfigNetwork : ConfigBase
{
    public int ConnectionInitialTimeoutMs { get; set; }
    public int ConnectionInactivityTimeoutMs { get; set; }
    public int MaxConnectionsPerIp4 { get; set; }
    public int MaxConnectionsPerIp6Prefix { get; set; }
    public int MaxConnectionsPerIp6PrefixSize { get; set; }
    public int MaxConnectionFrequencyPerMin { get; set; }
    public int ClientAllowlistTimeoutMs { get; set; }
    public int ReverseConnectionReceiptTimeMs { get; set; }
    public int HolePunchReceiptTimeMs { get; set; }
    public string NetworkKeyPassword { get; set; }
    public VeilidConfigRoutingTable RoutingTable { get; set; }
    public VeilidConfigRPC Rpc { get; set; }
    public VeilidConfigDHT Dht { get; set; }
    public bool Upnp { get; set; }
    public bool DetectAddressChanges { get; set; }
    public int RestrictedNatRetries { get; set; }
    public VeilidConfigTLS Tls { get; set; }
    public VeilidConfigApplication Application { get; set; }
    public VeilidConfigProtocol Protocol { get; set; }
}

public class VeilidConfig : ConfigBase
{
    public string ProgramName { get; set; }
    public string Namespace { get; set; }
    public VeilidConfigCapabilities Capabilities { get; set; }
    public VeilidConfigProtectedStore ProtectedStore { get; set; }
    public VeilidConfigTableStore TableStore { get; set; }
    public VeilidConfigBlockStore BlockStore { get; set; }
    public VeilidConfigNetwork Network { get; set; }
}
