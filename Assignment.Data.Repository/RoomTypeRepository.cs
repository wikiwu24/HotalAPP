using AssignmentApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace AssignmentApp.Data.Repository
{
    public class RoomTypeRepository : IRepository<RoomType>
    {
        ADbContext db;
        public RoomTypeRepository()
        {
            db = new ADbContext();
        }
        public int Delete(int id)
        {
            using(IDbConnection conn = db.GetDataConnection())
            {
                try
                {

                    return conn.Execute("Delete From RoomType where Id = @RId", new { @RId = id });

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
            
            return 0;
        }

        public IEnumerable<RoomType> GetAll()
        {
            
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {
                    return conn.Query<RoomType>("Select Id, RTDESC, Rent From RoomType");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }

            }

            return null;

        }

        public int Insert(RoomType item)
        {
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {

                    //return the number of rows affected
                    return conn.Execute("Insert Into RoomType Values(@RTDESC, @Rent)", item);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();

                }

            }

            return 0;

        }

        public int Update(RoomType item)
        {
            using(IDbConnection conn = db.GetDataConnection())
            {
                try
                {

                    return conn.Execute("Update RoomType Set RTDESC = @RTDESC, Rent = @Rent Where Id = @Id", item);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            
            return 0;

        }
    }
}
