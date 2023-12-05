using System;
using System.Collections.Generic;

namespace DLayer.Models;

public partial class TShortSong
{
    public long Id { get; set; }

    public string? Front { get; set; }

    public string Uta { get; set; } = null!;

    public string Kana { get; set; } = null!;

    public string? English { get; set; }

    public string? RefUta { get; set; }

    public string? Index { get; set; }

    public string? Memo { get; set; }

    public long Seazon { get; set; }

    public string CreateDate { get; set; } = null!;

    public long Delete { get; set; }

    public string? UpdateDate { get; set; }

    public long UpdateCount { get; set; }
}
