
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/25/2013 10:19:33
-- Generated from EDMX file: D:\Web\try\LNCDCDSS\LNCDCDSS\Models\LNCDDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [model];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_VisitRecordPatADL]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatADLSet] DROP CONSTRAINT [FK_VisitRecordPatADL];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordPatMoCA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatMoCASet] DROP CONSTRAINT [FK_VisitRecordPatMoCA];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordPatOtherTest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatOtherTestSet] DROP CONSTRAINT [FK_VisitRecordPatOtherTest];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordPatMMSE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatMMSESet] DROP CONSTRAINT [FK_VisitRecordPatMMSE];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordPatGDS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatGDSSet] DROP CONSTRAINT [FK_VisitRecordPatGDS];
GO
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforPatExam1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatBasicInforSet] DROP CONSTRAINT [FK_PatBasicInforPatExam1];
GO
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforPatDisease]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatBasicInforSet] DROP CONSTRAINT [FK_PatBasicInforPatDisease];
GO
IF OBJECT_ID(N'[dbo].[FK_DoctorAccountPatBasicInfor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatBasicInforSet] DROP CONSTRAINT [FK_DoctorAccountPatBasicInfor];
GO
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforVisitRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitRecordSet] DROP CONSTRAINT [FK_PatBasicInforVisitRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordPatRecentDrug]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatRecentDrugSet] DROP CONSTRAINT [FK_VisitRecordPatRecentDrug];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DoctorAccountSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DoctorAccountSet];
GO
IF OBJECT_ID(N'[dbo].[PatBasicInforSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatBasicInforSet];
GO
IF OBJECT_ID(N'[dbo].[PatPhysicalExamSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatPhysicalExamSet];
GO
IF OBJECT_ID(N'[dbo].[PatMMSESet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatMMSESet];
GO
IF OBJECT_ID(N'[dbo].[PatMoCASet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatMoCASet];
GO
IF OBJECT_ID(N'[dbo].[PatADLSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatADLSet];
GO
IF OBJECT_ID(N'[dbo].[PatOtherTestSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatOtherTestSet];
GO
IF OBJECT_ID(N'[dbo].[PatDiseaseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatDiseaseSet];
GO
IF OBJECT_ID(N'[dbo].[PatGDSSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatGDSSet];
GO
IF OBJECT_ID(N'[dbo].[VisitRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VisitRecordSet];
GO
IF OBJECT_ID(N'[dbo].[PatRecentDrugSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatRecentDrugSet];
GO
IF OBJECT_ID(N'[dbo].[PatLabExamSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatLabExamSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DoctorAccountSet'
CREATE TABLE [dbo].[DoctorAccountSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [PassWord] nvarchar(max)  NOT NULL,
    [Hospital] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PatBasicInforSet'
CREATE TABLE [dbo].[PatBasicInforSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DoctorAccountId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Sex] nvarchar(max)  NOT NULL,
    [Birthday] nvarchar(max)  NOT NULL,
    [Education] nvarchar(max)  NOT NULL,
    [Job] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [FamilyMember] nvarchar(max)  NOT NULL,
    [PatExam_1_Id] int  NOT NULL,
    [PatDisease_Id] int  NOT NULL
);
GO

-- Creating table 'PatPhysicalExamSet'
CREATE TABLE [dbo].[PatPhysicalExamSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Height] nvarchar(max)  NOT NULL,
    [Weight] nvarchar(max)  NOT NULL,
    [Waistline] nvarchar(max)  NOT NULL,
    [Hipline] nvarchar(max)  NOT NULL,
    [BloodPressureH] nvarchar(max)  NOT NULL,
    [BloodPressureL] nvarchar(max)  NOT NULL,
    [B1_Result] nvarchar(max)  NOT NULL,
    [B1_Note] nvarchar(max)  NOT NULL,
    [B2_Result] nvarchar(max)  NOT NULL,
    [B2_Note] nvarchar(max)  NOT NULL,
    [B3_Result] nvarchar(max)  NOT NULL,
    [B3_Note] nvarchar(max)  NOT NULL,
    [B4_Result] nvarchar(max)  NOT NULL,
    [B4_Note] nvarchar(max)  NOT NULL,
    [B5_Result] nvarchar(max)  NOT NULL,
    [B5_Note] nvarchar(max)  NOT NULL,
    [B6_Result] nvarchar(max)  NOT NULL,
    [B6_Note] nvarchar(max)  NOT NULL,
    [B7_Result] nvarchar(max)  NOT NULL,
    [B7_Note] nvarchar(max)  NOT NULL,
    [B8_Result] nvarchar(max)  NOT NULL,
    [B8_Note] nvarchar(max)  NOT NULL,
    [B9_Result] nvarchar(max)  NOT NULL,
    [B9_Note] nvarchar(max)  NOT NULL,
    [B10_Result] nvarchar(max)  NOT NULL,
    [B10_Note] nvarchar(max)  NOT NULL,
    [B11_Result] nvarchar(max)  NOT NULL,
    [B11_Note] nvarchar(max)  NOT NULL,
    [B12_Result] nvarchar(max)  NOT NULL,
    [B12_Note] nvarchar(max)  NOT NULL,
    [B12a_Result] nvarchar(max)  NOT NULL,
    [B12a_Note] nvarchar(max)  NOT NULL,
    [B12b_Result] nvarchar(max)  NOT NULL,
    [B12b_Note] nvarchar(max)  NOT NULL,
    [B12c_Result] nvarchar(max)  NOT NULL,
    [B12c_Note] nvarchar(max)  NOT NULL,
    [B12d_Result] nvarchar(max)  NOT NULL,
    [B12d_Note] nvarchar(max)  NOT NULL,
    [B12e_Result] nvarchar(max)  NOT NULL,
    [B12e_Note] nvarchar(max)  NOT NULL,
    [B12f_Result] nvarchar(max)  NOT NULL,
    [B12f_Note] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PatMMSESet'
CREATE TABLE [dbo].[PatMMSESet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [M1] nvarchar(max)  NOT NULL,
    [M2] nvarchar(max)  NOT NULL,
    [M3] nvarchar(max)  NOT NULL,
    [M4] nvarchar(max)  NOT NULL,
    [M5] nvarchar(max)  NOT NULL,
    [M6] nvarchar(max)  NOT NULL,
    [M7] nvarchar(max)  NOT NULL,
    [M8] nvarchar(max)  NOT NULL,
    [M9] nvarchar(max)  NOT NULL,
    [M10] nvarchar(max)  NOT NULL,
    [M11] nvarchar(max)  NOT NULL,
    [Total] nvarchar(max)  NOT NULL,
    [VisitRecord_Id] int  NOT NULL
);
GO

-- Creating table 'PatMoCASet'
CREATE TABLE [dbo].[PatMoCASet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MC1] nvarchar(max)  NOT NULL,
    [MC2] nvarchar(max)  NOT NULL,
    [MC3] nvarchar(max)  NOT NULL,
    [MC4] nvarchar(max)  NOT NULL,
    [MC5] nvarchar(max)  NOT NULL,
    [MC6] nvarchar(max)  NOT NULL,
    [MC7] nvarchar(max)  NOT NULL,
    [MC8] nvarchar(max)  NOT NULL,
    [MC9] nvarchar(max)  NOT NULL,
    [Total] nvarchar(max)  NOT NULL,
    [VisitRecord_Id] int  NOT NULL
);
GO

-- Creating table 'PatADLSet'
CREATE TABLE [dbo].[PatADLSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [A1] nvarchar(max)  NOT NULL,
    [A2] nvarchar(max)  NOT NULL,
    [A3] nvarchar(max)  NOT NULL,
    [A4] nvarchar(max)  NOT NULL,
    [A5] nvarchar(max)  NOT NULL,
    [A6] nvarchar(max)  NOT NULL,
    [A7] nvarchar(max)  NOT NULL,
    [A8] nvarchar(max)  NOT NULL,
    [A9] nvarchar(max)  NOT NULL,
    [A10] nvarchar(max)  NOT NULL,
    [A11] nvarchar(max)  NOT NULL,
    [A12] nvarchar(max)  NOT NULL,
    [A13] nvarchar(max)  NOT NULL,
    [A14] nvarchar(max)  NOT NULL,
    [A15] nvarchar(max)  NULL,
    [A16] nvarchar(max)  NOT NULL,
    [A17] nvarchar(max)  NOT NULL,
    [A18] nvarchar(max)  NOT NULL,
    [A19] nvarchar(max)  NOT NULL,
    [A20] nvarchar(max)  NOT NULL,
    [Total] nvarchar(max)  NOT NULL,
    [VisitRecord_Id] int  NOT NULL
);
GO

-- Creating table 'PatOtherTestSet'
CREATE TABLE [dbo].[PatOtherTestSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Vocabulary1] nvarchar(max)  NOT NULL,
    [Vocabulary2] nvarchar(max)  NOT NULL,
    [Vocabulary3] nvarchar(max)  NOT NULL,
    [Picture1] nvarchar(max)  NOT NULL,
    [Picture2] nvarchar(max)  NOT NULL,
    [ConnectNumber1] nvarchar(max)  NOT NULL,
    [ConnectNumber2] nvarchar(max)  NOT NULL,
    [Vocabulary4] nvarchar(max)  NOT NULL,
    [VocabularyAnalyse1] nvarchar(max)  NOT NULL,
    [Picture3] nvarchar(max)  NOT NULL,
    [VocabularyAnalyse2] nvarchar(max)  NOT NULL,
    [PatCDR] nvarchar(max)  NOT NULL,
    [PatGDS] nvarchar(max)  NOT NULL,
    [VisitRecord_Id] int  NOT NULL
);
GO

-- Creating table 'PatDiseaseSet'
CREATE TABLE [dbo].[PatDiseaseSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PatBasicInforId] int  NOT NULL,
    [D1_Date] datetime  NOT NULL,
    [D1_Result] bit  NOT NULL,
    [D1_Note] nvarchar(max)  NOT NULL,
    [D2_Date] datetime  NOT NULL,
    [D2_Result] bit  NOT NULL,
    [D2_Note] nvarchar(max)  NOT NULL,
    [D3_Date] datetime  NOT NULL,
    [D3_Result] bit  NOT NULL,
    [D3_Note] nvarchar(max)  NOT NULL,
    [D4_Date] datetime  NOT NULL,
    [D4_Result] bit  NOT NULL,
    [D4_Note] nvarchar(max)  NOT NULL,
    [D5_Date] datetime  NOT NULL,
    [D5_Result] bit  NOT NULL,
    [D5_Note] nvarchar(max)  NOT NULL,
    [D6_Date] datetime  NOT NULL,
    [D6_Result] bit  NOT NULL,
    [D6_Note] nvarchar(max)  NOT NULL,
    [D7_Date] datetime  NOT NULL,
    [D7_Result] bit  NOT NULL,
    [D7_Note] nvarchar(max)  NOT NULL,
    [D8_Date] datetime  NOT NULL,
    [D8_Result] bit  NOT NULL,
    [D8_Note] nvarchar(max)  NOT NULL,
    [D9_Date] datetime  NOT NULL,
    [D9_Result] bit  NOT NULL,
    [D9_Note] nvarchar(max)  NOT NULL,
    [D10_Date] datetime  NOT NULL,
    [D10_Result] bit  NOT NULL,
    [D10_Note] nvarchar(max)  NOT NULL,
    [D11_Date] datetime  NOT NULL,
    [D11_Result] bit  NOT NULL,
    [D11_Note] nvarchar(max)  NOT NULL,
    [D12_Date] datetime  NOT NULL,
    [D12_Result] bit  NOT NULL,
    [D12_Note] nvarchar(max)  NOT NULL,
    [D13_Date] datetime  NOT NULL,
    [D13_Result] bit  NOT NULL,
    [D13_Note] nvarchar(max)  NOT NULL,
    [D14_Date] datetime  NOT NULL,
    [D14_Result] bit  NOT NULL,
    [D14_Note] nvarchar(max)  NOT NULL,
    [D15_Date] datetime  NOT NULL,
    [D15_Result] bit  NOT NULL,
    [D15_Note] nvarchar(max)  NOT NULL,
    [D16_Date] datetime  NOT NULL,
    [D16_Result] bit  NOT NULL,
    [D16_Note] nvarchar(max)  NOT NULL,
    [D17_Date] datetime  NOT NULL,
    [D17_Result] bit  NOT NULL,
    [D17_Note] nvarchar(max)  NOT NULL,
    [D18_Date] datetime  NOT NULL,
    [D18_Result] bit  NOT NULL,
    [D18_Note] nvarchar(max)  NOT NULL,
    [D19_Date] datetime  NOT NULL,
    [D19_Result] bit  NOT NULL,
    [D19_Note] nvarchar(max)  NOT NULL,
    [D20_Date] datetime  NOT NULL,
    [D20_Result] bit  NOT NULL,
    [D20_Note] nvarchar(max)  NOT NULL,
    [D21_Date] datetime  NOT NULL,
    [D21_Result] bit  NOT NULL,
    [D21_Note] nvarchar(max)  NOT NULL,
    [ImportantD_Date] datetime  NOT NULL,
    [ImportantD_Result] bit  NOT NULL,
    [ImportantD_Note] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PatGDSSet'
CREATE TABLE [dbo].[PatGDSSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [G1] nvarchar(max)  NOT NULL,
    [G2] nvarchar(max)  NOT NULL,
    [G3] nvarchar(max)  NOT NULL,
    [G4] nvarchar(max)  NOT NULL,
    [G5] nvarchar(max)  NOT NULL,
    [G6] nvarchar(max)  NOT NULL,
    [G7] nvarchar(max)  NOT NULL,
    [G8] nvarchar(max)  NOT NULL,
    [G9] nvarchar(max)  NOT NULL,
    [G10] nvarchar(max)  NOT NULL,
    [G11] nvarchar(max)  NOT NULL,
    [G12] nvarchar(max)  NOT NULL,
    [G13] nvarchar(max)  NOT NULL,
    [G14] nvarchar(max)  NOT NULL,
    [G15] nvarchar(max)  NOT NULL,
    [Total] nvarchar(max)  NOT NULL,
    [VisitRecord_Id] int  NOT NULL
);
GO

-- Creating table 'VisitRecordSet'
CREATE TABLE [dbo].[VisitRecordSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PatBasicInforId] int  NOT NULL,
    [VisitRecordID] nvarchar(max)  NOT NULL,
    [DiagnosisiResult] nvarchar(max)  NOT NULL,
    [CDSSDiagnosis] nvarchar(max)  NOT NULL,
    [RecordNote] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PatRecentDrugSet'
CREATE TABLE [dbo].[PatRecentDrugSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VisitRecordId] int  NOT NULL,
    [DrugCatogary] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PatLabExamSet'
CREATE TABLE [dbo].[PatLabExamSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FT3] nvarchar(max)  NOT NULL,
    [FT4] nvarchar(max)  NOT NULL,
    [TT3] nvarchar(max)  NOT NULL,
    [TT4] nvarchar(max)  NOT NULL,
    [TSH] nvarchar(max)  NOT NULL,
    [Folacin] nvarchar(max)  NOT NULL,
    [B12] nvarchar(max)  NOT NULL,
    [Property] nvarchar(max)  NOT NULL,
    [Property_1] nvarchar(max)  NOT NULL,
    [GAfter] nvarchar(max)  NOT NULL,
    [HbAlc] nvarchar(max)  NOT NULL,
    [UricAcid] nvarchar(max)  NOT NULL,
    [Cholesterol] nvarchar(max)  NOT NULL,
    [GanEster] nvarchar(max)  NOT NULL,
    [HDLC] nvarchar(max)  NOT NULL,
    [LDLC] nvarchar(max)  NOT NULL,
    [GOT] nvarchar(max)  NOT NULL,
    [GPT] nvarchar(max)  NOT NULL,
    [BUN] nvarchar(max)  NOT NULL,
    [CR] nvarchar(max)  NOT NULL,
    [Albumin] nvarchar(max)  NOT NULL,
    [RBC] nvarchar(max)  NOT NULL,
    [HB] nvarchar(max)  NOT NULL,
    [PLT] nvarchar(max)  NOT NULL,
    [WBC] nvarchar(max)  NOT NULL,
    [ApoE] nvarchar(max)  NOT NULL,
    [Protein] nvarchar(max)  NOT NULL,
    [Electrocardiogram_Date] datetime  NOT NULL,
    [Electrocardiogram_Result] bit  NOT NULL,
    [Electrocardiogram_Note] nvarchar(max)  NOT NULL,
    [Echocardiagraphy_Date] datetime  NOT NULL,
    [Echocardiagraphy_Result] bit  NOT NULL,
    [Echocardiagraphy_Note] nvarchar(max)  NOT NULL,
    [EEG_Date] datetime  NOT NULL,
    [EEG_Result] bit  NOT NULL,
    [EEG_Note] nvarchar(max)  NOT NULL,
    [CT_Date] datetime  NOT NULL,
    [CT_Result] bit  NOT NULL,
    [CT_Note] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'DoctorAccountSet'
ALTER TABLE [dbo].[DoctorAccountSet]
ADD CONSTRAINT [PK_DoctorAccountSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PatBasicInforSet'
ALTER TABLE [dbo].[PatBasicInforSet]
ADD CONSTRAINT [PK_PatBasicInforSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PatPhysicalExamSet'
ALTER TABLE [dbo].[PatPhysicalExamSet]
ADD CONSTRAINT [PK_PatPhysicalExamSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PatMMSESet'
ALTER TABLE [dbo].[PatMMSESet]
ADD CONSTRAINT [PK_PatMMSESet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PatMoCASet'
ALTER TABLE [dbo].[PatMoCASet]
ADD CONSTRAINT [PK_PatMoCASet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PatADLSet'
ALTER TABLE [dbo].[PatADLSet]
ADD CONSTRAINT [PK_PatADLSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PatOtherTestSet'
ALTER TABLE [dbo].[PatOtherTestSet]
ADD CONSTRAINT [PK_PatOtherTestSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PatDiseaseSet'
ALTER TABLE [dbo].[PatDiseaseSet]
ADD CONSTRAINT [PK_PatDiseaseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PatGDSSet'
ALTER TABLE [dbo].[PatGDSSet]
ADD CONSTRAINT [PK_PatGDSSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VisitRecordSet'
ALTER TABLE [dbo].[VisitRecordSet]
ADD CONSTRAINT [PK_VisitRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PatRecentDrugSet'
ALTER TABLE [dbo].[PatRecentDrugSet]
ADD CONSTRAINT [PK_PatRecentDrugSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PatLabExamSet'
ALTER TABLE [dbo].[PatLabExamSet]
ADD CONSTRAINT [PK_PatLabExamSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [VisitRecord_Id] in table 'PatADLSet'
ALTER TABLE [dbo].[PatADLSet]
ADD CONSTRAINT [FK_VisitRecordPatADL]
    FOREIGN KEY ([VisitRecord_Id])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordPatADL'
CREATE INDEX [IX_FK_VisitRecordPatADL]
ON [dbo].[PatADLSet]
    ([VisitRecord_Id]);
GO

-- Creating foreign key on [VisitRecord_Id] in table 'PatMoCASet'
ALTER TABLE [dbo].[PatMoCASet]
ADD CONSTRAINT [FK_VisitRecordPatMoCA]
    FOREIGN KEY ([VisitRecord_Id])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordPatMoCA'
CREATE INDEX [IX_FK_VisitRecordPatMoCA]
ON [dbo].[PatMoCASet]
    ([VisitRecord_Id]);
GO

-- Creating foreign key on [VisitRecord_Id] in table 'PatOtherTestSet'
ALTER TABLE [dbo].[PatOtherTestSet]
ADD CONSTRAINT [FK_VisitRecordPatOtherTest]
    FOREIGN KEY ([VisitRecord_Id])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordPatOtherTest'
CREATE INDEX [IX_FK_VisitRecordPatOtherTest]
ON [dbo].[PatOtherTestSet]
    ([VisitRecord_Id]);
GO

-- Creating foreign key on [VisitRecord_Id] in table 'PatMMSESet'
ALTER TABLE [dbo].[PatMMSESet]
ADD CONSTRAINT [FK_VisitRecordPatMMSE]
    FOREIGN KEY ([VisitRecord_Id])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordPatMMSE'
CREATE INDEX [IX_FK_VisitRecordPatMMSE]
ON [dbo].[PatMMSESet]
    ([VisitRecord_Id]);
GO

-- Creating foreign key on [VisitRecord_Id] in table 'PatGDSSet'
ALTER TABLE [dbo].[PatGDSSet]
ADD CONSTRAINT [FK_VisitRecordPatGDS]
    FOREIGN KEY ([VisitRecord_Id])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordPatGDS'
CREATE INDEX [IX_FK_VisitRecordPatGDS]
ON [dbo].[PatGDSSet]
    ([VisitRecord_Id]);
GO

-- Creating foreign key on [PatExam_1_Id] in table 'PatBasicInforSet'
ALTER TABLE [dbo].[PatBasicInforSet]
ADD CONSTRAINT [FK_PatBasicInforPatExam1]
    FOREIGN KEY ([PatExam_1_Id])
    REFERENCES [dbo].[PatPhysicalExamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatBasicInforPatExam1'
CREATE INDEX [IX_FK_PatBasicInforPatExam1]
ON [dbo].[PatBasicInforSet]
    ([PatExam_1_Id]);
GO

-- Creating foreign key on [PatDisease_Id] in table 'PatBasicInforSet'
ALTER TABLE [dbo].[PatBasicInforSet]
ADD CONSTRAINT [FK_PatBasicInforPatDisease]
    FOREIGN KEY ([PatDisease_Id])
    REFERENCES [dbo].[PatDiseaseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatBasicInforPatDisease'
CREATE INDEX [IX_FK_PatBasicInforPatDisease]
ON [dbo].[PatBasicInforSet]
    ([PatDisease_Id]);
GO

-- Creating foreign key on [DoctorAccountId] in table 'PatBasicInforSet'
ALTER TABLE [dbo].[PatBasicInforSet]
ADD CONSTRAINT [FK_DoctorAccountPatBasicInfor]
    FOREIGN KEY ([DoctorAccountId])
    REFERENCES [dbo].[DoctorAccountSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorAccountPatBasicInfor'
CREATE INDEX [IX_FK_DoctorAccountPatBasicInfor]
ON [dbo].[PatBasicInforSet]
    ([DoctorAccountId]);
GO

-- Creating foreign key on [PatBasicInforId] in table 'VisitRecordSet'
ALTER TABLE [dbo].[VisitRecordSet]
ADD CONSTRAINT [FK_PatBasicInforVisitRecord]
    FOREIGN KEY ([PatBasicInforId])
    REFERENCES [dbo].[PatBasicInforSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatBasicInforVisitRecord'
CREATE INDEX [IX_FK_PatBasicInforVisitRecord]
ON [dbo].[VisitRecordSet]
    ([PatBasicInforId]);
GO

-- Creating foreign key on [VisitRecordId] in table 'PatRecentDrugSet'
ALTER TABLE [dbo].[PatRecentDrugSet]
ADD CONSTRAINT [FK_VisitRecordPatRecentDrug]
    FOREIGN KEY ([VisitRecordId])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordPatRecentDrug'
CREATE INDEX [IX_FK_VisitRecordPatRecentDrug]
ON [dbo].[PatRecentDrugSet]
    ([VisitRecordId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------