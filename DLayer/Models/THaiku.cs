using System;
using System.Collections.Generic;

namespace DLayer.Models;

public partial class THaiku
{
    public long Id { get; set; }

    public string Haiku { get; set; } = null!;

    public string? Kana { get; set; }

    public string? Front { get; set; }

    public long? Seazon { get; set; }

    public string? Memo { get; set; }

    public string? English { get; set; }
}
