using Microsoft.EntityFrameworkCore;

namespace Blue_it.Data
{
    public static class AnswerRepository
    {
        public async static Task<List<Answer>> GetAnswersForQuestionAsync(int questionId)
        {
            using (var db = new AppDbContext())
            {
                return await db.Answers.Where(x => x.QuestionId == questionId).ToListAsync();
            } 
        }
        public async static Task<bool> AddNewAnswerAsync(Answer answer)
        {
            using(var db = new AppDbContext())
            {
                try
                {
                    await db.Answers.AddAsync(answer);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        public async static Task<bool> UpdateAnswerAsync(Answer answerToUpdate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.Answers.Update(answerToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        public async static Task<bool> DeleteAnswerAsync(int answerId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    var answerToDelete = await db.Answers.FirstOrDefaultAsync(answer => answer.Id == answerId);
                    db.Remove(answerToDelete);
                    return db.SaveChanges() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
