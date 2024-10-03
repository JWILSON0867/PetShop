namespace PetStore.Data
{

    public class CatFood
    {
        public int CatFoodId { get; set; }  // Primary Key for CatFood
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}
