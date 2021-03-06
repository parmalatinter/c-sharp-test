using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleAppTest.pg.model
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class MovieMap : EntityTypeConfiguration<Movie>
    {
        public MovieMap()
        {
            this.ToTable("Movie");
            this.HasKey(Movie => Movie.Id);
            this.Property(Movie => Movie.Name);
        }
    }
}
