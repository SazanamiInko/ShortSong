using System;
using System.Collections.Generic;

namespace DLayer.Models;

public partial class THaiku
{
    public long Id { get; set; }

    public string? SwazonWord { get; set; }

    public string Haiku { get; set; } = null!;

    public string? Kana { get; set; }

    public string? Front { get; set; }

    public long? Seazon { get; set; }

    public string? Memo { get; set; }

    public string? Index { get; set; }

    public string? English { get; set; }

    public long? Delete { get; set; }

    public string? CreateDateTime { get; set; }

    public string? UpdateDateTime { get; set; }

    public long? UpdateCount { get; set; }
}
