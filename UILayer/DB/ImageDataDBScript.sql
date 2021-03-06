USE [master]
GO
/****** Object:  Database [ImageDataDB]    Script Date: 10/29/2017 11:31:26 ******/
CREATE DATABASE [ImageDataDB] ON  PRIMARY 
( NAME = N'ImageDataDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ImageDataDB.mdf' , SIZE = 287744KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ImageDataDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ImageDataDB_log.ldf' , SIZE = 388544KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ImageDataDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ImageDataDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ImageDataDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ImageDataDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ImageDataDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ImageDataDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ImageDataDB] SET ARITHABORT OFF
GO
ALTER DATABASE [ImageDataDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ImageDataDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ImageDataDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ImageDataDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ImageDataDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ImageDataDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ImageDataDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ImageDataDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ImageDataDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ImageDataDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ImageDataDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [ImageDataDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ImageDataDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ImageDataDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ImageDataDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ImageDataDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ImageDataDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ImageDataDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ImageDataDB] SET  READ_WRITE
GO
ALTER DATABASE [ImageDataDB] SET RECOVERY FULL
GO
ALTER DATABASE [ImageDataDB] SET  MULTI_USER
GO
ALTER DATABASE [ImageDataDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ImageDataDB] SET DB_CHAINING OFF
GO
USE [ImageDataDB]
GO
/****** Object:  Table [dbo].[MstMenuMaster]    Script Date: 10/29/2017 11:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MstMenuMaster](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[MenuText] [varchar](100) NULL,
	[MenuDesc] [varchar](100) NULL,
	[NavigateURL] [varchar](256) NULL,
	[ParentID] [int] NULL,
	[OrderNo] [int] NULL,
	[ApplicationID] [int] NULL,
	[UserEntryID] [int] NULL,
	[UserEntryDate] [datetime] NULL,
	[UserAffectedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_MstMenuMaster] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MstLanguage]    Script Date: 10/29/2017 11:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MstLanguage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LanguageName] [nvarchar](100) NULL,
	[LanguageCode] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_MstLanguage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[GetFileName]    Script Date: 10/29/2017 11:31:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create FUNCTION [dbo].[GetFileName]
(
 @fullpath nvarchar(260)
) 
RETURNS nvarchar(260)
AS
BEGIN
DECLARE @charIndexResult int
SET @charIndexResult = CHARINDEX('\', REVERSE(@fullpath))

IF @charIndexResult = 0
    RETURN NULL 

RETURN RIGHT(@fullpath, @charIndexResult -1)
END
GO
/****** Object:  Table [dbo].[ExportToImage]    Script Date: 10/29/2017 11:31:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExportToImage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RefrenceId] [int] NULL,
	[ConvertDate] [datetime] NULL,
	[ConvertBy] [int] NULL,
	[ConvertFilepath] [nvarchar](max) NULL,
 CONSTRAINT [PK_ExportToImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExportDataMaster]    Script Date: 10/29/2017 11:31:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExportDataMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileCode] [nvarchar](max) NULL,
	[ImageType] [int] NULL,
	[UploadDate] [datetime] NULL,
	[UploadBy] [int] NULL,
	[UploadPath] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsConverted] [bit] NULL,
 CONSTRAINT [PK_ExportDataMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExportDataDetail]    Script Date: 10/29/2017 11:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExportDataDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[masterId] [int] NULL,
	[recordnumber] [int] NULL,
	[customername] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[resaddress] [nvarchar](max) NULL,
	[city1] [nvarchar](max) NULL,
	[state1] [nvarchar](max) NULL,
	[zip1] [nvarchar](max) NULL,
	[phonenumber1] [nvarchar](max) NULL,
	[country1] [nvarchar](max) NULL,
	[UPPER] [nvarchar](max) NULL,
	[sex1] [nvarchar](max) NULL,
	[dbirth1] [nvarchar](max) NULL,
	[height] [nvarchar](max) NULL,
	[weight] [nvarchar](max) NULL,
	[bloodgroup] [nvarchar](max) NULL,
	[billingname] [nvarchar](max) NULL,
	[shippername] [nvarchar](max) NULL,
	[city2] [nvarchar](max) NULL,
	[state2] [nvarchar](max) NULL,
	[zip2] [nvarchar](max) NULL,
	[country2] [nvarchar](max) NULL,
	[LOWER] [nvarchar](max) NULL,
	[phone2] [nvarchar](max) NULL,
	[alcoholic] [nvarchar](max) NULL,
	[smoker] [nvarchar](max) NULL,
	[pastsurg] [nvarchar](max) NULL,
	[diabetic] [nvarchar](max) NULL,
	[allergiesd] [nvarchar](max) NULL,
	[policy] [nvarchar](max) NULL,
	[lifeassure] [nvarchar](max) NULL,
	[pinst] [nvarchar](max) NULL,
	[pholder] [nvarchar](max) NULL,
	[stmname] [nvarchar](max) NULL,
	[stmcode] [nvarchar](max) NULL,
	[dob] [nvarchar](max) NULL,
	[sex2] [nvarchar](max) NULL,
	[cardname] [nvarchar](max) NULL,
	[medicine] [nvarchar](max) NULL,
	[dosage] [nvarchar](max) NULL,
	[tablets] [nvarchar](max) NULL,
	[pillrate] [nvarchar](max) NULL,
	[cost] [nvarchar](max) NULL,
	[shippingcost] [nvarchar](max) NULL,
	[total] [nvarchar](max) NULL,
	[remark] [nvarchar](max) NULL,
	[value1] [nvarchar](max) NULL,
	[value2] [nvarchar](max) NULL,
	[value3] [nvarchar](max) NULL,
 CONSTRAINT [PK_ExportDataDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Roles]    Script Date: 10/29/2017 11:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[UserEntryID] [int] NULL,
	[UserEntryDate] [datetime] NULL,
	[UserAffectedDate] [datetime] NULL,
 CONSTRAINT [PK__aspnet_Roles__32E0915F] PRIMARY KEY NONCLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMstUserDetail]    Script Date: 10/29/2017 11:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMstUserDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[FirstName] [nvarchar](500) NULL,
	[LastName] [nvarchar](500) NULL,
	[EmailId] [nvarchar](max) NULL,
	[ContactNo] [nvarchar](50) NULL,
	[IPAllowed] [int] NULL,
	[UserEntryDate] [datetime] NULL,
 CONSTRAINT [PK_tblMstUserDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblIPMaster]    Script Date: 10/29/2017 11:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblIPMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IPAddress] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[UserEntryId] [int] NULL,
	[UserEntryDate] [datetime] NULL,
	[UserEffectedDate] [datetime] NULL,
 CONSTRAINT [PK_tblIPMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[proc_Paging_CTE]    Script Date: 10/29/2017 11:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Paging_CTE]
(
@Page int,
@RecsPerPage int,
@masterId int
)
AS
-- The number of rows affected by the different commands
-- does not interest the application, so turn NOCOUNT ON
SET NOCOUNT ON


-- Determine the first record and last record 
DECLARE @FirstRec int, @LastRec int

SELECT @FirstRec = (@Page - 1) * @RecsPerPage
SELECT @LastRec = (@Page * @RecsPerPage + 1);

WITH TempResult as
(
SELECT ROW_NUMBER() OVER(ORDER BY Id) as RowNum,id, recordnumber,masterId, customername, email, resaddress, city1, state1, zip1, phonenumber1, country1, sex1, dbirth1, height, weight, bloodgroup, billingname, shippername, 
                      city2, state2, zip2, country2, phone2, alcoholic, smoker, pastsurg, diabetic, allergiesd, policy, lifeassure, pinst, pholder, stmname, stmcode, dob, sex2, cardname, 
                      medicine, dosage, tablets, pillrate, cost, shippingcost, total, remark,value1,value2,value3 from ExportDataDetail where masterId=@masterId 

)
SELECT top (@LastRec-1) recordnumber,customername, email, resaddress, city1, state1, zip1, phonenumber1, country1, sex1, dbirth1, height, weight, bloodgroup, billingname, shippername, 
                      city2, state2, zip2, country2, phone2, alcoholic, smoker, pastsurg, diabetic, allergiesd, policy, lifeassure, pinst, pholder, stmname, stmcode, dob, sex2, cardname, 
                      medicine, dosage, tablets, pillrate, cost, shippingcost, total, remark,ISNULL(value1,'') as value1,ISNULL(value2,'') as value2,ISNULL(value3,'') as value3
FROM TempResult
WHERE RowNum > @FirstRec 
AND RowNum < @LastRec



-- Turn NOCOUNT back OFF
SET NOCOUNT OFF
GO
/****** Object:  Table [dbo].[MstMenuRoleMaster]    Script Date: 10/29/2017 11:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MstMenuRoleMaster](
	[MR_SNo] [int] IDENTITY(1,1) NOT NULL,
	[MM_MenuId] [int] NULL,
	[AR_RoleId] [int] NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[Active_Flag] [bit] NULL,
 CONSTRAINT [PK_MstMenuRoleMaster] PRIMARY KEY CLUSTERED 
(
	[MR_SNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblMstUserMaster]    Script Date: 10/29/2017 11:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblMstUserMaster](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [varchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](100) NULL,
	[Language] [int] NULL,
	[IsActive] [bit] NULL,
	[UserEntryId] [int] NULL,
	[UserEntryDate] [datetime] NULL,
	[UserEffectedDate] [datetime] NULL,
 CONSTRAINT [PK_tblMstUserMaster] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblMstUserLoginDetail]    Script Date: 10/29/2017 11:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMstUserLoginDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[AuthId] [uniqueidentifier] NULL,
	[BrowserType] [nvarchar](500) NULL,
	[IPAddress] [nvarchar](50) NULL,
	[CityName] [nvarchar](max) NULL,
	[Latitude] [nvarchar](50) NULL,
	[Longitude] [nvarchar](50) NULL,
	[LoginTime] [datetime] NULL,
	[LogoutTime] [datetime] NULL,
 CONSTRAINT [PK_tblMstUserLoginDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_UsersInRoles]    Script Date: 10/29/2017 11:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_UsersInRoles](
	[PkID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserEntryID] [int] NULL,
	[UserEntryDate] [datetime] NULL,
	[UserEffectedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[USP_ExportDataMaster]    Script Date: 10/29/2017 11:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_ExportDataMaster]
(
	@Type nvarchar(max)='',
	@FileCode nvarchar(max)='',
	@UploadPath nvarchar(max)='',
	@UploadBy int=0,
	@ImageType int=0,
	@RecordId int=0 out
	
)
AS
Begin
	IF @Type='INSERTMASTERDATA'
	begin
		INSERT INTO [ExportDataMaster]
           ([FileCode],[ImageType],[UploadDate],[UploadBy]
           ,[UploadPath]
           ,[IsActive],IsConverted)
     VALUES
           (@FileCode,@ImageType,GETDATE(),@UploadBy,@UploadPath,'true','false')
           set @RecordId=SCOPE_IDENTITY();
	end
	
	IF @Type='GETConvertData'
	begin
				
			SELECT     EDM.Id AS MasterId, EDM.FileCode, dbo.GetFileName(ExportToImage.ConvertFilepath) AS ZipFile, ExportToImage.ConvertFilepath, 
                      EDM.UploadDate, ExportToImage.ConvertDate, dbo.GetFileName(EDM.UploadPath) AS ExcelFile, UM.UserName, 
                      CASE WHEN EDM.IsConverted = 'true' THEN 'Done' ELSE 'Pending' END AS ConversionStatus, EDM.UploadPath, 
                      CASE WHEN EDM.ImageType = 1 THEN 'Image Without Border' WHEN EDM.ImageType = 2 THEN 'Image With Border' ELSE 'N/A' END AS ImageType
FROM         tblMstUserMaster AS UM INNER JOIN
                      ExportDataMaster AS EDM ON UM.UserId = EDM.UploadBy LEFT OUTER JOIN
                      ExportToImage ON EDM.Id = ExportToImage.RefrenceId order by EDM.UploadDate desc
	end
	
End
GO
/****** Object:  StoredProcedure [dbo].[uspMenuMaster]    Script Date: 10/29/2017 11:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[uspMenuMaster]     
(    
 @MenuId int=0,
 @ApplicationID int=0,    
 @MenuText varchar(100)='',    
 @MenuDesc varchar(100)='',    
 @MenuOrder int =0,    
 @NavigateURL varchar(100)='',    
 @CreatedBy int=0,    
 @ParentId int=0,    
 @ActiveFlag int=1,    
 @Type varchar(50)='SEARCH',    
 @RoleId varchar(100)='',    
 @IsApply char(1)='N',    
 @MessageOut varchar(200)='' OUTPUT,    
 @Column_name varchar(100)='',    
 @SearchCriteria varchar(100)=''    
)    
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
 BEGIN TRANSACTION    
  BEGIN     
  TRY    
   declare @varSearch nvarchar(4000)             
   IF @Type='SEARCH'    
    BEGIN    
     SET @varSearch='select MenuId,MenuText,case when NavigateURL=''#'' then ''Parent'' else NavigateURL end as NavigateURL from MstMenuMaster where IsActive=1'    
                --FOR FILTERING ACTIVE AND INACTIVE RECORDS     
    IF @ActiveFlag=2    
     BEGIN    
      SET @varSearch=@varSearch + ''    
     END    
    ELSE     
     BEGIN    
      SET @varSearch=@varSearch + ' AND  IsActive='+ cast(@ActiveFlag as varchar)     
                    
     END     
    SET @varSearch=@varSearch + ' order by MenuText'    
    execute sp_executesql @varSearch    
   
    END    
    
      
    
                
   IF @Type='SELECT_PARTICULAR_MENU'    
    BEGIN    
        
        
    SELECT MenuId,MenuText,MenuDesc,NavigateURL,OrderNo, CASE WHEN IsActive='1' THEN 'Active' else 'InActive'     
        end as IsActive  FROM MstMenuMaster WHERE 1=1    
    END    
    
    
    
    
       
   IF @Type='INSERT_MENU_ITEM'    
    BEGIN    
                 --Cheking whether Menu is already exist on corresponding Menutext and ParentId , IF not then insert otherwise flash message    
       IF NOT EXISTS    
      (SELECT * FROM  MstMenuMaster WHERE MenuText=@MenuText and ParentID=@ParentId)    
       BEGIN    
      --INSERT COUNTRY DETAILS    
       INSERT INTO MstMenuMaster    
       VALUES (@MenuText,@MenuDesc,@NavigateURL,@ParentId,@MenuOrder,@ApplicationID,@CreatedBy, getdate(),GETDATE(),@ActiveFlag)    
       SET @MessageOut=''    
       END    
       ELSE    
       BEGIN    
       SET @MessageOut='Exists'    
           
       END    
    END    
    
    
    
    
       
   IF @Type='UPDATE_MENU_ITEM'    
    BEGIN    
                  
       UPDATE MstMenuMaster SET MenuText=@MenuText,MenuDesc=@MenuDesc,NavigateURL=@NavigateURL,ApplicationID=@ApplicationID,   
       OrderNo=@MenuOrder,ParentID=@ParentId,UserEntryID=@CreatedBy,IsActive=@ActiveFlag    
       WHERE MenuId=@MenuId    
       SET @MessageOut=''    
         
    END    
       
    
    
    
             --USED IN MENU ROLE MAPPING MASTER      
             --USED FOR CHECKING CHECKBOXES OF MENU CORRESPONDING TO ROLE ASSIGNED TO THEM    
    IF @Type='SELECT_MENUIDS_FOR_ROLEID'    
           BEGIN    
            select mrm.MM_MenuId,aspr.RoleName,mrm.AR_RoleId from MstMenuRoleMaster mrm left join Aspnet_Roles aspr     
            on mrm.AR_RoleId=aspr.RoleId    
            where mrm.AR_RoleId= @RoleId     
           END     
    
    
    
    
   --USED IN MENU ROLE MASTER    
            --MAPPING ROLE WITH SELECTED MENUS    
   IF @Type='APPLY_ROLES_FOR_SELECTED_MENUS'    
           BEGIN    
             IF not exists(select * from MstMenuRoleMaster where MM_MenuId=@MenuId and AR_RoleId= @RoleId)    
               BEGIN    
                IF @IsApply='Y'    
                 BEGIN    
					  INSERT INTO MstMenuRoleMaster(MM_MenuId,AR_RoleId,CreatedBy, CreatedDate)    
					  values(@MenuId,@RoleId,@CreatedBy, getdate())    
                 END    
               END    
             ELSE    
              BEGIN    
                 IF @IsApply='N'    
                 BEGIN    
					 DELETE FROM MstMenuRoleMaster where MM_MenuId=@MenuId and AR_RoleId= @RoleId    
                 END    
              END    
           END      
    
    
    
             --USED IN MASTER PAGE    
             --FOR BINDING MENU    
   IF @Type='BIND_MENU_CONTROL'    
     BEGIN    
     SELECT DISTINCT lmm.MenuID,lmm.MenuText,lmm.NavigateURL    
     ,lmm.ParentId , lmm.OrderNo from MstMenuMaster lmm    
      inner join MstMenuRoleMaster mrm on lmm.MenuID=mrm.MM_MenuId    
     where lmm.Isactive='1'   
      and mrm.AR_RoleId in     
     (    
      select aspur.RoleId from     
      aspnet_Roles aspur     
      left join aspnet_UsersInRoles aspuir on aspur.RoleId=aspuir.RoleId    
      left join tblMstUserMaster aspu on aspu.UserId=aspuir.UserId     
      where aspu.UserId=@CreatedBy and aspuir.UserId=aspu.UserId    
      )     
     order by OrderNo    
     END    
    
    
    
    
               --USED IN MASTER PAGE     
               --VALIDATE USER FOR ROLE EITHER HE CAN ACCESS OR NOT    
    
     --IF @Type='VALIDATE_USER_ROLE_MENU'    
     --BEGIN    
     --SELECT count(*) as cnt from     
     --   aspnet_Roles aspur     
     --   left join aspnet_UsersInRoles aspuir on aspur.RoleId=aspuir.RoleId    
     --   left join MstEmployee aspu on aspu.UserId=aspuir.UserId     
     --   where aspu.username=@CreatedBy and aspuir.UserId=aspu.UserId    
     --   and aspur.RoleId in(    
     --select AR_RoleId from MstMenuRoleMaster mrm inner join     
     --Menu_Master lmm on lmm.Menu_ID=mrm.MM_MenuId    
     --where lower(lmm.Menu_Url)=lower(@NavigateURL)    
     --)    
     --END    
    
    
    
   COMMIT TRANSACTION    
   RETURN 1    
   END TRY    
   BEGIN CATCH    
   ROllBACK TRANSACTION    
       
   SELECT @MessageOut= 'ProcName: uspMenuMaster ErrorState :' + CAST(ERROR_STATE() AS VARCHAR) + '  ErrorNumber :'+ CAST(ERROR_NUMBER() AS VARCHAR) + '   ErrorLine:'+ CAST(ERROR_LINE() AS VARCHAR) + '  Error_Msg  '+ ERROR_MESSAGE()     
  -- EXECUTE [dbo].[uspLogError] @ProcName='uspMenuMaster'    
   RETURN -1    
       
   END CATCH    
END
GO
/****** Object:  StoredProcedure [dbo].[chkLogin]    Script Date: 10/29/2017 11:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[chkLogin]
(
	@Type varchar(100)='',
	@UserName varchar(100)='',
	@Password nvarchar(100)='',
	@TransactionPwd nvarchar(100)='',
	@UserLoginId int=0,
	@OutRes int=0 OUTPUT,
	@UserID int=0 output,
	@RoleID int=0 output,
	@CultureID nvarchar(50)=null output
)



as 
begin

IF @Type='CHECKLOGIN'
begin
set @OutRes = (SELECT count(*) FROM [tblMstUserMaster]
		WHERE Username = @Username And Password = @Password and IsActive=1)
		select case @OutRes
		when 1 then 1 --success Login 
		else
		0  --Bad login
		end 
  if @OutRes!=0
  begin
 SELECT     @UserID= AU.UserId,@RoleID=isnull((select top 1 RoleId from aspnet_UsersInRoles where UserId=au.UserId order by RoleId),0),
			@CultureID=isnull(ML.LanguageCode,'en-GB')
			FROM  tblMstUserMaster AS AU LEFT OUTER JOIN
               MstLanguage AS ML ON AU.Language = ML.Id LEFT OUTER JOIN
               aspnet_UsersInRoles AS AUR ON AU.UserId = AUR.UserId
					 where au.UserName=@UserName and Password=@Password
  end
  else
  begin
  set @UserID=0
  set @RoleID=0
  set @CultureID=null
  end
		
             
end

IF @Type ='GETUSERMAILID'
begin
SELECT     UserName,Password
FROM         tblMstUserMaster
WHERE     (UserName = @UserName)
     
end

IF @Type='ATTANDANCELOGIN'
BEGIN
SELECT     @UserID= AU.UserId,@RoleID=ISNULL(AUR.RoleId,0)
FROM         tblMstUserMaster AS AU LEFT OUTER JOIN
                      aspnet_UsersInRoles AS AUR ON AU.UserId = AUR.UserId
					 where au.UserName=@UserName
					 set @OutRes=1
					 
	IF @UserID is null
	begin
	 set @OutRes=0
	 set @UserID=0
	 set @RoleID=0
	 set @CultureID=null
	end
					 
					
END

IF @Type='UPDATE_U_PASSWORD'
BEGIN
	update tblMstUserMaster set Password=@Password,UserEntryId=@UserLoginId,UserEffectedDate=GETDATE() where UserId=@UserLoginId
END



IF @Type ='GET_U_PWD'
begin
	SELECT     Password, UserName
FROM         tblMstUserMaster
WHERE     (UserId = @UserLoginId)
end		
		
end
GO
/****** Object:  ForeignKey [FK_MstMenuRoleMaster_aspnet_Roles]    Script Date: 10/29/2017 11:31:43 ******/
ALTER TABLE [dbo].[MstMenuRoleMaster]  WITH CHECK ADD  CONSTRAINT [FK_MstMenuRoleMaster_aspnet_Roles] FOREIGN KEY([AR_RoleId])
REFERENCES [dbo].[aspnet_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[MstMenuRoleMaster] CHECK CONSTRAINT [FK_MstMenuRoleMaster_aspnet_Roles]
GO
/****** Object:  ForeignKey [FK_tblMstUserMaster_MstLanguage]    Script Date: 10/29/2017 11:31:43 ******/
ALTER TABLE [dbo].[tblMstUserMaster]  WITH CHECK ADD  CONSTRAINT [FK_tblMstUserMaster_MstLanguage] FOREIGN KEY([Language])
REFERENCES [dbo].[MstLanguage] ([Id])
GO
ALTER TABLE [dbo].[tblMstUserMaster] CHECK CONSTRAINT [FK_tblMstUserMaster_MstLanguage]
GO
/****** Object:  ForeignKey [FK_tblMstUserLoginDetail_tblMstUserMaster]    Script Date: 10/29/2017 11:31:43 ******/
ALTER TABLE [dbo].[tblMstUserLoginDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblMstUserLoginDetail_tblMstUserMaster] FOREIGN KEY([UserId])
REFERENCES [dbo].[tblMstUserMaster] ([UserId])
GO
ALTER TABLE [dbo].[tblMstUserLoginDetail] CHECK CONSTRAINT [FK_tblMstUserLoginDetail_tblMstUserMaster]
GO
/****** Object:  ForeignKey [FK_aspnet_UsersInRoles_aspnet_Roles]    Script Date: 10/29/2017 11:31:43 ******/
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[aspnet_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] CHECK CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Roles]
GO
/****** Object:  ForeignKey [FK_aspnet_UsersInRoles_tblMstUserMaster]    Script Date: 10/29/2017 11:31:43 ******/
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_aspnet_UsersInRoles_tblMstUserMaster] FOREIGN KEY([UserId])
REFERENCES [dbo].[tblMstUserMaster] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] CHECK CONSTRAINT [FK_aspnet_UsersInRoles_tblMstUserMaster]
GO
