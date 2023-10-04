using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BlazorPractice.Data
{
    public class ChatMessage
    {
        [Key]
        public int MessageID { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class ChatDbContext : DbContext
    {
        public DbSet<ChatMessage> ChatMessages { get; set; }

        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
        }
    }
}