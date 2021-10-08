using AssignmentApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace AssignmentApp.Data.Repository
{
    public class RoomRepository : IRepository<Room>
    {
        ADbContext db;
        public RoomRepository()
        {
            db = new ADbContext();
        }
        public int Delete(int id)
        {
            try
            {
                IDbConnection conn = db.GetDataConnection();
                return conn.Execute("Delete From Room where Id = @RId", new { @RId = id });

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }

        public IEnumerable<Room> GetAll()
        {
            string query = @"Select r.Id, rt.Id, r.Status From Room r Join RoomType rt on rt.Id = r.RTCODE";
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {
                    return conn.Query<Room, RoomType, Room>(query, (r, rt) => { r.RoomType = rt; return r; });
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

        public int Insert(Room item)
        {
           using(IDbConnection conn = db.GetDataConnection())
            {
                try
                {
                    //return the number of rows affected
                    return conn.Execute("Insert Into Room(RTCODE, Status) Values(@RTCODE, @Status)", new {@RTCODE = item.RoomType.Id, @Status = item.Status});

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

        public int Update(Room item)
        {
            try
            {
                IDbConnection conn = db.GetDataConnection();
                return conn.Execute("Update Room Set RTCODE = @RTCODE, Status = @Status Where Id = @Id", new { @RTCODE = item.RoomType.Id, @Status = item.Status, @Id = item.Id});

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;

        }
        
    }
}
