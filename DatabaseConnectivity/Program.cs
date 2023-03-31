using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace DBconnection
{
    internal class Program
    {
        static string ConnectionString = "Data Source=DESKTOP-JUTNFOA\\SQL2022;Database=db_hr_sibkm;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        static void Main(string[] args)
        {
            //InsertRegion("Polar");
            //DeleteRegion(6);
            //UpdateRegion(name: "Australia", id: 7);
            try { GetAllRegion(); } catch (Exception ex) { Console.WriteLine(ex.Message); }

            GetRegion(9);
        }

        public static void GetAllRegion()
        {
            using (connection = new SqlConnection(ConnectionString))
            {

                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM region";

                //Membuka koneksi
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Id: " + reader[0]);
                            Console.WriteLine("Name: " + reader[1]);
                            Console.WriteLine("====================");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data not found!");
                    }
                    reader.Close();
                }
                connection.Close();
            }
        }

        public static void GetRegion(int id)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM region WHERE id = @id";
                command.Parameters.Add(new SqlParameter("id", id));

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Region with ID {id} is {reader[1]}");
                        }
                    } else
                    {
                        Console.WriteLine("Data not found");
                    }
                    reader.Close();
                }
                connection.Close();
            }
        }
        public static void InsertRegion(string name)
        {
            connection = new SqlConnection(ConnectionString);

            //Membuka koneksi
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO region (name) VALUES (@name)";
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                //Menambahkan parameter ke command
                command.Parameters.Add(pName);

                //Menjalankan command
                int result = command.ExecuteNonQuery();
                transaction.Commit();

                if (result > 0)
                {
                    Console.WriteLine("Data berhasil ditambahkan!");
                }
                else
                {
                    Console.WriteLine("Data gagal ditambahkan!");
                }

                //Menutup koneksi
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }

        }
        //Update Region
        public static void UpdateRegion(int id, string name)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction= transaction;

                try
                {
                    command.CommandText = "UPDATE region SET name = @name WHERE id = @id";
                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@id", id));

                    int result = command.ExecuteNonQuery();
                    transaction.Commit();
                    if (result > 0)
                    {
                        Console.WriteLine("Data berhasil diubah");
                    } else
                    {
                        Console.WriteLine("Data gagal diubah");
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    try
                    {
                        transaction.Rollback();
                    } catch ( Exception rollback)
                    {
                        Console.WriteLine(rollback.Message);
                    }
                } finally
                {
                    connection.Close();
                }
            }
        }

        //Delete Region
        public static void DeleteRegion(int id)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM region WHERE id = @id";
                    command.Transaction = transaction;
                    command.Parameters.Add(new SqlParameter("id", id));

                    int result = command.ExecuteNonQuery();
                    transaction.Commit();
                    if (result > 0)
                    {
                        Console.WriteLine("Data berhasil dihapus");
                    } else
                    {
                        Console.WriteLine("Data gagal dihapus");
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    try
                    {
                        transaction.Rollback();
                    } catch (Exception rollback)
                    {
                        Console.WriteLine(rollback.Message);
                    }
                } finally
                {
                    connection.Close();
                }
            }
        }
    }
}