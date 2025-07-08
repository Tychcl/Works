namespace pr45.Models
{
    public class Users
    {
        /// <summary>
        /// Код
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// токен
        /// </summary>
        public string Token { get; set; }
    }
}
