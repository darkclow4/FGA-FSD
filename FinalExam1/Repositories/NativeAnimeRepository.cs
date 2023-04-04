using Final_exam1.Interfaces;
using Final_exam1.Models;
using System.Data;
using System.Data.SqlClient;

namespace Final_exam1.Repositories
{
    class NativeAnimeRepository : IAnime
    {
        static string connectionString = "Data Source=DESKTOP-JUTNFOA\\SQL2022;Database=db_anime;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        public void Create(Anime animeRecord)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "INSERT INTO anime (title, release_date, rating, status_id, duration_minutes, type_id) VALUES (@title, @release_date, @rating, @status_id, @duration_minutes, @type_id)";
                    command.Parameters.Add(new SqlParameter("@title", animeRecord.Title));

                    if(animeRecord.Release_date != null )
                    {
                        SqlParameter pName = new SqlParameter();
                        pName.ParameterName = "@release_date";
                        pName.Value = animeRecord.Release_date?.ToDateTime(TimeOnly.MinValue);
                        pName.SqlDbType = SqlDbType.Date;
                        command.Parameters.Add(pName);
                    } else
                    {
                        command.Parameters.Add(new SqlParameter("@release_date", DBNull.Value));
                    }
                    
                    if(animeRecord.Rating != null )
                    {
                        command.Parameters.Add(new SqlParameter("@rating", Math.Round(animeRecord.Rating.Value, 2)));
                    } else
                    {
                        command.Parameters.Add(new SqlParameter("@rating", DBNull.Value));
                    }
                    if(animeRecord.Duration_minutes != null)
                    {
                        command.Parameters.Add(new SqlParameter("@duration_minutes", animeRecord.Duration_minutes));
                    } else
                    {
                        command.Parameters.Add(new SqlParameter("@duration_minutes", DBNull.Value));
                    }
                    command.Parameters.Add(new SqlParameter("@status_id", animeRecord.Status_id));
                    
                    command.Parameters.Add(new SqlParameter("@type_id", animeRecord.Type_id));

                    int result = command.ExecuteNonQuery();
                    transaction.Commit();
                    if (result > 0)
                    {
                        Console.WriteLine("\nSuccess add new record.");
                    }
                    else
                    {
                        Console.WriteLine("\nFail to add new record.");
                    }
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
                finally
                {
                    connection.Close();
                }
            }
        }
        public void Update() { }
        public void Delete() { }
        public List<Anime> ReadAll() {
            List<Anime> AnimeList = new List<Anime>();
            using (connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM anime";
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DateOnly? releaseDate = reader.IsDBNull(2) ? null : DateOnly.FromDateTime(reader.GetDateTime(2));
                            float? rating = reader.IsDBNull(3)? null : (float)reader.GetDouble(3);
                            int? duration = reader.IsDBNull(5) ? null : reader.GetInt32(5);
                            Anime animeRecord = new Anime(
                                reader.GetString(1),
                                (int)reader.GetByte(4),
                                reader.GetInt32(6),
                                reader.GetInt32(0),
                                releaseDate,
                                rating,
                                duration
                            );
                            AnimeList.Add(animeRecord);
                        }
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return AnimeList;
        }
        public void ReadById(int id) { }

        
    }
}
