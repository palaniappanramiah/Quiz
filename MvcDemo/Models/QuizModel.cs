using System.ComponentModel.DataAnnotations;
using System.Data.Entity; 

namespace MvcDemo.Models
{
    public class QuizModel
    {
        [Key]
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public string CorrectAnswer { get; set; }
    }

    public class QuizContext : DbContext
    {
        public DbSet<QuizModel> QuizModels { get; set; }
    } 
}