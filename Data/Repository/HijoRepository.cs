using Data.Interface;
using Entity.Models;
using System.Data.SqlClient;
using System.Data;

namespace Data.Repository
{
    public class HijoRepository : IHijoRepository
    {
        private readonly string _connectionString;

        public HijoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> AddOrUpdateHijo(Hijo hijo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("InsertarHijo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (hijo.IdHijo > 0)
                    {
                        command.CommandText = "ActualizarHijo"; 
                        command.Parameters.AddWithValue("@IdHijo", hijo.IdHijo);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@IdPersonal", hijo.IdPersonal);
                    }
                    command.Parameters.AddWithValue("@TipoDoc", hijo.TipoDoc);
                    command.Parameters.AddWithValue("@NumeroDoc", hijo.NumeroDoc);
                    command.Parameters.AddWithValue("@ApPaterno", hijo.ApPaterno);
                    command.Parameters.AddWithValue("@ApMaterno", hijo.ApMaterno);
                    command.Parameters.AddWithValue("@Nombre1", hijo.Nombre1);
                    command.Parameters.AddWithValue("@Nombre2", hijo.Nombre2);
                    command.Parameters.AddWithValue("@NombreCompleto", hijo.NombreCompleto);
                    command.Parameters.AddWithValue("@FechaNac", hijo.FechaNac);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }


        public async Task<bool> DeleteHijo(int IdHijo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("EliminarHijoPorIdHijo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdHijo", IdHijo);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }

        public async Task<Hijo> GetHijoById(int IdHijo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("ObtenerHijoPorIdHijo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdHijo", IdHijo);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            var hijo = new Hijo
                            {
                                IdHijo = reader.GetInt32(reader.GetOrdinal("IdHijo")),
                                IdPersonal = reader.GetInt32(reader.GetOrdinal("IdPersonal")),
                                TipoDoc = reader.GetString(reader.GetOrdinal("TipoDoc")),
                                NumeroDoc = reader.GetString(reader.GetOrdinal("NumeroDoc")),
                                ApPaterno = reader.GetString(reader.GetOrdinal("ApPaterno")),
                                ApMaterno = reader.GetString(reader.GetOrdinal("ApMaterno")),
                                Nombre1 = reader.GetString(reader.GetOrdinal("Nombre1")),
                                Nombre2 = reader.GetString(reader.GetOrdinal("Nombre2")),
                                NombreCompleto = reader.GetString(reader.GetOrdinal("NombreCompleto")),
                                FechaNac = reader.GetDateTime(reader.GetOrdinal("FechaNac"))
                            };
                            return hijo;
                        }
                        return null;
                    }
                }
            }
        }

        public async Task<List<Hijo>> GetHijosByIdPersonal(int IdPersonal)
        {
            var hijos = new List<Hijo>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("ObtenerHijosPorIdPersonal", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdPersonal", IdPersonal);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var hijo = new Hijo
                            {
                                IdHijo = reader.GetInt32(reader.GetOrdinal("IdHijo")),
                                IdPersonal = reader.GetInt32(reader.GetOrdinal("IdPersonal")),
                                TipoDoc = reader.GetString(reader.GetOrdinal("TipoDoc")),
                                NumeroDoc = reader.GetString(reader.GetOrdinal("NumeroDoc")),
                                ApPaterno = reader.GetString(reader.GetOrdinal("ApPaterno")),
                                ApMaterno = reader.GetString(reader.GetOrdinal("ApMaterno")),
                                Nombre1 = reader.GetString(reader.GetOrdinal("Nombre1")),
                                Nombre2 = reader.GetString(reader.GetOrdinal("Nombre2")),
                                NombreCompleto = reader.GetString(reader.GetOrdinal("NombreCompleto")),
                                FechaNac = reader.GetDateTime(reader.GetOrdinal("FechaNac"))
                            };

                            hijos.Add(hijo);
                        }
                    }
                }
            }

            return hijos;
        }

    }
}
