using WEBHELP.Models;
using System.Data.SqlClient;
using System.Data;



namespace WEBHELP.Datos
{
    public class EmpleadoDatos
    {
        public List<EmpleadoModel> Listar(){

            var oLista = new List<EmpleadoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {

                    while (dr.Read()) {
                        oLista.Add(new EmpleadoModel() {
                            IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            Tipo_Documento = dr["Tipo_Documento"].ToString(),
                            Identificacion = dr["Identificacion"].ToString(),
                            Fecha_Contrato = dr["Fecha_Contrato"].ToString(),
                            Pais = dr["Pais"].ToString(),
                            Area = dr["Area"].ToString(),
                            Subarea = dr["Subarea"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        public EmpleadoModel Obtener(int IdEmpleado)
        {

            var oEmpleado = new EmpleadoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdEmpleado", IdEmpleado);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oEmpleado.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]);
                        oEmpleado.Nombres = dr["Nombres"].ToString();
                        oEmpleado.Apellidos = dr["Apellidos"].ToString();
                        oEmpleado.Tipo_Documento = dr["Tipo_Documento"].ToString();
                        oEmpleado.Identificacion = dr["Identificacion"].ToString();
                        oEmpleado.Fecha_Contrato = dr["Fecha_Contrato"].ToString();
                        oEmpleado.Pais = dr["Pais"].ToString();
                        oEmpleado.Area = dr["Area"].ToString();
                        oEmpleado.Subarea = dr["Subarea"].ToString();
                    }
                }
            }
            return oEmpleado;
        }

        public bool Guardar(EmpleadoModel oempleado){
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombres", oempleado.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oempleado.Apellidos);
                    cmd.Parameters.AddWithValue("Tipo_Documento", oempleado.Tipo_Documento);
                    cmd.Parameters.AddWithValue("Identificacion", oempleado.Identificacion);
                    cmd.Parameters.AddWithValue("Fecha_Contrato", oempleado.Fecha_Contrato);
                    cmd.Parameters.AddWithValue("Pais", oempleado.Pais);
                    cmd.Parameters.AddWithValue("Area", oempleado.Area);
                    cmd.Parameters.AddWithValue("Subarea", oempleado.Subarea);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e){
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Editar(EmpleadoModel oempleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", oempleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("Nombres", oempleado.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oempleado.Apellidos);
                    cmd.Parameters.AddWithValue("Tipo_Documento", oempleado.Tipo_Documento);
                    cmd.Parameters.AddWithValue("Identificacion", oempleado.Identificacion);
                    cmd.Parameters.AddWithValue("Fecha_Contrato", oempleado.Fecha_Contrato);
                    cmd.Parameters.AddWithValue("Pais", oempleado.Pais);
                    cmd.Parameters.AddWithValue("Area", oempleado.Area);
                    cmd.Parameters.AddWithValue("Subarea", oempleado.Subarea);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(int IdEmpleado)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Elimnar", conexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", IdEmpleado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
