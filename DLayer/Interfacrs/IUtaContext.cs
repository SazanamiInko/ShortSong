using DLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLayer.Interfacrs
{
    /// <summary>
    /// 歌コンテキストインターフェース
    /// </summary>
    public interface IUtaContext
    {
        public DbSet<MSeazon> MSeazons { get;  }

        public DbSet<THaiku> THaikus { get;  }

        public DbSet<THistory> THistories { get; }

        public DbSet<TPreference> TPreferences { get; }

        public DbSet<TShortSong> TShortSongs { get; }

        public void SaveChanges();
    }
}
