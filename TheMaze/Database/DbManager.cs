/**
 * 
 *  Class managing the SQLite Database
 *  used for persisting data collected from the Maze API
 * 
 */ 

using System;
using System.IO;
using System.Linq;
using TheMaze.Containers;

namespace TheMaze.Database
{
    public class DBManager : ISQLiteDB
    {
        public DBManager()
        {
        }

        /// <summary>
        /// Deletes the physical database flatfile
        /// </summary>
        /// <returns></returns>
        public bool deleteDatabase()
        {
            var result = true;
            string dbName = AppConst.DB_NAME;

            try
            {
                if (File.Exists(dbName))
                {
                    File.Delete(dbName);
                }
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }


        public void echoData()
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.Database.EnsureCreated();
                if (!dbContext.Blogs.Any())
                {
                    dbContext.Blogs.AddRange(new Blog[]
                        {
                             new Blog{ BlogId=1, Title="Blog 1", SubTitle="Blog 1 subtitle" },
                             new Blog{ BlogId=2, Title="Blog 2", SubTitle="Blog 2 subtitle" },
                             new Blog{ BlogId=3, Title="Blog 3", SubTitle="Blog 3 subtitle" }
                        });
                    dbContext.SaveChanges();
                }
                foreach (var blog in dbContext.Blogs)
                {
                    Console.WriteLine($"BlogID={blog.BlogId}\tTitle={blog.Title}\t{blog.SubTitle}\tDateTimeAdd={blog.DateTimeAdd}");
                }
            }
        }

    }
}
