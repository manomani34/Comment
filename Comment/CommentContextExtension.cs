using Comment.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comment
{
    public static class CommentContextExtension
    {
        public static void EnsureSeedDataForContext(this CommentContext context)
        {
            if (context.users.Any())
            {
                return;
            }

            var users = new List<User>()
            {
                new User()
                {
                    FirstName= "Ali",
                    LastName = "Baheri",
                    Email = "baheri@gmail.com",
                    Commnets = new List<Commnet>()
                    {
                        new Commnet()
                        {
                            Title = "Micanich",
                            Description = "i'm in america and i'm good!"
                        },
                        new Commnet()
                        {
                            Title = "Technical Ciense",
                            Description = "i'm Michanic Student"
                        }
                    }
                },
                new User()
                {
                    FirstName= "Mohammad",
                    LastName = "Ashabi",
                    Email = "ashabi@gmail.com",
                    Commnets = new List<Commnet>()
                    {
                        new Commnet()
                        {
                            Title = "Chenistry",
                            Description = "i'm in Iran and in Beheshti Uc i'm good!"
                        },
                        new Commnet()
                        {
                            Title = "Pruposal",
                            Description = "i'm Chemistry Student"
                        },
                         new Commnet()
                        {
                            Title = "Hi!",
                            Description = "i'm heare"
                        }
                    }
                }
            };

            context.users.AddRange(users);
            context.SaveChanges();
        }
    }
}
