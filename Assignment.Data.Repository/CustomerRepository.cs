using AssignmentApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;

namespace AssignmentApp.Data.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        ADbContext db;
        public CustomerRepository()
        {
            db = new ADbContext();
        }
        public int Delete(int id)
        {
            using(IDbConnection conn = db.GetDataConnection())
            {
                try
                {

                    return conn.Execute("Delete From Customer where Id = @CId", new { @CId = id });

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

        public IEnumerable<Customer> GetAll()
        {
            string query = @"Select c.CName, c.Address,c.Phone, c.Email, c.CheckIn, c.TotalPersons, c.BookingDays, c.Advance, r.Id From Customer c Join Room r on c.RoomNo = r.Id";
            using(IDbConnection conn = db.GetDataConnection())
            {
                try
                {

                    return conn.Query<Customer, Room, Customer>(query, (c, r) => { c.Room = r; return c; });

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
        /*public IEnumerable<Customer> GetWithService()
        {
            string query = @"select * from customer c 
                            join Room r on r.Id = c.RoomNo
                            join Service  s on s.RoomNo = r.Id
                            where serviceDate >= c.CheckIn  AND ServiceDate <= c.CheckIn + + c.BookingDays
                            ";
            using (IDbConnection conn = db.GetDataConnection())
            {
                try
                {

                    return conn.Query<Customer, Room, Service,Customer>(query, (c, r, s) => { c.Room = r; s.Room = r; return c; });

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

        }*/

        public int Insert(Customer item)
        {
            using(IDbConnection conn = db.GetDataConnection())
            {
                try
                {

                    //return the number of rows affected
                    return conn.Execute("Insert Into Customer Values(@CName, @Address,@Phone, @Email, @CheckIn, @TotalPersons, @BookingDays, @Advance, @RoomNo)",
                        new { @CName = item.CName, @Address = item.Address, 
                              @Phone = item.Phone, @Email = item.Email, @CheckIn = item.CheckIn, 
                              @TotalPersons = item.TotalPersons, @BookingDays = item.BookingDays, @Advance = item.Advance, 
                              @RoomNo = item.Room.Id });

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            return 0;
            
        }

        public int Update(Customer item)
        {
            using(IDbConnection conn = db.GetDataConnection())
            {
                try
                {

                    return conn.Execute("Update Customer Set CName =  @CName, Address = @Address, Phone = @Phone, Email = @Email, " +
                        "CheckIn = @CheckIn, TotalPersons = @TotalPersons, BookingDays = @BookingDays, Advance = @Advance Where Id = @Id",
                        new
                        {
                            @CName = item.CName,
                            @Address = item.Address,
                            @Phone = item.Phone,
                            @Email = item.Email,
                            @CheckIn = item.CheckIn,
                            @TotalPersons = item.TotalPersons,
                            @BookingDays = item.BookingDays,
                            @Advance = item.Advance,
                            @RoomNo = item.Room.Id
                        });

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
