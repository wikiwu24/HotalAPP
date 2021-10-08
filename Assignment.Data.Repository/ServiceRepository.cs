using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AssignmentApp.Data.Model;
using Dapper;

namespace AssignmentApp.Data.Repository
{
    public class ServiceRepository : IRepository<Service>
    {
        ADbContext db;
        public ServiceRepository()
        {
            db = new ADbContext();
        }
        public int Delete(int id)
        {
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {

                    return conn.Execute("Delete From Service where Id = @SId", new { @SId = id });

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

        public IEnumerable<Service> GetAll()
        {
            string query = @"Select s.Id, s.SDESC,s.Amount,s.ServiceDate,r.Id From Service s Join Room r on r.Id = s.RoomNo";

            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {
                    return conn.Query<Service, Room, Service>(query, (s, r) => { s.Room = r; return s; }) ;
                   
        
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

        public int Insert(Service item)
        {
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {

                    //return the number of rows affected
                    return conn.Execute("Insert Into Service Values(@SDESC,@Amount,@ServiceDate,@RoomNo)", 
                        new { @SDESC = item.SDESC, @Amount = item.Amount, @ServiceDate = item.ServiceDate, @RoomNo = item.Room.Id});

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

        public int Update(Service item)
        {
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {

                    return conn.Execute("Update Service Set SDESC = @SDESC, Amount = @Amount, ServiceDate = @ServiceDate, " +
                        "RoomNo = @RoomNo Where Id = @Id", new {@Id = item.Id, @SDESC = item.SDESC, @Amount = item.Amount, @ServiceDate = item.ServiceDate, @RoomNo = item.Room.Id });

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
