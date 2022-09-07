using Microsoft.EntityFrameworkCore;

namespace Blue_it.Data
{
    public static class CommentRepository
    {
        public async static Task<List<Comment>> GetCommentsForAnswerAsync(int answerId)
        {
            using (var db = new AppDbContext())
            {
                return await db.Comments.Where(comment => comment.AnswerId == answerId).ToListAsync();
            }
        }
        public async static Task<bool> AddNewCommentAsync(Comment comment)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    await db.Comments.AddAsync(comment);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        public async static Task<bool> UpdateCommentAsync(Comment commentToUpdate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.Comments.Update(commentToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        public async static Task<bool> DeleteCommentAsync(int commentId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    var commentToDelete = await db.Comments.FirstOrDefaultAsync(comment => comment.Id == commentId);
                    db.Remove(commentToDelete);
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
