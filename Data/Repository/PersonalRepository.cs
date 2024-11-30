using Data.Interface;
using Entity.Models;
using System.Data;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class PersonalRepository : IPersonalRepository
    {
        private readonly string _connectionString;

        public PersonalRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> AddOrUpdatePersonal(Personal personal)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    if (personal.IdPersonal <= 0)
                    {
                        using (var command = new SqlCommand("InsertarPersonal", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@TipoDoc", personal.TipoDoc);
                            command.Parameters.AddWithValue("@NumeroDoc", personal.NumeroDoc);
                            command.Parameters.AddWithValue("@ApPaterno", personal.ApPaterno);
                            command.Parameters.AddWithValue("@ApMaterno", personal.ApMaterno);
                            command.Parameters.AddWithValue("@Nombre1", personal.Nombre1);
                            command.Parameters.AddWithValue("@Nombre2", personal.Nombre2);
                            command.Parameters.AddWithValue("@NombreCompleto", personal.NombreCompleto);
                            command.Parameters.AddWithValue("@FechaNac", personal.FechaNac);
                            command.Parameters.AddWithValue("@FechaIngreso", personal.FechaIngreso);

                            var result = await command.ExecuteScalarAsync(); 
                            personal.IdPersonal = Convert.ToInt32(result); 
                        }
                    }
                    else
                    {
                        using (var command = new SqlCommand("ActualizarPersonal", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@IdPersonal", personal.IdPersonal);
                            command.Parameters.AddWithValue("@TipoDoc", personal.TipoDoc);
                            command.Parameters.AddWithValue("@NumeroDoc", personal.NumeroDoc);
                            command.Parameters.AddWithValue("@ApPaterno", personal.ApPaterno);
                            command.Parameters.AddWithValue("@ApMaterno", personal.ApMaterno);
                            command.Parameters.AddWithValue("@Nombre1", personal.Nombre1);
                            command.Parameters.AddWithValue("@Nombre2", personal.Nombre2);
                            command.Parameters.AddWithValue("@NombreCompleto", personal.NombreCompleto);
                            command.Parameters.AddWithValue("@FechaNac", personal.FechaNac);
                            command.Parameters.AddWithValue("@FechaIngreso", personal.FechaIngreso);

                            var result = await command.ExecuteNonQueryAsync(); 
                            return result > 0; 
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeletePersonal(int IdPersonal)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("EliminarPersonal", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IdPersonal", IdPersonal);

                        var result = await command.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Personal>> GetPersonal()
        {
            List<Personal> personal = new List<Personal>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EXEC ListarPersonal", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    personal.Add(new Personal
                    {
                        IdPersonal = reader.GetInt32(0),
                        TipoDoc = reader.GetString(1),
                        NumeroDoc = reader.GetString(2),
                        ApPaterno = reader.GetString(3),
                        ApMaterno = reader.GetString(4),
                        Nombre1 = reader.GetString(5),
                        Nombre2 = reader.GetString(6),
                        NombreCompleto = reader.GetString(7),
                        FechaNac = reader.GetDateTime(8),
                        FechaIngreso = reader.GetDateTime(9),
                    });
                }
            }
            return personal;

        }

        public async Task<Personal> GetPersonalById(int IdPersonal)
        {
            Personal personal = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("ListarPersonalPorId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdPersonal", IdPersonal);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            personal = new Personal
                            {
                                IdPersonal = reader.GetInt32(reader.GetOrdinal("IdPersonal")),
                                TipoDoc = reader.GetString(reader.GetOrdinal("TipoDoc")),
                                NumeroDoc = reader.GetString(reader.GetOrdinal("NumeroDoc")),
                                ApPaterno = reader.GetString(reader.GetOrdinal("ApPaterno")),
                                ApMaterno = reader.GetString(reader.GetOrdinal("ApMaterno")),
                                Nombre1 = reader.GetString(reader.GetOrdinal("Nombre1")),
                                Nombre2 = reader.GetString(reader.GetOrdinal("Nombre2")),
                                NombreCompleto = reader.GetString(reader.GetOrdinal("NombreCompleto")),
                                FechaNac = reader.GetDateTime(reader.GetOrdinal("FechaNac")),
                                FechaIngreso = reader.GetDateTime(reader.GetOrdinal("FechaIngreso"))
                            };
                        }
                    }
                }
            }

            return personal;
        }
    }
}
