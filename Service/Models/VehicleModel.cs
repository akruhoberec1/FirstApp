namespace Project.Service.Models
{
    public class VehicleModel
    {
        public VehicleModel(string name, int id, string abrv, int makeid)
        {
            Id = id;    
            Name = name;    
            Abrv = abrv;
            MakeId = makeid;
        }
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual VehicleMake? Make { get; set; }
    }
}
