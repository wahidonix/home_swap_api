﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace homeswapapi.Migrations
{
    /// <inheritdoc />
    public partial class DateBlocked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateBlocked",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBlocked",
                table: "Users");
        }
    }
}
