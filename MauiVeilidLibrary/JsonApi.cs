using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

public class JsonApi
{
    private readonly StreamReader _reader;
    private readonly StreamWriter _writer;
    private readonly Func<VeilidUpdate, Task> _updateCallback;
    private Task _handleRecvMessagesTask;
    private bool _validateSchema;
    private bool _done;
    private readonly object _lock = new object();
    private int _nextId;
    private readonly Dictionary<int, TaskCompletionSource<object>> _inFlightRequests;

    public JsonApi(StreamReader reader, StreamWriter writer, Func<VeilidUpdate, Task> updateCallback, bool validateSchema = true)
    {
        _reader = reader;
        _writer = writer;
        _updateCallback = updateCallback;
        _validateSchema = validateSchema;
        _done = false;
        _nextId = 0;
        _inFlightRequests = new Dictionary<int, TaskCompletionSource<object>>();
    }

    private async Task _CleanupClose()
    {
        await _lock.WaitAsync();
        try
        {
            _reader = null;
            Debug.Assert(_writer != null);
            try
            {
                _writer.Close();
                await _writer.WaitUntilClosed();
            }
            catch
            {
                // Already closed
            }
            _writer = null;

            foreach (var request in _inFlightRequests.Values)
            {
                request.TrySetCanceled();
            }
        }
        finally
        {
            _lock.Release();
        }
    }

    public bool IsDone()
    {
        return _done;
    }

    public async Task Release()
    {
        // Take the task
        await lockObj.WaitAsync();
        try
        {
            if (handleRecvMessagesTask == null)
            {
                return;
            }
            Task handleRecvMessagesTask = this.handleRecvMessagesTask;
            this.handleRecvMessagesTask = null;
        }
        finally
        {
            lockObj.Release();
        }
        // Cancel it
        handleRecvMessagesTask.Cancel();
        try
        {
            await handleRecvMessagesTask;
        }
        catch (TaskCanceledException)
        {
            // Handle cancellation
        }
        done = true;
    }


    // Other methods...

    public async Task<string> Control(List<string> args)
    {
        // Control method implementation
    }

    public async Task<VeilidState> GetState()
    {
        // GetState method implementation
    }

    public async Task Attach()
    {
        // Attach method implementation
    }

    public async Task Detach()
    {
        // Detach method implementation
    }

    public async Task<(RouteId, byte[])> NewPrivateRoute()
    {
        // NewPrivateRoute method implementation
    }

    public async Task<(RouteId, byte[])> NewCustomPrivateRoute(List<CryptoKind> kinds, Stability stability, Sequencing sequencing)
    {
        // NewCustomPrivateRoute method implementation
    }

    public async Task<RouteId> ImportRemotePrivateRoute(byte[] blob)
    {
        // ImportRemotePrivateRoute method implementation
    }

    public async Task ReleasePrivateRoute(RouteId routeId)
    {
        // ReleasePrivateRoute method implementation
    }

    public async Task AppCallReply(OperationId callId, byte[] message)
    {
        // AppCallReply method implementation
    }

    public async Task<RoutingContext> NewRoutingContext()
    {
        // NewRoutingContext method implementation
    }

    public async Task<TableDb> OpenTableDb(string name, int columnCount)
    {
        // OpenTableDb method implementation
    }

    public async Task<bool> DeleteTableDb(string name)
    {
        // DeleteTableDb method implementation
    }

    public async Task<CryptoSystem> GetCryptoSystem(CryptoKind kind)
    {
        // GetCryptoSystem method implementation
    }

    public async Task<CryptoSystem> BestCryptoSystem()
    {
        // BestCryptoSystem method implementation
    }

    public async Task<List<TypedKey>> VerifySignatures(List<TypedKey> nodeIds, byte[] data, List<TypedSignature> signatures)
    {
        // VerifySignatures method implementation
    }

    public async Task<List<TypedSignature>> GenerateSignatures(byte[] data, List<TypedKeyPair> keyPairs)
    {
        // GenerateSignatures method implementation
    }

    public async Task<List<TypedKeyPair>> GenerateKeyPair(CryptoKind kind)
    {
        // GenerateKeyPair method implementation
    }

    public async Task<Timestamp> Now()
    {
        // Now method implementation
    }

    public async Task<string> Debug(string command)
    {
        // Debug method implementation
    }

    public async Task<string> VeilidVersionString()
    {
        // VeilidVersionString method implementation
    }

    public async Task<VeilidVersion> VeilidVersion()
    {
        // VeilidVersion method implementation
    }

    public async Task<string> DefaultVeilidConfig()
    {
        // DefaultVeilidConfig method implementation
    }
}

public class RoutingContext
{
    private readonly JsonApi _api;
    private readonly int _rcId;
    private bool _done;

    public RoutingContext(JsonApi api, int rcId)
    {
        _api = api;
        _rcId = rcId;
        _done = false;
    }

    public bool IsDone()
    {
        return _done;
    }

    public async Task Release()
    {
        // Release method implementation
    }

    // Other methods...
}

public class TableDbTransaction
{
    private readonly JsonApi _api;
    private readonly int _txId;
    private bool _done;

    public TableDbTransaction(JsonApi api, int txId)
    {
        _api = api;
        _txId = txId;
        _done = false;
    }

    public bool IsDone()
    {
        return _done;
    }

    public async Task Commit()
    {
        // Commit method implementation
    }

    public async Task Rollback()
    {
        // Rollback method implementation
    }

    // Other methods...
}

public class TableDb
{
    private readonly JsonApi _api;
    private readonly int _dbId;
    private bool _done;

    public TableDb(JsonApi api, int dbId)
    {
        _api = api;
        _dbId = dbId;
        _done = false;
    }

    public bool IsDone()
    {
        return _done;
    }

    public async Task Release()
    {
        // Release method implementation
    }

    // Other methods...
}

public class CryptoSystem
{
    private readonly JsonApi _api;
    private readonly int _csId;
    private bool _done;

    public CryptoSystem(JsonApi api, int csId)
    {
        _api = api;
        _csId = csId;
        _done = false;
    }

    public bool IsDone()
    {
        return _done;
    }

    // Other methods...
}

public class VeilidUpdate
{
    // VeilidUpdate properties
}

public class VeilidState
{
    // VeilidState properties
}

public class CryptoKind
{
    // CryptoKind properties
}

public class Stability
{
    // Stability properties
}

public class Sequencing
{
    // Sequencing properties
}

public class RouteId
{
    // RouteId properties
}

public class OperationId
{
    // OperationId properties
}

public class TypedKey
{
    // TypedKey properties
}

public class TypedSignature
{
    // TypedSignature properties
}

public class TypedKeyPair
{
    // TypedKeyPair properties
}

public class VeilidVersion
{
    // VeilidVersion properties
}