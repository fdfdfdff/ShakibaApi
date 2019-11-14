using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RCNClinicApp.MobileAppService.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Account",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameBank = table.Column<string>(maxLength: 100, nullable: false),
                    NumAccount = table.Column<string>(unicode: false, nullable: true),
                    NumCard = table.Column<string>(unicode: false, nullable: true),
                    Branch = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Information",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(maxLength: 500, nullable: true),
                    Tell = table.Column<string>(maxLength: 50, nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    ServerAdress = table.Column<string>(maxLength: 500, nullable: true),
                    FolderPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Information", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_InsurOrg",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Code = table.Column<string>(unicode: false, fixedLength: true, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_InsurOrg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Insure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Percents = table.Column<int>(nullable: true),
                    percentBed = table.Column<int>(nullable: true),
                    IdInsureOrg = table.Column<int>(nullable: true),
                    InsureCDName = table.Column<string>(maxLength: 300, nullable: true),
                    Code = table.Column<string>(unicode: false, fixedLength: true, maxLength: 4, nullable: true),
                    IsDelete = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Insure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Insure_tbl_InsurOrg_IdInsureOrg",
                        column: x => x.IdInsureOrg,
                        principalTable: "tbl_InsurOrg",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Dual",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    TypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Dual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Dual_tbl_Type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "tbl_Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_GeneralGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    IdTypeward = table.Column<int>(nullable: true),
                    IdType = table.Column<int>(nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Tel = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_GeneralGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_GeneralGroups_tbl_Dual_IdType",
                        column: x => x.IdType,
                        principalTable: "tbl_Dual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_GeneralGroups_tbl_Dual_IdTypeward",
                        column: x => x.IdTypeward,
                        principalTable: "tbl_Dual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_patient",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(maxLength: 50, nullable: false),
                    Moaref = table.Column<string>(maxLength: 150, nullable: true),
                    IdSex = table.Column<int>(nullable: false),
                    Job = table.Column<string>(maxLength: 100, nullable: true),
                    birthDay = table.Column<string>(maxLength: 15, nullable: true),
                    InsurenceBookletNum = table.Column<string>(maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(maxLength: 50, nullable: true),
                    IDFirstInsure = table.Column<int>(nullable: true),
                    DossierNumberTemporary = table.Column<string>(maxLength: 50, nullable: true),
                    DossierNumberPermanent = table.Column<string>(maxLength: 50, nullable: true),
                    Education = table.Column<string>(maxLength: 50, nullable: true),
                    PathPic = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_patient_tbl_Dual_IdSex",
                        column: x => x.IdSex,
                        principalTable: "tbl_Dual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_docter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(maxLength: 15, nullable: true),
                    Tel = table.Column<string>(maxLength: 15, nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    IdSpecialityDr = table.Column<int>(nullable: true),
                    MedicalCouncil = table.Column<string>(maxLength: 20, nullable: true),
                    CalculationType = table.Column<int>(nullable: true),
                    Pic = table.Column<string>(maxLength: 100, nullable: true),
                    IdGenereal_Group = table.Column<int>(nullable: true),
                    PercentOrConstValue = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_docter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_docter_tbl_Dual_CalculationType",
                        column: x => x.CalculationType,
                        principalTable: "tbl_Dual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_docter_tbl_GeneralGroups_IdGenereal_Group",
                        column: x => x.IdGenereal_Group,
                        principalTable: "tbl_GeneralGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_docter_tbl_Dual_IdSpecialityDr",
                        column: x => x.IdSpecialityDr,
                        principalTable: "tbl_Dual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Nationcode = table.Column<string>(maxLength: 50, nullable: true),
                    Barcode = table.Column<string>(maxLength: 15, nullable: true),
                    Unit = table.Column<string>(maxLength: 100, nullable: true),
                    FreePrices = table.Column<double>(nullable: true),
                    IdType = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    IsConflict = table.Column<bool>(nullable: true),
                    IdGeneral_Group = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Service_tbl_GeneralGroups_IdGeneral_Group",
                        column: x => x.IdGeneral_Group,
                        principalTable: "tbl_GeneralGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Service_tbl_Dual_IdType",
                        column: x => x.IdType,
                        principalTable: "tbl_Dual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 500, nullable: false),
                    Password = table.Column<string>(maxLength: 500, nullable: true),
                    UserCommand = table.Column<string>(type: "ntext", nullable: true),
                    IsDr = table.Column<bool>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    PersonnelOrDrId = table.Column<int>(nullable: true),
                    IdGeneralGroup = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Users_tbl_GeneralGroups_IdGeneralGroup",
                        column: x => x.IdGeneralGroup,
                        principalTable: "tbl_GeneralGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblReception",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPatient = table.Column<long>(nullable: false),
                    IdService = table.Column<int>(nullable: false),
                    RegDate = table.Column<DateTime>(nullable: false),
                    IdWaiting = table.Column<int>(nullable: true),
                    IdDoctor = table.Column<int>(nullable: true),
                    KnowledgeOfOperation = table.Column<string>(maxLength: 1500, nullable: true),
                    ExperienceOfBeauty = table.Column<string>(maxLength: 1500, nullable: true),
                    ProblemOfOpearation = table.Column<string>(maxLength: 1500, nullable: true),
                    WhatTimeWhatDo = table.Column<string>(maxLength: 1500, nullable: true),
                    WhatCases = table.Column<string>(maxLength: 1500, nullable: true),
                    UsageDrugs = table.Column<string>(maxLength: 1500, nullable: true),
                    AlergyDrug = table.Column<string>(maxLength: 1500, nullable: true),
                    ExperienceBlood = table.Column<string>(maxLength: 1500, nullable: true),
                    PhysicalProblem = table.Column<string>(maxLength: 1500, nullable: true),
                    Sign = table.Column<string>(maxLength: 1500, nullable: true),
                    PenSatisfaction = table.Column<string>(maxLength: 1500, nullable: true),
                    IdGeneralGroup = table.Column<int>(nullable: true),
                    IdInsure = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReception", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblReception_tbl_docter_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "tbl_docter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblReception_tbl_GeneralGroups_IdGeneralGroup",
                        column: x => x.IdGeneralGroup,
                        principalTable: "tbl_GeneralGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblReception_tbl_patient_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "tbl_patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblReception_tbl_Service_IdService",
                        column: x => x.IdService,
                        principalTable: "tbl_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblReception_tbl_Dual_IdWaiting",
                        column: x => x.IdWaiting,
                        principalTable: "tbl_Dual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_InsureAccount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: true),
                    IdInsurence = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WhoSave = table.Column<int>(nullable: true),
                    DateSave = table.Column<DateTime>(nullable: true),
                    WhoEdit = table.Column<int>(nullable: true),
                    DateEdit = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_InsureAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_InsureAccount_tbl_Insure_IdInsurence",
                        column: x => x.IdInsurence,
                        principalTable: "tbl_Insure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_InsureAccount_tbl_Users_WhoEdit",
                        column: x => x.WhoEdit,
                        principalTable: "tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_InsureAccount_tbl_Users_WhoSave",
                        column: x => x.WhoSave,
                        principalTable: "tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Tankhah",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Payer = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IdGeneralGroup = table.Column<int>(nullable: true),
                    DateSave = table.Column<DateTime>(nullable: true),
                    DateEdit = table.Column<DateTime>(nullable: true),
                    WhoSave = table.Column<int>(nullable: true),
                    WhoEdit = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Tankhah", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Tankhah_tbl_GeneralGroups_IdGeneralGroup",
                        column: x => x.IdGeneralGroup,
                        principalTable: "tbl_GeneralGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Tankhah_tbl_Users_WhoEdit",
                        column: x => x.WhoEdit,
                        principalTable: "tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Tankhah_tbl_Users_WhoSave",
                        column: x => x.WhoSave,
                        principalTable: "tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Users_Role",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Users_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Users_Role_tbl_Dual_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_Dual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Users_Role_tbl_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cash_AllTransaction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdReception = table.Column<long>(nullable: true),
                    payment = table.Column<double>(nullable: true),
                    SerialNum = table.Column<string>(maxLength: 25, nullable: true),
                    IdPayType = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    payer = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    IsConfirm = table.Column<bool>(nullable: true),
                    AccountId = table.Column<short>(nullable: true),
                    WhoSave = table.Column<int>(nullable: true),
                    DateSave = table.Column<DateTime>(nullable: true),
                    WhoEdit = table.Column<int>(nullable: true),
                    DateEdit = table.Column<DateTime>(nullable: true),
                    DateDelete = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_cash_AllTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_cash_AllTransaction_tbl_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tbl_Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_cash_AllTransaction_tbl_Dual_IdPayType",
                        column: x => x.IdPayType,
                        principalTable: "tbl_Dual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_cash_AllTransaction_tblReception_IdReception",
                        column: x => x.IdReception,
                        principalTable: "tblReception",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_cash_AllTransaction_tbl_Users_WhoEdit",
                        column: x => x.WhoEdit,
                        principalTable: "tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_cash_AllTransaction_tbl_Users_WhoSave",
                        column: x => x.WhoSave,
                        principalTable: "tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cashrecords",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdReception = table.Column<long>(nullable: true),
                    TotalPrice = table.Column<double>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    WhoSave = table.Column<int>(nullable: true),
                    DateSave = table.Column<DateTime>(nullable: true),
                    WhoEdit = table.Column<int>(nullable: true),
                    DateEdit = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_cashrecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_cashrecords_tblReception_IdReception",
                        column: x => x.IdReception,
                        principalTable: "tblReception",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_cashrecords_tbl_Users_WhoEdit",
                        column: x => x.WhoEdit,
                        principalTable: "tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_cashrecords_tbl_Users_WhoSave",
                        column: x => x.WhoSave,
                        principalTable: "tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblVisit",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdReception = table.Column<long>(nullable: false),
                    VisitDate = table.Column<DateTime>(nullable: false),
                    IdWaiting = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: true),
                    Percents = table.Column<double>(nullable: true),
                    Tariff = table.Column<double>(nullable: true),
                    FreePrices = table.Column<double>(nullable: true),
                    DateRequest = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblVisit_tblReception_IdReception",
                        column: x => x.IdReception,
                        principalTable: "tblReception",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblVisit_tbl_Dual_IdWaiting",
                        column: x => x.IdWaiting,
                        principalTable: "tbl_Dual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Advertising",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdVisit = table.Column<long>(nullable: false),
                    SendDate = table.Column<DateTime>(nullable: false),
                    IsSend = table.Column<bool>(nullable: true),
                    IdService = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Advertising", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Advertising_tbl_Service_IdService",
                        column: x => x.IdService,
                        principalTable: "tbl_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Advertising_tblVisit_IdVisit",
                        column: x => x.IdVisit,
                        principalTable: "tblVisit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SMS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdVisit = table.Column<long>(nullable: false),
                    SendDate = table.Column<DateTime>(nullable: false),
                    IsSend = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_SMS_tblVisit_IdVisit",
                        column: x => x.IdVisit,
                        principalTable: "tblVisit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPicture",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdVisit = table.Column<long>(nullable: false),
                    Filepath = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPicture_tblVisit_IdVisit",
                        column: x => x.IdVisit,
                        principalTable: "tblVisit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Advertising_IdService",
                table: "tbl_Advertising",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Advertising_IdVisit",
                table: "tbl_Advertising",
                column: "IdVisit");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cash_AllTransaction_AccountId",
                table: "tbl_cash_AllTransaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cash_AllTransaction_IdPayType",
                table: "tbl_cash_AllTransaction",
                column: "IdPayType");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cash_AllTransaction_IdReception",
                table: "tbl_cash_AllTransaction",
                column: "IdReception");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cash_AllTransaction_WhoEdit",
                table: "tbl_cash_AllTransaction",
                column: "WhoEdit");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cash_AllTransaction_WhoSave",
                table: "tbl_cash_AllTransaction",
                column: "WhoSave");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cashrecords_IdReception",
                table: "tbl_cashrecords",
                column: "IdReception");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cashrecords_WhoEdit",
                table: "tbl_cashrecords",
                column: "WhoEdit");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cashrecords_WhoSave",
                table: "tbl_cashrecords",
                column: "WhoSave");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_docter_CalculationType",
                table: "tbl_docter",
                column: "CalculationType");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_docter_IdGenereal_Group",
                table: "tbl_docter",
                column: "IdGenereal_Group");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_docter_IdSpecialityDr",
                table: "tbl_docter",
                column: "IdSpecialityDr");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Dual_TypeId",
                table: "tbl_Dual",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_GeneralGroups_IdType",
                table: "tbl_GeneralGroups",
                column: "IdType");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_GeneralGroups_IdTypeward",
                table: "tbl_GeneralGroups",
                column: "IdTypeward");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Insure_IdInsureOrg",
                table: "tbl_Insure",
                column: "IdInsureOrg");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_InsureAccount_IdInsurence",
                table: "tbl_InsureAccount",
                column: "IdInsurence");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_InsureAccount_WhoEdit",
                table: "tbl_InsureAccount",
                column: "WhoEdit");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_InsureAccount_WhoSave",
                table: "tbl_InsureAccount",
                column: "WhoSave");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_patient_IdSex",
                table: "tbl_patient",
                column: "IdSex");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Service_IdGeneral_Group",
                table: "tbl_Service",
                column: "IdGeneral_Group");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Service_IdType",
                table: "tbl_Service",
                column: "IdType");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SMS_IdVisit",
                table: "tbl_SMS",
                column: "IdVisit");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Tankhah_IdGeneralGroup",
                table: "tbl_Tankhah",
                column: "IdGeneralGroup");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Tankhah_WhoEdit",
                table: "tbl_Tankhah",
                column: "WhoEdit");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Tankhah_WhoSave",
                table: "tbl_Tankhah",
                column: "WhoSave");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Users_IdGeneralGroup",
                table: "tbl_Users",
                column: "IdGeneralGroup");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Users_Role_RoleId",
                table: "tbl_Users_Role",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Users_Role_UsersId",
                table: "tbl_Users_Role",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPicture_IdVisit",
                table: "tblPicture",
                column: "IdVisit");

            migrationBuilder.CreateIndex(
                name: "IX_tblReception_IdDoctor",
                table: "tblReception",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_tblReception_IdGeneralGroup",
                table: "tblReception",
                column: "IdGeneralGroup");

            migrationBuilder.CreateIndex(
                name: "IX_tblReception_IdPatient",
                table: "tblReception",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_tblReception_IdService",
                table: "tblReception",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_tblReception_IdWaiting",
                table: "tblReception",
                column: "IdWaiting");

            migrationBuilder.CreateIndex(
                name: "IX_tblVisit_IdReception",
                table: "tblVisit",
                column: "IdReception");

            migrationBuilder.CreateIndex(
                name: "IX_tblVisit_IdWaiting",
                table: "tblVisit",
                column: "IdWaiting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Advertising");

            migrationBuilder.DropTable(
                name: "tbl_cash_AllTransaction");

            migrationBuilder.DropTable(
                name: "tbl_cashrecords");

            migrationBuilder.DropTable(
                name: "tbl_Information");

            migrationBuilder.DropTable(
                name: "tbl_InsureAccount");

            migrationBuilder.DropTable(
                name: "tbl_SMS");

            migrationBuilder.DropTable(
                name: "tbl_Tankhah");

            migrationBuilder.DropTable(
                name: "tbl_Users_Role");

            migrationBuilder.DropTable(
                name: "tblPicture");

            migrationBuilder.DropTable(
                name: "tbl_Account");

            migrationBuilder.DropTable(
                name: "tbl_Insure");

            migrationBuilder.DropTable(
                name: "tbl_Users");

            migrationBuilder.DropTable(
                name: "tblVisit");

            migrationBuilder.DropTable(
                name: "tbl_InsurOrg");

            migrationBuilder.DropTable(
                name: "tblReception");

            migrationBuilder.DropTable(
                name: "tbl_docter");

            migrationBuilder.DropTable(
                name: "tbl_patient");

            migrationBuilder.DropTable(
                name: "tbl_Service");

            migrationBuilder.DropTable(
                name: "tbl_GeneralGroups");

            migrationBuilder.DropTable(
                name: "tbl_Dual");

            migrationBuilder.DropTable(
                name: "tbl_Type");
        }
    }
}
