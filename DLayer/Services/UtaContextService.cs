using DLayer.Interfacrs;
using DLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLayer.Services
{
    /// <summary>
    /// 歌コンテキストサービス
    /// </summary>
    public class UtaContextService : IUtaContext
    {
        #region メンバー

        private UtaContext context;

        #endregion

        #region プロパティ
        public DbSet<MSeazon> MSeazons { get { return context.MSeazons; } }

        public DbSet<THaiku> THaikus {get{ return context.THaikus; } }

        public DbSet<THistory> THistories { get { return context.THistories; } }

        public DbSet<TPreference> TPreferences { get { return context.TPreferences; } }

        public DbSet<TShortSong> TShortSongs { get { return context.TShortSongs; } }
        #endregion


        public UtaContextService()
        {
            context = new UtaContext();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
