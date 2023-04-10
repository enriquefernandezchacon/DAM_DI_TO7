using System.Linq;
using System.Text.RegularExpressions;

namespace DI06_Tarea_Fernandez_Chacon_EnriqueOctavio.Extensiones
{
    public static class StringExtension
    {
        private static readonly Regex REGEX_TELEFONO = new Regex(@"[6789]\d{8}");
        private static readonly Regex REGEX_DNI= new Regex(@"\d{8}[A-Z]");
        private static readonly Regex REGEX_EMAIL = new Regex(@"[A-z0-9._%+-]+@[A-z0-9.-]+[A-z0-9]+\.[A-z]{2,3}$");

        /// <summary>
        /// Extension que comprueba que un string no este vacio
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool EsValido(this string s)
        {
            return s.Trim().All(static t => char.IsLetter(t) || char.IsWhiteSpace(t));
        }

        /// <summary>
        /// Extension para comprobar que el string sea un telefono español
        /// </summary>
        /// <param name="telefono"></param>
        /// <returns></returns>

        public static bool EsTelefono(this string telefono)
        {
            return telefono.Trim().All(char.IsDigit) && REGEX_TELEFONO.IsMatch(telefono.Trim());
        }

        /// <summary>
        /// Extension para comprobar que el string sea un email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool EsEmail(this string email)
        {
            return REGEX_EMAIL.IsMatch(email.Trim());
        }

        /// <summary>
        /// Extension para comprobar que el string sea un dni español
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public static bool EsDni(this string dni)
        {
            return REGEX_DNI.IsMatch(dni.Trim());
        }

        /// <summary>
        /// Extension para crear un mensaje de error para un campo vacío
        /// </summary>
        /// <param name="nombreCampo"></param>
        /// <returns></returns>

        public static string ErrorVacio(this string nombreCampo)
        {
            return string.Concat("El campo ",nombreCampo," no puede estar vacío");
        }

        /// <summary>
        /// Extension para crear un mensaje de error para un campo con un formato incorrecto
        /// </summary>
        /// <param name="nombreCampo"></param>
        /// <returns></returns>
        public static string ErrorFormato(this string nombreCampo)
        {
            return string.Concat("El campo ", nombreCampo, " no tiene un formato correcto");
        }

        
    }
}
