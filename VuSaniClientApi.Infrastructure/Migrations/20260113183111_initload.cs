using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Parent = table.Column<int>(type: "int", nullable: true),
                    IsStatic = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disabilities_Disabilities_Parent",
                        column: x => x.Parent,
                        principalTable: "Disabilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HighestQualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UniqueId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighestQualifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsStatic = table.Column<int>(type: "int", nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UniqueId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    BusinessLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgroundImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeaderImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontSize = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PickColor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UniqueId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BusinessAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Organizations_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationShips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationShips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleHierarchies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<int>(type: "int", nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Editable = table.Column<int>(type: "int", nullable: true),
                    UniqueId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleHierarchies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillsType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsStatic = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UniqueId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DepartmentHead = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    ParentDepartment = table.Column<int>(type: "int", nullable: true),
                    UniqueId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Department_ParentDepartment",
                        column: x => x.ParentDepartment,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Department_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationLicences",
                columns: table => new
                {
                    LicenceId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationLicences", x => new { x.OrganizationId, x.LicenceId });
                    table.ForeignKey(
                        name: "FK_OrganizationLicences_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationLicences_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    Responsibilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification = table.Column<int>(type: "int", nullable: true),
                    YearOfExperience = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OtherRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectOtherRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportToRole = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Department = table.Column<int>(type: "int", nullable: true),
                    Hierarchy = table.Column<int>(type: "int", nullable: true),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PreEmployment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostEmployment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationRoleHierarchies",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    RoleHierarchyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationRoleHierarchies", x => new { x.OrganizationId, x.RoleHierarchyId });
                    table.ForeignKey(
                        name: "FK_OrganizationRoleHierarchies_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationRoleHierarchies_RoleHierarchies_RoleHierarchyId",
                        column: x => x.RoleHierarchyId,
                        principalTable: "RoleHierarchies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReasonForInactives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UniqueId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonForInactives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReasonForInactives_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReasonForInactives_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NextOfKins",
                columns: table => new
                {
                    NextOfKinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationshipId = table.Column<int>(type: "int", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKins", x => x.NextOfKinId);
                    table.ForeignKey(
                        name: "FK_NextOfKins_RelationShips_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "RelationShips",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UniqueIdStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Profile = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    Disability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaceId = table.Column<int>(type: "int", nullable: true),
                    EmployeeType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HighestQualificationId = table.Column<int>(type: "int", nullable: true),
                    NameOfQualification = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    RoleDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Department = table.Column<int>(type: "int", nullable: true),
                    Accountability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Otp = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MyOrganization = table.Column<int>(type: "int", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    Permission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialPermission = table.Column<int>(type: "int", nullable: true),
                    NotificationSender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationAccess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsSuperAdmin = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmployeeContactDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProbationPeriod = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfTermination = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResidentialAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IncomeTaxNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TaxResidencyStatus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmploymentChecklist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentMedications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VaccinationRecords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VisaNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    PersonWithDisabilities = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CurrentAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NextOfKinId = table.Column<int>(type: "int", nullable: true),
                    EmploymentType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartProbationPeriod = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndProbationPeriod = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonForEmployeeBecomingInactive = table.Column<int>(type: "int", nullable: true),
                    HierarchyLevel = table.Column<int>(type: "int", nullable: true),
                    Manager = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WorkPermitExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeDepartment = table.Column<int>(type: "int", nullable: true),
                    PermitLicense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveStep = table.Column<int>(type: "int", nullable: true),
                    PreEmploymentCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostEmploymentCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeDepartmentInfo = table.Column<int>(type: "int", nullable: true),
                    DdrmId = table.Column<int>(type: "int", nullable: true),
                    CompletedStep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Policy = table.Column<int>(type: "int", nullable: true),
                    Incident = table.Column<int>(type: "int", nullable: true),
                    NonConformance = table.Column<int>(type: "int", nullable: true),
                    Risk = table.Column<int>(type: "int", nullable: true),
                    UnifiedUserUiqueId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RelationShipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_HighestQualifications_HighestQualificationId",
                        column: x => x.HighestQualificationId,
                        principalTable: "HighestQualifications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_NextOfKins_NextOfKinId",
                        column: x => x.NextOfKinId,
                        principalTable: "NextOfKins",
                        principalColumn: "NextOfKinId");
                    table.ForeignKey(
                        name: "FK_Users_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_RelationShips_RelationShipId",
                        column: x => x.RelationShipId,
                        principalTable: "RelationShips",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Other" },
                    { 4, "Prefer not to say" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_OrganizationId",
                table: "Department",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_ParentDepartment",
                table: "Department",
                column: "ParentDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_Disabilities_Parent",
                table: "Disabilities",
                column: "Parent");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_RelationshipId",
                table: "NextOfKins",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_UserId",
                table: "NextOfKins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationLicences_LicenceId",
                table: "OrganizationLicences",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationRoleHierarchies_RoleHierarchyId",
                table: "OrganizationRoleHierarchies",
                column: "RoleHierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ParentId",
                table: "Organizations",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonForInactives_DepartmentId",
                table: "ReasonForInactives",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonForInactives_OrganizationId",
                table: "ReasonForInactives",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_OrganizationId",
                table: "Roles",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_HighestQualificationId",
                table: "Users",
                column: "HighestQualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LanguageId",
                table: "Users",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NextOfKinId",
                table: "Users",
                column: "NextOfKinId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RaceId",
                table: "Users",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RelationShipId",
                table: "Users",
                column: "RelationShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StateId",
                table: "Users",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Users_UserId",
                table: "NextOfKins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_States_StateId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Organizations_OrganizationId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_RelationShips_RelationshipId",
                table: "NextOfKins");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RelationShips_RelationShipId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Users_UserId",
                table: "NextOfKins");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Disabilities");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "OrganizationLicences");

            migrationBuilder.DropTable(
                name: "OrganizationRoleHierarchies");

            migrationBuilder.DropTable(
                name: "ReasonForInactives");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Licences");

            migrationBuilder.DropTable(
                name: "RoleHierarchies");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "RelationShips");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "HighestQualifications");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "NextOfKins");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
