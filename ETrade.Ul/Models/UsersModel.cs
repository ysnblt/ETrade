using ETrade.Entity.Concretes;

namespace ETrade.Ul.Models
{
    public class UsersModel
    {
        public Users User { get; set; }
        public List<County> Counties { get; set; }
        public string Error { get; set; }
    }
}
