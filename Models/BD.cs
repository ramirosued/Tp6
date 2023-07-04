using System.Data.SqlClient;
using Dapper;
namespace Tp6.Models;
public static class BD
{
    private static string connectionString = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";
    public static void AgregarCandidato(Candidato can)
    {
        string sql = "INSERT INTO Candidato(FkPartido,Apellido,Nombre,FechaNacimiento,Foto,Postulacion) VALUES (@FkPartido, @Apellido, @Nombre, @FechaNacimiento, @Foto, @Postulacion)";
        using (SqlConnection bd = new SqlConnection(connectionString))
        {
            bd.Execute(sql, new { FkPartido = can.FkPartido, Apellido = can.Apellido, Nombre = can.Nombre, FechaNacimiento = can.FechaNacimiento, Foto = can.Foto, Postulacion = can.Postulacion });
        }
    }

    public static void EliminarCandidato(int IdCandidato)
    {
        string sql = "DELETE FROM Candidato WHERE IdCandidato = @IdCandidato";
        using (SqlConnection bd = new SqlConnection(connectionString))
        {
            bd.Execute(sql, new { IdCandidato = IdCandidato });
        }
    }

    public static Partido InfoPartido(int IdPartido)
    {
        Partido MiPartido = null;
        using (SqlConnection bd = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Partido WHERE IdPartido = @IdPartido";
            MiPartido = bd.QueryFirstOrDefault<Partido>(sql, new { IdPartido = IdPartido });
        }
        return MiPartido;
    }

    public static Candidato InfoCandidato(int IdCandidato)
    {
        Candidato MiCandidato = null;
        using (SqlConnection bd = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Candidato where IdCandidato=@IdCandidato";
            MiCandidato = bd.QueryFirstOrDefault<Candidato>(sql, new { IdCandidato = IdCandidato });
        }
        return MiCandidato;
    }
    private static List<Partido> ListaPartidos = new List<Partido>();
    public static List<Partido> ListarPartidos()
    {
        using (SqlConnection bd = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Partido";
            ListaPartidos = bd.Query<Partido>(sql).ToList();
        }
        return ListaPartidos;
    }
    private static List<Candidato> ListaCandidatos=new List<Candidato>();
    public static List<Candidato> ListarCandidatos(int IdPartido){
        using (SqlConnection bd = new SqlConnection(connectionString))
        {
            string sql="SELECT * FROM Candidato WHERE FkPartido=@IdPartido";
            ListaCandidatos=bd.Query<Candidato>(sql,new{IdPartido=IdPartido}).ToList();
        }
        return ListaCandidatos;
    }
}


