using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Npgsql.Lab.Migrations
{
    /// <inheritdoc />
    public partial class Func : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                CREATE OR REPLACE FUNCTION public.demo(
                    in_from_dt timestamp without time zone,
                    in_to_dt timestamp without time zone
                    )
                    RETURNS TABLE(id INTEGER, tid character varying(8)) 
                    LANGUAGE 'plpgsql'
                    COST 100
                    VOLATILE PARALLEL UNSAFE
                    ROWS 1000

                AS $BODY$
                BEGIN        
                    RETURN QUERY
                    SELECT c.id, c.tid 
                    FROM public.terminal as t;
                END;
                $BODY$;

                ALTER FUNCTION public.demo(in_from_dt timestamp without time zone, in_to_dt timestamp without time zone)
                    OWNER TO postgres;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                DROP FUNCTION IF EXISTS public.demo(in_from_dt timestamp without time zone, in_to_dt timestamp without time zone);
                """);
        }
    }
}
