using System.ComponentModel.DataAnnotations.Schema;

namespace Npgsql.Lab.Data;

[Table("terminal")]
public class Terminal
{
    [Column("id")]
    public int Id { get; set; }

    [Column("tid")]
    public string Tid { get; set; } = null!;
}
