IF OBJECT_ID(N'DocumenteInline_TD', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[DocumenteInline_TD](
        [nId] [int] IDENTITY(1,1) NOT NULL,
        [nTipObiect] [smallint] NULL,
        [xnIdObiect] [int] NULL,
        [nTipImagine] [tinyint] NULL,
        [nImagine] [varbinary](max) NULL,
        [dDataCreare] [datetime] NULL,
        [xnUtilizatorCreare] [int] NULL,
        [dDataInchidere] [datetime] NULL,
        [xnUtilizatorInchidere] [int] NULL,
        [tMotivInchidere] [nvarchar](500) NULL,
        [tInformatiiComplementare] [nvarchar](max) NULL
     CONSTRAINT [PK_DocumenteInline_TD] PRIMARY KEY CLUSTERED
    (
        [nId] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END