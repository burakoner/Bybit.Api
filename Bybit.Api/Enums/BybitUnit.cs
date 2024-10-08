﻿namespace Bybit.Api.Enums;

/// <summary>
/// Bybit market unit
/// </summary>
public enum BybitUnit
{
    /// <summary>
    /// Base asset
    /// </summary>
    [Map("baseCoin")]
    BaseAsset = 1,

    /// <summary>
    /// Quote asset
    /// </summary>
    [Map("quoteCoin")]
    QuoteAsset = 2,
}