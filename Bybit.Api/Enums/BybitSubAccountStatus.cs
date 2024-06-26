﻿namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Sub Account Status
/// </summary>
public enum BybitSubAccountStatus
{
    /// <summary>
    /// Normal
    /// </summary>
    [Label("1")]
    Normal,

    /// <summary>
    /// Banned
    /// </summary>
    [Label("2")]
    LoginBanned,

    /// <summary>
    /// Frozen
    /// </summary>
    [Label("4")]
    Frozen,
}