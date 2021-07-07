//
//   Written by Patrik Forsberg 2021 <patrik.forsberg@coldmind.com>
//   This file is part of the TvMaze Work Sample Project
//

using System;
using System.IO;
using System.Linq;
using TvMazeWebApp.DataProvider.Types;

namespace TvMazeWebApp.Database
{
    public class DbManager : ISQLiteDB
    {
        /// <summary>
        ///     Deletes the physical database flatfile
        /// </summary>
        /// <returns></returns>
        public bool deleteDatabase()
        {
            var result = true;
            var dbName = AppConst.DB_NAME;

            try
            {
                if (File.Exists(dbName)) File.Delete(dbName);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }


        public void EchoData()
        {
            /*
            using (var dbContext = new MyDbContext())
            {
                dbContext.Database.EnsureCreated();
                if (!dbContext.Blogs.Any())
                {
                    dbContext.Blogs.AddRange(new CastMember() { = 1, Title = "Blog 1", SubTitle = "Blog 1 subtitle"},
                        new Blog {BlogId = 2, Title = "Blog 2", SubTitle = "Blog 2 subtitle"},
                        new Blog {BlogId = 3, Title = "Blog 3", SubTitle = "Blog 3 subtitle"});
                    dbContext.SaveChanges();
                }

                foreach (var blog in dbContext.Blogs)
                    Console.WriteLine(
                        $"BlogID={blog.BlogId}\tTitle={blog.Title}\t{blog.SubTitle}\tDateTimeAdd={blog.DateTimeAdd}");
            }
            */
        }
    }
}