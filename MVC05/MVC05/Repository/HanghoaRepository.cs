using System;
using System.Data;
using Microsoft.Data.SqlClient;
using MVC05.Models;

namespace MVC05.Repository
{
    public class HanghoaRepository
    {
        private string connectionString = "Data Source=DESKTOP-GOAKFLS\\SQLEXPRESS;Initial Catalog=db_Shop4Training;Integrated Security=True; TrustServerCertificate=True";
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HanghoaRepository(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile) 
        {
            if (imageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                await imageFile.CopyToAsync(new FileStream(filePath, FileMode.Create));
                return "/uploads/" + uniqueFileName;
            }
            return null;
        }

        public async Task InsertHanghoaAsync(string sTenhang, float fGianiemyet, string sDacdiem, string sXuatxu, IFormFile imageFile)
        {
            string anhminhhoaPath = await SaveImageAsync(imageFile);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertHanghoa", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@sTenhang", SqlDbType.NVarChar, 300)).Value = sTenhang;
                    cmd.Parameters.Add(new SqlParameter("@fGianiemyet", SqlDbType.Float)).Value = fGianiemyet;
                    cmd.Parameters.Add(new SqlParameter("@sDacdiem", SqlDbType.NText)).Value = sDacdiem;
                    cmd.Parameters.Add(new SqlParameter("@sXuatxu", SqlDbType.NVarChar, 300)).Value = sXuatxu;
                    cmd.Parameters.Add(new SqlParameter("@sAnhminhhoa", SqlDbType.VarChar, 200)).Value = anhminhhoaPath;
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public List<Hanghoa> GetHanghoaList()
        {
            List<Hanghoa> hanghoaList = new List<Hanghoa>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetHanghoaList", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Hanghoa hanghoa = new Hanghoa
                            {
                                Tenhang = reader["sTenhang"].ToString(),
                                Gianiemyet = Convert.ToSingle(reader["fGianiemyet"]),
                                Dacdiem = reader["sDacdiem"].ToString(),
                                Xuatxu = reader["sXuatxu"].ToString(),
                                Anhminhhoa = reader["sAnhminhhoa"].ToString()
                            };
                            hanghoaList.Add(hanghoa);
                        }
                    }
                }
            }

            return hanghoaList;
        }

    }
}

