
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/21/2019 12:15:45
-- Generated from EDMX file: F:\ITP project\ITP-final-master\StudentApp\Models\TCMSDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TMSDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__computer__LabNo__04E4BC85]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[computer] DROP CONSTRAINT [FK__computer__LabNo__04E4BC85];
GO
IF OBJECT_ID(N'[dbo].[FK__emp_atten__emp_i__5FB337D6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[emp_attendence] DROP CONSTRAINT [FK__emp_atten__emp_i__5FB337D6];
GO
IF OBJECT_ID(N'[dbo].[FK__repair__MachineN__07C12930]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[repair] DROP CONSTRAINT [FK__repair__MachineN__07C12930];
GO
IF OBJECT_ID(N'[dbo].[FK__student_s__sub_i__5441852A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[student_subject] DROP CONSTRAINT [FK__student_s__sub_i__5441852A];
GO
IF OBJECT_ID(N'[dbo].[FK__student_su__s_id__534D60F1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[student_subject] DROP CONSTRAINT [FK__student_su__s_id__534D60F1];
GO
IF OBJECT_ID(N'[dbo].[FK__student_t__st_id__4F7CD00D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[student_tute] DROP CONSTRAINT [FK__student_t__st_id__4F7CD00D];
GO
IF OBJECT_ID(N'[dbo].[FK__student_t__tute___5070F446]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[student_tute] DROP CONSTRAINT [FK__student_t__tute___5070F446];
GO
IF OBJECT_ID(N'[dbo].[FK__subject_e__exam___5812160E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[subject_exam] DROP CONSTRAINT [FK__subject_e__exam___5812160E];
GO
IF OBJECT_ID(N'[dbo].[FK__subject_e__sub_i__571DF1D5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[subject_exam] DROP CONSTRAINT [FK__subject_e__sub_i__571DF1D5];
GO
IF OBJECT_ID(N'[dbo].[FK__tute__sub_id__4222D4EF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tute] DROP CONSTRAINT [FK__tute__sub_id__4222D4EF];
GO
IF OBJECT_ID(N'[dbo].[FK__tute__t_id__412EB0B6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tute] DROP CONSTRAINT [FK__tute__t_id__412EB0B6];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bills]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bills];
GO
IF OBJECT_ID(N'[dbo].[classroom]', 'U') IS NOT NULL
    DROP TABLE [dbo].[classroom];
GO
IF OBJECT_ID(N'[dbo].[classroom_allocation_data]', 'U') IS NOT NULL
    DROP TABLE [dbo].[classroom_allocation_data];
GO
IF OBJECT_ID(N'[dbo].[computer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[computer];
GO
IF OBJECT_ID(N'[dbo].[emp_attendence]', 'U') IS NOT NULL
    DROP TABLE [dbo].[emp_attendence];
GO
IF OBJECT_ID(N'[dbo].[employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[employee];
GO
IF OBJECT_ID(N'[dbo].[exam]', 'U') IS NOT NULL
    DROP TABLE [dbo].[exam];
GO
IF OBJECT_ID(N'[dbo].[fund_info]', 'U') IS NOT NULL
    DROP TABLE [dbo].[fund_info];
GO
IF OBJECT_ID(N'[dbo].[Invoices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Invoices];
GO
IF OBJECT_ID(N'[dbo].[lab]', 'U') IS NOT NULL
    DROP TABLE [dbo].[lab];
GO
IF OBJECT_ID(N'[dbo].[repair]', 'U') IS NOT NULL
    DROP TABLE [dbo].[repair];
GO
IF OBJECT_ID(N'[dbo].[student_attendence]', 'U') IS NOT NULL
    DROP TABLE [dbo].[student_attendence];
GO
IF OBJECT_ID(N'[dbo].[student_subject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[student_subject];
GO
IF OBJECT_ID(N'[dbo].[student_tute]', 'U') IS NOT NULL
    DROP TABLE [dbo].[student_tute];
GO
IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO
IF OBJECT_ID(N'[dbo].[subject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[subject];
GO
IF OBJECT_ID(N'[dbo].[subject_exam]', 'U') IS NOT NULL
    DROP TABLE [dbo].[subject_exam];
GO
IF OBJECT_ID(N'[dbo].[Taxes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Taxes];
GO
IF OBJECT_ID(N'[dbo].[teacher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[teacher];
GO
IF OBJECT_ID(N'[dbo].[tute]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tute];
GO
IF OBJECT_ID(N'[dbo].[Tutes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tutes];
GO
IF OBJECT_ID(N'[dbo].[user]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'classrooms'
CREATE TABLE [dbo].[classrooms] (
    [class_id] int IDENTITY(1,1) NOT NULL,
    [max] int  NULL,
    [min] int  NULL,
    [location] varchar(20)  NULL,
    [name] varchar(20)  NULL,
    [ac_nonac] varchar(10)  NULL
);
GO

-- Creating table 'computers'
CREATE TABLE [dbo].[computers] (
    [LabNo] int  NOT NULL,
    [MachineNO] int  NOT NULL,
    [Processor_Type] nvarchar(25)  NOT NULL,
    [Motherboard_ID] nvarchar(25)  NOT NULL,
    [PowerSupply_ID] nvarchar(10)  NOT NULL,
    [RAM_Capacity] nvarchar(9)  NOT NULL,
    [HDD_Capacity] nvarchar(9)  NOT NULL
);
GO

-- Creating table 'emp_attendence'
CREATE TABLE [dbo].[emp_attendence] (
    [att_id] int IDENTITY(1,1) NOT NULL,
    [date] datetime  NULL,
    [emp_id] int  NULL
);
GO

-- Creating table 'employees'
CREATE TABLE [dbo].[employees] (
    [emp_id] int IDENTITY(1,1) NOT NULL,
    [full_name] varchar(100)  NULL,
    [salary] float  NULL,
    [birthday] datetime  NULL,
    [email] varchar(50)  NULL,
    [contact_num] char(10)  NULL
);
GO

-- Creating table 'exams'
CREATE TABLE [dbo].[exams] (
    [exam_id] int IDENTITY(1,1) NOT NULL,
    [exam_title] varchar(30)  NULL
);
GO

-- Creating table 'fund_info'
CREATE TABLE [dbo].[fund_info] (
    [f_id] int IDENTITY(1,1) NOT NULL,
    [epf_rate] int  NULL,
    [etf_rate] int  NULL,
    [amount] float  NULL
);
GO

-- Creating table 'labs'
CREATE TABLE [dbo].[labs] (
    [LabNo] int  NOT NULL,
    [floor] char(10)  NULL
);
GO

-- Creating table 'repairs'
CREATE TABLE [dbo].[repairs] (
    [MachineNO] int  NOT NULL,
    [repair_id] int IDENTITY(1,1) NOT NULL,
    [cost] float  NULL,
    [description] varchar(100)  NULL,
    [repair_date] datetime  NULL
);
GO

-- Creating table 'student_attendence'
CREATE TABLE [dbo].[student_attendence] (
    [att_id] int IDENTITY(1,1) NOT NULL,
    [date] datetime  NULL,
    [class] varchar(20)  NULL
);
GO

-- Creating table 'student_tute'
CREATE TABLE [dbo].[student_tute] (
    [st_id] int  NOT NULL,
    [tute_id] int  NOT NULL,
    [t_mark] int  NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Full_Name] nvarchar(100)  NOT NULL,
    [School] nvarchar(100)  NOT NULL,
    [Address] nvarchar(100)  NOT NULL,
    [Division] nvarchar(100)  NOT NULL,
    [Email] nvarchar(100)  NOT NULL,
    [Contact_No] nchar(10)  NOT NULL,
    [Parent_Name] nvarchar(100)  NOT NULL,
    [Parent_Mobile] nchar(10)  NOT NULL,
    [Parent_Work] nchar(10)  NOT NULL
);
GO

-- Creating table 'subjects'
CREATE TABLE [dbo].[subjects] (
    [sub_id] int IDENTITY(1,1) NOT NULL,
    [title] varchar(20)  NULL,
    [grade] int  NULL
);
GO

-- Creating table 'subject_exam'
CREATE TABLE [dbo].[subject_exam] (
    [sub_id] int  NOT NULL,
    [exam_id] int  NOT NULL,
    [e_mark] int  NULL
);
GO

-- Creating table 'teachers'
CREATE TABLE [dbo].[teachers] (
    [t_id] int IDENTITY(1,1) NOT NULL,
    [full_name] varchar(100)  NULL,
    [school] varchar(100)  NULL,
    [division] varchar(10)  NULL,
    [t_address] varchar(50)  NULL,
    [contact_number] char(10)  NULL,
    [email] varchar(50)  NULL
);
GO

-- Creating table 'tutes'
CREATE TABLE [dbo].[tutes] (
    [tute_id] int IDENTITY(1,1) NOT NULL,
    [title] varchar(20)  NULL,
    [upload_date] datetime  NULL,
    [t_id] int  NULL,
    [sub_id] int  NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [UserId_] int IDENTITY(1,1) NOT NULL,
    [UserName_] varchar(50)  NOT NULL,
    [Password_] varchar(50)  NOT NULL,
    [IsActive_] bit  NOT NULL
);
GO

-- Creating table 'Allocations'
CREATE TABLE [dbo].[Allocations] (
    [ca_id] int IDENTITY(1,1) NOT NULL,
    [day] varchar(20)  NULL,
    [start_time] varchar(10)  NULL,
    [end_time] varchar(10)  NULL,
    [t_id] varchar(10)  NULL,
    [class_id] varchar(10)  NULL,
    [sub_id] varchar(10)  NULL,
    [no_of_students] varchar(10)  NULL
);
GO

-- Creating table 'Bills'
CREATE TABLE [dbo].[Bills] (
    [billId] int  NOT NULL,
    [type] varchar(20)  NOT NULL,
    [date] datetime  NOT NULL,
    [amount] float  NOT NULL,
    [description] varchar(50)  NOT NULL
);
GO

-- Creating table 'Invoices'
CREATE TABLE [dbo].[Invoices] (
    [invoiceId] int  NOT NULL,
    [from] varchar(45)  NOT NULL,
    [date] datetime  NOT NULL,
    [amount] float  NOT NULL,
    [description] varchar(60)  NOT NULL
);
GO

-- Creating table 'Taxes'
CREATE TABLE [dbo].[Taxes] (
    [taxId] int  NOT NULL,
    [type] varchar(30)  NOT NULL,
    [date] datetime  NOT NULL,
    [amount] float  NOT NULL,
    [descrption] varchar(50)  NOT NULL
);
GO

-- Creating table 'Tutes1'
CREATE TABLE [dbo].[Tutes1] (
    [Tute_id] int IDENTITY(1,1) NOT NULL,
    [Tute_title] nvarchar(50)  NOT NULL,
    [Sub_name] nvarchar(50)  NOT NULL,
    [Teacher_name_] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'student_subject'
CREATE TABLE [dbo].[student_subject] (
    [subjects_sub_id] int  NOT NULL,
    [Students_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [class_id] in table 'classrooms'
ALTER TABLE [dbo].[classrooms]
ADD CONSTRAINT [PK_classrooms]
    PRIMARY KEY CLUSTERED ([class_id] ASC);
GO

-- Creating primary key on [MachineNO] in table 'computers'
ALTER TABLE [dbo].[computers]
ADD CONSTRAINT [PK_computers]
    PRIMARY KEY CLUSTERED ([MachineNO] ASC);
GO

-- Creating primary key on [att_id] in table 'emp_attendence'
ALTER TABLE [dbo].[emp_attendence]
ADD CONSTRAINT [PK_emp_attendence]
    PRIMARY KEY CLUSTERED ([att_id] ASC);
GO

-- Creating primary key on [emp_id] in table 'employees'
ALTER TABLE [dbo].[employees]
ADD CONSTRAINT [PK_employees]
    PRIMARY KEY CLUSTERED ([emp_id] ASC);
GO

-- Creating primary key on [exam_id] in table 'exams'
ALTER TABLE [dbo].[exams]
ADD CONSTRAINT [PK_exams]
    PRIMARY KEY CLUSTERED ([exam_id] ASC);
GO

-- Creating primary key on [f_id] in table 'fund_info'
ALTER TABLE [dbo].[fund_info]
ADD CONSTRAINT [PK_fund_info]
    PRIMARY KEY CLUSTERED ([f_id] ASC);
GO

-- Creating primary key on [LabNo] in table 'labs'
ALTER TABLE [dbo].[labs]
ADD CONSTRAINT [PK_labs]
    PRIMARY KEY CLUSTERED ([LabNo] ASC);
GO

-- Creating primary key on [repair_id] in table 'repairs'
ALTER TABLE [dbo].[repairs]
ADD CONSTRAINT [PK_repairs]
    PRIMARY KEY CLUSTERED ([repair_id] ASC);
GO

-- Creating primary key on [att_id] in table 'student_attendence'
ALTER TABLE [dbo].[student_attendence]
ADD CONSTRAINT [PK_student_attendence]
    PRIMARY KEY CLUSTERED ([att_id] ASC);
GO

-- Creating primary key on [st_id], [tute_id] in table 'student_tute'
ALTER TABLE [dbo].[student_tute]
ADD CONSTRAINT [PK_student_tute]
    PRIMARY KEY CLUSTERED ([st_id], [tute_id] ASC);
GO

-- Creating primary key on [Id] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [sub_id] in table 'subjects'
ALTER TABLE [dbo].[subjects]
ADD CONSTRAINT [PK_subjects]
    PRIMARY KEY CLUSTERED ([sub_id] ASC);
GO

-- Creating primary key on [sub_id], [exam_id] in table 'subject_exam'
ALTER TABLE [dbo].[subject_exam]
ADD CONSTRAINT [PK_subject_exam]
    PRIMARY KEY CLUSTERED ([sub_id], [exam_id] ASC);
GO

-- Creating primary key on [t_id] in table 'teachers'
ALTER TABLE [dbo].[teachers]
ADD CONSTRAINT [PK_teachers]
    PRIMARY KEY CLUSTERED ([t_id] ASC);
GO

-- Creating primary key on [tute_id] in table 'tutes'
ALTER TABLE [dbo].[tutes]
ADD CONSTRAINT [PK_tutes]
    PRIMARY KEY CLUSTERED ([tute_id] ASC);
GO

-- Creating primary key on [UserId_] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([UserId_] ASC);
GO

-- Creating primary key on [ca_id] in table 'Allocations'
ALTER TABLE [dbo].[Allocations]
ADD CONSTRAINT [PK_Allocations]
    PRIMARY KEY CLUSTERED ([ca_id] ASC);
GO

-- Creating primary key on [billId] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [PK_Bills]
    PRIMARY KEY CLUSTERED ([billId] ASC);
GO

-- Creating primary key on [invoiceId] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [PK_Invoices]
    PRIMARY KEY CLUSTERED ([invoiceId] ASC);
GO

-- Creating primary key on [taxId] in table 'Taxes'
ALTER TABLE [dbo].[Taxes]
ADD CONSTRAINT [PK_Taxes]
    PRIMARY KEY CLUSTERED ([taxId] ASC);
GO

-- Creating primary key on [Tute_id] in table 'Tutes1'
ALTER TABLE [dbo].[Tutes1]
ADD CONSTRAINT [PK_Tutes1]
    PRIMARY KEY CLUSTERED ([Tute_id] ASC);
GO

-- Creating primary key on [subjects_sub_id], [Students_Id] in table 'student_subject'
ALTER TABLE [dbo].[student_subject]
ADD CONSTRAINT [PK_student_subject]
    PRIMARY KEY CLUSTERED ([subjects_sub_id], [Students_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LabNo] in table 'computers'
ALTER TABLE [dbo].[computers]
ADD CONSTRAINT [FK__computer__LabNo__04E4BC85]
    FOREIGN KEY ([LabNo])
    REFERENCES [dbo].[labs]
        ([LabNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__computer__LabNo__04E4BC85'
CREATE INDEX [IX_FK__computer__LabNo__04E4BC85]
ON [dbo].[computers]
    ([LabNo]);
GO

-- Creating foreign key on [MachineNO] in table 'repairs'
ALTER TABLE [dbo].[repairs]
ADD CONSTRAINT [FK__repair__MachineN__07C12930]
    FOREIGN KEY ([MachineNO])
    REFERENCES [dbo].[computers]
        ([MachineNO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__repair__MachineN__07C12930'
CREATE INDEX [IX_FK__repair__MachineN__07C12930]
ON [dbo].[repairs]
    ([MachineNO]);
GO

-- Creating foreign key on [emp_id] in table 'emp_attendence'
ALTER TABLE [dbo].[emp_attendence]
ADD CONSTRAINT [FK__emp_atten__emp_i__5FB337D6]
    FOREIGN KEY ([emp_id])
    REFERENCES [dbo].[employees]
        ([emp_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__emp_atten__emp_i__5FB337D6'
CREATE INDEX [IX_FK__emp_atten__emp_i__5FB337D6]
ON [dbo].[emp_attendence]
    ([emp_id]);
GO

-- Creating foreign key on [exam_id] in table 'subject_exam'
ALTER TABLE [dbo].[subject_exam]
ADD CONSTRAINT [FK__subject_e__exam___5812160E]
    FOREIGN KEY ([exam_id])
    REFERENCES [dbo].[exams]
        ([exam_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__subject_e__exam___5812160E'
CREATE INDEX [IX_FK__subject_e__exam___5812160E]
ON [dbo].[subject_exam]
    ([exam_id]);
GO

-- Creating foreign key on [st_id] in table 'student_tute'
ALTER TABLE [dbo].[student_tute]
ADD CONSTRAINT [FK__student_t__st_id__4F7CD00D]
    FOREIGN KEY ([st_id])
    REFERENCES [dbo].[Students]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [tute_id] in table 'student_tute'
ALTER TABLE [dbo].[student_tute]
ADD CONSTRAINT [FK__student_t__tute___5070F446]
    FOREIGN KEY ([tute_id])
    REFERENCES [dbo].[tutes]
        ([tute_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__student_t__tute___5070F446'
CREATE INDEX [IX_FK__student_t__tute___5070F446]
ON [dbo].[student_tute]
    ([tute_id]);
GO

-- Creating foreign key on [sub_id] in table 'subject_exam'
ALTER TABLE [dbo].[subject_exam]
ADD CONSTRAINT [FK__subject_e__sub_i__571DF1D5]
    FOREIGN KEY ([sub_id])
    REFERENCES [dbo].[subjects]
        ([sub_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [sub_id] in table 'tutes'
ALTER TABLE [dbo].[tutes]
ADD CONSTRAINT [FK__tute__sub_id__4222D4EF]
    FOREIGN KEY ([sub_id])
    REFERENCES [dbo].[subjects]
        ([sub_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tute__sub_id__4222D4EF'
CREATE INDEX [IX_FK__tute__sub_id__4222D4EF]
ON [dbo].[tutes]
    ([sub_id]);
GO

-- Creating foreign key on [t_id] in table 'tutes'
ALTER TABLE [dbo].[tutes]
ADD CONSTRAINT [FK__tute__t_id__412EB0B6]
    FOREIGN KEY ([t_id])
    REFERENCES [dbo].[teachers]
        ([t_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tute__t_id__412EB0B6'
CREATE INDEX [IX_FK__tute__t_id__412EB0B6]
ON [dbo].[tutes]
    ([t_id]);
GO

-- Creating foreign key on [subjects_sub_id] in table 'student_subject'
ALTER TABLE [dbo].[student_subject]
ADD CONSTRAINT [FK_student_subject_subject]
    FOREIGN KEY ([subjects_sub_id])
    REFERENCES [dbo].[subjects]
        ([sub_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Students_Id] in table 'student_subject'
ALTER TABLE [dbo].[student_subject]
ADD CONSTRAINT [FK_student_subject_Students]
    FOREIGN KEY ([Students_Id])
    REFERENCES [dbo].[Students]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_student_subject_Students'
CREATE INDEX [IX_FK_student_subject_Students]
ON [dbo].[student_subject]
    ([Students_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------