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

            // Obtener todos los clientes
            public IEnumerable<Customer> GetAll()
            {
                var list = new List<Customer>();

                using (var cn = Db.Open())
                using (var cmd = new SqlCommand("SELECT IdCustomer, NameCustomer, LastCustomer, IdentifyCustomer, AddressCustomer, PhoneCustomer, IdWorker FROM Customer", cn))
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
                            IdWorker = rd["IdWorker"] == DBNull.Value ? null : (int?)Convert.ToInt32(rd["IdWorker"])
                        });
                    }
                }

                return list;
            }

            // Buscar clientes por filtro
            public IEnumerable<Customer> Search(string filtro)
            {
                var list = new List<Customer>();

                using (var cn = Db.Open())
                using (var cmd = new SqlCommand(@"
            SELECT IdCustomer, NameCustomer, LastCustomer, IdentifyCustomer, AddressCustomer, PhoneCustomer, IdWorker
            FROM Customer
            WHERE NameCustomer LIKE @filtro 
               OR LastCustomer LIKE @filtro
               OR IdentifyCustomer LIKE @filtro", cn))
                {
                    cmd.Parameters.AddWithValue("@filtro", $"%{filtro}%");

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
                                IdWorker = rd["IdWorker"] == DBNull.Value ? null : (int?)Convert.ToInt32(rd["IdWorker"])
                            });
                        }
                    }
                }

                return list;
            }

            // Obtener cliente por Id
            public Customer Get(int id)
            {
                Customer customer = null;

                using (var cn = Db.Open())
                using (var cmd = new SqlCommand("SELECT IdCustomer, NameCustomer, LastCustomer, IdentifyCustomer, AddressCustomer, PhoneCustomer, IdWorker FROM Customer WHERE IdCustomer = @id", cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            customer = new Customer
                            {
                                IdCustomer = (int)rd["IdCustomer"],
                                NameCustomer = rd["NameCustomer"].ToString(),
                                LastCustomer = rd["LastCustomer"].ToString(),
                                IdentifyCustomer = rd["IdentifyCustomer"].ToString(),
                                AddressCustomer = rd["AddressCustomer"].ToString(),
                                PhoneCustomer = rd["PhoneCustomer"].ToString(),
                                IdWorker = rd["IdWorker"] == DBNull.Value ? null : (int?)Convert.ToInt32(rd["IdWorker"])
                            };
                        }
                    }
                }

                return customer;
            }

        // Agregar cliente
        public int Add(Customer customer)
        {
            using (var cn = Db.Open())
            using (var cmd = new SqlCommand(@"
        INSERT INTO Customer (NameCustomer, LastCustomer, IdentifyCustomer, AddressCustomer, PhoneCustomer, IdWorker)
        OUTPUT INSERTED.IdCustomer
        VALUES (@NameCustomer, @LastCustomer, @IdentifyCustomer, @AddressCustomer, @PhoneCustomer, @IdWorker)", cn))
            {
                cmd.Parameters.AddWithValue("@NameCustomer", customer.NameCustomer);
                cmd.Parameters.AddWithValue("@LastCustomer", customer.LastCustomer);
                cmd.Parameters.AddWithValue("@IdentifyCustomer", customer.IdentifyCustomer);
                cmd.Parameters.AddWithValue("@AddressCustomer", customer.AddressCustomer);
                cmd.Parameters.AddWithValue("@PhoneCustomer", customer.PhoneCustomer);
                cmd.Parameters.AddWithValue("@IdWorker", customer.IdWorker ?? (object)DBNull.Value);

                return (int)cmd.ExecuteScalar();
            }
        }

        // Editar cliente
        public void Update(Customer c)
            {
                using (var cn = Db.Open())
                using (var cmd = new SqlCommand(@"
            UPDATE Customer
            SET NameCustomer = @name,
                LastCustomer = @last,
                IdentifyCustomer = @ident,
                AddressCustomer = @addr,
                PhoneCustomer = @phone,
                IdWorker = @worker
            WHERE IdCustomer = @id", cn))
                {
                    cmd.Parameters.AddWithValue("@id", c.IdCustomer);
                    cmd.Parameters.AddWithValue("@name", c.NameCustomer);
                    cmd.Parameters.AddWithValue("@last", c.LastCustomer);
                    cmd.Parameters.AddWithValue("@ident", c.IdentifyCustomer);
                    cmd.Parameters.AddWithValue("@addr", c.AddressCustomer);
                    cmd.Parameters.AddWithValue("@phone", c.PhoneCustomer);
                    cmd.Parameters.AddWithValue("@worker", c.IdWorker != null ? (object)c.IdWorker : DBNull.Value);


                cmd.ExecuteNonQuery();
                }
            }
        }
    }
