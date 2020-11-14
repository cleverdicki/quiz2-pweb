using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using quiz2_webpro.Models;

namespace quiz2_webpro.Controllers
{
    public class FilmController : Controller
    {
        SqlConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\filmDb.mdf;Integrated Security=True");
        // GET: Film
        public ActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (db)
            {
                db.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM films", db);
                sqlDataAdapter.Fill(dataTable);
            }
            return View(dataTable);
        }

        // GET: Film/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        [HttpGet]
        // GET: Film/Create
        public ActionResult Create()
        {
            return View(new FilmModel());
        }

        // POST: Film/Create
        [HttpPost]
        public ActionResult Create(FilmModel filmModel)
        {
            using(db)
            {
                db.Open();
                string query = "INSERT INTO films VALUES(@name_film, @distributor_film, @genre_film, @year_film, @country_film, @duration_film, @trailer_film)";
                SqlCommand sqlCommand = new SqlCommand(query, db);
                sqlCommand.Parameters.AddWithValue("@name_film", filmModel.name_film);
                sqlCommand.Parameters.AddWithValue("@distributor_film", filmModel.distributor_film);
                sqlCommand.Parameters.AddWithValue("@genre_film", filmModel.genre_film);
                sqlCommand.Parameters.AddWithValue("@year_film", filmModel.year_film);
                sqlCommand.Parameters.AddWithValue("@country_film", filmModel.country_film);
                sqlCommand.Parameters.AddWithValue("@duration_film", filmModel.duration_film);
                sqlCommand.Parameters.AddWithValue("@trailer_film", filmModel.trailer_film);
                sqlCommand.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        // GET: Film/Edit/5
        public ActionResult Edit(int id)
        {
            FilmModel filmModel = new FilmModel();
            DataTable dataTable = new DataTable();
            using (db)
            {
                db.Open();
                string query = "SELECT * FROM films Where id_film = @id_film";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,db);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@id_film",id);
                sqlDataAdapter.Fill(dataTable);
            }
            if (dataTable.Rows.Count == 1)
            {
                filmModel.id_film = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                filmModel.name_film = dataTable.Rows[0][1].ToString();
                filmModel.distributor_film = dataTable.Rows[0][2].ToString();
                filmModel.genre_film = dataTable.Rows[0][3].ToString();
                filmModel.year_film = Convert.ToInt32(dataTable.Rows[0][4].ToString());
                filmModel.country_film = dataTable.Rows[0][5].ToString();
                filmModel.duration_film = dataTable.Rows[0][6].ToString();
                filmModel.trailer_film = dataTable.Rows[0][7].ToString();
                return View(filmModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Film/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FilmModel filmModel)
        {
            using (db)
            {
                db.Open();
                string query = "UPDATE films SET name_film = @name_film, distributor_film = @distributor_film, genre_film = @genre_film, year_film = @year_film, country_film = @country_film, duration_film = @duration_film, trailer_film = @trailer_film Where id_film = @id_film";
                SqlCommand sqlCommand = new SqlCommand(query, db);
                sqlCommand.Parameters.Add("@id_film", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.AddWithValue("@name_film", filmModel.name_film);
                sqlCommand.Parameters.AddWithValue("@distributor_film", filmModel.distributor_film);
                sqlCommand.Parameters.AddWithValue("@genre_film", filmModel.genre_film);
                sqlCommand.Parameters.AddWithValue("@year_film", filmModel.year_film);
                sqlCommand.Parameters.AddWithValue("@country_film", filmModel.country_film);
                sqlCommand.Parameters.AddWithValue("@duration_film", filmModel.duration_film);
                sqlCommand.Parameters.AddWithValue("@trailer_film", filmModel.trailer_film);
                sqlCommand.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Film/Delete/5
        public ActionResult Delete(int id)
        {
            using (db)
            {
                db.Open();
                string query = "DELETE FROM films Where id_film = @id_film";
                SqlCommand sqlCommand = new SqlCommand(query, db);
                sqlCommand.Parameters.AddWithValue("@id_film", id);
                sqlCommand.ExecuteNonQuery();
            }
            //return View("Index");
            return RedirectToAction("Index");
        }
    }
}
