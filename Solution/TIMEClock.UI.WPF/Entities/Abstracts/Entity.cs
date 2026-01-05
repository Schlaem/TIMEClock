namespace TIMEClock.UI.WPF.Entities.Abstracts
{
    public abstract class Entity
    {
        public int ID { get; set; }

        public DateTime Created { get; set; }
    }
}
