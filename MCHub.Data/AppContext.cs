﻿using MCHub.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WMCHub.Data
{
    public class AppContext : DbContext
    {

        public AppContext() : base("name=AttachToMdfStoredInAppFolder")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppContext,
            MCHub.Data.Migrations.Configuration>("AttachToMdfStoredInAppFolder"));
        }


        public DbSet<MediaItem> MediaItems { get; set; }
        public DbSet<MediaItemDetail> MediaItemDetails { get; set; }
        public DbSet<MetadataItem> MetadataItems { get; set; }
        public DbSet<RecordingDetail> RecordingDetails { get; set; }
        public DbSet<MetadataItemView> MetadataItemViews { get; set; }

        // public DbSet<WtvRecording> WtvRecordings { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<WtvRecording>().Map(m =>
        //        {
        //            m.Properties(p => new { p.WtvRecordingId, p.FileName, p.FilePath });
        //            m.ToTable("MediaItems");

        //        }).Map(m =>
        //        {
        //            m.Properties(p => new { p.WtvRecordingId, p.Size, p.DateCreated });
        //            m.ToTable("MediaItemDetails");
        //        }).Map(m =>
        //        {
        //            m.Properties(p => new { p.WtvRecordingId, p.ChannelNumber, p.StationName, p.StationCallSign });
        //            m.ToTable("RecordingDetails");
        //        });

        //}
    }
}
