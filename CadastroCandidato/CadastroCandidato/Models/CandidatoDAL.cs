using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CadastroCandidato.Models
{
    public class CandidatoDAL : ICandidatoDAL
    {
        string strConnection = @"Data Source=(local);Initial Catalog=DB_BTEASYCOMTECH;Integrated Security=True;";

        public IEnumerable<Candidato> GetAllCandidatos()
        {
            List<Candidato> lstCandidato = new List<Candidato>();

            using (SqlConnection con = new SqlConnection(strConnection))
            {
                SqlCommand cmdSel = new SqlCommand("SELECT CandidatoID, vchNome, vchEmail, vchCidade, vchEstado", con);
                cmdSel.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmdSel.ExecuteReader();

                // Criando candidatos e adicionando a lista
                while (reader.Read())
                {
                    Candidato candidato = new Candidato();

                    candidato.CandidatoID = Convert.ToInt32(reader["CandidatoID"]);
                    candidato.vchNome = reader["vchNome"].ToString();
                    candidato.vchEmail = reader["vchEmail"].ToString();
                    candidato.vchCidade = reader["vchCidade"].ToString();
                    candidato.vchEstado = reader["vchEstado"].ToString();

                    lstCandidato.Add(candidato);
                }
                con.Close();
            }
            return lstCandidato;
        }

        public void AddCandidato(Candidato candidato)
        {
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string queryInsert = "INSERT INTO Candidato (vchNome, vchEmail, vchCidade, vchEstado) VALUES (@vchNome, @vchEmail, @vchCidade, @vchEstado)";

                SqlCommand cmdIns = new SqlCommand(queryInsert, con);
                cmdIns.CommandType = CommandType.Text;

                // Criando parametros a serem inseridos
                cmdIns.Parameters.AddWithValue("@vchNome", candidato.vchNome);
                cmdIns.Parameters.AddWithValue("@vchEmail", candidato.vchEmail);
                cmdIns.Parameters.AddWithValue("@vchCidade", candidato.vchCidade);
                cmdIns.Parameters.AddWithValue("@vchEstado", candidato.vchEstado);

                con.Open();
                cmdIns.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateCandidato(Candidato candidato)
        {
            using (SqlConnection con = new SqlConnection())
            {
                string queryUpdate =    "UPDATE Candidato SET vchNome = @vchNome, vchEmail = @vchEmail, vchCidade = @vchCidade, vchEstado = @vchEstado" +
                                        "WHERE CandidatoID = @CandidatoID";

                SqlCommand cmdUpd = new SqlCommand(queryUpdate, con);
                cmdUpd.CommandType = CommandType.Text;

                // Criando parametros utilizados no update
                cmdUpd.Parameters.AddWithValue("@CandidatoID", candidato.CandidatoID);
                cmdUpd.Parameters.AddWithValue("@vchNome", candidato.vchNome);
                cmdUpd.Parameters.AddWithValue("@vchEmail", candidato.vchEmail);
                cmdUpd.Parameters.AddWithValue("@vchCidade", candidato.vchCidade);
                cmdUpd.Parameters.AddWithValue("@vchEstado", candidato.vchEstado);

                con.Open();
                cmdUpd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Candidato GetCandidato(int? CandidatoID)
        {
            Candidato candidato = new Candidato();

            using (SqlConnection con = new SqlConnection())
            {
                string querySelect = "SELECT * FROM Candidato WHERE CandidatoID = @CandidatoID";

                SqlCommand cmdSel = new SqlCommand(querySelect, con);
                cmdSel.CommandType = CommandType.Text;

                cmdSel.Parameters.AddWithValue("@CandidatoID", CandidatoID);

                con.Open();

                SqlDataReader reader = cmdSel.ExecuteReader();

                while (reader.Read())
                {
                    candidato.CandidatoID = Convert.ToInt32(reader["CandidatoID"]);
                    candidato.vchNome = reader["vchNome"].ToString();
                    candidato.vchEmail = reader["vchEmail"].ToString();
                    candidato.vchCidade = reader["vchCidade"].ToString();
                    candidato.vchEstado = reader["vchEstado"].ToString();

                }

                con.Close();
            }
            return candidato;
        }

        public void DeleteCandidato(int? CandidatoID)
        {
            using (SqlConnection con = new SqlConnection())
            {
                string queryDelete = "DELETE FROM Candidato WHERE CandidatoID = @CandidatoID";

                SqlCommand cmdDel = new SqlCommand(queryDelete, con);
                cmdDel.CommandType = CommandType.Text;

                cmdDel.Parameters.AddWithValue("@CandidatoID", CandidatoID);

                con.Open();
                cmdDel.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
