namespace Project.Service.Models
{
    public class VehicleMake
    {
        public VehicleMake(string name, string abrv)
        {
            Models = new HashSet<VehicleModel>();
            Name = name;   
            Abrv = abrv;    
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual ICollection<VehicleModel> Models { get; set; }
    }
}
