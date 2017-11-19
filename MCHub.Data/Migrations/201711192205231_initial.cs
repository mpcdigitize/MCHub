namespace MCHub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MediaItemDetails",
                c => new
                    {
                        MediaItemDetailId = c.Guid(nullable: false),
                        Size = c.String(),
                        Duration = c.String(),
                        DateCreated = c.String(),
                        MediaItemId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.MediaItemDetailId);
            
            CreateTable(
                "dbo.MediaItems",
                c => new
                    {
                        MediaItemId = c.Guid(nullable: false),
                        FileName = c.String(),
                        FilePath = c.String(),
                        MediaItemDetail_MediaItemDetailId = c.Guid(),
                        MetadataItem_MetadataItemId = c.Guid(),
                        MetadataItemView_MetadataItemViewId = c.Guid(),
                        RecordingDetail_RecordingDetailId = c.Guid(),
                    })
                .PrimaryKey(t => t.MediaItemId)
                .ForeignKey("dbo.MediaItemDetails", t => t.MediaItemDetail_MediaItemDetailId)
                .ForeignKey("dbo.MetadataItems", t => t.MetadataItem_MetadataItemId)
                .ForeignKey("dbo.MetadataItemViews", t => t.MetadataItemView_MetadataItemViewId)
                .ForeignKey("dbo.RecordingDetails", t => t.RecordingDetail_RecordingDetailId)
                .Index(t => t.MediaItemDetail_MediaItemDetailId)
                .Index(t => t.MetadataItem_MetadataItemId)
                .Index(t => t.MetadataItemView_MetadataItemViewId)
                .Index(t => t.RecordingDetail_RecordingDetailId);
            
            CreateTable(
                "dbo.MetadataItems",
                c => new
                    {
                        MetadataItemId = c.Guid(nullable: false),
                        Title = c.String(),
                        TitleSort = c.String(),
                        Description = c.String(),
                        Genre = c.String(),
                        MediaItemId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.MetadataItemId);
            
            CreateTable(
                "dbo.MetadataItemViews",
                c => new
                    {
                        MetadataItemViewId = c.Guid(nullable: false),
                        LibrarySectionId = c.Int(nullable: false),
                        MetadataType = c.Int(nullable: false),
                        EpisodeNumber = c.Int(nullable: false),
                        SeriesName = c.String(),
                        SeasonNumber = c.String(),
                        MediaItemId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.MetadataItemViewId);
            
            CreateTable(
                "dbo.RecordingDetails",
                c => new
                    {
                        RecordingDetailId = c.Guid(nullable: false),
                        DateReleased = c.String(),
                        ChannelNumber = c.String(),
                        StationName = c.String(),
                        StationCallSign = c.String(),
                        RecordingTime = c.String(),
                        IsRerun = c.String(),
                        IsProtected = c.String(),
                        MediaItemId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.RecordingDetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MediaItems", "RecordingDetail_RecordingDetailId", "dbo.RecordingDetails");
            DropForeignKey("dbo.MediaItems", "MetadataItemView_MetadataItemViewId", "dbo.MetadataItemViews");
            DropForeignKey("dbo.MediaItems", "MetadataItem_MetadataItemId", "dbo.MetadataItems");
            DropForeignKey("dbo.MediaItems", "MediaItemDetail_MediaItemDetailId", "dbo.MediaItemDetails");
            DropIndex("dbo.MediaItems", new[] { "RecordingDetail_RecordingDetailId" });
            DropIndex("dbo.MediaItems", new[] { "MetadataItemView_MetadataItemViewId" });
            DropIndex("dbo.MediaItems", new[] { "MetadataItem_MetadataItemId" });
            DropIndex("dbo.MediaItems", new[] { "MediaItemDetail_MediaItemDetailId" });
            DropTable("dbo.RecordingDetails");
            DropTable("dbo.MetadataItemViews");
            DropTable("dbo.MetadataItems");
            DropTable("dbo.MediaItems");
            DropTable("dbo.MediaItemDetails");
        }
    }
}
