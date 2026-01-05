using TIMEClock.UI.WPF.Entities.Abstracts;

namespace TIMEClock.UI.WPF.Entities
{
    public class TimeRecord : Entity
    {
        public DateTime From { get; set; }

        public DateTime? Until { get; set; }
    }
}
