
/*==============================================================*/
/* Table: Y_Call_Cust                                           */
/*==============================================================*/
create table Y_Call_Cust (
   DeptId               bigint               not null,
   DeptName             nvarchar(500)        not null,
   StuffId              bigint               not null,
   StuffName            nvarchar(500)        not null,
   EntryDate            datetime             not null,
   CustCode             varchar(12)          not null,
   CustName             varchar(50)          not null,
   AreaId               bigint               not null,
   Area                 varchar(50)          not null,
   Province             nvarchar(255)        not null,
   ProvinceId           bigint               not null,
   Sex                  bit                  not null,
   CustSourceId         bigint               not null,
   CustSource           nvarchar(255)        not null,
   Phone                varchar(18)          null,
   Tel                  varchar(15)          null,
   Email                varchar(50)          null,
   Job                  nvarchar(50)         null,
   Product              nvarchar(50)         not null,
   Question             nvarchar(200)        not null,
   constraint PK_Y_CALL_CUST primary key (CustCode)
)
go


/*==============================================================*/
/* Table: Y_Generate_Key                                        */
/*==============================================================*/
create table Y_Generate_Key (
   KeyType              int                  not null,
   KeyNumber            int                  not null,
   CurrentDate          datetime             not null,
   PreValue             varchar(2)           null,
   constraint PK_Y_GENERATE_KEY primary key (KeyType)
)
go

/*==============================================================*/
/* Table: Y_User_Info                                           */
/*==============================================================*/
create table Y_User_Info (
   UserId               bigint               not null,
   EmailAddr            varchar(50)          null,
   EmailPsw             varchar(50)          null,
   Smtp                 varchar(100)         null,
   SmgAddr              varchar(200)         null,
   EmailIsLogin         bit                  not null default 0,
   Pop3                 varchar(100)         null,
   UserName             varchar(50)          null,
   HoldEmailPwd         bit                  null default 0,
   constraint PK_Y_USER_INFO primary key (UserId)
)
go



/*==============================================================*/
/* Table: Y_KnowledgeBase                                       */
/*==============================================================*/
create table Y_KnowledgeBase (
   KnowledgeCode        bigint               identity,
   CreateDate           date                 not null,
   Suffix               varchar(10)          not null,
   Title                nvarchar(100)        not null,
   KeyWords             nvarchar(100)        not null,
   Content              binary varying(Max)  null,
   UpdateDate           date                 null,
   constraint PK_Y_KNOWLEDGEBASE primary key (KnowledgeCode)
)
go


/*==============================================================*/
/* Table: Y_KnowledgeBaseChanges                                */
/*==============================================================*/
create table Y_KnowledgeBaseChanges (
   Id                   bigint               identity,
   KnowledgeCode        bigint               null,
   StuffId              bigint               not null,
   StuffName            nvarchar(500)        not null,
   DeptId               bigint               not null,
   DeptName             nvarchar(500)        not null,
   OperateType          int                  not null,
   OperateName          nvarchar(4)          not null,
   OperateDate          date                 not null,
   constraint PK_Y_KNOWLEDGEBASECHANGES primary key (Id)
)
go

alter table Y_KnowledgeBaseChanges
   add constraint FK_Y_KNOWLE_REFERENCE_Y_KNOWLE foreign key (KnowledgeCode)
      references Y_KnowledgeBase (KnowledgeCode)
go


/*==============================================================*/
/* Table: Y_Function                                            */
/*==============================================================*/
create table Y_Function (
   FunctionId           int                  not null,
   FunctionName         varchar(100)         not null,
   FunctionType         int                  not null,
   constraint PK_Y_FUNCTION primary key (FunctionId)
)
go

/*==============================================================*/
/* Table: Y_Operation                                           */
/*==============================================================*/
create table Y_Operation (
   OperationId          int                  not null,
   OperationName        varchar(100)         not null,
   OperationType        int                  not null,
   constraint PK_Y_OPERATION primary key (OperationId)
)
go

/*==============================================================*/
/* Table: Y_Position                                            */
/*==============================================================*/
create table Y_Position (
   PostId               bigint               identity,
   PostName             nvarchar(50)         not null,
   IsDelete             bit                  not null default 0,
   IsDistribution       bit                  not null default 0,
   constraint PK_Y_POSITION primary key (PostId)
)
go


/*==============================================================*/
/* Table: Y_Post_Privilege                                      */
/*==============================================================*/
create table Y_Post_Privilege (
   PostId               bigint               not null,
   FunctionId           int                  not null,
   OperationId          int                  not null,
   constraint PK_Y_POST_PRIVILEGE primary key (PostId, OperationId, FunctionId)
)
go

alter table Y_Post_Privilege
   add constraint FK_Y_POST_P_REFERENCE_Y_POSITI foreign key (PostId)
      references Y_Position (PostId)
go

alter table Y_Post_Privilege
   add constraint FK_Y_POST_P_REFERENCE_Y_OPERAT foreign key (OperationId)
      references Y_Operation (OperationId)
go

alter table Y_Post_Privilege
   add constraint FK_Y_POST_P_REFERENCE_Y_FUNCTI foreign key (FunctionId)
      references Y_Function (FunctionId)
go



/*==============================================================*/
/* Table: Y_Department                                          */
/*==============================================================*/
create table Y_Department (
   DepartId             bigint               identity,
   DepartName           nvarchar(50)         not null,
   Code                 varchar(100)         not null,
   IsDelete             bit                  not null default 0,
   constraint PK_Y_DEPARTMENT primary key (DepartId)
)
go


/*==============================================================*/
/* Table: Y_Dept_Position                                       */
/*==============================================================*/
create table Y_Dept_Position (
   PermissionId         bigint               identity,
   PostId               bigint               not null,
   DepartId             bigint               not null,
   constraint PK_Y_DEPT_POSITION primary key (PostId, DepartId)
)
go

alter table Y_Dept_Position
   add constraint FK_Y_DEPT_P_REFERENCE_Y_POSITI foreign key (PostId)
      references Y_Position (PostId)
go

alter table Y_Dept_Position
   add constraint FK_Y_DEPT_P_REFERENCE_Y_DEPART foreign key (DepartId)
      references Y_Department (DepartId)
go


/*==============================================================*/
/* Table: Y_Manager                                             */
/*==============================================================*/
create table Y_Manager (
   ManagerId            bigint               not null,
   LoginName            nvarchar(20)         not null,
   Pwd                  varchar(200)         not null,
   IsUse                bit                  not null default 1,
   PermissionId         bigint               null,
   Channel              varchar(100)         not null,
   constraint PK_Y_MANAGER primary key (ManagerId)
)
go

create table Y_Call_Log (
   ChannelNo            int                  not null,
   SeatPhone            varchar(4)           not null,
   Phone                varchar(20)          not null,
   StartTime            datetime             not null,
   TalkTime             varchar(10)          not null
)
go



/*==============================================================*/
/* Table: Y_Call_Log                                            */
/*==============================================================*/
create table Y_Call_Log (
   ChannelNo            int                  not null,
   SeatPhone            varchar(4)           not null,
   Phone                varchar(20)          not null,
   StartTime            datetime             not null,
   TalkTime             varchar(10)          not null
)
go


/*****************************************************************************************************************************************************************/
/*                                                         视图                                                                                                  */
/*****************************************************************************************************************************************************************/


/*==============================================================*/
/* View: Y_V_ORG_MEMBER                                         */
/*==============================================================*/
create view Y_V_ORG_MEMBER as
select A.*,B.NAME as DEPARTMENTNAME from ORG_MEMBER A left join 
ORG_UNIT B on A.ORG_DEPARTMENT_ID = B.ID
where A.IS_DELETED=0
go


/*==============================================================*/
/* View: Y_V_Dept_Position                                      */
/*==============================================================*/
create view Y_V_Dept_Position as
select A.*,B.DepartName,B.Code as DepartCode,C.PostName
from Y_Dept_Position A,Y_Department B,Y_Position C
where A.PostId = C.PostId and A.DepartId = B.DepartId
go

/*==============================================================*/
/* View: Y_V_Manager                                            */
/*==============================================================*/
create view Y_V_Manager as
select A.*,B.NAME,C.PostId,C.DepartId,C.DepartCode,C.PostName,C.DepartName as DepartName from Y_Manager A
left join ORG_MEMBER B on A.ManagerId = B.ID
left join Y_V_Dept_Position C on A.PermissionId = C.PermissionId
go

