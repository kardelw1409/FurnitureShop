using Show_project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop_project.Models
{
    public class FurnitureRepository
    {
        private ModelsDbContext modelsDbContext;

        private IEnumerable<Furniture> Snowboards { get; }

        public FurnitureRepository(ModelsDbContext modelsDbContext)
        {
            this.modelsDbContext = modelsDbContext;
        }

        public IEnumerable<Furniture> Furnitures
        {
            get
            {
                return modelsDbContext.Furnitures;
            }
        }

        public IEnumerable<Furniture> GetAllSnowboards()
        {

            return modelsDbContext.Furnitures;
        }

        public Furniture GetSnowboardById(int furnitureId)
        {
            return modelsDbContext.Furnitures.FirstOrDefault(s => s.FurnitureId == furnitureId);
        }
    }
}