using System.Data;
using System.Data.SqlClient;

namespace DBconnection
{
    internal class Program
    {
        static string ConnectionString = "Data Source=DESKTOP-JUTNFOA\\SQL2022;Database=db_hr_sibkm;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        static void Main(string[] args)
        {
            //InsertRegion("Polar"); //Menambahkan region baru dengan nama Polar
            //DeleteRegion(6); //Menghapus region dengan id 6
            //UpdateRegion(name: "Australia", id: 7); //Merubah nama region pada id 7 dengan nama Australia
            try { GetAllRegion(); } catch (Exception ex) { Console.WriteLine(ex.Message); } //Menampilkan semua region, jika gagal, menampilkan pesan gagal

            GetRegion(4); //Menampilkan region dengan id 4
        }

        public static void GetAllRegion()
        {
            using (connection = new SqlConnection(ConnectionString)) //Membuat koneksi
            {

                //Membuat instance untuk command
                SqlCommand command = new SqlCommand(); //membuat command
                command.Connection = connection; //command menggunakan koneksi connection
                command.CommandText = "SELECT * FROM region"; //perintah pada command

                //Membuka koneksi
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader()) //mengeksekusi command dan membuat sqlDataReader untuk membaca hasil command yang telah diberikan
                {
                    if (reader.HasRows) //jika hasil eksekusi memiliki hasil (baris)
                    {
                        while (reader.Read()) //melakukan print terhadap semua data hasil eksekusi
                        {
                            Console.WriteLine("Id: " + reader[0]); //print kolom 0 (id)
                            Console.WriteLine("Name: " + reader[1]); //print kolom 1 (name)
                            Console.WriteLine("====================");
                        }
                    }
                    else //jika tidak ada hasilnya
                    {
                        Console.WriteLine("Data not found!");
                    }
                    reader.Close(); //menutup objek reader
                }
                connection.Close(); //menutup koneksi
            }
        }

        public static void GetRegion(int id)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM region WHERE id = @id"; //perintah pada command dengan parameter
                command.Parameters.Add(new SqlParameter("id", id)); //menambahkan nilai parameter id

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

            SqlTransaction transaction = connection.BeginTransaction(); //memulai transaksi
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO region (name) VALUES (@name)";
                command.Transaction = transaction; //command menggunakan Transaction transaction

                //Membuat parameter
                SqlParameter pName = new SqlParameter(); //membuat parameter baru
                pName.ParameterName = "name"; //nama parameter "name"
                pName.Value = name; //dengan value variabel name
                pName.SqlDbType = SqlDbType.VarChar; //tipe nilai di db

                //Menambahkan parameter ke command
                command.Parameters.Add(pName); //menambahkan parameter ke command

                //Menjalankan command
                int result = command.ExecuteNonQuery(); //melakukan eksekusi
                transaction.Commit(); //akhir dari transaksi

                if (result > 0) //jika jumlah baris yang berubah lebih dari 0, yang berarti data berhasil ditambahkan
                {
                    Console.WriteLine("Data berhasil ditambahkan!");
                }
                else //jika data gagal ditambahkan
                {
                    Console.WriteLine("Data gagal ditambahkan!");
                }

                //Menutup koneksi
                connection.Close();

            }
            catch (Exception e) //menangkap exception yang terjadi
            {
                Console.WriteLine(e.Message);
                try
                {
                    transaction.Rollback(); //mencoba untuk melakukan rollback
                }
                catch (Exception rollback) //jika rollback gagal dilakukan
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
                    command.Parameters.Add(new SqlParameter("@name", name)); //menambahkan parameter name dengan nilai variabel name
                    command.Parameters.Add(new SqlParameter("@id", id)); //menambahkan parameter id dengan nilai variabel id

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