using Microsoft.EntityFrameworkCore;

namespace Blue_it.Data
{
    public static class QuestionRepository
    {
        public async static Task<List<Question>> GetQuestionsAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.Questions!.ToListAsync();
            }
        }
        public async static Task<Question> GetQuestionByIdAsync(int questionId)
        {
            using (var db = new AppDbContext())
            {
                return await db.Questions.FirstOrDefaultAsync(question => question.Id == questionId);
            }
        }
        public async static Task<bool> AddNewQuestionAsync(Question newQuestion)
        {
            using(var db = new AppDbContext())
            {
                try
                {
                    await db.Questions.AddAsync(newQuestion);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }
        public async static Task<bool> UpdateQuestionAsync(Question questionToUpdate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.Questions.Update(questionToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        public async static Task<bool> DeleteQuestionAsync(int questionId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    var questionToDelete = db.Questions.FirstOrDefaultAsync(question => question.Id == questionId);
                    db.Remove(questionToDelete);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
