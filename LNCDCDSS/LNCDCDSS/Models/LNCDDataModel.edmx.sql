
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/05/2013 21:04:39
-- Generated from EDMX file: D:\2013CDSS\Web\LNCDCDSS\LNCDCDSS\Models\LNCDDataModel.edmx
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
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforPatDisease]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatBasicInforSet] DROP CONSTRAINT [FK_PatBasicInforPatDisease];
GO
IF OBJECT_ID(N'[dbo].[FK_DoctorAccountPatBasicInfor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatBasicInforSet] DROP CONSTRAINT [FK_DoctorAccountPatBasicInfor];
GO
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforVisitRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitRecordSet] DROP CONSTRAINT [FK_PatBasicInforVisitRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordPatLabExam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatLabExamSet] DROP CONSTRAINT [FK_VisitRecordPatLabExam];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitRecordPatRecentDrug]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatRecentDrugSet] DROP CONSTRAINT [FK_VisitRecordPatRecentDrug];
GO
IF OBJECT_ID(N'[dbo].[FK_PatRecentDrugDrug]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugSet] DROP CONSTRAINT [FK_PatRecentDrugDrug];
GO
IF OBJECT_ID(N'[dbo].[FK_PatBasicInforPatPhysicalExam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatPhysicalExamSet] DROP CONSTRAINT [FK_PatBasicInforPatPhysicalExam];
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
IF OBJECT_ID(N'[dbo].[VisitRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VisitRecordSet];
GO
IF OBJECT_ID(N'[dbo].[PatRecentDrugSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatRecentDrugSet];
GO
IF OBJECT_ID(N'[dbo].[PatLabExamSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatLabExamSet];
GO
IF OBJECT_ID(N'[dbo].[DrugSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DrugSet];
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
    [Id] nvarchar(255)  NOT NULL,
    [DoctorAccountId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Sex] nvarchar(max)  NOT NULL,
    [Age] nvarchar(max)  NOT NULL,
    [Education] nvarchar(max)  NOT NULL,
    [Job] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [FamilyMember] nvarchar(max)  NOT NULL,
    [ChiefDoctor] nvarchar(max)  NOT NULL,
    [PatDisease_Id] int  NOT NULL
);
GO

-- Creating table 'PatPhysicalExamSet'
CREATE TABLE [dbo].[PatPhysicalExamSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Height] nvarchar(max)  NULL,
    [Weight] nvarchar(max)  NULL,
    [Waistline] nvarchar(max)  NULL,
    [Hipline] nvarchar(max)  NULL,
    [BloodPressureH] nvarchar(max)  NULL,
    [BloodPressureL] nvarchar(max)  NULL,
    [B1_Result] nvarchar(max)  NULL,
    [B1_Note] nvarchar(max)  NULL,
    [B2_Result] nvarchar(max)  NULL,
    [B2_Note] nvarchar(max)  NULL,
    [B3_Result] nvarchar(max)  NULL,
    [B3_Note] nvarchar(max)  NULL,
    [B4_Result] nvarchar(max)  NULL,
    [B4_Note] nvarchar(max)  NULL,
    [B5_Result] nvarchar(max)  NULL,
    [B5_Note] nvarchar(max)  NULL,
    [B6_Result] nvarchar(max)  NULL,
    [B6_Note] nvarchar(max)  NULL,
    [B7_Result] nvarchar(max)  NULL,
    [B7_Note] nvarchar(max)  NULL,
    [B8_Result] nvarchar(max)  NULL,
    [B8_Note] nvarchar(max)  NULL,
    [B9_Result] nvarchar(max)  NULL,
    [B9_Note] nvarchar(max)  NULL,
    [B10_Result] nvarchar(max)  NULL,
    [B10_Note] nvarchar(max)  NULL,
    [B11_Result] nvarchar(max)  NULL,
    [B11_Note] nvarchar(max)  NULL,
    [B12_Result] nvarchar(max)  NULL,
    [B12_Note] nvarchar(max)  NULL,
    [B12a_Result] nvarchar(max)  NULL,
    [B12a_Note] nvarchar(max)  NULL,
    [B12b_Result] nvarchar(max)  NULL,
    [B12b_Note] nvarchar(max)  NULL,
    [B12c_Result] nvarchar(max)  NULL,
    [B12c_Note] nvarchar(max)  NULL,
    [B12d_Result] nvarchar(max)  NULL,
    [B12d_Note] nvarchar(max)  NULL,
    [B12e_Result] nvarchar(max)  NULL,
    [B12e_Note] nvarchar(max)  NULL,
    [B12f_Result] nvarchar(max)  NULL,
    [B12f_Note] nvarchar(max)  NULL,
    [PatBasicInforId] nvarchar(255)  NOT NULL
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
    [PatBasicInforId] nvarchar(255)  NOT NULL,
    [D1_Name] nvarchar(max)  NULL,
    [D1_Situation] nvarchar(max)  NULL,
    [D2_Name] nvarchar(max)  NULL,
    [D2_Situation] nvarchar(max)  NULL,
    [D3_Name] nvarchar(max)  NULL,
    [D3_Situation] nvarchar(max)  NULL,
    [D4_Name] nvarchar(max)  NULL,
    [D4_Situation] nvarchar(max)  NULL,
    [D5_Name] nvarchar(max)  NULL,
    [D5_Situation] nvarchar(max)  NULL,
    [D6_Name] nvarchar(max)  NULL,
    [D6_Situation] nvarchar(max)  NULL,
    [D7_Name] nvarchar(max)  NULL,
    [D7_Situation] nvarchar(max)  NULL,
    [D8_Name] nvarchar(max)  NULL,
    [D8_Situation] nvarchar(max)  NULL,
    [D9_Name] nvarchar(max)  NULL,
    [D9_Situation] nvarchar(max)  NULL,
    [D10_Name] nvarchar(max)  NULL,
    [D10_Situation] nvarchar(max)  NULL,
    [D11_Name] nvarchar(max)  NULL,
    [D11_Situation] nvarchar(max)  NULL,
    [D12_Name] nvarchar(max)  NULL,
    [D12_Situation] nvarchar(max)  NULL,
    [D13_Name] nvarchar(max)  NULL,
    [D13_Situation] nvarchar(max)  NULL,
    [D14_Name] nvarchar(max)  NULL,
    [D14_Situation] nvarchar(max)  NULL,
    [D15_Name] nvarchar(max)  NULL,
    [D15_Situation] nvarchar(max)  NULL,
    [D16_Name] nvarchar(max)  NULL,
    [D16_Situation] nvarchar(max)  NULL,
    [D17_Name] nvarchar(max)  NULL,
    [D17_Situation] nvarchar(max)  NULL,
    [D18_Name] nvarchar(max)  NULL,
    [D18_Situation] nvarchar(max)  NULL,
    [D19_Name] nvarchar(max)  NULL,
    [D19_Situation] nvarchar(max)  NULL,
    [D20_Name] nvarchar(max)  NULL,
    [D20_Situation] nvarchar(max)  NULL,
    [D21_Name] nvarchar(max)  NULL,
    [D21_Situation] nvarchar(max)  NULL,
    [ImportantD_Name] nvarchar(max)  NULL,
    [ImportantD_Situation] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'VisitRecordSet'
CREATE TABLE [dbo].[VisitRecordSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PatBasicInforId] nvarchar(255)  NOT NULL,
    [VisitRecordID] nvarchar(max)  NOT NULL,
    [DiagnosisiResult] nvarchar(max)  NULL,
    [CDSSDiagnosis] nvarchar(max)  NULL,
    [RecordNote] nvarchar(max)  NULL,
    [OutpatientID] nvarchar(max)  NULL,
    [HospitalID] nvarchar(max)  NULL,
    [VisitDate] datetime  NOT NULL
);
GO

-- Creating table 'PatRecentDrugSet'
CREATE TABLE [dbo].[PatRecentDrugSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DrugCatogary] nvarchar(max)  NOT NULL,
    [VisitRecord_Id] int  NOT NULL
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
    [CT_Note] nvarchar(max)  NOT NULL,
    [VisitRecord_Id] int  NOT NULL
);
GO

-- Creating table 'DrugSet'
CREATE TABLE [dbo].[DrugSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PatRecentDrugId] int  NOT NULL
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

-- Creating primary key on [Id] in table 'DrugSet'
ALTER TABLE [dbo].[DrugSet]
ADD CONSTRAINT [PK_DrugSet]
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

-- Creating foreign key on [VisitRecord_Id] in table 'PatLabExamSet'
ALTER TABLE [dbo].[PatLabExamSet]
ADD CONSTRAINT [FK_VisitRecordPatLabExam]
    FOREIGN KEY ([VisitRecord_Id])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordPatLabExam'
CREATE INDEX [IX_FK_VisitRecordPatLabExam]
ON [dbo].[PatLabExamSet]
    ([VisitRecord_Id]);
GO

-- Creating foreign key on [VisitRecord_Id] in table 'PatRecentDrugSet'
ALTER TABLE [dbo].[PatRecentDrugSet]
ADD CONSTRAINT [FK_VisitRecordPatRecentDrug]
    FOREIGN KEY ([VisitRecord_Id])
    REFERENCES [dbo].[VisitRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitRecordPatRecentDrug'
CREATE INDEX [IX_FK_VisitRecordPatRecentDrug]
ON [dbo].[PatRecentDrugSet]
    ([VisitRecord_Id]);
GO

-- Creating foreign key on [PatRecentDrugId] in table 'DrugSet'
ALTER TABLE [dbo].[DrugSet]
ADD CONSTRAINT [FK_PatRecentDrugDrug]
    FOREIGN KEY ([PatRecentDrugId])
    REFERENCES [dbo].[PatRecentDrugSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatRecentDrugDrug'
CREATE INDEX [IX_FK_PatRecentDrugDrug]
ON [dbo].[DrugSet]
    ([PatRecentDrugId]);
GO

-- Creating foreign key on [PatBasicInforId] in table 'PatPhysicalExamSet'
ALTER TABLE [dbo].[PatPhysicalExamSet]
ADD CONSTRAINT [FK_PatBasicInforPatPhysicalExam]
    FOREIGN KEY ([PatBasicInforId])
    REFERENCES [dbo].[PatBasicInforSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PatBasicInforPatPhysicalExam'
CREATE INDEX [IX_FK_PatBasicInforPatPhysicalExam]
ON [dbo].[PatPhysicalExamSet]
    ([PatBasicInforId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------