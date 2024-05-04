using System;

public enum Operation
{
    Control,
    GetState,
    Attach,
    Detach,
    NewPrivateRoute,
    NewCustomPrivateRoute,
    ImportRemotePrivateRoute,
    ReleasePrivateRoute,
    AppCallReply,
    NewRoutingContext,
    RoutingContext,
    OpenTableDb,
    DeleteTableDb,
    TableDb,
    TableDbTransaction,
    GetCryptoSystem,
    BestCryptoSystem,
    CryptoSystem,
    VerifySignatures,
    GenerateSignatures,
    GenerateKeyPair,
    Now,
    Debug,
    VeilidVersionString,
    VeilidVersion,
    DefaultVeilidConfig
}

public enum RoutingContextOperation
{
    InvalidId,
    Release,
    WithDefaultSafety,
    WithSafety,
    WithSequencing,
    Safety,
    AppCall,
    AppMessage,
    CreateDhtRecord,
    OpenDhtRecord,
    CloseDhtRecord,
    DeleteDhtRecord,
    GetDhtValue,
    SetDhtValue,
    WatchDhtValues,
    CancelDhtWatch,
    InspectDhtRecord
}

public enum TableDbOperation
{
    InvalidId,
    Release,
    GetColumnCount,
    GetKeys,
    Transact,
    Store,
    Load,
    Delete
}

public enum TableDbTransactionOperation
{
    InvalidId,
    Commit,
    Rollback,
    Store,
    Delete
}

public enum CryptoSystemOperation
{
    InvalidId,
    Release,
    CachedDh,
    ComputeDh,
    GenerateSharedSecret,
    RandomBytes,
    DefaultSaltLength,
    HashPassword,
    VerifyPassword,
    DeriveSharedSecret,
    RandomNonce,
    RandomSharedSecret,
    GenerateKeyPair,
    GenerateHash,
    ValidateKeyPair,
    ValidateHash,
    Distance,
    Sign,
    Verify,
    AeadOverhead,
    DecryptAead,
    EncryptAead,
    CryptNoAuth
}

public enum RecvMessageType
{
    Response,
    Update
}
