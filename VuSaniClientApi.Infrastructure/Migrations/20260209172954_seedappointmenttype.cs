using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedappointmenttype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RenewedFromId",
                schema: "Structuralrole",
                table: "HseAppointment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "Structuralrole",
                table: "HseAppointment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "PendingAcceptance");

            migrationBuilder.InsertData(
                schema: "Structuralrole",
                table: "AppointmentType",
                columns: new[] { "Id", "Applicable", "Assignment", "CreatedAt", "CreatedBy", "Designated", "Name", "UniqueId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "<p>OHSAct, Section 16 (1)</p>", "<p>In accordance with section 16 (1) of the Occupational Health and Safety Act, (85 of 1993), you are hereby charged with ensuring in as far as it is reasonably practicable that the duties of the employer as contemplated in the OHSAct, are properly discharged.</p>", new DateTime(2025, 8, 11, 10, 3, 18, 0, DateTimeKind.Unspecified), 1, "<p>a) Ensuring that the provisions of the OHS Act are implemented and that all duties imposed by the Act and any relevant regulation(s) are complied with. b) Ensure that provisions of the Act and any or all relevant regulation(s) are complied with within Organisation c) Report directly to the Board with regard to these duties. d) Report all instances of non-compliance within the provisions of the Act to the Organisation Board</p>", "Section 16 (1)", "H&HG/SKI/2425/0001", new DateTime(2025, 8, 11, 10, 3, 18, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "<p>OHSAct, Section 16 (2)</p>", "<p>In accordance with section 16 (2) of the Occupational Health and Safety Act (85 of 1993), you are hereby assigned to assist the GCE, the 16(1) appointee, in the discharge of his duties as outlined in the OHSAct.</p>", new DateTime(2025, 8, 11, 10, 3, 18, 0, DateTimeKind.Unspecified), 1, "<p>a) Ensuring that the provisions of the OHS Act are implemented and that all duties imposed by the Act and any relevant regulation(s) are complied with. b) Ensure that provisions of the Act and any or all relevant regulation(s) are complied with within Organisation c) Report directly to the 16 (1) with regard to these duties. d) Report all instances of non-compliance with the provisions of the Act to the Organisation 16 (1) if not in a position to rectify these instances of non-compliance yourself.</p>", "Section 16 (2)", "H&HG/SKI/2425/0002", new DateTime(2025, 8, 11, 10, 3, 18, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "<p>General Machinery Regulation 2(1)</p>", "<p>In accordance with General Machinery Regulation 2(1) of the Occupational Health and Safety Act (85 of 1993), you are hereby designated as Supervisor for Machinery, as indicated hereunder:</p>", new DateTime(2025, 8, 11, 10, 3, 18, 0, DateTimeKind.Unspecified), 1, "<p>a) Ensure that the provisions of the Act and associated Regulations with regard to machinery are complied with; b) Familiarise yourself with the provisions of the Act and Regulations; c) Implement a preventive maintenance programme aimed at ensuring the safe and continued operability of all machinery; d) Ensure that the required documentation of the above system is maintained and available; e) Ensure compliance to the company’s health and safety requirements that relate to machinery, such as lock-out, confined space entry, equipment inspections, operator training, machine guarding, hazard identification and risk assessment; f) Ensure that adequate systems are implemented to reduce incidents related to the use of machinery; g) Ensure that all significant activities are carried out in line with Organisation standards, objectives, strategies and management plans; h) Implement and monitor business area's management plans and targets; i) Make representation to the employer on general matters affecting the physical environment as well as the health and safety of employees at their area of designation; j) Conduct and chair your applicable SHE Committee Meetings and sign off minutes; k) Assist during investigations of incidents, as contemplated in Section 18 of the OHSAct as amended; l) Act as committee member for Section 24 incidents and Level 1 and 2 incidents according to the BOI Policy within your business and endorse all incident investigation findings; m) You are further authorised to effect appointments in terms of the OHS Act, i.e. GMR 2 (7), SHE Reps, First Aiders, etc. to ensure compliance in your area of jurisdiction; n) Embed the BCM policy in your area of responsibility; o) Oversee and guide the implementation of the BCP's; p) Ensure that Business Continuity Management Plans are developed, implemented, maintained and tested; q) Identify, evaluate and review departmental Business Continuity Management risks; r) Escalate significant BCM risks to the relevant governance structures; s) Provide feedback to your department with regards to the developments in BCM;</p>", "General Machinery Regulation (GMR) (2) 1", "H&HG/SKI/2425/0003", new DateTime(2025, 8, 11, 10, 3, 18, 0, DateTimeKind.Unspecified), 1 },
                    { 4, "General Machinery Regulation 2(7)", "In accordance with General Machinery Regulation 2(1) of the Occupational Health and Safety Act (85 of 1993), you are hereby designated as Assistant to the Supervisor for Machinery, as indicated hereunder: ", new DateTime(2025, 8, 11, 10, 3, 18, 0, DateTimeKind.Unspecified), 1, "a) Ensure that the provisions of the Act and Regulations with regard to machinery are complied with;\r\nb) Familiarise yourself with the provisions of the Act and Regulations;\r\nc) Implement a preventive maintenance programme aimed at ensuring the safety and continued operability of all machinery;\r\nd) Ensure that the required documentation of the above system is maintained and available;\r\ne) Ensure compliance to the company’s health and safety requirements that relate to machinery, such as lock-out, confined space entry, equipment inspections, operator training, machine guarding and hazard identification and risk assessment;\r\nf) Ensure that adequate systems are implemented to reduce incidents related to the use of machinery.", "GMR (2) 7", "H&HG/SKI/2425/0004", new DateTime(2025, 8, 11, 10, 3, 18, 0, DateTimeKind.Unspecified), null },
                    { 5, "<p>Section 9(3) and General Safety Regulation 8 of OHSAct</p>", "<p>As an appointed IMS Operational Co-ordinator, and without derogating from my overall responsibility or liability, I hereby assign you as a Supervisor in terms of Section 19(3) and General Safety Regulation (GSR) 8 of the Occupational Health and Safety Act 85 of 1993 (hereinafter referred to as the Act).</p>", new DateTime(2025, 8, 11, 10, 3, 18, 0, DateTimeKind.Unspecified), 1, "<p>a) Ensure that all inspections take place on a monthly basis and immediately attend to deviations on SHE Representative reports; b) Attend regulated Safety, Health and Environmental Committee meetings; c) Complete monthly report for the SHE meetings; d) Conduct Plan Job Observations as per the outlined procedure and schedule where applicable; e) Act as Committee Member during investigation of incidents; f) Create employee awareness on safety, health and environmental instructions and standards; g) Compliance to the OHS Act, with particular regard to section 8 and 37(1); h) Familiarise himself/herself with the said GSR (8); i) Regularly inspect all the stacking in respective sections to ensure that it adheres to GSR (8); j) Ensure that flammable liquids, gas cylinders, and chemicals are stored safely, and report any unsafe stacking to the allocated SHE Committee; k) Always maintain good housekeeping within your area of responsibility; l) Ensure that any employee under their direct control carry out work in a safe and environmentally friendly manner having due regard to him / her self and that of other employees; m) All equipment at the work site is safe for use and fit for purpose; n) All employees are fully trained to operate the equipment which they are to use to carry out their duties; o) Render assistance to the SHE Representative with respect to his / her monthly inspections as well as investigation into any accident or incident that may have occurred within that particular section; p) Reporting and recording of all accidents and near misses in the appropriate format and submission to relevant department(s); q) Conduct Toolbox Talks at least once a week. Each talk is to be on a subject relevant to that section and the work carried out therein; r) All work projects are properly planned and a formal risk assessment is undertaken, if not already in place; s) Communicate work procedures / instructions / risk assessments to those under their span of control and who are required to undertake the work.</p>", "Supervisor Appointment", "H&HG/SKI/2425/0005", new DateTime(2025, 8, 11, 10, 3, 18, 0, DateTimeKind.Unspecified), 1 },
                    { 6, "<p>Section 17 of the OHSAct</p>", "<p>In accordance with Section (s) 17, 18 and 19 of the Occupational Health and Safety Act, 1993 (Act 85 of 1993), you are hereby designated as Safety, Health and Environmental Representative and member of the relevant Safety, Health and Environmental Committee, as indicated hereunder:</p>", new DateTime(2025, 8, 11, 10, 3, 18, 0, DateTimeKind.Unspecified), 1, "<p>a) Review the effectiveness of safety, health and environmental measures; b) Identify potential hazards and potential major incidents at the workplace; c) In collaboration with his employer, examine the causes of incidents at a workplace; d) Investigate complaints by any employee relating to that employee’s health or safety at work; e) Be a member of the allocated SHE Committee and attend all arranged meetings thereof; f) Make representation to the employer or a SHE Committee on matters arising from above or to an inspector where such representations are unsuccessful; g) Make representations to the employer on general matters affecting the health and/or safety of employees at the workplace; h) Inspect the workplace, including any article, substance, plant, machinery or piece of health and safety equipment at that workplace with a view to the health and safety of employees at such intervals as may be agreed upon with the employer; i) Participate in consultation with inspectors and accompany inspectors on inspections of the workplace; j) In his/her capacity as a SHE Representative attend SHE Committee meetings of which he/she is a member, in connection with the above functions; k) Visit a site of incident at all reasonable times and attend relevant inspections; l) Attend any investigation or formal inquiry held in terms of the Act; m) In so far as is reasonably necessary for performing his/her functions, inspect any document which the employer is required to keep in terms of the Act; n) Participate in any internal Safety, Health and Environmental audit(s)</p>", "SHE Representative", "H&HG/SKI/2425/0006", new DateTime(2025, 8, 11, 10, 3, 18, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6656), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6657) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6662), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6664) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6668), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6669) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6672), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6673) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6677), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6678) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(9530), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(9518), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(9517), "fo8+TI7DHVbrQju2O/M+z+7WL8o8aEuRwaY=", new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(9532) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Structuralrole",
                table: "AppointmentType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Structuralrole",
                table: "AppointmentType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Structuralrole",
                table: "AppointmentType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Structuralrole",
                table: "AppointmentType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Structuralrole",
                table: "AppointmentType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Structuralrole",
                table: "AppointmentType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "RenewedFromId",
                schema: "Structuralrole",
                table: "HseAppointment");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Structuralrole",
                table: "HseAppointment");

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2249), new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2250) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2253), new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2254) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2257), new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2257) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2260), new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2261) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2263), new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2264) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 3, 46, 955, DateTimeKind.Utc).AddTicks(4093), new DateTime(2026, 2, 9, 15, 3, 46, 955, DateTimeKind.Utc).AddTicks(4083), new DateTime(2026, 2, 9, 15, 3, 46, 955, DateTimeKind.Utc).AddTicks(4082), "6k9kxq0qaXl7JMSefY5nWtrxKOmuCPrO", new DateTime(2026, 2, 9, 15, 3, 46, 955, DateTimeKind.Utc).AddTicks(4094) });
        }
    }
}
