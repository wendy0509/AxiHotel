using AxiHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiHotel.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public int Add(Customer c)
        {
            using (var cn = Db.Open())
            {
                var cmd = new SqlCommand(@"
              INSERT INTO Customer(NameCustomer,LastCustomer,IdentifyCustomer,AddressCustomer,PhoneCustomer,IdWorker)
              OUTPUT INSERTED.IdCustomer
              VALUES(@n,@l,@i,@a,@p,@w)", cn);

                cmd.Parameters.AddWithValue("@n", c.NameCustomer);
                cmd.Parameters.AddWithValue("@l", c.LastCustomer);
                cmd.Parameters.AddWithValue("@i", c.IdentifyCustomer);
                cmd.Parameters.AddWithValue("@a", c.AddressCustomer ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@p", c.PhoneCustomer ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@w", c.IdWorker);

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update(Customer c)
        {
            using (var cn = Db.Open())
            {
                var cmd = new SqlCommand(@"
              UPDATE Customer SET NameCustomer=@n, LastCustomer=@l, IdentifyCustomer=@i,
              AddressCustomer=@a, PhoneCustomer=@p
              WHERE IdCustomer=@id", cn);

                cmd.Parameters.AddWithValue("@id", c.IdCustomer);
                cmd.Parameters.AddWithValue("@n", c.NameCustomer);
                cmd.Parameters.AddWithValue("@l", c.LastCustomer);
                cmd.Parameters.AddWithValue("@i", c.IdentifyCustomer);
                cmd.Parameters.AddWithValue("@a", c.AddressCustomer ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@p", c.PhoneCustomer ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Customer> Search(string text)
        {
            var list = new List<Customer>();

            using (var cn = Db.Open())
            {
                var cmd = new SqlCommand(@"
              SELECT TOP 200 * FROM Customer
              WHERE @t = '' OR NameCustomer LIKE '%'+@t+'%'
                 OR LastCustomer LIKE '%'+@t+'%'
                 OR IdentifyCustomer LIKE '%'+@t+'%'
                 OR PhoneCustomer LIKE '%'+@t+'%'", cn);

                cmd.Parameters.AddWithValue("@t", text ?? "");

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Customer
                        {
                            IdCustomer = (int)rd["IdCustomer"],
                            NameCustomer = rd["NameCustomer"].ToString(),
                            LastCustomer = rd["LastCustomer"].ToString(),
                            IdentifyCustomer = rd["IdentifyCustomer"].ToString(),
                            AddressCustomer = rd["AddressCustomer"].ToString(),
                            PhoneCustomer = rd["PhoneCustomer"].ToString(),
                            IdWorker = (int)rd["IdWorker"]
                        });
                    }
                }
            }

            return list;
        }

        // Implementación del método opcional SetTag
        public void SetTag(int idCustomer, string tag)
        {
            using (var cn = Db.Open())
            {
                var cmd = new SqlCommand(@"
              UPDATE Customer
              SET AddressCustomer = ISNULL(AddressCustomer,'') + ' [' + @tag + ']'
              WHERE IdCustomer = @id", cn);

                cmd.Parameters.AddWithValue("@id", idCustomer);
                cmd.Parameters.AddWithValue("@tag", tag ?? "");

                cmd.ExecuteNonQuery();
            }
        }

    }
}
