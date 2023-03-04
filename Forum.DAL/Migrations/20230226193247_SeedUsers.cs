using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Forum.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReactionType",
                keyColumn: "Id",
                keyValue: new Guid("74373a5e-ef21-4b3c-8709-43ae482d7248"));

            migrationBuilder.DeleteData(
                table: "ReactionType",
                keyColumn: "Id",
                keyValue: new Guid("76822a43-7c7e-4bb6-80a9-888542bf185a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("21dc2fcd-17c3-49cf-862e-cd6ffbe9fd03"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8b6ac206-c7cd-49fb-9d3f-548063ceb469"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b3775d8e-62d2-4f82-8649-5192d90c804b"));

            migrationBuilder.InsertData(
                table: "ReactionType",
                columns: new[] { "Id", "Abrv", "DateCreated", "DateUpdated", "Name" },
                values: new object[,]
                {
                    { new Guid("2d5de9c7-99c5-4b93-8e9a-68aca3202af7"), "Downvote", new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9531), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9532), "Downvote" },
                    { new Guid("35814a70-dc96-4942-a911-d81e921b50ea"), "upvote", new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9528), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9529), "Upvote" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Abrv", "DateCreated", "DateUpdated", "Name" },
                values: new object[,]
                {
                    { new Guid("18812906-8a79-47a8-905e-d5ab1c98298a"), "admin", new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9450), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9451), "Admin" },
                    { new Guid("2ef7989e-5cf9-4553-b2c6-31f394299e54"), "super-admin", new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9453), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9454), "Super Admin" },
                    { new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "user", new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9456), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9456), "User" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("013837bb-026c-4384-9f45-4c405fc177a2"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9676), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9676), "danijel.jakovac8@gmail.com", "Danijel - 8", "Jakovac - 8", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel8" },
                    { new Guid("051c705a-6d66-42a9-8a34-d958a683f5a2"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9791), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9792), "danijel.jakovac23@gmail.com", "Danijel - 23", "Jakovac - 23", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel23" },
                    { new Guid("07ef98a0-bde6-4c7b-9886-026066b52610"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9812), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9812), "danijel.jakovac26@gmail.com", "Danijel - 26", "Jakovac - 26", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel26" },
                    { new Guid("081d8f14-6ade-423a-87cc-4c91d2159c28"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9829), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9829), "danijel.jakovac29@gmail.com", "Danijel - 29", "Jakovac - 29", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel29" },
                    { new Guid("1cf70561-7f91-4d88-80cf-cd6f52da6033"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9727), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9727), "danijel.jakovac16@gmail.com", "Danijel - 16", "Jakovac - 16", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel16" },
                    { new Guid("2f6b5645-0070-466f-9ad2-1875d2a7db32"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9689), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9690), "danijel.jakovac10@gmail.com", "Danijel - 10", "Jakovac - 10", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel10" },
                    { new Guid("3c2fa294-0ef1-46b2-85a2-15501a0751c5"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9660), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9660), "danijel.jakovac6@gmail.com", "Danijel - 6", "Jakovac - 6", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel6" },
                    { new Guid("41f43c69-b2b6-4ee6-891a-b5120358b6b4"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9623), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9623), "danijel.jakovac5@gmail.com", "Danijel - 5", "Jakovac - 5", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel5" },
                    { new Guid("44061739-451d-4ce9-b2ab-d2f6468b9ab2"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9616), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9616), "danijel.jakovac4@gmail.com", "Danijel - 4", "Jakovac - 4", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel4" },
                    { new Guid("49763c99-86c2-4d7f-9cdb-be01cd0638a4"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9609), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9609), "danijel.jakovac3@gmail.com", "Danijel - 3", "Jakovac - 3", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel3" },
                    { new Guid("4cc87730-7807-4c12-9597-e34b2f4ed617"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9746), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9746), "danijel.jakovac19@gmail.com", "Danijel - 19", "Jakovac - 19", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel19" },
                    { new Guid("58d87839-bbe6-4957-a271-d5e7f5ac6027"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9799), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9800), "danijel.jakovac24@gmail.com", "Danijel - 24", "Jakovac - 24", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel24" },
                    { new Guid("5d11ee27-e156-44bd-a0bd-7446fe46fccb"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9740), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9741), "danijel.jakovac18@gmail.com", "Danijel - 18", "Jakovac - 18", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel18" },
                    { new Guid("69dca97c-b245-4c9a-a306-89a875452e6a"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9568), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9569), "danijel.jakovac0@gmail.com", "Danijel - 0", "Jakovac - 0", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel0" },
                    { new Guid("73d1644a-29e9-4312-b66a-5a4ad3b807ce"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9708), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9709), "danijel.jakovac13@gmail.com", "Danijel - 13", "Jakovac - 13", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel13" },
                    { new Guid("8b775a51-ecb3-44e8-9817-c4b7ed1f45e4"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9667), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9667), "danijel.jakovac7@gmail.com", "Danijel - 7", "Jakovac - 7", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel7" },
                    { new Guid("9e3ca134-2008-4419-b8a5-4e39ac781dd6"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9817), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9818), "danijel.jakovac27@gmail.com", "Danijel - 27", "Jakovac - 27", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel27" },
                    { new Guid("bbfc9964-ccc5-435b-a77a-1742b9393f62"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9823), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9823), "danijel.jakovac28@gmail.com", "Danijel - 28", "Jakovac - 28", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel28" },
                    { new Guid("bef7064b-cd97-413f-9608-10b590c30115"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9702), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9702), "danijel.jakovac12@gmail.com", "Danijel - 12", "Jakovac - 12", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel12" },
                    { new Guid("c3bcad5c-3bc5-4626-90da-a2ae2b2b8de6"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9602), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9603), "danijel.jakovac2@gmail.com", "Danijel - 2", "Jakovac - 2", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel2" },
                    { new Guid("c5b66ea3-1775-4181-907a-54d0c5c51e79"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9734), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9734), "danijel.jakovac17@gmail.com", "Danijel - 17", "Jakovac - 17", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel17" },
                    { new Guid("c62de030-942f-47ec-a263-4fe39749961d"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9714), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9715), "danijel.jakovac14@gmail.com", "Danijel - 14", "Jakovac - 14", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel14" },
                    { new Guid("c98856dc-2601-4c3b-882b-fdab27863272"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9595), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9595), "danijel.jakovac1@gmail.com", "Danijel - 1", "Jakovac - 1", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel1" },
                    { new Guid("cc9dbd24-d0c7-4574-8415-e7494ca7bd7d"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9683), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9684), "danijel.jakovac9@gmail.com", "Danijel - 9", "Jakovac - 9", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel9" },
                    { new Guid("d2299741-0b59-4e29-956f-a945927403dc"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9720), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9720), "danijel.jakovac15@gmail.com", "Danijel - 15", "Jakovac - 15", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel15" },
                    { new Guid("de11cabe-c85b-4f11-bb64-36491b753769"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9696), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9696), "danijel.jakovac11@gmail.com", "Danijel - 11", "Jakovac - 11", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel11" },
                    { new Guid("dec336e1-4067-4828-b9eb-b1c8aded8d99"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9806), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9806), "danijel.jakovac25@gmail.com", "Danijel - 25", "Jakovac - 25", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel25" },
                    { new Guid("e8dcdcf9-770d-42be-b1c8-3396e33cd517"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9779), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9779), "danijel.jakovac21@gmail.com", "Danijel - 21", "Jakovac - 21", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel21" },
                    { new Guid("ec4d8faa-d15f-4815-a5ce-cbc79dcb919b"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9772), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9772), "danijel.jakovac20@gmail.com", "Danijel - 20", "Jakovac - 20", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel20" },
                    { new Guid("f83e1a89-041e-43d7-bf45-3d18b8372831"), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9785), new DateTime(2023, 2, 26, 19, 32, 47, 160, DateTimeKind.Utc).AddTicks(9786), "danijel.jakovac22@gmail.com", "Danijel - 22", "Jakovac - 22", "danijel123", new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"), "Danijel22" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReactionType",
                keyColumn: "Id",
                keyValue: new Guid("2d5de9c7-99c5-4b93-8e9a-68aca3202af7"));

            migrationBuilder.DeleteData(
                table: "ReactionType",
                keyColumn: "Id",
                keyValue: new Guid("35814a70-dc96-4942-a911-d81e921b50ea"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("18812906-8a79-47a8-905e-d5ab1c98298a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2ef7989e-5cf9-4553-b2c6-31f394299e54"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("013837bb-026c-4384-9f45-4c405fc177a2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("051c705a-6d66-42a9-8a34-d958a683f5a2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("07ef98a0-bde6-4c7b-9886-026066b52610"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("081d8f14-6ade-423a-87cc-4c91d2159c28"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1cf70561-7f91-4d88-80cf-cd6f52da6033"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2f6b5645-0070-466f-9ad2-1875d2a7db32"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3c2fa294-0ef1-46b2-85a2-15501a0751c5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("41f43c69-b2b6-4ee6-891a-b5120358b6b4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("44061739-451d-4ce9-b2ab-d2f6468b9ab2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("49763c99-86c2-4d7f-9cdb-be01cd0638a4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4cc87730-7807-4c12-9597-e34b2f4ed617"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("58d87839-bbe6-4957-a271-d5e7f5ac6027"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5d11ee27-e156-44bd-a0bd-7446fe46fccb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("69dca97c-b245-4c9a-a306-89a875452e6a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("73d1644a-29e9-4312-b66a-5a4ad3b807ce"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8b775a51-ecb3-44e8-9817-c4b7ed1f45e4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9e3ca134-2008-4419-b8a5-4e39ac781dd6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bbfc9964-ccc5-435b-a77a-1742b9393f62"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bef7064b-cd97-413f-9608-10b590c30115"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3bcad5c-3bc5-4626-90da-a2ae2b2b8de6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c5b66ea3-1775-4181-907a-54d0c5c51e79"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c62de030-942f-47ec-a263-4fe39749961d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c98856dc-2601-4c3b-882b-fdab27863272"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cc9dbd24-d0c7-4574-8415-e7494ca7bd7d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d2299741-0b59-4e29-956f-a945927403dc"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("de11cabe-c85b-4f11-bb64-36491b753769"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("dec336e1-4067-4828-b9eb-b1c8aded8d99"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e8dcdcf9-770d-42be-b1c8-3396e33cd517"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ec4d8faa-d15f-4815-a5ce-cbc79dcb919b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f83e1a89-041e-43d7-bf45-3d18b8372831"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d9f2cf76-cbb4-4191-9d14-3340416204ea"));

            migrationBuilder.InsertData(
                table: "ReactionType",
                columns: new[] { "Id", "Abrv", "DateCreated", "DateUpdated", "Name" },
                values: new object[,]
                {
                    { new Guid("74373a5e-ef21-4b3c-8709-43ae482d7248"), "upvote", new DateTime(2023, 2, 26, 11, 18, 39, 526, DateTimeKind.Utc).AddTicks(6661), new DateTime(2023, 2, 26, 11, 18, 39, 526, DateTimeKind.Utc).AddTicks(6661), "Upvote" },
                    { new Guid("76822a43-7c7e-4bb6-80a9-888542bf185a"), "Downvote", new DateTime(2023, 2, 26, 11, 18, 39, 526, DateTimeKind.Utc).AddTicks(6673), new DateTime(2023, 2, 26, 11, 18, 39, 526, DateTimeKind.Utc).AddTicks(6673), "Downvote" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Abrv", "DateCreated", "DateUpdated", "Name" },
                values: new object[,]
                {
                    { new Guid("21dc2fcd-17c3-49cf-862e-cd6ffbe9fd03"), "super-admin", new DateTime(2023, 2, 26, 11, 18, 39, 526, DateTimeKind.Utc).AddTicks(6590), new DateTime(2023, 2, 26, 11, 18, 39, 526, DateTimeKind.Utc).AddTicks(6590), "Super Admin" },
                    { new Guid("8b6ac206-c7cd-49fb-9d3f-548063ceb469"), "admin", new DateTime(2023, 2, 26, 11, 18, 39, 526, DateTimeKind.Utc).AddTicks(6587), new DateTime(2023, 2, 26, 11, 18, 39, 526, DateTimeKind.Utc).AddTicks(6588), "Admin" },
                    { new Guid("b3775d8e-62d2-4f82-8649-5192d90c804b"), "user", new DateTime(2023, 2, 26, 11, 18, 39, 526, DateTimeKind.Utc).AddTicks(6591), new DateTime(2023, 2, 26, 11, 18, 39, 526, DateTimeKind.Utc).AddTicks(6592), "User" }
                });
        }
    }
}
