using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "Id", "CreatedAt", "Deleted", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Work and training combined, typically...</p>", "Apprenticeship", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Irregular work with no guaranteed hours...</p>", "Casual Employment", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>External expert hired for advice or services...</p>", "Consultant", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Employment for a set period or project...</p>", "Fixed-Term Contract", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Self-employed individual contracted for services...</p>", "Freelancer / Independent Contractor", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Standard employment with full weekly hours...</p>", "Full-Time Employment", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Role previously outsourced but now internal...</p>", "In-sourced Employment", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "Time-limited training for students or graduates...", "Internship", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "Work-based learning program leading to a qualification...", "Learnership (SA-specific)", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Regular employment with fewer hours...</p>", "Part-Time Employment", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Long-term employment with full benefits...</p>", "Permanent Employment", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Work tied to specific seasons or events...</p>", "Seasonal Employment", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Temporary transfer of an employee to another role...</p>", "Secondment", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Provides services to a contractor rather than employer...</p>", "Subcontractor", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Short-term work, often seasonal...</p>", "Temporary Employment", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Entry-level structured program to develop skills...</p>", "Trainee/Graduate Program", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified), false, "<p>Individual works without pay, usually for experience...</p>", "Volunteer", new DateTime(2025, 8, 11, 10, 3, 26, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "HighestQualifications",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "Description", "Name", "Organization", "UniqueId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1, 0, "<p>NQF Level 1: Typically awarded after ...</p>", "General Education and Training Certificate (GETC)", null, "H&HG/SKI/2425/0001", new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1, 0, "<p>NQF Level 4: Also known as the matric...</p>", "National Senior Certificate (NSC)", null, "H&HG/SKI/2425/0002", new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1, 0, "NQF Level 5: A one-year vocational or occupational...", "Higher Certificate", null, "H&HG/SKI/2425/0003", new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1, 0, "NQF Level 6: Builds on a Higher Certificate or Dip...", "Advanced Certificate", null, "H&HG/SKI/2425/0004", new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1, 0, "<p>NQF Levels 2–4: Technical and ...</p>", "National Certificate (Vocational) – NC(V)", null, "H&HG/SKI/2425/0005", new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1, 0, "<p>NQF Level 6: Typically a 2–3 y...</p>", "Diploma", null, "H&HG/SKI/2425/0006", new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1, 0, "<p>NQF Level 7: Post-diploma qualificati...</p>", "Advanced Diploma", null, "H&HG/SKI/2425/0007", new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1, 0, "<p>NQF Level 7: A 3–4 year underg...</p>", "Bachelor’s Degree", null, "H&HG/SKI/2425/0008", new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1, 0, "<p>NQF Level 8: A postgraduate year of s...</p>", "Bachelor Honours Degree", null, "H&HG/SKI/2425/0009", new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1, 0, "<p>NQF Level 8: A vocational or professi...</p>", "Postgraduate Diploma", null, "H&HG/SKI/2425/0010", new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1, 0, "<p>NQF Level 9: A postgraduate academic ...</p>", "Master’s Degree", null, "H&HG/SKI/2425/0011", new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1, 0, "<p>NQF Level 10: The highest academic qu...</p>", "Doctoral Degree (PhD or DTech)", null, "H&HG/SKI/2425/0012", new DateTime(2025, 8, 11, 10, 3, 27, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "Spanish" },
                    { 3, "isiZulu" },
                    { 4, "isiXhosa" },
                    { 5, "Afrikaans" },
                    { 6, "Sepedi (Northern Sotho)" },
                    { 7, "Setswana" },
                    { 8, "Sesotho (Southern Sotho)" },
                    { 9, "Xitsonga" },
                    { 10, "siSwati" },
                    { 11, "Tshivenda" },
                    { 12, "isiNdebele" },
                    { 13, "South African Sign Language (SASL)" }
                });

            migrationBuilder.InsertData(
                table: "Licences",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "Description", "IsStatic", "Name", "Organization", "UniqueId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 11, 10, 3, 29, 0, DateTimeKind.Unspecified), 1, 0, "<p>Proof that products or systems comply...", 0, "SANS Compliance Certificate", null, "HAM/LIC/2526/0243", new DateTime(2025, 8, 11, 10, 3, 29, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 8, 11, 10, 3, 29, 0, DateTimeKind.Unspecified), 1, 0, "<p>SAQA-accredited certificate for occup...", 0, "Occupational Certificate", null, "HAM/LIC/2526/0244", new DateTime(2025, 8, 11, 10, 3, 29, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 8, 11, 10, 3, 29, 0, DateTimeKind.Unspecified), 1, 0, "<p>Good Manufacturing Practice certifica...", 0, "GMP Certificate", null, "HAM/LIC/2526/0242", new DateTime(2025, 8, 11, 10, 3, 29, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "BackgroundImage", "BusinessAddress", "BusinessLogo", "CreatedAt", "CreatedBy", "Deleted", "Description", "FontSize", "FooterImage", "HeaderImage", "Level", "Name", "ParentId", "PickColor", "UniqueId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, "https://saapi.vusani360.africa/main_logo.png", "65 Garden Road", "https://saapi.vusani360.africa/main_logo.png", new DateTime(2025, 8, 11, 10, 3, 30, 0, DateTimeKind.Unspecified), 1, 0, "<p>Corporate Office</p>", "16", "https://saapi.vusani360.africa/main_logo.png", "https://saapi.vusani360.africa/main_logo.png", 1, "Harmony and Motors", null, "#45c421", "H&HG/2425/001", new DateTime(2025, 8, 11, 10, 3, 30, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "White" },
                    { 2, "Black" },
                    { 3, "Coloured" },
                    { 4, "Indian" },
                    { 5, "Other" }
                });

            migrationBuilder.InsertData(
                table: "RelationShips",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Father" },
                    { 2, "Mother" },
                    { 3, "Son" },
                    { 4, "Daughter" },
                    { 5, "Brother" },
                    { 6, "Sister" },
                    { 7, "Half-Brother" },
                    { 8, "Half-Sister" },
                    { 9, "Stepfather" },
                    { 10, "Stepmother" },
                    { 11, "Stepson" },
                    { 12, "Stepdaughter" },
                    { 13, "Stepbrother" },
                    { 14, "Stepsister" },
                    { 15, "Husband" },
                    { 16, "Wife" },
                    { 17, "Ex-Husband" },
                    { 18, "Ex-Wife" },
                    { 19, "Father-in-law" },
                    { 20, "Mother-in-law" },
                    { 21, "Brother-in-law" },
                    { 22, "Sister-in-law" },
                    { 23, "Son-in-law" },
                    { 24, "Daughter-in-law" },
                    { 25, "Grandfather" },
                    { 26, "Grandmother" },
                    { 27, "Grandson" },
                    { 28, "Granddaughter" },
                    { 29, "Great-grandfather" },
                    { 30, "Great-grandmother" },
                    { 31, "Great-grandson" },
                    { 32, "Great-granddaughter" },
                    { 33, "Uncle" },
                    { 34, "Aunt" },
                    { 35, "Cousin" },
                    { 36, "First Cousin" },
                    { 37, "Second Cousin" },
                    { 38, "Cousin-in-law" },
                    { 39, "Nephew" },
                    { 40, "Niece" },
                    { 41, "Great-Nephew (Grandnephew)" },
                    { 42, "Great-Niece (Grandniece)" },
                    { 43, "Foster Father" },
                    { 44, "Foster Mother" },
                    { 45, "Foster Child" },
                    { 46, "Adoptive Father" },
                    { 47, "Adoptive Mother" },
                    { 48, "Adopted Son" },
                    { 49, "Adopted Daughter" },
                    { 50, "Guardian" },
                    { 51, "Sibling-in-law" },
                    { 52, "Godfather" },
                    { 53, "Godmother" },
                    { 54, "Godson" },
                    { 55, "Goddaughter" },
                    { 56, "Co-parent" },
                    { 57, "Partner" },
                    { 58, "Fiancé" },
                    { 59, "Fiancée" }
                });

            migrationBuilder.InsertData(
                table: "RoleHierarchies",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "Department", "Description", "Editable", "Level", "Name", "Organization", "UniqueId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 11, 10, 3, 32, 0, DateTimeKind.Unspecified), 1, 0, null, "Elected group responsible for governance...", 1, "Corporate/Executive Level", "Board of Directors", "[3,2,1]", "H&HG/RH/2425/0001", new DateTime(2025, 8, 11, 10, 3, 32, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 8, 11, 10, 3, 32, 0, DateTimeKind.Unspecified), 1, 0, null, "Leads the board, ensures board effectiveness...", 1, "Corporate/Executive Level", "Chairperson of the Board", "[3,2,1]", "H&HG/RH/2425/0002", new DateTime(2025, 8, 11, 10, 3, 32, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 8, 11, 10, 3, 32, 0, DateTimeKind.Unspecified), 1, 0, null, "Highest-ranking executive managing overall operations...", 1, "Corporate/Executive Level", "Chief Executive Officer (CEO)", "[3,2,1]", "H&HG/RH/2425/0003", new DateTime(2025, 8, 11, 10, 3, 32, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 8, 11, 10, 3, 32, 0, DateTimeKind.Unspecified), 1, 0, null, "Sometimes separate from CEO; handles strategic leadership...", 1, "Corporate/Executive Level", "President", "[3,2,1]", "H&HG/RH/2425/0004", new DateTime(2025, 8, 11, 10, 3, 32, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 8, 11, 10, 3, 32, 0, DateTimeKind.Unspecified), 1, 0, null, "Manages day-to-day operations and strategy execution...", 1, "Corporate/Executive Level", "Chief Operating Officer (COO)", "[3,2,1]", "H&HG/RH/2425/0005", new DateTime(2025, 8, 11, 10, 3, 32, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "Description", "Industry", "IsStatic", "Name", "Organization", "SkillsType", "UniqueId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), 1, 0, null, null, 1, "Communication Skills", "[1]", "Soft Skill", "HAM/SKI/2526/0001", new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), 1, 0, null, null, 1, "Problem-solving", "[1]", "Soft Skill", "HAM/SKI/2526/0002", new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), 1, 0, null, null, 1, "Critical thinking", "[1]", "Soft Skill", "HAM/SKI/2526/0003", new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), 1, 0, null, null, 1, "Time management", "[1]", "Soft Skill", "HAM/SKI/2526/0004", new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), 1, 0, null, null, 1, "Adaptability", "[1]", "Soft Skill", "HAM/SKI/2526/0005", new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), null },
                    { 6, new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), 1, 0, null, null, 1, "Collaboration", "[1]", "Soft Skill", "HAM/SKI/2526/0006", new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), null },
                    { 7, new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), 1, 0, null, null, 1, "Emotional Intelligence", "[1]", "Soft Skill", "HAM/SKI/2526/0007", new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), null },
                    { 8, new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), 1, 0, null, null, 1, "Leadership", "[1]", "Soft Skill", "HAM/SKI/2526/0008", new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), null },
                    { 9, new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), 1, 0, null, null, 1, "Creativity", "[1]", "Soft Skill", "HAM/SKI/2526/0009", new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), null },
                    { 10, new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), 1, 0, null, null, 1, "Conflict Resolution", "[1]", "Soft Skill", "HAM/SKI/2526/0010", new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), null },
                    { 11, new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), 1, 0, null, null, 1, "Programming (Python, Java, C++, etc.)", "[1]", "Hard or Technical Skill", "HAM/SKI/2526/0011", new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), null },
                    { 12, new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), 1, 0, null, null, 1, "Data Analysis", "[1]", "Hard or Technical Skill", "HAM/SKI/2526/0012", new DateTime(2025, 8, 11, 10, 3, 33, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "DepartmentHead", "Description", "Name", "OrganizationId", "ParentDepartment", "UniqueId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(1983), 1, false, 1, null, "Devs", 1, null, "HAM/D/2526/001", new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(1985), 1 });

            migrationBuilder.InsertData(
                table: "OrganizationLicences",
                columns: new[] { "LicenceId", "OrganizationId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrganizationRoleHierarchies",
                columns: new[] { "OrganizationId", "RoleHierarchyId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "BackgroundImage", "BusinessAddress", "BusinessLogo", "CreatedAt", "CreatedBy", "Deleted", "Description", "FontSize", "FooterImage", "HeaderImage", "Level", "Name", "ParentId", "PickColor", "UniqueId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 2, "https://harmonyandmotors-api.vusani360.africa/org1.png", "65 Garden Road", "https://harmonyandmotors-api.vusani360.africa/org1.png", new DateTime(2025, 8, 13, 20, 41, 7, 0, DateTimeKind.Unspecified), 1, 0, "<p>Property Division</p>", "16", "https://harmonyandmotors-api.vusani360.africa/org1.png", "https://harmonyandmotors-api.vusani360.africa/org1.png", 2, "Harmony and Properties", 1, "#6c1d45", "HAP/ORG/2526/002", new DateTime(2025, 8, 13, 20, 41, 7, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "https://harmonyandmotors-api.vusani360.africa/org2.png", "65 Garden Road", "https://harmonyandmotors-api.vusani360.africa/org2.png", new DateTime(2025, 8, 18, 17, 17, 1, 0, DateTimeKind.Unspecified), 1, 0, "<p>Academy division</p>", "16", "https://harmonyandmotors-api.vusani360.africa/org2.png", "https://harmonyandmotors-api.vusani360.africa/org2.png", 1, "Harmony and Academy", 1, null, "HAA/ORG/2526/003", new DateTime(2025, 8, 18, 17, 17, 1, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "Department", "Description", "Hierarchy", "Level", "License", "Name", "OrganizationId", "OtherRequirements", "Permission", "PostEmployment", "PreEmployment", "Qualification", "ReportToRole", "Responsibilities", "SelectOtherRequirements", "Skills", "UniqueId", "UpdatedAt", "UpdatedBy", "YearOfExperience" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 11, 10, 23, 3, 0, DateTimeKind.Unspecified), 1, 0, null, "<p>Administrator</p>", null, null, null, "Administrator", 1, null, null, null, null, null, null, null, null, null, "HAM/ROL/2526/001", new DateTime(2025, 8, 11, 10, 23, 3, 0, DateTimeKind.Unspecified), null, null },
                    { 2, new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(3676), null, 0, null, null, null, null, null, "Technical Support and Resolution", 1, null, null, null, null, null, null, null, null, null, "HAM/ROL/2526/002", new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(3676), null, null },
                    { 3, new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(3679), null, 0, null, null, null, null, null, "Managing Director", 1, null, null, null, null, null, null, null, null, null, "HAM/ROL/2526/003", new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(3680), null, null }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "DepartmentHead", "Description", "Name", "OrganizationId", "ParentDepartment", "UniqueId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 2, new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(1989), 1, false, 1, "<h2><strong>1. Strategic Technology</strong></h2>", "ICT Department", 1, 1, "HAM/AT/2526/001", new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(1991), 1 },
                    { 4, new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(2000), 1, false, 1, "<p>The <strong>SHEQ Department ensures...</strong></p>", "SHEQ Department", 1, 1, "HAM/AT/2526/001", new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(2001), 1 },
                    { 5, new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(2004), 1, false, 1, "<p>The <strong>Training and Development Department...</strong></p>", "Training and Development Department", 1, 1, "HAM/AT/2526/001", new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(2005), 1 }
                });

            migrationBuilder.InsertData(
                table: "OrganizationLicences",
                columns: new[] { "LicenceId", "OrganizationId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrganizationRoleHierarchies",
                columns: new[] { "OrganizationId", "RoleHierarchyId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountNumber", "AccountType", "Accountability", "ActiveStep", "Age", "Allergies", "BankName", "BloodType", "BranchCode", "CityId", "CompletedStep", "CountryId", "CreatedAt", "CreatedBy", "CurrentAddress", "CurrentMedications", "DateOfBirth", "DateOfEmployment", "DateOfTermination", "DdrmId", "Deleted", "Department", "Disability", "Email", "EmployeeDepartment", "EmployeeDepartmentInfo", "EmployeeTypeId", "EmploymentChecklist", "EmploymentStatus", "EndDate", "EndProbationPeriod", "GenderId", "HierarchyLevel", "HighestQualificationId", "IdNumber", "Incident", "IncomeTaxNumber", "IsSuperAdmin", "JoiningDate", "LanguageId", "Level", "License", "Manager", "MaritalStatus", "MyOrganization", "Name", "NameOfQualification", "NationalId", "NonConformance", "NotificationSender", "OrganizationAccess", "OrganizationId", "Otp", "PassportNumber", "Password", "Permission", "PermitLicense", "PersonWithDisabilities", "Phone", "Policy", "PostEmploymentCheck", "PostalAddress", "PreEmploymentCheck", "ProbationPeriod", "Profile", "RaceId", "ReasonForEmployeeBecomingInactive", "RelationShipId", "ResidentialAddress", "Risk", "RoleDesc", "RoleId", "Skills", "SpecialPermission", "StartProbationPeriod", "StateId", "Surname", "TaxResidencyStatus", "UnifiedUserUiqueId", "UniqueId", "UniqueIdStatus", "UpdatedAt", "UpdatedBy", "VaccinationRecords", "ViewType", "VisaNumber", "WorkPermitExpiryDate" },
                values: new object[] { 1, null, null, "[{\"accountability\":\"Accountability asdkfjhaklsdfas...\"}]", null, null, null, null, null, null, 108956, null, 205, new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(6656), 1, null, null, null, null, null, null, "0", 1, null, "learn@hhacademy.africa", null, null, 11, null, null, new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(6645), null, null, null, 1, "95021228928288", null, null, 1, new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(6644), null, null, null, null, null, 204, "Mirriam", "Graduation", null, null, null, "[205]", 1, null, null, "tyBqCuMQrmJboukQM66P+Rofl08DUeGP0wXw", "[{\"sidebarId\":1,\"permissions\":{\"1\":{\"view\":true}}}]", null, null, null, null, null, null, null, null, "profile/1717141951646_download.jfif", 1, null, null, null, null, null, 1, "1", 0, null, 3904, "Tenyane", null, "UIH-1052", "SR0001", "automatic", new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(6658), 1, null, "all", null, null });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "DepartmentHead", "Description", "Name", "OrganizationId", "ParentDepartment", "UniqueId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3, new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(1995), 1, false, 1, "<h2><strong>1. Strategic Workforce Planning</strong></h2>", "Human Resource Department", 1, 2, "HAM/AT/2526/001", new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(1996), 1 });

            migrationBuilder.InsertData(
                table: "NextOfKins",
                columns: new[] { "NextOfKinId", "ContactNumber", "Name", "RelationshipId", "UserId" },
                values: new object[] { 1, "27712654987", "Paulina Tenyane", 6, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "NextOfKins",
                keyColumn: "NextOfKinId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrganizationLicences",
                keyColumns: new[] { "LicenceId", "OrganizationId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrganizationLicences",
                keyColumns: new[] { "LicenceId", "OrganizationId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "OrganizationLicences",
                keyColumns: new[] { "LicenceId", "OrganizationId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "OrganizationLicences",
                keyColumns: new[] { "LicenceId", "OrganizationId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "OrganizationLicences",
                keyColumns: new[] { "LicenceId", "OrganizationId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "OrganizationLicences",
                keyColumns: new[] { "LicenceId", "OrganizationId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "OrganizationRoleHierarchies",
                keyColumns: new[] { "OrganizationId", "RoleHierarchyId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "OrganizationRoleHierarchies",
                keyColumns: new[] { "OrganizationId", "RoleHierarchyId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "OrganizationRoleHierarchies",
                keyColumns: new[] { "OrganizationId", "RoleHierarchyId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "OrganizationRoleHierarchies",
                keyColumns: new[] { "OrganizationId", "RoleHierarchyId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "OrganizationRoleHierarchies",
                keyColumns: new[] { "OrganizationId", "RoleHierarchyId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "OrganizationRoleHierarchies",
                keyColumns: new[] { "OrganizationId", "RoleHierarchyId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Licences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Licences",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Licences",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RelationShips",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
